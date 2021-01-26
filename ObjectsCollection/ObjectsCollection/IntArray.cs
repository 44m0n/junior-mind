using System;

namespace ObjectsCollection
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            array = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref array, array.Length + 1);
            array[^1] = element;
        }

        public int Count()
        {
            return array.Length;
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
            foreach (var el in array)
            {
                if (array[el] == element)
                {
                    return el;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            ShiftRight(index + 1);
            SetElement(index, element);
        }

        public void Clear()
        {
            array = new int[0];
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

        public void ShiftRight(int index)
        {
            Array.Resize(ref array, array.Length + 1);

            int temp = array[index - 1];

            for (int i = index; i < array.Length; i++)
            {
                temp = Swap(temp, i);
            }
        }

        public void ShiftLeft(int index)
        {
            int temp = array[^1];

            for (int i = array.Length - 2; i >= index; i--)
            {
                temp = Swap(temp, i);
            }

            Array.Resize(ref array, array.Length - 1);
        }

        public int Swap(int temp, int index)
        {
            temp = temp * array[index];
            array[index] = temp / array[index];

            return temp / array[index];
        }
    }
}
