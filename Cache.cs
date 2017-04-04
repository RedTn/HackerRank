using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class LRUCache<TypeKey, TypeValue>
    {
        public class LinkedListNode
        {
            public TypeValue Value { get; set; }
            public LinkedListNode Next { get; set; }
            public LinkedListNode Previous { get; set; }
        }

        Dictionary<TypeKey, LinkedListNode> map = new Dictionary<TypeKey, LinkedListNode>();
        LinkedListNode head = null;
        LinkedListNode tail = null;
        public int Capacity { get; set; }

        public LRUCache(int capacity = 10)
        {
            Capacity = capacity;
        }

        public bool TryGetValue(TypeKey key, out TypeValue value)
        {
            value = default(TypeValue);
            LinkedListNode entry;
            if (!map.TryGetValue(key, out entry)) return false;
            MoveToHead(entry);
            value = entry.Value;
            return true;
        }

        public void MoveToHead(LinkedListNode node)
        {
            if (head == null || head == node)
            {
                tail = head;
                return;
            }
        }
    }
}
