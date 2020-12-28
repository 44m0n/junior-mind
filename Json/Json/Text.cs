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
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            if (prefix == "")
            {
                return new Match(true, text);
            }

            bool prefixExists = text.StartsWith(prefix);

            return new Match(prefixExists, prefixExists ? text.Substring(prefix.Length) : text);
        }
    }
}
