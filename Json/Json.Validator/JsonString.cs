using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            Console.WriteLine(input);
            return CheckForLength(input) && CheckForControlCharacters(input) && CheckForEscapeorUnicodeCharacters(input);
        }

        private static bool CheckForLength(string input)
        {
            return (!string.IsNullOrEmpty(input) && input.Length != 1) && input[0] == '\"' && input[^1] == '\"';
        }

        private static bool CheckForEscapeorUnicodeCharacters(string text)
        {
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i - 1] == '\\')
                {
                    if (text[i] != 'u')
                    {
                        return CheckIfEscapeCharactersAreValid(text[i].ToString());
                    }

                    return CheckIfUnicodeCharactersAreValid(text, i);
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
            string[] escapeCharacters = { "n", "\"", @"\", "/", "b", "f", "n", "r", "t" };
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

        private static string Quoted(string input)
        {
            return "\"" + input + "\"";
        }
    }
}
