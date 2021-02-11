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

        public LinkedListNode<T> First => Count != 0 ? sentinel.Next : CheckNode();

        public LinkedListNode<T> Last => Count != 0 ? sentinel.Previous : CheckNode();

        public void Add(T item)
        {
            AddAfter(new LinkedListNode<T>(item, this), sentinel.Previous);
        }

        public void Add(LinkedListNode<T> item)
        {
            AddAfter(item, sentinel.Previous);
        }

        public void AddAfter(LinkedListNode<T> item, LinkedListNode<T> node)
        {
            CheckNode(item);
            CheckNode(node);

            item.LinkTo(node, node.Next);
            node.Next.LinkTo(item, node.Next.Next);
            node.LinkTo(node.Previous, item);
        }

        public void AddAfter(T item, LinkedListNode<T> node)
        {
            AddAfter(new LinkedListNode<T>(item, this), node);
        }

        public void AddBefore(LinkedListNode<T> item, LinkedListNode<T> node)
        {
            AddAfter(item, node?.Previous);
        }

        public void AddBefore(T item, LinkedListNode<T> node)
        {
            AddAfter(new LinkedListNode<T>(item, this), node?.Previous);
        }

        public void AddFirst(LinkedListNode<T> item)
        {
            AddAfter(item, sentinel);
        }

        public void AddFirst(T item)
        {
            AddAfter(new LinkedListNode<T>(item, this), sentinel);
        }

        public void Clear()
        {
            Count = 0;
        }

        public LinkedListNode<T> Find(T item)
        {
            foreach (var node in EnumerateNodes())
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
            foreach (var node in EnumerateNodesBackwards())
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

            if (arrayIndex >= array.Length || array.Length < arrayIndex + Count)
            {
                throw new InvalidOperationException("Index is out of range");
            }

            foreach (var node in EnumerateNodes())
            {
                array.SetValue(node.Value, arrayIndex++);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in EnumerateNodes())
            {
                yield return node.Value;
            }
        }

        public bool Remove(T item)
        {
            var node = Find(item);

            if (node == null)
            {
                return false;
            }

            Remove(node);
            return true;
        }

        public bool Remove(LinkedListNode<T> item)
        {
            if (item == null || item.List != this)
            {
                return false;
            }

            item.Previous.Next = item.Next;
            item.Next.Previous = item.Previous;

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

        private IEnumerable<LinkedListNode<T>> EnumerateNodes()
        {
            for (LinkedListNode<T> i = sentinel.Next; i != sentinel; i = i.Next)
            {
                yield return i;
            }
        }

        private IEnumerable<LinkedListNode<T>> EnumerateNodesBackwards()
        {
            for (LinkedListNode<T> i = sentinel.Previous; i != sentinel; i = i.Previous)
            {
                yield return i;
            }
        }

        private LinkedListNode<T> CheckNode(LinkedListNode<T> node = null)
            {
            if (node == null)
            {
                throw new InvalidOperationException("The node is null! The node should be initializated before calling this method");
            }

            if (node.List != this)
            {
                throw new InvalidOperationException("The node is not in the current list or belongs to another list");
            }

            return node;
        }
    }
}
