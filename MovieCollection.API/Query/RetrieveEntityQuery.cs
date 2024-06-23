using MediatR;
using MovieCollection.Query.View.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityQuery<TView>:IRequest<RetrieveEntityResponse<TView>> where TView : BaseView
    {
        public Guid Id { get; set; }
    }
}
