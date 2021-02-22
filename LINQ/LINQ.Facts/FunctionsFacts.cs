using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Facts
{
    public class FunctionsFacts
    {
        [Fact]
        public void AllTestReturnTrue()
        {
            var array = new int[] { 2, 4, 6, 8 };
            Functions.All(array, e => e % 2 == 0);

            Assert.True(array.All(e => e % 2 == 0));
        }

        [Fact]
        public void AllTestReturnFalse()
        {
            var array = new int[] { 1, 3, 4, 7 };

            Assert.False(array.All(e => e % 2 == 0));
        }

        [Fact]
        public void AllTestReturnExceptionForSource()
        {
            int[] array = null;

            var info = Assert.Throws<ArgumentNullException>(() => Functions.All(array, e => e % 2 == 0));
            Assert.Equal("source", info.ParamName);
        }

        [Fact]
        public void AllTestReturnExceptionForPredicate()
        {
            var array = new int[] { 1, 3, 4, 7 };

            var info = Assert.Throws<ArgumentNullException>(() => Functions.All(array, null));
            Assert.Equal("predicate", info.ParamName);
        }

        [Fact]
        public void AnyTestReturnTrue()
        {
            var array = new int[] { 1, 3, 4, 7 }; 

            Assert.True(array.Any(e => e % 2 == 0));
        }

        [Fact]
        public void AnyTestReturnFalse()
        {
            var array = new int[] { 1, 3, 5, 7 };

            Assert.False(array.Any(e => e % 2 == 0));
        }

        [Fact]
        public void FirstTestReturelement()
        {
            var array = new int[] { 1, 3, 4, 7 };

            Assert.Equal(4, array.First(e => e % 2 == 0));
        }

        [Fact]
        public void SelectFact()
        {
            var array = new int[] { 1, 3, 4, 7 };

            var results = array.Select(e => e % 2 == 0);

            Assert.Equal(new[] { false, false, true, false }, results);
        }

        [Fact]
        public void WhereFact()
        {
            var array = new int[] { 1, 3, 4, 7 };

            var results = array.Where(e => e % 2 == 0);

            var element = results.GetEnumerator();
            element.MoveNext();

            Assert.Equal(4, element.Current);
        }

        [Fact]
        public void ToDictionaryFact()
        {
            var array = new int[] { 1 };

            var results = array.ToDictionary(e => 1, f => "test");

            Assert.Contains(new KeyValuePair<int, string>(1, "test"), results);
        }

        [Fact]
        public void ZipFacts()
        {
            var firstArray = new int[] { 1, 3 };
            var secondArray = new int[] { 2, 4, 6 };

            var results = firstArray.Zip( secondArray, (e, f) => e + f);

            Assert.Equal(new[] { 3, 7 }, results);
        }

        [Fact]
        public void AggregateFacts()
        {
            var array = new int[] { 1, 3 };

            var result = array.Aggregate( 2, (e, f) => e + f);
            Assert.Equal(6, result);
        }

        [Fact]

        public void JoinTests()
        {
            var outer = new[] { 1, 3 };
            var inner = new[] { 2, 3 };

            var result = outer.Join(inner, e => e % 2 == 0, f => f % 2 == 0, (f, g) => f + g);
            Assert.Equal(new[] { 4, 6 }, result);
        }

        [Fact]
        public void DistinctTEst()
        {
            var source = new[] { 1, 2, 3, 3, 4, 4 };
            Assert.Equal(new[] { 1, 2, 3, 4 }, source.Distinct());
        }

        [Fact]
        public void UnionTests()
        {
            var first = new[] { 1, 2, 3 };
            var second = new[] { 3, 4, 5, 6 };

            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, first.Union(second));
        }
    }
}
