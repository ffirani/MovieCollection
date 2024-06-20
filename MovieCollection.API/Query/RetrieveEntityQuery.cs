using MediatR;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityQuery<T>:IRequest<RetrieveEntityResponse<T>>
    {
        public Guid Id { get; set; }
    }
}
