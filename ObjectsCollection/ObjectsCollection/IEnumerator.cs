namespace ObjectsCollection
{
    class IEnumerator
    {
        private readonly ObjectArray array;
        private readonly int count;
        private int position = -1;

        public IEnumerator(ObjectArray array, int count)
        {
            this.array = array;
            this.count = count;
        }

        public object Current { get => array[position]; }

        public bool MoveNext()
        {
            position++;
            return position < count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
