using Xunit;

namespace Json.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var no = new Number();

            Assert.True(no.Match("1").Success() && no.Match("1").RemainingText() == "");
            Assert.True(no.Match("-1").Success() && no.Match("-1").RemainingText() == "");
            Assert.True(no.Match("-1").Success() && no.Match("-1").RemainingText() == "");
            Assert.True(!no.Match("+1").Success() && no.Match("+1").RemainingText() == "+1");
            Assert.True(no.Match("123").Success() && no.Match("123").RemainingText() == "");
            Assert.True(no.Match("-123").Success() && no.Match("-123").RemainingText() == "");
            Assert.True(no.Match("01").Success() && no.Match("01").RemainingText() == "1");
            Assert.True(no.Match("-0").Success() && no.Match("-0").RemainingText() == "");



            Assert.True(no.Match("1.5").Success() && no.Match("1.5").RemainingText() == "");
            Assert.True(!no.Match("+1.55").Success() && no.Match("+1.55").RemainingText() == "+1.55");
            Assert.True(no.Match("-1.5").Success() && no.Match("-1.5").RemainingText() == "");
            Assert.True(no.Match("-1.55").Success() && no.Match("-1.55").RemainingText() == "");
            Assert.True(no.Match("-11.55").Success() && no.Match("-11.55").RemainingText() == "");
            Assert.True(no.Match("-0.5").Success() && no.Match("-0.5").RemainingText() == "");

            Assert.True(no.Match("1e2").Success() && no.Match("1e2").RemainingText() == "");
            Assert.True(no.Match("1e22").Success() && no.Match("1e22").RemainingText() == "");
            Assert.True(no.Match("11e22").Success() && no.Match("11e22").RemainingText() == "");
            Assert.True(no.Match("1E2").Success() && no.Match("1E2").RemainingText() == "");

            Assert.True(no.Match("1.1e2").Success() && no.Match("1.1e2").RemainingText() == "");
            Assert.True(no.Match("-1.1e2").Success() && no.Match("-1.1e2").RemainingText() == "");
            Assert.True(no.Match("1.1e2").Success() && no.Match("1.1e2").RemainingText() == "");
            Assert.True(no.Match("1.1e-2").Success() && no.Match("1.1e-2").RemainingText() == "");
            Assert.True(no.Match("1.1e+2").Success() && no.Match("1.1e+2").RemainingText() == "");
        }
    }
}
