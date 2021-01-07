using Xunit;
namespace Json.Facts
{
    public class ValueFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var value = new Value();

            Assert.True(value.Match("true").Success() && value.Match("true").RemainingText() == "");
            Assert.True(value.Match("\"Test123\"").Success() && value.Match("\"Test123\"").RemainingText() == "");
            Assert.True(value.Match("null").Success() && value.Match("null").RemainingText() == "");
            Assert.True(value.Match("5").Success() && value.Match("5").RemainingText() == "");
            Assert.True(value.Match("-1.1e-2").Success() && value.Match("-1.1e-2").RemainingText() == "");

            Assert.True(value.Match("[]").Success() && value.Match("[]").RemainingText() == "");
            Assert.True(value.Match("[ ]").Success() && value.Match("[ ]").RemainingText() == "");
            Assert.True(value.Match("[true]").Success() && value.Match("[true]").RemainingText() == "");
            Assert.True(value.Match("[true,true]").Success() && value.Match("[true,true]").RemainingText() == "");
            Assert.True(value.Match("[true, true]").Success() && value.Match("[true, true]").RemainingText() == "");
            Assert.True(value.Match("[ true ]").Success() && value.Match("[ true ]").RemainingText() == "");

            Assert.True(value.Match("{}").Success() && value.Match("{}").RemainingText() == "");
            Assert.True(value.Match("{ }").Success() && value.Match("{ }").RemainingText() == "");
            Assert.True(value.Match("{ \"true\" : true, \"true\" : false}").Success() && value.Match("{ \"true\" : true, \"true\" : false}").RemainingText() == "");
            Assert.True(value.Match("{\"test\" : \"test\"}").Success() && value.Match("{\"test\" : \"test\"}").RemainingText() == "");
            Assert.True(value.Match("{\"test\" : \"test\"}").Success() && value.Match("{\"test\" : \"test\"}").RemainingText() == "");
            Assert.True(value.Match("{\"test\" : [true, true]}").Success() && value.Match("{\"test\" : [true, true]}").RemainingText() == "");

            Assert.False(value.Match("{\"test\" : \"test\"").Success() && value.Match("{\"test\" : \"test\"").RemainingText() == "");
            Assert.False(value.Match("[true, true").Success() && value.Match("[true, true").RemainingText() == "");
        }
    }
}
