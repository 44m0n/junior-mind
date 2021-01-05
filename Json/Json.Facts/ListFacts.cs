using Xunit;
using RangeConstructor;
using CharacterConstructor;
using ListConstructor;
using OneOrMoreConstructor;
using SequenceConstructor;
using ManyConstructor;
using AnyConstructor;
using IPatternConstructor;
namespace Json.Facts
{
    public class ListFacts
    {
        [Fact]
        public void ManyFacts()
        {
            var a = new List(new RangeConstructor.Range('0', '9'), new Character(','));


            Assert.True(a.Match("1,2,3").Success() && a.Match("1,2,3").RemainingText() == "");
            Assert.True(a.Match("1,2,3").Success() && a.Match("1,2,3,").RemainingText() == ",");
            Assert.True(a.Match("1a").Success() && a.Match("1a").RemainingText() == "a");
            Assert.True(a.Match("").Success() && a.Match("").RemainingText() == "");
            Assert.True(a.Match(null).Success() && a.Match(null).RemainingText() == null);

            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success() && list.Match("1; 22  ;\n 333 \t; 22").RemainingText() == "");
            Assert.True(list.Match("1 \n;").Success() && list.Match("1 \n;").RemainingText() == " \n;");
            Assert.True(list.Match("abc").Success() && list.Match("abc").RemainingText() == "abc");
        }
    }
}
