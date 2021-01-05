namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            /* digits:
             *      digit:
             *          0-9
             *          1-9
             *      digit digits
             */
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);
            var oneNineDigit = new Range('1', '9');

            /* integer:
            *      digit
            *      onenine digits
            *      '-' digit
            *      '-' onenine digits
            */
            var integer = new Choice(
                new Sequence(new Character('-'), oneNineDigit, digits),
                new Sequence(new Character('-'), digit),
                new Sequence(oneNineDigit, digits),
                digit);

            // fraction: "" || '.' digits
            var fraction = new Optional(new Choice(new Sequence(new Character('.'), digits)));

            // sign: "" || '+' || '-'
            var sign = new Optional(
                new Choice(
                    new Character('+'),
                    new Character('-')));

            // exponent: "" || 'e' sign digits
            var expo = new Optional(
                new Choice(
                    new Sequence(new Character('e'), sign, digits),
                    new Sequence(new Character('E'), sign, digits)));

            pattern = new Sequence(integer, fraction, expo);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
