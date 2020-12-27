using Xunit;
using CharacterConstructor;
using ChoiceConstructor;
using RangeConstructor;
using SequenceConstructor;

namespace Json.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void MatchFacts()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.True(ab.Match("abcd").Success() == true && ab.Match("abcd").RemainingText() == "cd"); // true / "cd"
        }
    }
}
