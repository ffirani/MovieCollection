using MovieCollection.Query.View.Base;

namespace MovieCollection.Query.Parser
{
    public enum ConditionOperator
    {
        Equal=1,
        NotEqual=2,
        GreateThan=3,
        SmallerThan=4,
        Contain = 5
    }
    public class QueryCondition 
    {
        public string PropertyName { get; internal set; }
        public ConditionOperator ConditionOperator { get; set; }
        public object Value { get; set; }

        public QueryCondition(string propertyName , ConditionOperator conditionOperator, object value)
        {
            PropertyName = propertyName;
            ConditionOperator = conditionOperator;
            Value = value;
        }
    }
}
