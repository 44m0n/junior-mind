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

            var element = new Sequence(whitespace, value, whitespace);

            var arrayElements = new List(
                element,
                new Character(','));

            var array = new Sequence(
                new Character('['),
                whitespace,
                new Optional(new Sequence(arrayElements, whitespace)),
                new Character(']'));

            var objElement = new Sequence(
                whitespace,
                new String(),
                whitespace,
                new Character(':'),
                element);

            var objElements = new List(objElement, new Character(','));
            var obj = new Sequence(
                new Character('{'),
                whitespace,
                new Optional(new Sequence(objElements, whitespace)),
                new Character('}'));

            value.Add(array);
            value.Add(obj);

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
