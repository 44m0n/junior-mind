using Xunit;
using CharacterConstructor;
using OptionalConstructor;

namespace Json.Facts
{
    public class OptionalFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var a = new Optional(new Character('a'));

            Assert.Equal("bc", a.Match("abc").RemainingText());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
            Assert.Equal("bc", a.Match("bc").RemainingText());
            Assert.Equal("", a.Match("").RemainingText());
            Assert.True(a.Match(null).RemainingText() == null);

            var sign = new Optional(new Character('-'));

            Assert.Equal("123", sign.Match("123").RemainingText());
            Assert.Equal("123", sign.Match("-123").RemainingText());
        }
    }
}
