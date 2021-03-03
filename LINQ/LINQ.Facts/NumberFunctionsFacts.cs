using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Facts
{
    public class NumberFunctionsFacts
    {
        [Fact]
        public void GetAllSubsetTest()
        {
            var source = new[] { 1, 2, 3, 4, 5 };

            var result = NumberFunctions.GetAllSubsetsLessThan(source, 4);
            IEnumerable<IEnumerable<int>> expected = new[] { new[] { 1, 2 }, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 } };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAllCombinationsTest()
        {
            var result = NumberFunctions.GetAllCombinations(3, 2);
            IEnumerable<IEnumerable<int>> expected = new[] { new[] { 1, -2, 3 } };

            Assert.Equal(expected, result);
        }
    }
}
