using MediatR;

namespace MovieCollection.API.Commands
{
    public class AssociateToSelectionCommand:IRequest
    {
        public Guid MovieId { get; set; }
        public Guid SelectionId { get; set; }
    }
}
