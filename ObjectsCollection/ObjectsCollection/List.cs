using System;
using System.Collections;
using System.Collections.Generic;

namespace ObjectsCollection
{
    public class List<T> : IEnumerable<T>
    {
        private const int ActualLength = 4;
        private T[] array;

        public List()
        {
            array = new T[ActualLength];
        }

        public int Count { get; private set; }

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual void Add(T element)
        {
            Count++;
            CheckActualLength();
            array[Count - 1] = element;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            ShiftRight(index);
            array[index] = element;
        }

        public void Clear()
        {
            array = new T[ActualLength];
            Count = 0;
        }

        public void Remove(T element)
        {
            var index = IndexOf(element);
            if (index == -1)
            {
                return;
            }

            RemoveAt(index);
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
            array[i] = array[j];
        }

        private void UpdateArrayLength()
        {
            const int doubleLength = 2;
            Array.Resize(ref array, array.Length * doubleLength);
        }

        private void CheckActualLength()
        {
            if (Count <= array.Length)
            {
                return;
            }

            UpdateArrayLength();
        }
    }
}
