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

        public TValue this[TKey key]
        {
            get
            {
                ArgumentIsNullException(key);
                KeyNotFoundException(key);
                return elements[ElementIndex(key)].Value;
            }

            set
            {
                ArgumentIsNullException(key);
                KeyNotFoundException(key);
                elements[ElementIndex(key)].Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            KeyIsInvalid(key);
            int bucketIndex = GetBucketIndex(key);
            int index = GetNextEmptyPosition();

            elements[index] = new Element<TKey, TValue>(key, value, buckets[bucketIndex]);
            buckets[bucketIndex] = index;

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Count = 0;
            Array.Fill(buckets, -1);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ElementIndex(item.Key) > -1;
        }

        public bool ContainsKey(TKey key)
        {
            return ElementIndex(key) > -1;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new InvalidOperationException("Array is null!");
            }

            if (arrayIndex >= array.Length || array.Length < arrayIndex + Count)
            {
                throw new InvalidOperationException("Index is out of range");
            }

            foreach (var element in elements)
            {
                array.SetValue(element.Value, arrayIndex++);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int currentLength = Count;

            for (int i = 0; i < currentLength; i++)
            {
                if (!ContainsKey(elements[i].Key))
                {
                    currentLength++;
                    continue;
                }

                yield return new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
            }
        }

        public bool Remove(TKey key)
        {
            (int position, int last) keyIndex = SearchKeyIndex(key);

            if (keyIndex.position == -1)
            {
                return false;
            }

            if (keyIndex.last != -1)
            {
                elements[keyIndex.last].Next = elements[keyIndex.position].Next;
            }
            else
            {
                buckets[GetBucketIndex(key)] = elements[keyIndex.position].Next;
            }

            elements[keyIndex.position].Next = freeIndex;
            freeIndex = keyIndex.position;
            Count--;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private (int, int) SearchKeyIndex(TKey key, int last = -1)
        {
            for (int index = buckets[GetBucketIndex(key)]; index > -1; index = elements[index].Next)
            {
                if (elements[index].Key.Equals(key))
                {
                    return (index, last);
                }

                last = index;
            }

            return (-1, last);
        }

        private int ElementIndex(TKey key)
        {
            return SearchKeyIndex(key).Item1;
        }

        private int GetBucketIndex(TKey key)
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

        private void ArgumentIsNullException(TKey key)
            {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(key));
        }

        private void KeyNotFoundException(TKey key)
        {
            if (ContainsKey(key))
            {
                return;
            }

            throw new KeyNotFoundException($"{key} doesn't exists in the actual dictionary!");
        }

        private void KeyIsInvalid(TKey key)
        {
            if (!ContainsKey(key))
            {
                return;
            }

            throw new ArgumentException($"{key} already exists in the current dictionary!");
        }
    }
}
