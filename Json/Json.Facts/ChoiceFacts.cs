using Xunit;
using CharacterConstructor;
using ChoiceConstructor;
using RangeConstructor;

namespace Json.Facts
{
    public class ChoiceFacts
    {
        /*
        [Fact]
        public void MatchFactsReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.True(digit.Match("012"));
            Assert.True(digit.Match("12"));
            Assert.True(digit.Match("92"));
            Assert.False(digit.Match("a9"));
            Assert.False(digit.Match(""));
            Assert.False(digit.Match(null));

            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
                ));

            Assert.True(hex.Match("012")); // true
            Assert.True(hex.Match("12")); // true
            Assert.True(hex.Match("92")); // true
            Assert.True(hex.Match("a9")); // true
            Assert.True(hex.Match("f8")); // true
            Assert.True(hex.Match("A9")); // true
            Assert.True(hex.Match("F8")); // true
            Assert.False(hex.Match("g8")); // false
            Assert.False(hex.Match("G8")); // false
            Assert.False(hex.Match("")); // false
            Assert.False(hex.Match(null)); // false
        */
        }

    }
}
