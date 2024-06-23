using MediatR;
using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityQueryHandler<TView> : 
        IRequestHandler<RetrieveMultipleEntityQuery<TView>, RetrieveMultipleEntityResponse<TView>> where TView : BaseView
    {
        public Task<RetrieveMultipleEntityResponse<TView>> Handle(RetrieveMultipleEntityQuery<TView> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
