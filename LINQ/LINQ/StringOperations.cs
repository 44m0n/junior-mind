using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class StringOperations
    {
        public static (int vowels, int consonants) GetConsAndVowelsCount(string text)
        {
            return text.Aggregate((0, 0), (tup, ch) => "aeiouAEIOU".Contains(ch) ?
                                                        (tup.Item1 + 1, tup.Item2) : !char.IsLetter(ch) ?
                                                        (tup.Item1, tup.Item2) :
                                                        (tup.Item1, tup.Item2 + 1));
        }

        public static char FirstUniqueCharacter(string text)
        {
            return text.FirstOrDefault(ch => text.IndexOf(ch) == text.LastIndexOf(ch));
        }

        public static int ConvertStrintToInt(string text)
        {
            CheckParameterIsNull(text, nameof(text));

            const int Bs = 10;
            int sign = text[0] == '-' ? -1 : 1;

            return text.Aggregate(0, (x, ch) => char.IsDigit(ch) ?
            x * Bs + int.Parse(ch.ToString()) : x) * sign;
        }

        private static void CheckParameterIsNull<T>(T param, string name)
        {
            if (param != null)
            {
                return;
            }

            throw new ArgumentNullException(paramName: name);
        }
    }
}
