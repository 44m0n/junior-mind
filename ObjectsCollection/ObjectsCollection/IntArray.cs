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
            foreach (var el in array)
            {
                if (array[el] == element)
                {
                    return true;
                }
            }

            return false;
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
            Array.Resize(ref array, array.Length + 1);

            int temp = 0;
            for (int i = index; i < array.Length; i++)
            {
                if (i == index)
                {
                    temp = array[i];
                    array[i] = element;
                    continue;
                }

                int temp2 = array[i];
                array[i] = temp;
                temp = temp2;
            }
        }

        public void Clear()
        {
            array = new int[0];
        }

        public void Remove(int element)
        {
            int index = -1;
            bool firstElement = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (firstElement && array[i] == element)
                {
                    index = i;
                    firstElement = false;
                }

                if (i >= index)
                {
                    array[i] = array[i + 1];
                }
            }

            Array.Resize(ref array, array.Length - 1);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);
        }
    }
}
