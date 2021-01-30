using System;

namespace ObjectsCollection
{
    public class IntArray
    {
        private const int ActualLength = 4;
        private int[] array;

        public IntArray()
        {
            array = new int[ActualLength];
        }

        public int Count { get; private set; }

        public void Add(int element)
        {
            Count++;
            CheckActualLength();
            array[Count - 1] = element;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            ShiftRight(index);
            SetElement(index, element);
        }

        public void Clear()
        {
            array = new int[ActualLength];
        }

        public void Remove(int element)
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
