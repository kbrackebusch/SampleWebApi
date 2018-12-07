using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LinkedListController : ControllerBase
    {
        private ICache cache;

        public LinkedListController(ICache cache)
        {
            this.cache = cache;
        }

        /// <summary>
        /// Note normally a web api has a deserialized object as a parameter to a method.  Since we are going to use a string representation of a linked list as a key
        /// then it is more performant to deal with the string before it is deserialized.  (Also, I did not want to take write a custom serializer)
        /// </summary>
        /// <param name="listA"></param>
        /// <param name="ListB"></param>
        /// <returns>a string since I don't have a custom serializer for this demo</returns>
        [HttpGet]
        public string Merge(string listA, string listB)
        {
            SimpleLinkedList result;

            if (cache.TryGetValue(listA, listB, out result))
            {
                return result.ToString();
            }

            result = MergeList(new SimpleLinkedList(listA), new SimpleLinkedList(listB));

            cache.CacheQuery(listA, listB, result);

            return result.ToString();
        }

        /// <summary>
        /// Merge and dedup
        /// </summary>
        /// <param name="listA"></param>
        /// <param name="listB"></param>
        /// <returns></returns>
        private SimpleLinkedList MergeList(SimpleLinkedList listA, SimpleLinkedList listB)
        {
            var result = new SimpleLinkedList();

            var listANode = listA.Head;
            var listBNode = listB.Head;

            Node temp;

            while(listANode !=null || listBNode != null)
            {
                if(listANode < listBNode)
                {
                    temp = listANode.NextNode;
                    result.Add(listANode);
                    listANode = temp;
                }
                else
                {
                    temp = listBNode.NextNode;
                    result.Add(listBNode);
                    listBNode = temp;
                }

                while (listANode != null && listANode.Value == result.LastNode.Value)
                {
                    listANode = listANode.NextNode;
                }
                while (listBNode != null && listBNode.Value == result.LastNode.Value)
                {
                    listBNode = listBNode.NextNode;
                }
            }

            return result;
        }


    }
}