namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);

            var integer = new Sequence(
                new Optional(new Character('-')),
                new Choice(new Character('0'), digits));

            var fraction = new Optional(new Choice(new Sequence(new Character('.'), digits)));
            var sign = new Optional(new Any("-+"));
            var expo = new Optional(new Sequence(new Any("eE"), sign, digits));

            pattern = new Sequence(integer, fraction, expo);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
