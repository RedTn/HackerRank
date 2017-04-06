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
            public TypeKey Key { get; set; }
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

        public bool TryGetValue(TypeKey key, out TypeValue val)
        {
            val = default(TypeValue);
            LinkedListNode entry;
            if (!map.TryGetValue(key, out entry)) return false;
            MoveToHead(entry);
            val = entry.Value;
            return true;
        }

        public void Set(TypeKey key, TypeValue val)
        {
            LinkedListNode node = new LinkedListNode();
            if (map.TryGetValue(key, out node))
            {
                MoveToHead(node);
                return;
            }
            node = new LinkedListNode();
            if (map.Count() >= Capacity)
            {
                map.Remove(tail.Key);
                LinkedListNode previous = tail.Previous;
                tail = previous;
                previous.Next = null;
            }
            node.Value = val;
            node.Key = key;
            MoveToHead(node);
            map.Add(key, node);
        }

        public void MoveToHead(LinkedListNode node)
        {
            if (head == null)
            {
                head = tail = node;
                return;
            }
            if (head == node)
            {
                return;
            }

            LinkedListNode prev = node.Previous;
            LinkedListNode next = node.Next;


            if (prev != null)
            {
                if (next == null)
                {
                    prev.Next = null;
                    tail = prev;
                }
                else
                {
                    prev.Next = next;
                    next.Previous = prev;
                }
            }

            node.Next = head;
            node.Next.Previous = node;
            head = node;
            head.Previous = null;
        }

        public void Debug()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Hash output:");
            foreach (var m in map)
            {
                sb.AppendFormat("Key: {0}, Value: {1}", m.Key.ToString(), m.Value.Value.ToString());
                sb.AppendLine();
            }
            sb.AppendLine("Queue output:");
            LinkedListNode node = head;
            while (node != null)
            {
                sb.AppendFormat("Node: {0}", node.Value);
                sb.AppendLine();
                node = node.Next;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
