using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using LINQ;

namespace LINQ.Facts
{
    public class FunctionsFacts
    {
        [Fact]
        public void AllTestReturnTrue()
        {
            var array = new int[] { 2, 4, 6, 8 };

            Assert.True(Functions.All(array, e => e % 2 == 0));
        }

        [Fact]
        public void AllTestReturnFalse()
        {
            var array = new int[] { 1, 3, 4, 7 };

            Assert.False(Functions.All(array, e => e % 2 == 0));
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

            Assert.True(Functions.Any(array, e => e % 2 == 0));
        }

        [Fact]
        public void AnyTestReturnFalse()
        {
            var array = new int[] { 1, 3, 5, 7 };

            Assert.False(Functions.Any(array, e => e % 2 == 0));
        }

        [Fact]
        public void FirstTestReturelement()
        {
            var array = new int[] { 1, 3, 4, 7 };

            Assert.Equal(4, Functions.First(array, e => e % 2 == 0));
        }

        [Fact]
        public void SelectFact()
        {
            var array = new int[] { 1, 3, 4, 7 };

            var results = Functions.Select(array, e => e % 2 == 0);

            var element = results.GetEnumerator();

            for (int i = 0; i < array.Length; i ++)
            {
                element.MoveNext();

                if (array[i] % 2 == 0)
                {
                    Assert.True(element.Current);
                }
                else
                {
                    Assert.False(element.Current);
                }
            }
        }

        [Fact]
        public void WhereFact()
        {
            var array = new int[] { 1, 3, 4, 7 };

            var results = Functions.Where(array, e => e % 2 == 0);

            var element = results.GetEnumerator();
            element.MoveNext();

            Assert.Equal(4, element.Current);
        }

        [Fact]
        public void ToDictionaryFact()
        {
            var array = new int[] { 1 };

            var results = Functions.ToDictionary(array, e => 1, f => "test");

            Assert.Contains(new KeyValuePair<int, string>(1, "test"), results);
        }

        [Fact]
        public void ZipFacts()
        {
            var firstArray = new int[] { 1, 3 };
            var secondArray = new int[] { 2, 4, 6 };

            var results = Functions.Zip(firstArray, secondArray, (e, f) => e + f);

            int i = -1;

            foreach (var el in results)
            {
                i++;
                Assert.Equal((firstArray[i] + secondArray[i]), el);
            }

            Assert.Equal(1, i);
        }
    }
}
