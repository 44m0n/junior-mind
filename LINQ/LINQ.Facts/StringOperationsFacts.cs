using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Facts
{
    public class StringOperationsFacts
    {
        [Fact]
        public void GetConsAndVowelsCountTest()
        {
            string text = "ana are mere";

            (int v, int c) result = StringOperations.GetConsAndVowelsCount(text);
            Assert.Equal(6, result.v);
            Assert.Equal(4, result.c);
        }

        [Fact]
        public void FirstUniqueCharacterTest()
        {
            string text = "ana are mere";

            Assert.Equal('n', StringOperations.FirstUniqueCharacter(text));
        }

        [Fact]
        public void ConvertToIntTest()
        {
            string text = "123";
            Assert.Equal(123, StringOperations.ConvertStringToInt(text));
            text = "-123";
            Assert.Equal(-123, StringOperations.ConvertStringToInt(text));
        }
    }
}
