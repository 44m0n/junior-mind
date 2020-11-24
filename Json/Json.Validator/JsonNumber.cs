using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsStringADigit(input) && ContainLetters(input);
        }

        private static bool IsStringADigit(string input)
        {
            const int ZeroAscii = 48;
            return input[0] == ZeroAscii;
        }

        private static bool ContainLetters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
