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

            (int c, int i) result = StringOperations.GetConsAndVowelsCount(text);
            Assert.Equal(6, result.c);
            Assert.Equal(4, result.i);
        }

        [Fact]
        public void FirstUniqueCharacterTest()
        {
            string text = "ana are mere";

            Assert.Equal('n', StringOperations.FirstUniqueCharacter(text));
        }
    }
}
