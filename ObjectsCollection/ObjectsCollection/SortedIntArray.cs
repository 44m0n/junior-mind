namespace ObjectsCollection
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray()
        {
        }

        public override int this[int index]
        {
            get => base[index];
            set
            {
                if (ElementAtOrDefault(index - 1, value) > value || value > ElementAtOrDefault(index + 1, value))
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(int element)
        {
            Sort(element);
        }

        public override void Insert(int index, int element)
        {
            if (ElementAtOrDefault(index - 1, element) > element || element > ElementAtOrDefault(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private void Sort(int element)
        {
            if (Count == 0)
            {
                base.Add(element);
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                if (element < this[i])
                {
                    base.Insert(i, element);
                    return;
                }
            }

            base.Add(element);
        }

        private int ElementAtOrDefault(int index, int value)
        {
            return index < 0 || index >= Count ? value : this[index];
        }
    }
}