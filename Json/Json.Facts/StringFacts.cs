using Xunit;

namespace Json.Facts
{
    public class StringFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var s = new String();

            Assert.True(s.Match("\"\"").Success() && s.Match("\"\"").RemainingText() == "");
            Assert.True(s.Match("\" \"").Success() && s.Match("\" \"").RemainingText() == "");
            Assert.True(s.Match("\"Text\"").Success() && s.Match("\"Text\"").RemainingText() == "");
            Assert.True(s.Match("\"Text\\u1111\"").Success() && s.Match("\"Text\\u1111\"").RemainingText() == "");
            Assert.True(s.Match("\"\\u1111\"").Success() && s.Match("\"\\u1111\"").RemainingText() == "");
            Assert.True(s.Match("\"\\r\"").Success() && s.Match("\"\\r\"").RemainingText() == "");
            Assert.True(s.Match("\"\\/\"").Success() && s.Match("\"\\/\"").RemainingText() == "");

            Assert.True(!s.Match("Text\"").Success() && s.Match("Text\"").RemainingText() == "Text\"");
            Assert.True(!s.Match("\"\\\"").Success() && s.Match("\"\\\"").RemainingText() == "\"\\\"");
        }
    }
}
