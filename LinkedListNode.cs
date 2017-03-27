using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class LinkedListNode
    {
        public int Val { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode()
        {

        }

        public LinkedListNode(int val)
        {
            Val = val;
        }

        public override string ToString()
        {
            string result = Val.ToString();
            return (this.Next == null) ?  result : result + ", " + this.Next.ToString();
        }

        public static LinkedListNode GenerateList(List<int> values)
        {
            if(values.Count > 0)
            {
                LinkedListNode current = new LinkedListNode();
                current.Val = values[0];
                values.RemoveAt(0);
                current.Next = GenerateList(values);
                return current;
            }
            else
            {
                return null;
            }
        }

        public static int GetLength(LinkedListNode n)
        {
            int count = 1;
            if(n.Next != null)
            {
                count += GetLength(n.Next);
            }

            return count;
        }

        /// <summary>
        /// For 2.5
        /// </summary>
        /// <param name="n"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static LinkedListNode Pad(LinkedListNode n, int length)
        {
            LinkedListNode pad = new LinkedListNode(0);
            if (length > 0)
            {
                length--;
                pad.Next = Pad(n, length);
            }
            else
            {
                return n;
            }
            return pad;
        }
    }
}
