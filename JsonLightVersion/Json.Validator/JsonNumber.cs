using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return CheckIfNumberIsACorrectFormat(input) && IsValidExponent(input) && IsValidFraction(input);
        }

        private static bool CheckIfNumberIsACorrectFormat(string input)
        {
            return !string.IsNullOrEmpty(input) && (char.IsDigit(input[0]) || input[0] == '-') && char.IsDigit(input[^1]);
        }

        private static bool IsValidFraction(string input)
        {
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetterOrDigit(input[i]) && !IsValidExponentSign(input[i]))
                {
                    count++;
                }
            }

            if (input[0] == '0' && input.Length > 1 && count == 0)
            {
                count++;
            }

            if (count == 1)
            {
                var (position, digits) = SplitFraction(input);
                return IsCorrectPosition(position, input)
                    && IsFractionalPartValid(digits);
            }

            return count == 0;
        }

        private static bool IsFractionalPartValid(string digits)
        {
            return AreDigits(digits) || IsValidExponent(digits);
        }

        private static bool IsCorrectPosition(int position, string input)
        {
            if (input.Length > 1 && input[0] == '0' && position != 1)
            {
                return false;
            }

            return position > 0;
        }

        private static (int position, string digits) SplitFraction(string input)
        {
            int position = input.IndexOf('.');
            string digits = input.Remove(0, position + 1);

            return (position, digits);
        }

        private static bool IsValidExponent(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    count++;
                }
            }

            if (count == 1)
            {
                var (e, sign, digits) = SplitExponent(input);

                return IsE(e)
                     && IsValidExponentSign(sign)
                     && AreDigits(digits);
            }

            return count == 0;
        }

        private static bool AreDigits(string digits)
        {
            for (int i = 1; i < digits.Length; i++)
            {
                if (!char.IsDigit(digits[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidExponentSign(char sign)
        {
            return sign == '-' || sign == '+' || char.IsDigit(sign);
        }

        private static bool IsE(char e)
        {
            return e == 'e' || e == 'E';
        }

        private static (char e, char sign, string digits) SplitExponent(string number)
        {
            for (int i = 1; i < number.Length; i++)
            {
                if (char.IsLetter(number[i - 1]))
                {
                    char e = number[i - 1];
                    char sign = number[i];
                    string digits = number.Remove(0, i);

                    return (e, sign, digits);
                }
            }

            return (' ', ' ', " ");
        }
    }
}
