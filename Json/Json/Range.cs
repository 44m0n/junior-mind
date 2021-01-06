namespace Json
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;
        readonly string excluded;

        public Range(char start, char end, string excluded = "")
        {
            this.start = start;
            this.end = end;
            this.excluded = excluded;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            return (text[0] >= start && text[0] <= end) && !excluded.Contains(text[0])
                ? new Match(true, text.Substring(1))
                : new Match(false, text);
        }
    }
}
