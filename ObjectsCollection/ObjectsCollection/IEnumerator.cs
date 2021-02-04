using System.Collections;

namespace ObjectsCollection
{
    public class IEnumeratorObjects : IEnumerator
    {
        private readonly ObjectArray array;
        private int position = -1;

        public IEnumeratorObjects(ObjectArray array)
        {
            this.array = array;
        }

        public object Current { get => array[position]; }

        public bool MoveNext()
        {
            position++;
            return position < array.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
