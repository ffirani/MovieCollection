using MovieCollection.Query.View;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MovieCollection.Query.Expression
{
    public class QueryVisitor<T>
    {
        private ParameterExpression _parameter;
        private QueryExpression<MovieView> query;

        public QueryVisitor(QueryExpression<MovieView> query)
        {
            this.query = query;
        }

        public Expression<Func<T, bool>> Visit(QueryExpression<T> query)
        {
            _parameter = Expression.Parameter(typeof(T), "x");
            Expression exp = VisitFilters(query.Filters);
            return Expression.Lambda<Func<T, bool>>(exp, _parameter);
        }

        private Expression VisitFilters(IEnumerable<QueryFilter<T>> filters)
        {
            if (filters == null || filters.Count == 0)
                return Expression.Constant(true);

            Expression combined = null;
            foreach (var filter in filters)
            {
                var filterExpression = VisitFilter(filter);
                if (combined == null)
                {
                    combined = filterExpression;
                }
                else
                {
                    combined = filter.Operation == OperatorType.And
                        ? Expression.AndAlso(combined, filterExpression)
                        : Expression.OrElse(combined, filterExpression);
                }
            }
            return combined;
        }

        private Expression VisitFilter(QueryFilter<T> filter)
        {
            var conditionExpressions = VisitConditions(filter.Conditions);
            var nestedFilterExpressions = VisitFilters(filter.Filters);

            if (conditionExpressions == null)
                return nestedFilterExpressions;

            return filter.Operation == OperatorType.And
                ? Expression.AndAlso(conditionExpressions, nestedFilterExpressions)
                : Expression.OrElse(conditionExpressions, nestedFilterExpressions);
        }

        private Expression VisitConditions(IEnumerable<QueryCondition<T>> conditions)
        {
            if (conditions == null || conditions.Count == 0)
                return Expression.Constant(true);

            Expression combined = null;
            foreach (var condition in conditions)
            {
                var conditionExpression = VisitCondition(condition);
                if (combined == null)
                {
                    combined = conditionExpression;
                }
                else
                {
                    combined = condition.LogicalOperator == OperatorType.And
                        ? Expression.AndAlso(combined, conditionExpression)
                        : Expression.OrElse(combined, conditionExpression);
                }
            }
            return combined;
        }

        private Expression VisitCondition(QueryCondition<T> condition)
        {
            var member = Expression.PropertyOrField(_parameter, condition.PropertyName);
            var constant = Expression.Constant(condition.Value);

            switch (condition.Operator)
            {
                case ConditionOperator.Equal:
                    return Expression.Equal(member, constant);
                case ConditionOperator.NotEqual:
                    return Expression.NotEqual(member, constant);
                default:
                    throw new NotSupportedException($"Condition operator '{condition.Operator}' is not supported.");
            }
        }
    }
}
