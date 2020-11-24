using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsValidInteger(input);
        }

        private static bool IsValidInteger(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length > 1 && (input[0] == '0' && !IsValidFractional(input)))
            {
                return false;
            }

            if (!char.IsDigit(input[0]) && input[0] != '-')
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidFractional(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    count++;
                }
            }

            return count == 1;
        }
    }
}
