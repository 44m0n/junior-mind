using Xunit;

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

            //Double-calling should be avoid. Every result should be saved without calling Match(string) twice. 
            //I did this because I write fewer lines of code and this class it's just for testing.

            Assert.True(ab.Match("abcd").Success() == true && ab.Match("abcd").RemainingText() == "cd"); // true / "cd"
            Assert.True(ab.Match("ax").Success() == false && ab.Match("ax").RemainingText() == "ax"); // false / "ax"
            Assert.True(ab.Match("def").Success() == false && ab.Match("def").RemainingText() == "def"); // false / "def"
            Assert.True(ab.Match("").Success() == false && ab.Match("").RemainingText() == ""); // false / ""
            Assert.True(ab.Match(null).Success() == false && ab.Match(null).RemainingText() == null); // false / null

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.True(abc.Match("abcd").Success() == true && abc.Match("abcd").RemainingText() == "d"); // true / "d"
            Assert.True(abc.Match("def").Success() == false && abc.Match("def").RemainingText() == "def"); // false / "def"
            Assert.True(abc.Match("abx").Success() == false && abc.Match("abx").RemainingText() == "abx"); // false / "abx"
            Assert.True(abc.Match("").Success() == false && abc.Match("").RemainingText() == ""); // false / ""
            Assert.True(abc.Match(null).Success() == false && abc.Match(null).RemainingText() == null); // false / null


            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );


            Assert.True(hexSeq.Match("u1234").Success() == true && hexSeq.Match("u1234").RemainingText() == ""); // true / ""
            Assert.True(hexSeq.Match("uabcdef").Success() == true && hexSeq.Match("uabcdef").RemainingText() == "ef"); // true / "ef"
            Assert.True(hexSeq.Match("uB005 ab").Success() == true && hexSeq.Match("uB005 ab").RemainingText() == " ab"); // true / " ab"
            Assert.True(hexSeq.Match("abc").Success() == false && hexSeq.Match("abc").RemainingText() == "abc"); // false / "abc"
            Assert.True(hexSeq.Match(null).Success() == false && hexSeq.Match(null).RemainingText() == null); // false / null
            Assert.True(hexSeq.Match("").Success() == false && hexSeq.Match("").RemainingText() == ""); // false / ""
        }
    }
}
