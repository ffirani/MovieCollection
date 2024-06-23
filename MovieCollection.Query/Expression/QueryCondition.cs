namespace MovieCollection.Query.Expression
{
    public enum ConditionOperator
    {
        Equal=1,
        NotEqual=2,
        GreateThan=3,
        SmallerThan=4
    }
    public class QueryCondition<T>
    {
        public ConditionOperator Operator { get; set; }
        public object Value1 { get; set; }
        public object Value2 { get; set; }


        public QueryCondition(ConditionOperator @operator, object value1)
        {
            Operator = @operator;
            Value1 = value1;
        }
        public QueryCondition(ConditionOperator @operator, object value1, object value2)
        {
            Operator = @operator;
            Value1 = value1;
            Value2 = value2;
        }
    }
}
