using IMatchConstructor;
using IPatternConstructor;
using MatchConstructor;

namespace AnyConstructor
{
    public class Any : IPattern
    {
        readonly string letters;

        public Any(string letters)
        {
            this.letters = letters;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            foreach (char c in letters)
            {
                if (text[0] == c)
                {
                    return new Match(true, text.Substring(1));
                }
            }

            return new Match(false, text);
        }
    }
}
