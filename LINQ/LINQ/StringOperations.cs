using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class StringOperations
    {
        public static (int consonants, int vowels) GetConsAndVowelsCount(string text)
        {
            var c = from ch in text
                    where char.IsLetter(ch) && "aeiouAEIOU".Contains(ch)
                    select ch;

            var v = from ch in text
                    where char.IsLetter(ch) && !"aeiouAEIOU".Contains(ch)
                    select ch;

            return (c.Count(), v.Count());
        }
    }
}
