using System;
using IMatchConstructor;
using IPatternConstructor;
using MatchConstructor;

namespace SequenceConstructor
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
            var remainingText = text;

            foreach (var pattern in patterns)
            {
                var result = pattern.Match(remainingText);

                if (!result.Success())
                {
                    return new Match(false, text);
                }

                remainingText = result.RemainingText();
            }

            return new Match(true, remainingText);
        }
    }
}
