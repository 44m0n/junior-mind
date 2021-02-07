using System;

namespace ObjectsCollection
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override T this[int index]
        {
            get => base[index];
            set
            {
                if (ElementAtOrDefault(index - 1, value).CompareTo(value) == 1 || value.CompareTo(ElementAtOrDefault(index + 1, value)) == 1)
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(T element)
        {
            Sort(element);
        }

        public override void Insert(int index, T element)
        {
            if (ElementAtOrDefault(index - 1, element).CompareTo(element) == 1 || element.CompareTo(ElementAtOrDefault(index, element)) == 1)
            {
                return;
            }

            base.Insert(index, element);
        }

        private void Sort(T element)
        {
            if (Count == 0)
            {
                base.Add(element);
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                if (element.CompareTo(this[i]) == -1)
                {
                    base.Insert(i, element);
                    return;
                }
            }

            base.Add(element);
        }

        private T ElementAtOrDefault(int index, T value)
        {
            return index < 0 || index >= Count ? value : this[index];
        }
    }
}
