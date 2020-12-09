using System;
using ChoiceConstructor;

namespace RangeConstructor
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] >= start && text[0] <= end;
        }
    }
}
