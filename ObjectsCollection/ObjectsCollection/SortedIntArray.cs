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
                if (!CheckNeighbours(index, value))
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
            if (!CheckNeighbours(index, element))
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

        private bool CheckNeighbours(int index, int element)
        {
            if (index == 0)
            {
                return element < this[0] || Count == 1;
            }

            if (index == Count - 1)
            {
                return element > this[index];
            }

            return element >= this[index - 1]
                && (element <= this[index + 1] || element <= this[index]);
        }
    }
}
