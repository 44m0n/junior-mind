namespace Json
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
            return (!string.IsNullOrEmpty(text) && text.StartsWith(prefix))
                ? new Match(true, text.Substring(prefix.Length))
                : new Match(false, text);
        }
    }
}
