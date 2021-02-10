using System;
using Xunit;
using LinkedList;

namespace LinkedList.Facts
{
    public class LinkedListFacts
    {
        [Fact]
        public void AddFact()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>();
            Assert.Equal(0, list.Count);
            list.Add(1);
            Assert.Equal(1, list.Count);
        }
    }
}
