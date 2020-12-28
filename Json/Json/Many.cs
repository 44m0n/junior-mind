using IMatchConstructor;
using IPatternConstructor;
using MatchConstructor;

namespace ManyConstructor
{
    public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(true, text);
            }

            var match = pattern.Match(text);

            while (match.Success())
            {
                text = match.RemainingText();
                match = pattern.Match(text);
            }

            return new Match(true, text);
        }
    }
}
