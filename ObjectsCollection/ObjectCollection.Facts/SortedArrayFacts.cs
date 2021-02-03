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

            obj.Add(5);
            Assert.True(obj[0] == 5);
            obj[0] = 4;
            Assert.True(obj[0] == 4);
            Assert.True(obj.Count == 1);

            
            obj.Add(3);
            Assert.True(obj.Count == 2);
            Assert.True(obj[0] == 3);
            Assert.True(obj[1] == 4);

            
            obj.Insert(0, 5);
            Assert.True(obj.Count == 2);
            Assert.True(obj[0] == 3);
            Assert.True(obj[1] == 4);
            Assert.False(obj[0] == 5);

            
            obj.Remove(4);
            Assert.Equal(1, obj.Count);
            Assert.Equal(3, obj[0]);

            obj[0] = 1;
            Assert.Equal(1, obj[0]);

            obj.Add(4);
            Assert.True(obj.Count == 2);
            obj.Insert(1, 2);
            Assert.True(obj.Count == 3);
            Assert.True(obj[1] == 2);
            obj[2] = 3;
            Assert.True(obj[2] == 3);
            obj[2] = 1;
            Assert.False(obj[2] == 1);

        }
    }
}
