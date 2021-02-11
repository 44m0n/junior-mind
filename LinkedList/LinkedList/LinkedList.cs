using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedListCollection<T> : ICollection<T>
        where T : IComparable<T>
    {
        private readonly LinkedListNode<T> sentinel;

        public LinkedListCollection()
        {
            Count = 0;
            sentinel = new LinkedListNode<T>(default);
            sentinel.IsLinkedTo(sentinel, sentinel);
        }

        public bool IsReadOnly { get; }

        public int Count { get; private set; }

        public LinkedListNode<T> First => Count != 0 ? sentinel.Next : throw NodeIsNull();

        public LinkedListNode<T> Last => Count != 0 ? sentinel.Previous : throw NodeIsNull();

        public void Add(T item)
        {
            var nodeToAdd = new LinkedListNode<T>(item);
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
            if (item == null || node == null)
            {
                throw NodeIsNull();
            }

            InsertNode(node, item, node.Next);
        }

        public void AddAfter(T item, LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw NodeIsNull();
            }

            InsertNode(node, new LinkedListNode<T>(item), node.Next);
        }

        public void AddBefore(LinkedListNode<T> item, LinkedListNode<T> node)
        {
            if (item == null || node == null)
            {
                throw NodeIsNull();
            }

            InsertNode(node.Previous, item, node);
        }

        public void AddBefore(T item, LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw NodeIsNull();
            }

            InsertNode(node.Previous, new LinkedListNode<T>(item), node);
        }

        public void Addfirst(LinkedListNode<T> item)
        {
            if (item == null)
            {
                throw NodeIsNull();
            }

            InsertNode(sentinel, item, sentinel.Next);
        }

        public void Addfirst(T item)
        {
            InsertNode(sentinel, new LinkedListNode<T>(item), sentinel.Next);
        }

        public void Clear()
        {
            Count = 0;
        }

        public LinkedListNode<T> Find(T item)
        {
            foreach (var node in GetNodesAtStart())
            {
                if (node.Value.CompareTo(item) == 0)
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
                if (node.Value.CompareTo(item) == 0)
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            actual.IsLinkedTo(first, last);
            first.IsLinkedTo(last.Previous, actual);
            last.IsLinkedTo(actual, last.Next);
            Count++;
        }

        private Exception NodeIsNull()
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one
            throw new ArgumentNullException("The node is null! The node should be initializated before calling this method");
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one
        }
    }
}
