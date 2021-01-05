namespace Json
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch result = new Match(true, text);

            foreach (var pattern in patterns)
            {
                result = pattern.Match(result.RemainingText());

                if (!result.Success())
                {
                    return new Match(false, text);
                }
            }

            return result;
        }
    }
}
