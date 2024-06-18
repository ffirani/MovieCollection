using MediatR;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityQuery<T>:IRequest
    {
        public Guid Id { get; set; }
    }
}
