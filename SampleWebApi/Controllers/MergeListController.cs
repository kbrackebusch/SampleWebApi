using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MergeListController : ControllerBase
    {
        private Cache cache;

        public MergeListController(Cache cache)
        {
        }

        /// <summary>
        /// Note normally a web api has a deserialized object as a parameter to a method.  Since we are going to use a string representation of a linked list as a key
        /// then it is more performant to deal with the string before it is deserialized.  (Also, I did not want to take write a custom serializer)
        /// </summary>
        /// <param name="listA"></param>
        /// <param name="ListB"></param>
        /// <returns></returns>
        public string MergeList(string listA, string ListB)
        {
            return "";
        }


    }
}