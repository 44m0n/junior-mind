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
            return (!string.IsNullOrEmpty(text) && letters.Contains(text[0])) ? new Match(true, text.Substring(1)) : new Match(false, text);
        }
    }
}
