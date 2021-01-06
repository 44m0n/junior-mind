using System;

namespace Json
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                var result = pattern.Match(text);

                if (result.Success())
                {
                    return result;
                }
            }

            return new Match(false, text);
        }

        public void Add(IPattern patternToAdd)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = patternToAdd;
        }
    }
}
