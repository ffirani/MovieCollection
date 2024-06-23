namespace MovieCollection.Query.Expression
{
    public class QueryFilter<T>
    {
        public IEnumerable<QueryCondition<T>> Conditions { get; set; }
        public IEnumerable<QueryFilter<T>> Filters { get; set; }
    }
}
