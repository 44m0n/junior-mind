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

        public override void Add(T item)
        {
            Sort(item);
        }

        public override void Insert(int index, T item)
        {
            if (ElementAtOrDefault(index - 1, item).CompareTo(item) == 1 || item.CompareTo(ElementAtOrDefault(index, item)) == 1)
            {
                return;
            }

            base.Insert(index, item);
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
