using MediatR;
using MovieCollection.Query.Parser;
using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityQuery<TView>:IRequest<RetrieveMultipleEntityResponse<TView>> where TView : BaseView
    {
        public QueryExpression Expression { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
