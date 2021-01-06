﻿namespace Json
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

            /* integer:
            *      digit
            *      onenine digits
            *      '-' digit
            *      '-' onenine digits
            */

            var integer = new Sequence(
                new Optional(new Character('-')),
                new Choice(new Character('0'), digits));

            // fraction: "" || '.' digits
            var fraction = new Optional(new Choice(new Sequence(new Character('.'), digits)));

            // sign: "" || '+' || '-'
            var sign = new Optional(new Any("-+"));

            // exponent: "" || 'e' sign digits
            var expo = new Optional(new Sequence(new Any("eE"), sign, digits));

            pattern = new Sequence(integer, fraction, expo);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}