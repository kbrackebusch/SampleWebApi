namespace SampleWebApi
{
    public interface ICache
    {
        void CacheQuery(string listA, string listB, SimpleLinkedList mergedList);
        bool TryGetValue(string listA, string listB, out SimpleLinkedList mergedList);
    }
}