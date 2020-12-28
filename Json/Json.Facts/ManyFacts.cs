using Xunit;
using ManyConstructor;
using CharacterConstructor;
using RangeConstructor;

namespace Json.Facts
{
    public class ManyFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var a = new Many(new Character('a'));

            Assert.Equal("bc", a.Match("abc").RemainingText());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
            Assert.Equal("bc", a.Match("bc").RemainingText());
            Assert.Equal("", a.Match("").RemainingText());
            Assert.True(a.Match(null).RemainingText() == null);

            var digits = new Many(new Range('0', '9'));

            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }
    }
}
