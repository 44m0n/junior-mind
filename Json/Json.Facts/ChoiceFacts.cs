using Xunit;
using CharacterConstructor;
using ChoiceConstructor;
using RangeConstructor;

namespace Json.Facts
{
    public class ChoiceFacts
    {

        [Fact]
        public void MatchFactsReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );

            Assert.True(digit.Match("012").Success());
            Assert.True(digit.Match("12").Success());
            Assert.True(digit.Match("92").Success());
            Assert.False(digit.Match("a9").Success());
            Assert.False(digit.Match("").Success());
            Assert.False(digit.Match(null).Success());

            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
                ));

            Assert.True(hex.Match("012").Success()); // true
            Assert.True(hex.Match("12").Success()); // true
            Assert.True(hex.Match("92").Success()); // true
            Assert.True(hex.Match("a9").Success()); // true
            Assert.True(hex.Match("f8").Success()); // true
            Assert.True(hex.Match("A9").Success()); // true
            Assert.True(hex.Match("F8").Success()); // true
            Assert.False(hex.Match("g8").Success()); // false
            Assert.False(hex.Match("G8").Success()); // false
            Assert.False(hex.Match("").Success()); // false
            Assert.False(hex.Match(null).Success()); // false
        
        }
    }
}
