using IMatchConstructor;
using IPatternConstructor;
using MatchConstructor;

namespace ChoiceConstructor
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                var result = pattern.Match(text);
                Match match = new Match(result.Success(), result.RemainingText());

                if (match.Success())
                {
                    return match;
                }
            }

            return new Match(false, null);
        }
    }
}
