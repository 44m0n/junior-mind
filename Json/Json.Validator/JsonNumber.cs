using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return ContainLetters(input);
        }

        private static bool ContainLetters(string input)
        {
            if (string.IsNullOrEmpty(input))
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
    }
}
