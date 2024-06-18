using MediatR;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityQueryHandler<T> : IRequestHandler<RetrieveEntityQuery<T>>
    {
        Task IRequestHandler<RetrieveEntityQuery<T>>.Handle(RetrieveEntityQuery<T> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
