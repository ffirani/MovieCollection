using MediatR;

namespace MovieCollection.API.Commands
{
    public class DisassociateFromSelectionCommandHandler : IRequestHandler<DisassociateFromSelectionCommand>
    {
        public Task Handle(DisassociateFromSelectionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
