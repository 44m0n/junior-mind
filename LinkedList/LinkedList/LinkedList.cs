﻿using System;
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

        public LinkedListNode<T> First => Count != 0 ? sentinel.Next : null;

        public LinkedListNode<T> Last => Count != 0 ? sentinel.Previous : null;

        public void Add(T item)
        {
            throw new NotImplementedException();
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
    }
}
