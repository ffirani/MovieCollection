using Azure;
using MovieCollection.Query.View;
using MovieCollection.Query.View.Base;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MovieCollection.Query.Parser
{
    public class QueryParser<T>:IQueryParser<T> where T : BaseView
    {
        private ParameterExpression _parameter;

        public QueryParser()
        {
        }

        public Expression<Func<T, bool>> Pars(QueryExpression query)
        {
            _parameter = Expression.Parameter(typeof(T), "x");
            Expression exp = VisitFilter(query.Filter);
            return Expression.Lambda<Func<T, bool>>(exp, _parameter);
        }
        private Expression VisitFilters(IEnumerable<QueryFilter> filters)
        {
            if (filters == null || !filters.Any())
                return null;

            Expression combined = null;
            foreach (var filter in filters)
            {
                var filterExpression = VisitFilter(filter);
                if(filterExpression == null) continue;
                if (combined == null)
                {
                    combined = filterExpression;
                }
                else
                {
                    combined = filter.LogicalOperator == LogicalOperator.And
                        ? Expression.AndAlso(combined, filterExpression)
                        : Expression.OrElse(combined, filterExpression);
                }
            }
            return combined;
        }

        private Expression VisitFilter(QueryFilter filter)
        {
            var conditionExpressions = VisitConditions(filter.Conditions,filter.LogicalOperator);
            var nestedFilterExpressions = VisitFilters(filter.Filters);

            if (conditionExpressions != null && nestedFilterExpressions!=null)
            {
                return filter.LogicalOperator == LogicalOperator.And
                ? Expression.AndAlso(conditionExpressions, nestedFilterExpressions)
                : Expression.OrElse(conditionExpressions, nestedFilterExpressions);
            }

            if(nestedFilterExpressions == null)
            {
                return conditionExpressions;
            }
            return nestedFilterExpressions;
        }

        private Expression VisitConditions(IEnumerable<QueryCondition> conditions, LogicalOperator operation)
        {
            if (conditions == null || !conditions.Any())
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
                    combined = operation == LogicalOperator.And
                        ? Expression.AndAlso(combined, conditionExpression)
                        : Expression.OrElse(combined, conditionExpression);
                }
            }
            return combined;
        }

        private Expression VisitCondition(QueryCondition condition)
        {
            var property = typeof(T).GetProperty(condition.PropertyName);
            
            var member = Expression.PropertyOrField(_parameter, condition.PropertyName);
            var constant = Expression.Constant(Convert.ChangeType(condition.Value.ToString(), property.PropertyType));

            switch (condition.ConditionOperator)
            {
                case ConditionOperator.Equal:
                    return Expression.Equal(member, constant);
                case ConditionOperator.NotEqual:
                    return Expression.NotEqual(member, constant);
                case ConditionOperator.GreateThan:
                    return Expression.GreaterThan(member, constant);
                case ConditionOperator.SmallerThan:
                    return Expression.LessThan(member, constant);
                case ConditionOperator.Contain:
                    return CreateExpressionForContain(member,constant);
                default:
                    throw new NotSupportedException($"Condition operator '{condition.ConditionOperator}' is not supported.");
            }
        }

        private Expression CreateExpressionForContain(MemberExpression member, ConstantExpression constant)
        {
            if (member.Type != typeof(string))
            {
                throw new NotSupportedException("Only property of type string can use Contain operator");
            }
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            return Expression.Call(member, containsMethod, constant);
        }

    }
}
