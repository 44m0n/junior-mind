using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedListCollection<T> : ICollection<T>
    {
        private readonly LinkedListNode<T> sentinel;

        public LinkedListCollection()
        {
            Count = 0;
            sentinel = new LinkedListNode<T>(default, this);
            sentinel.LinkTo(sentinel, sentinel);
        }

        public bool IsReadOnly { get; }

        public int Count { get; private set; }

        public LinkedListNode<T> First => Count != 0 ? sentinel.Next : throw NodeIsNull();

        public LinkedListNode<T> Last => Count != 0 ? sentinel.Previous : throw NodeIsNull();

        public void Add(T item)
        {
            var nodeToAdd = new LinkedListNode<T>(item, this);
            InsertNode(sentinel.Previous, nodeToAdd, sentinel);
        }

        public void Add(LinkedListNode<T> item)
        {
            if (item == null)
            {
                throw NodeIsNull();
            }

            InsertNode(sentinel.Previous, item, sentinel);
        }

        public void AddAfter(LinkedListNode<T> item, LinkedListNode<T> node)
        {
            if (item == null || node == null || node.List != this)
            {
                throw NodeIsNull();
            }

            item.LinkTo(node, node.Next);
            node.Next.LinkTo(item, node.Next.Next);
            node.LinkTo(node.Previous, item);
        }

        public void AddAfter(T item, LinkedListNode<T> node)
        {
            if (node == null || !Contains(node.Value))
            {
                throw NodeIsNull();
            }

            InsertNode(node, new LinkedListNode<T>(item, this), node.Next);
        }

        public void AddBefore(LinkedListNode<T> item, LinkedListNode<T> node)
        {
            if (item == null || node == null || !Contains(node.Value))
            {
                throw NodeIsNull();
            }

            InsertNode(node.Previous, item, node);
        }

        public void AddBefore(T item, LinkedListNode<T> node)
        {
            if (node == null || !Contains(node.Value))
            {
                throw NodeIsNull();
            }

            InsertNode(node.Previous, new LinkedListNode<T>(item, this), node);
        }

        public void AddFirst(LinkedListNode<T> item)
        {
            if (item == null)
            {
                throw NodeIsNull();
            }

            InsertNode(sentinel, item, sentinel.Next);
        }

        public void AddFirst(T item)
        {
            InsertNode(sentinel, new LinkedListNode<T>(item, this), sentinel.Next);
        }

        public void Clear()
        {
            Count = 0;
        }

        public LinkedListNode<T> Find(T item)
        {
            foreach (var node in GetNodesAtStart())
            {
                if (node.Value.Equals(item))
                {
                    return node;
                }
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            foreach (var node in GetNodesAtEnd())
            {
                if (node.Value.Equals(item))
                {
                    return node;
                }
            }

            return null;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new InvalidOperationException("Array is null!");
            }

            var node = GetNodeAtIndex(arrayIndex);

            if (node == null)
            {
                throw NodeIsNull();
            }

            int index = 0;

            for (var i = node; i != sentinel; i = i.Next)
            {
                array[index] = node.Value;
                index++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = sentinel;

            for (int i = 0; i < Count; i++)
            {
                currentNode = currentNode.Next;
                yield return currentNode.Value;
            }
        }

        public bool Remove(T item)
        {
            var node = Find(item);

            if (node == null)
            {
                return false;
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;

            return true;
        }

        public bool Remove(LinkedListNode<T> item)
        {
            if (item == null)
            {
                throw NodeIsNull();
            }

            var node = Find(item.Value);

            if (node == null)
            {
                return false;
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;

            return true;
        }

        public void RemoveFirst()
        {
            Remove(First.Value);
        }

        public void RemoveLast()
        {
            Remove(Last.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<LinkedListNode<T>> GetNodesAtStart()
        {
            for (LinkedListNode<T> i = sentinel.Next; i != sentinel; i = i.Next)
            {
                yield return i;
            }
        }

        private IEnumerable<LinkedListNode<T>> GetNodesAtEnd()
        {
            for (LinkedListNode<T> i = sentinel.Previous; i != sentinel; i = i.Previous)
            {
                yield return i;
            }
        }

        private void InsertNode(LinkedListNode<T> first, LinkedListNode<T> actual, LinkedListNode<T> last)
        {
            actual.LinkTo(first, last);
            first.LinkTo(last.Previous, actual);
            last.LinkTo(actual, last.Next);
            Count++;
        }

        private LinkedListNode<T> GetNodeAtIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new InvalidOperationException($"Index cannot be less than 0 and greater or equal to {Count}.");
            }

            int currentIndex = 0;

            foreach (var node in GetNodesAtStart())
            {
                if (currentIndex == index)
                {
                    return node;
                }

                currentIndex++;
            }

            return null;
        }

        private Exception NodeIsNull()
        {
            return new InvalidOperationException("The node is null! The node should be initializated before calling this method");
        }
    }
}
