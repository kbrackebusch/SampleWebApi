using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi
{
   

    public class SimpleLinkedList 
    {
        public Node Head { get; set; }
        public Node LastNode { get; private set; }

        public SimpleLinkedList()
        {
        }

        public SimpleLinkedList(string spaceSeparatedString)
        {
            if(string.IsNullOrEmpty(spaceSeparatedString))
            {
                return;
            }

            var array = spaceSeparatedString.Split(' ');
            foreach(var item in array)
            {
                int value;
                if( ! int.TryParse(item, out value))
                {
                    throw new ArgumentException($"Could not parse {item} as an integer", nameof(spaceSeparatedString));
                }
                this.Add(new Node() { Value = value });
            }
        }

        public void Add(Node node)
        {
            node.NextNode = null;
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

        public override string ToString()
        {
            var result = new StringBuilder();

            var node = Head;
            while(node!=null)
            {
                result.Append(node.Value);
                result.Append(' ');
                node = node.NextNode;
            }

            // handle null head problem
            if(result.Length>1)
            {
                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }

    }

    
}
