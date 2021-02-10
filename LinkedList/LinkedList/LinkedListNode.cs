namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
            Previous = null;
            Next = null;
        }

        public T Value { get; private set; }

        public LinkedListNode<T> Next { get; private set; }

        public LinkedListNode<T> Previous { get; private set; }

        public void IsLinkedTo(LinkedListNode<T> previous, LinkedListNode<T> next)
        {
            Previous = previous;
            Next = next;
        }
    }
}
