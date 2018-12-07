using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi
{
    public class Cache
    {
        private ConcurrentDictionary<(string a, string b), LinkedList> cache = new ConcurrentDictionary<(string a, string b), LinkedList>();

        public bool TryGetValue(string listA, string listB, out LinkedList mergedList)
        {
            return cache.TryGetValue((listA, listB), out mergedList);
        }

        public void CacheQuery(string listA, string listB, LinkedList mergedList)
        {
            // ok for any thread to succed here.  Since both should have the same value
            cache[(listA, listB)] = mergedList;
        }
    }
}
