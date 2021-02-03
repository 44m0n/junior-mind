using System;

namespace ObjectsCollection
{
    public class ObjectArray
    {
        private const int ActualLength = 4;
        private object[] array;

        public ObjectArray()
        {
            array = new object[ActualLength];
        }

        public int Count { get; private set; }

        public virtual object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public void Add(object element)
        {
            Count++;
            CheckActualLength();
            array[Count - 1] = element;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
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

        public void Insert(int index, object element)
        {
            ShiftRight(index);
            array[index] = element;
        }

        public void Clear()
        {
            array = new object[ActualLength];
            Count = 0;
        }

        public void Remove(object element)
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
