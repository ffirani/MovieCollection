using MediatR;
using MovieCollection.Query.ExpressionType;
using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityQuery<TView>:IRequest<RetrieveMultipleEntityResponse<TView>> where TView : BaseView
    {
        public QueryExpression<TView> Expression { get; set; }
        public int PageIndex { get; set; }
    }
}
