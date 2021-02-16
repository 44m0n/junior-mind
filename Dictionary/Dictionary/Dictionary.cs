using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dictionary
{
    public class DictionaryObject<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int size = 5;
        private readonly int[] buckets;
        private readonly Element<TKey, TValue>[] elements;
        private int freeIndex = -1;

        public DictionaryObject()
        {
            buckets = new int[size];
            elements = new Element<TKey, TValue>[size];

            for (int i = 0; i < size; i++)
            {
                buckets[i] = -1;
            }

            Count = 0;
        }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count { get; private set;  }

        public bool IsReadOnly => false;

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
            int bucketIndex = GetKeyIndex(key);
            int index = GetNextEmptyPosition();

            elements[index] = new Element<TKey, TValue>(key, value, buckets[bucketIndex]);
            buckets[bucketIndex] = index;

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private int GetKeyIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % buckets.Length);
        }

        private int GetNextEmptyPosition()
        {
            if (freeIndex == -1)
            {
                return Count;
            }

            int index = freeIndex;
            freeIndex = elements[freeIndex].Next;
            return index;
        }
    }
}
