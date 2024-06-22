using MediatR;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityQuery<TView>:IRequest<RetrieveEntityResponse<TView>>
    {
        public Guid Id { get; set; }
    }
}
