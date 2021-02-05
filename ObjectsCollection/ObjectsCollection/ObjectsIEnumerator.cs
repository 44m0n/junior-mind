using System.Collections;

namespace ObjectsCollection
{
    public class ObjectsIEnumerator : IEnumerator
    {
        private readonly ObjectArray array;
        private int position = -1;

        public ObjectsIEnumerator(ObjectArray array)
        {
            this.array = array;
        }

        public object Current { get => array[position]; }

        public bool MoveNext()
        {
            if (position == array.Count)
            {
                return false;
            }

            position++;
            return position < array.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
