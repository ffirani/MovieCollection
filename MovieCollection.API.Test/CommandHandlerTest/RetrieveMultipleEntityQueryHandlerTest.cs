using MovieCollection.API.Query;
using MovieCollection.Query.Db.Base;
using MovieCollection.Query.Parser;
using MovieCollection.Query.View;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.API.Test.CommandHandlerTest
{
    public class RetrieveMultipleEntityQueryHandlerTest
    {
        public async Task Handle_query_movie_with_title_imdbrate_return_one_movie()
        {
            //Arange
            var queriable = Substitute.For<IQueryable>();
            var dbContext = Substitute.For<IReadOnlyDbContext>();
           
            dbContext.Query<MovieView>().Returns(queriable);
            IQueryParser<MovieView> parser = new QueryParser<MovieView>();
            var handler = new RetrieveMultipleEntityQueryHandler<MovieView>(dbContext,parser);

            var request = new RetrieveMultipleEntityQuery<MovieView>
            {
                Expression = new QueryExpression
                {
                    Filter = new QueryFilter
                    {
                        LogicalOperator = LogicalOperator.And,
                        Conditions = new[]
                        {
                            new QueryCondition(nameof(MovieView.CreatedOn),ConditionOperator.SmallerThan, new DateTime(2023,10,1))
                        }
                    }
                }
            };
            //Action
            var response = await handler.Handle(request,CancellationToken.None);
            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Entities);
        }
    }
}
