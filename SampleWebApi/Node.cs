using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }

        public static bool operator <(Node a, Node b)
        {
            // null is always greater in our use case
            if(a==null)
            {
                return false;
            }
            // if a is not null and b is null, a is less than b for our use case
            if (b==null)
            {
                return true;
            }
            return a.Value < b.Value;
        }

        public static bool operator >(Node a, Node b)
        {
            // null on left or right makes no sense in our use case
            if (a == null || b==null)
            {
                return false;
            }

            return a.Value < b.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
