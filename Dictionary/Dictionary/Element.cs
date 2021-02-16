using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    public class Element<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        public int Next;

        public Element(TKey key, TValue value, int next = -1)
        {
            this.Key = key;
            this.Value = value;
            this.Next = next;
        }
    }
}
