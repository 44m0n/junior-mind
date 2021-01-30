using System;
using Xunit;
using ObjectsCollection;

namespace ObjectCollection.Facts
{
    public class IntArrayFacts
    {
        [Fact]
        public void IntArray()
        {
            var obj = new IntArray();

            Assert.True(obj.Count() == 0);

            obj.Add(5);
            Assert.True(obj.IndexOf(5) == 0);
            Assert.True(obj.Count() == 1);

            Assert.True(obj.Element(0) == 5);

            obj.Add(3);
            Assert.True(obj.Count() == 2);
            Assert.True(obj.IndexOf(3) == 1);
            Assert.True(obj.Element(1) == 3);

            obj.SetElement(0, 2);
            Assert.True(obj.IndexOf(2) == 0);

            obj.Remove(2);
            Assert.True(obj.Count() == 1);
            Assert.True(obj.IndexOf(3) == 0);
            Assert.True(obj.Contains(3));

            obj.Insert(0, 1);
            Assert.True(obj.IndexOf(1) == 0);
            Assert.True(obj.IndexOf(3) == 1);

            obj.Remove(1);
            Assert.True(obj.IndexOf(3) == 0);
            Assert.True(obj.Count() == 1);
        }
    }
}
