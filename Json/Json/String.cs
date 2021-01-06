namespace Json
{
    public class String
    {
        private readonly IPattern pattern;

        public String()
        {
            var digit = new Range('0', '9');

            var hex = new Choice(
                digit,
                new Range('A', 'F'),
                new Range('a', 'f'));

            var escape = new Choice(
                new Any("\"\\/bfnrt"),
                new Sequence(new Character('u'), hex, hex, hex, hex));

            var character = new Choice(
                new Range(' ', '~', "\"\\"),
                new Sequence(new Character('\\'), escape));

            pattern = new Sequence(new Character('\"'), new Many(character), new Character('\"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
