using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedListCollection<T> : ICollection<T>
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

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
