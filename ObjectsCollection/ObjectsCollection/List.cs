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
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array?.SetValue(array[i], arrayIndex++);
            }
        }

        public virtual void Add(T item)
        {
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
            ShiftRight(index);
            contents[index] = item;
        }

        public void Clear()
        {
            contents = new T[ActualLength];
            Count = 0;
        }

        public bool Remove(T item)
        {
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
    }
}
