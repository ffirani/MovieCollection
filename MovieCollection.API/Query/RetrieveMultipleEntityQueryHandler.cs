using MediatR;

namespace MovieCollection.API.Query
{
    public class RetrieveMultipleEntityQueryHandler<TView> : 
        IRequestHandler<RetrieveMultipleEntityQuery<TView>, RetrieveMultipleEntityResponse<TView>> where TView : class
    {
        public Task<RetrieveMultipleEntityResponse<TView>> Handle(RetrieveMultipleEntityQuery<TView> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
