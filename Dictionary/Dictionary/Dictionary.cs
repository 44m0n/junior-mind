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

            Clear();

            Count = 0;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                var list = new List<TKey>();

                foreach (var e in this)
                {
                    list.Add(e.Key);
                }

                return list;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                var list = new List<TValue>();

                foreach (var e in this)
                {
                    list.Add(e.Value);
                }

                return list;
            }
        }

        public int Count { get; private set;  }

        public bool IsReadOnly => false;

        public TValue this[TKey key]
        {
            get
            {
                KeyIsNullException(key);
                int index = ElementIndex(key);
                return index > -1 ? elements[index].Value : throw new KeyNotFoundException($"{key} doesn't exists in the actual dictionary!");
            }

            set
            {
                KeyIsNullException(key);
                int index = ElementIndex(key);
                if (index == -1)
                {
                    throw new KeyNotFoundException($"{key} doesn't exists in the actual dictionary!");
                }

                elements[ElementIndex(key)].Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            KeyIsNullException(key);
            KeyIsInvalid(key);
            int bucketIndex = GetBucketIndex(key);
            int index = GetNextEmptyPosition();

            elements[index] = new Element<TKey, TValue>(key, value, buckets[bucketIndex]);
            buckets[bucketIndex] = index;

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            KeyIsNullException(item.Key);
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
            KeyIsNullException(key);

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
            int index = ElementIndex(key);

            if (index > -1)
            {
                value = elements[index].Value;
                return true;
            }

            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private (int index, int last) SearchKeyIndex(TKey key, int last = -1)
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
            return SearchKeyIndex(key).index;
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

        private void KeyIsNullException(TKey key)
            {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(key));
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
