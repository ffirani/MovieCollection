using MovieCollection.Query.Expression;
using MovieCollection.Query.View;

namespace MovieCollection.Query.Test
{
    public class QueryVisitorTest
    {
        [Fact]
        public void Visi_query_retrieve_view_with_specific_id_valid_expression()
        {
            //Arrange
            var query = new QueryExpression<MovieView>()
            {
                Filter = new QueryFilter<MovieView>
                {
                    Conditions = new[]
                    {
                        new QueryCondition<MovieView>(
                            ConditionOperator.Equal,
                             new Guid("D929F6CC-9162-4260-B5F8-1F21EB45D091"))
                    }
                }
            };
            var visitor = new QueryVisitor<MovieView>(query);

            //Action
            var expression = visitor.Visit(query);

            //Assert

        }
    }
}