using Xunit;
using Json;

namespace Json.Facts
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.True(a.Match("123").Success() && a.Match("123").RemainingText() == "");
            Assert.True(a.Match("1a").Success() && a.Match("1a").RemainingText() == "a");
            Assert.True(!a.Match("bc").Success() && a.Match("bc").RemainingText() == "bc");
            Assert.True(!a.Match("").Success() && a.Match("").RemainingText() == "");
            Assert.True(!a.Match(null).Success() && a.Match(null).RemainingText() == null);
        }
    }
}
