using IMatchConstructor;
using IPatternConstructor;
using MatchConstructor;

namespace TextConstructor
{
    // Text (and txt) conflicts with System.Drawing.Text
    public class Ttext : IPattern
    {
        readonly string prefix;

        public Ttext(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return (!string.IsNullOrEmpty(text) && text.StartsWith(prefix)) ? new Match(true, text.TrimStart(prefix.ToCharArray())) : new Match(false, text);
        }
    }
}
