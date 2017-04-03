using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class LRUCache<TypeKey, TypeValue>
    {
        Dictionary<TypeKey, LinkedListNode<TypeValue>> map = new Dictionary<TypeKey, LinkedListNode<TypeValue>>();
        LinkedList<TypeValue> list = new LinkedList<TypeValue>();
        LinkedListNode<TypeValue> head = null;
        LinkedListNode<TypeValue> tail = null;
        public int Capacity { get; set; }

        public LRUCache(int capacity = 10)
        {
            Capacity = capacity;
        }

        public bool TryGetValue(TypeKey key, out TypeValue value)
        {
            value = default(TypeValue);
            LinkedListNode<TypeValue> entry;
            if (!map.TryGetValue(key, out entry)) return false;
            MoveToHead(entry);
            value = entry.Value;
            return true;
        }

        public void MoveToHead(LinkedListNode<TypeValue> node)
        {

        }
    }
}
