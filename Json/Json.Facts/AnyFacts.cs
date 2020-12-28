using Xunit;
using AnyConstructor;

namespace Json.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var e = new Any("eE");

            Assert.True(e.Match("ea").Success() && e.Match("ea").RemainingText() == "a"); // true / "a"
            Assert.True(e.Match("Ea").Success() && e.Match("ea").RemainingText() == "a"); // true / "a"
            Assert.True(!e.Match("a").Success() && e.Match("a").RemainingText() == "a"); // false / "a"
            Assert.True(!e.Match("").Success() && e.Match("").RemainingText() == "");    // false / ""
            Assert.True(!e.Match(null).Success() && e.Match(null).RemainingText() == null); // false / null

            var sign = new Any("-+");

            Assert.True(sign.Match("+3").Success() && sign.Match("+3").RemainingText() == "3"); // true / "3"
            Assert.True(sign.Match("-2").Success() && sign.Match("-2").RemainingText() == "2"); // true / "2"
            Assert.True(!sign.Match("2").Success() && sign.Match("2").RemainingText() == "2"); // true / "2"
            Assert.True(!sign.Match("").Success() && sign.Match("").RemainingText() == ""); // true / ""
            Assert.True(!sign.Match(null).Success() && sign.Match(null).RemainingText() == null); // true / null
        } 
    }
}
