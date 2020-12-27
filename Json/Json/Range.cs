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
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, null);
            }

            return text[0] >= start && text[0] <= end ? new Match(true, text.Substring(1)) : new Match(false, text);
        }
    }
}
