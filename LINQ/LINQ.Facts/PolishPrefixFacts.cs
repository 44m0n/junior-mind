using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Facts
{
    public class PolishPrefixFacts
    {
        [Fact]
        public void AdditionFact()
        {
            Assert.Equal(3, new PolishPostfix("1 2 +").Calculate());
            Assert.Equal(6, new PolishPostfix("1 2 3 + +").Calculate());
        }

        [Fact]
        public void SubstractFact()
        {
            Assert.Equal(-1, new PolishPostfix("1 2 -").Calculate());
            Assert.Equal(0, new PolishPostfix("3 2 1 - -").Calculate());
        }

        [Fact]
        public void MultiplyFact()
        {
            Assert.Equal(2, new PolishPostfix("1 2 *").Calculate());
            Assert.Equal(6, new PolishPostfix("3 2 1 * *").Calculate());
        }

        [Fact]
        public void DivideFact()
        {
            Assert.Equal(3, new PolishPostfix("6 2 /").Calculate());
            Assert.Equal(2, new PolishPostfix("12 3 2 / /").Calculate());
        }

        [Fact]
        public void MultipleoperationsFact()
        {
            Assert.Equal(8, new PolishPostfix("7 4 + 3 -").Calculate());
            Assert.Equal(10, new PolishPostfix("2 3 * 4 +").Calculate());
            Assert.Equal(9, new PolishPostfix("1 2 + 3 *").Calculate());
            Assert.Equal(1, new PolishPostfix("1 2 + 3 /").Calculate());
        }
    }
}
