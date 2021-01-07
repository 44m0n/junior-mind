namespace Json
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var whitespace = new Many(new Any(" \n\t\r"));

            var value = new Choice(
                new Ttext("true"),
                new Ttext("false"),
                new Ttext("null"),
                new Number(),
                new String());

            var arrayElements = new List(
                new Sequence(whitespace, value, whitespace),
                new Character(','));

            var array = new Choice(
                new Sequence(
                    new Character('['),
                    whitespace,
                    new Optional(new Sequence(arrayElements, whitespace)),
                    new Character(']')));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
