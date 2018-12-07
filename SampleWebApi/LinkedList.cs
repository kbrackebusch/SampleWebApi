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
    }

    public class LinkedList //: CustomCreationConverter
    {
        public Node Head { get; set; }
        public Node LastNode { get; private set; }

        public LinkedList()
        {
        }

        public LinkedList(string spaceSeparatedString)
        {
            var array = spaceSeparatedString.Split(' ');
        }

        public void Add(Node node)
        {
            if(Head==null)
            {
                Head = node;
                LastNode = Head;
            }
            else
            {
                LastNode.NextNode = node;
                LastNode = node;
            }
        }

    }

    
}
