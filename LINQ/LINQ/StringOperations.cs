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
    }
}
