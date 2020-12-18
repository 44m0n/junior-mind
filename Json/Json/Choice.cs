using System;
using CharacterConstructor;
using RangeConstructor;

namespace ChoiceConstructor
{
    public interface IPattern
    {
        bool Match(string text);
    }

    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
