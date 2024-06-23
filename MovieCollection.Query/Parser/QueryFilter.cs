using MovieCollection.Query.View.Base;

namespace MovieCollection.Query.Parser
{
    public enum LogicalOperator
    {
        And=1,
        Or=2
    }
    public class QueryFilter 
    {
        public LogicalOperator LogicalOperator { get; set; }
        public IEnumerable<QueryCondition>? Conditions { get; set; }
        public IEnumerable<QueryFilter>? Filters { get; set; }

        public QueryFilter(LogicalOperator logicalOperator=LogicalOperator.And)
        {
            LogicalOperator = logicalOperator;
        }
    }
}
