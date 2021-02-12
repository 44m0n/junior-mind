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

        [Fact]
        public void LastProprietyReturnException()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>();
            var err = Assert.Throws<InvalidOperationException>(() => list.Last);
            Assert.Equal("The node is null! The node should be initializated before calling this method", err.Message);
        }

        [Fact]
        public void AddFact()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>();
            list.Add(2);
            Assert.Equal(1, list.Count);
            Assert.Equal(2, list.First.Value);
            Assert.Equal(2, list.Last.Value);
        }

        [Fact]
        public void AddFactNode()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>();
            LinkedListNode<int> node = new LinkedListNode<int>(2, list);
            list.Add(node);
            Assert.Equal(1, list.Count);
            Assert.Equal(2, list.First.Value);
            Assert.Equal(2, list.Last.Value);
        }
    }
}
