using System;
using ObjectsCollection;
using Xunit;

namespace ObjectsCollection.Facts
{
    public class SortedArrayFacts
    {
        [Fact]
        public void SortedArray()
        {
            var obj = new SortedIntArray();

            Assert.True(obj.Count == 0);

            obj[0] = 5;
            obj[0] = 4;
            Assert.True(obj[0] == 4);
            Assert.True(obj.Count == 1);

            obj.Add(3);
            Assert.True(obj.Count == 2);
            Assert.True(obj[0] == 3);
            Assert.True(obj[1] == 4);

            obj.Insert(0, 5);
            Assert.True(obj.Count == 3);
            Assert.True(obj[0] == 3);
            Assert.True(obj[1] == 4);
            Assert.True(obj[2] == 5);

            obj.Remove(4);
            Assert.Equal(2, obj.Count);
            Assert.Equal(5, obj[1]);

            obj[1] = 1;
            Assert.Equal(3, obj[1]);
        }
    }
}
