using MediatR;
using MovieCollection.API.Query.Expression;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityQuery<TView>:IRequest<RetrieveMultipleEntityResponse<TView>>
    {
        public QueryExpression<TView> Expression { get; set; }
        public int PageIndex { get; set; }
    }
}
