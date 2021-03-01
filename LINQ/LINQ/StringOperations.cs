using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class StringOperations
    {
        public static (int vowels, int consonants) GetConsAndVowelsCount(string text)
        {
            return text.Aggregate((vowels: 0, consonants: 0), (letters, ch) =>
            {
                if (char.IsLetter(ch))
                {
                    return "aeiouAEIOU".Contains(ch) ? (letters.vowels + 1, letters.consonants) : (letters.vowels, letters.consonants + 1);
                }

                return (letters.vowels, letters.consonants);
            });
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
