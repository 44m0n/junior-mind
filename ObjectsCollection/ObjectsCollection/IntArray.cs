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
            var (exists, _) = CheckElement(element);

            return exists;
        }

        public int IndexOf(int element)
        {
            var (_, index) = CheckElement(element);

            return index;
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

            ShiftLeft(index);
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
        }

        public (bool, int) CheckElement(int element)
        {
            foreach (var el in array)
            {
                if (array[el] == element)
                {
                    return (true, el);
                }
            }

            return (false, -1);
        }

        public void ShiftRight(int index)
        {
            Array.Resize(ref array, array.Length + 1);

            int temp = array[index - 1];

            for (int i = index; i < array.Length; i++)
            {
                temp = temp * array[i];
                array[i] = temp / array[i];
                temp = temp / array[i];
            }
        }

        public void ShiftLeft(int index)
        {
            int temp = array[^1];

            for (int i = array.Length - 2; i >= index; i--)
            {
                temp = temp * array[i];
                array[i] = temp / array[i];
                temp = temp / array[i];
            }

            Array.Resize(ref array, array.Length - 1);
        }
    }
}
