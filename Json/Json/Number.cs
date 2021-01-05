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
            IPattern digit = new Range('0', '9');
            IPattern digits = new OneOrMore(digit);
            IPattern oneNineDigit = new Range('1', '9');

            /* integer:
            *      digit
            *      onenine digits
            *      '-' digit
            *      '-' onenine digits
            */
            IPattern integer = new Choice(
                new Sequence(new Character('-'), oneNineDigit, digits),
                new Sequence(new Character('-'), digit),
                new Sequence(oneNineDigit, digits),
                digit);

            // fraction: "" || '.' digits
            IPattern fraction = new Optional(new Choice(new Sequence(new Character('.'), digits)));

            // sign: "" || '+' || '-'
            IPattern sign = new Optional(
                new Choice(
                    new Character('+'),
                    new Character('-')));

            // exponent: "" || 'e' sign digits
            IPattern expo = new Optional(
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
