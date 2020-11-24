using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return CheckForLength(input) && CheckForControlCharacters(input);
        }

        private static bool CheckForLength(string input)
        {
            return (!string.IsNullOrEmpty(input) && input.Length != 1) && input[0] == '\"' && input[^1] == '\"';
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
