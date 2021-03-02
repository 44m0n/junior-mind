using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            return text.GroupBy(ch => ch).First(x => x.Count() == 1).Key;
        }

        public static int ConvertStringToInt(string text)
        {
            CheckParameterIsNull(text, nameof(text));

            const int Bs = 10;
            int sign = text[0] == '-' ? -1 : 1;

            return text.Aggregate(0, (x, ch) => char.IsDigit(ch) ?
            x * Bs + int.Parse(ch.ToString()) : x) * sign;
        }

        public static char MaxOccurence(string text)
        {
            return text.GroupBy(ch => ch).Aggregate((el, m) => el.Count() > m.Count() ? el : m).Key;
        }

        public static IEnumerable<string> GetPalindroms(string text)
        {
            return text.SelectMany((ch1, firstIndex) =>
                        text.Substring(firstIndex).Select((ch2, secondIndex) =>
                            text.Substring(firstIndex, text.Length - firstIndex - secondIndex))).Where(el =>
                                el.SequenceEqual(el.Reverse()));
        }

        public static IEnumerable<(string, int)> TopWords(string text, int top)
        {
            CheckParameterIsNull(text, nameof(text));
            CheckParameterIsNull(top, nameof(top));

            return Regex.Split(text, "[^a-zA-Z]").Where(x => x.Length > 0).GroupBy(x => x)
                .OrderByDescending(x => x.Count()).Take(top).Select(x => (x.Key, x.Count()));
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
