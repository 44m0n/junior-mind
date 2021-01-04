using System;
using IMatchConstructor;
using IPatternConstructor;
using MatchConstructor;

namespace OptionalConstructor
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public class Optional : IPattern
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var result = pattern.Match(text);

            return new Match(true, result.RemainingText());
        }
    }
}
