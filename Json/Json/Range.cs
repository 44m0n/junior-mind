using IMatchConstructor;
using IPatternConstructor;
using MatchConstructor;

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

        public IMatch Match(string text)
        {
            return new Match(!string.IsNullOrEmpty(text) && text[0] >= start && text[0] <= end, string.IsNullOrEmpty(text) ? null : text.Substring(1));
        }
    }
}
