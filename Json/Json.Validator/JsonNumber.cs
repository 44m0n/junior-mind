using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return CheckForForbiddenCharacters(input) && IsValidInteger(input) && IsValidExponential(input) && IsValidFractional(input);
        }

        private static bool IsValidInteger(string input)
        {
            return char.IsDigit(input[0]) || input[0] == '-';
        }

        private static bool CheckForForbiddenCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            input = input.ToLower();

            for (int i = 1; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && input[i] != 'e')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidFractional(string input)
        {
            int count = 0;

            if (!char.IsDigit(input[^1]))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    count++;
                }
            }

            if (input.Length > 1 && input[0] == '0' && count != 1)
            {
                return false;
            }

            return count <= 1;
        }

        private static bool IsValidExponential(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'e')
                {
                    count++;
                }

                if (input[i] == '.' && count > 0)
                {
                    return false;
                }

                if (i == 0)
                {
                    continue;
                }

                if (!char.IsDigit(input[i]) && input[i] != '-' && input[i] != '+' && input[i - 1] == 'e')
                {
                    return false;
                }
            }

            return count <= 1;
        }
    }
}
