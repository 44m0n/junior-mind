using Xunit;
using TextConstructor;

namespace Json.Facts
{
    public class TextFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var tr = new Ttext("true");

            Assert.True(tr.Match("true").Success() && tr.Match("true").RemainingText() == ""); // true / ""
            Assert.True(tr.Match("trueX").Success() && tr.Match("trueX").RemainingText() == "X"); // true / "X"
            Assert.True(!tr.Match("false").Success() && tr.Match("false").RemainingText() == "false"); // false / "false"
            Assert.True(!tr.Match("").Success() && tr.Match("").RemainingText() == ""); // false / ""
            Assert.True(!tr.Match(null).Success() && tr.Match(null).RemainingText() == null); // false / null

            var empty = new Ttext("");
            Assert.True(empty.Match("true").Success() && empty.Match("true").RemainingText() == "true");
            Assert.True(!empty.Match(null).Success() && empty.Match(null).RemainingText() == null);
        }
    }
}
