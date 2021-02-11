using System;
using Xunit;
using LinkedList;

namespace LinkedList.Facts
{
    public class LinkedListFacts
    {
        [Fact]
        public void CountPropriety()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void FirstProprietyReturnException()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>();
            var err = Assert.Throws<InvalidOperationException>(() => list.First);
            Assert.Equal("The node is null! The node should be initializated before calling this method", err.Message);
        }
    }
}
