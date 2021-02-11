namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value, LinkedListCollection<T> list)
        {
            Value = value;
            List = list;
            Previous = null;
            Next = null;
        }

        public T Value { get; private set; }

        public LinkedListCollection<T> List { get; }

        public LinkedListNode<T> Next { get;  set; }

        public LinkedListNode<T> Previous { get;  set; }

        public void LinkTo(LinkedListNode<T> previous, LinkedListNode<T> next)
        {
            Previous = previous;
            Next = next;
        }
    }
}
