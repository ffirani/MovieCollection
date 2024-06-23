using MovieCollection.Query.Parser;
using MovieCollection.Query.View;

namespace MovieCollection.Query.Test
{
    public class QueryExpressionParserTest
    {
        [Fact]
        public void Visi_query_retrieve_view_with_specific_id_valid_expression()
        {
            //Arrange
            var query = new Parser.QueryExpression()
            {
                Filter = new QueryFilter(LogicalOperator.And)
                {
                    Conditions = new[]
                    {
                        new QueryCondition(nameof(MovieView.Title),ConditionOperator.Contain,"Test"),
                        new QueryCondition(nameof(MovieView.ImdbRate),ConditionOperator.GreateThan,6m)
                    }
                }
            };
            var visitor = new QueryParser<MovieView>();

            //Action
            var expression = visitor.Pars(query);

            //Assert
            //Assert.Equal(".Lambda #Lambda1<System.Func`2[MovieCollection.Query.View.MovieView,System.Boolean]>(MovieCollection.Query.View.MovieView $x)\r\n{\r\n    .Call ($x.Title).Contains(\"Test\") && $x.ImdbRate > 6M\r\n}",
            //    expression.DebugView);
        }
    }
}