using MovieCollection.API.Query.Expression;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityQuery<T>
    {
        public QueryExpression<T> Expression { get; set; }
        public int PageIndex { get; set; }
    }
}
