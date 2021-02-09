using System;
using System.Collections;
using System.Collections.Generic;

namespace ObjectsCollection
{
    public class List<T> : IList<T>
    {
        private const int ActualLength = 4;
        private T[] contents;

        public List()
        {
            contents = new T[ActualLength];
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get => false; }

        public virtual T this[int index]
        {
            get => contents[index];
            set => contents[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return contents[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CheckIfArrayIsNull(array);
            CheckIfIndexIsOutOfRange(arrayIndex);
            CheckArrayLength(array, arrayIndex);

            for (int i = 0; i < Count; i++)
            {
                array?.SetValue(array[i], arrayIndex++);
            }
        }

        public virtual void Add(T item)
        {
            CheckIfReadOnly();
            Count++;
            CheckActualLength();
            contents[Count - 1] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (contents[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            CheckIfReadOnly();
            CheckIfIndexIsOutOfRange(index);
            ShiftRight(index);
            contents[index] = item;
        }

        public void Clear()
        {
            CheckIfReadOnly();
            Count = 0;
        }

        public bool Remove(T item)
        {
            CheckIfReadOnly();

            var index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            CheckIfReadOnly();
            CheckIfIndexIsOutOfRange(index);
            ShiftLeft(index);
        }

        private void ShiftRight(int index)
        {
            Count++;
            UpdateArrayLength();

            for (int i = Count - 1; i > index; i--)
            {
                Swap(i, i - 1);
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                Swap(i, i + 1);
            }

            Count--;
        }

        private void Swap(int i, int j)
        {
            contents[i] = contents[j];
        }

        private void UpdateArrayLength()
        {
            const int doubleLength = 2;
            Array.Resize(ref contents, contents.Length * doubleLength);
        }

        private void CheckActualLength()
        {
            if (Count <= contents.Length)
            {
                return;
            }

            UpdateArrayLength();
        }

        private void CheckIfArrayIsNull(T[] array)
        {
            if (array != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(array), $"The {nameof(array)} should not be null");
        }

        private void CheckIfIndexIsOutOfRange(int arrayIndex)
        {
            if (arrayIndex >= 0 && arrayIndex < Count)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index does not exists");
        }

        private void CheckArrayLength(T[] array, int arrayIndex)
        {
            if (array.Length >= this.Count + arrayIndex)
            {
                return;
            }

            throw new ArgumentException("Copying failed. Destination array is too small.");
        }

        private void CheckIfReadOnly()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException("List is set to read only.");
        }
    }
}
