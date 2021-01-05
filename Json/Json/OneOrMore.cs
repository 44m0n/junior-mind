using IMatchConstructor;
using IPatternConstructor;
using ManyConstructor;
using SequenceConstructor;

namespace OneOrMoreConstructor
{
    public class OneOrMore
    {
        readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(pattern, new Many(pattern));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
