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
                var no = base[index];
                Add(value);
                Remove(no);
            }
        }

        public override void Add(int element)
        {
            Sort(element);
        }

        public override void Insert(int index, int element)
        {
            Add(element);
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
    }
}
