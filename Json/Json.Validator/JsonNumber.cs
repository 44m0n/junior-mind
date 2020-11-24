using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsStringADigit(input);
        }

        private static bool IsStringADigit(string input)
        {
            const int ZeroAscii = 48;
            return input[0] == ZeroAscii;
        }
    }
}
