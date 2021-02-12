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

        [Fact]
        public void AddFactNodeReturnException()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>();
            LinkedListNode<int> node = new LinkedListNode<int>(2, default);
            var err = Assert.Throws<InvalidOperationException>(() => list.Add(node));
            Assert.Equal("The node is not in the current list or belongs to another list", err.Message);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void AddAfter()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>() { 1, 2, 3 };

            var node = list.Last;
            list.Add(4);

            list.AddAfter(5, node);
            Assert.Equal(5, list.Count);
            Assert.Equal(4, list.Last.Value);
            list.RemoveLast();
            Assert.Equal(4, list.Count);
            Assert.Equal(5, list.Last.Value);
        }

        [Fact]
        public void AddBefore()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>() { 1, 2, 3 };

            var node = list.First;
            list.AddBefore(5, node);
            Assert.Equal(4, list.Count);
            Assert.Equal(5, list.First.Value);
        }

        [Fact]
        public void AddFirst()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>() { 1, 2, 3 };

            Assert.Equal(1, list.First.Value);
            list.AddFirst(5);
            Assert.Equal(4, list.Count);
            Assert.Equal(5, list.First.Value);
        }

        [Fact]
        public void CheckNeighbors()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>() { 1, 2, 3 };

            var node = list.Last.Previous;
            Assert.Equal(1, node.Previous.Value);
            Assert.Equal(3, node.Next.Value);
        }

        [Fact]
        public void Find()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>() { 1, 2, 3 };

            var node = list.Find(2);
            Assert.Equal(2, node.Value);
        }

        [Fact]
        public void FindReturnNull()
        {
            LinkedListCollection<int> list = new LinkedListCollection<int>() { 1, 2, 3 };

            var node = list.Find(5);
            Assert.Null(node);
        }
    }
}
