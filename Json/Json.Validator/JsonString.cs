using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            var (start, content, end) = SplitString(input);

            return IsQuote(start)
                && IsQuote(end)
                && ContainsOnlyValidCharacters(content);
        }

        private static bool ContainsOnlyValidCharacters(string content)
        {
            return string.IsNullOrEmpty(content) ||
                CheckLastCharacter(content)
                && CheckForControlCharacters(content) && CheckForEscapeOrUnicodeCharacters(content);
        }

        private static bool IsQuote(char quote)
        {
            return quote == '\"';
        }

        private static Tuple<char, string, char> SplitString(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length <= 1)
            {
                return new Tuple<char, string, char>(' ', null, ' ');
            }

            char start = input[0];
            char end = input[^1];
            string content = input;

            content = content.Remove(0, 1);
            content = content.Remove(content.Length - 1, 1);

            return new Tuple<char, string, char>(start, content, end);
        }

        private static bool CheckLastCharacter(string input)
        {
            return input[^1] != '\\';
        }

        private static bool CheckForEscapeOrUnicodeCharacters(string text)
        {
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i - 1] == '\\')
                {
                    if (text[i] != 'u' && !CheckIfEscapeCharactersAreValid(text[i].ToString()))
                    {
                        return false;
                    }

                    if (text[i] == 'u' && !CheckIfUnicodeCharactersAreValid(text, i))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool CheckIfUnicodeCharactersAreValid(string text, int i)
        {
            const int HexDigits = 4;

            if (i + HexDigits >= text.Length)
            {
                return false;
            }

            string hexNumber = "";
            for (int j = 0; j < HexDigits; j++)
            {
                hexNumber += text[i + 1 + j];
            }

            return System.Text.RegularExpressions.Regex.IsMatch(hexNumber, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        private static bool CheckIfEscapeCharactersAreValid(string character)
        {
            string[] escapeCharacters = { "n", "\"", @"\", "/", "b", "f", "n", "r", "t", " " };
            for (int j = 0; j < escapeCharacters.Length; j++)
            {
                if (character == escapeCharacters[j])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckForControlCharacters(string input)
        {
            const int ControlAsciiLimit = 32;

            foreach (char c in input)
            {
                if (c < ControlAsciiLimit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
