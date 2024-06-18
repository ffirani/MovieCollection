using MediatR;

namespace MovieCollection.API.Commands
{
    public class AssociateToSelectionCommandHandler : IRequestHandler<AssociateToSelectioCommand>
    {
        public Task Handle(AssociateToSelectioCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
