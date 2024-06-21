using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;

namespace MovieCollection.API.Commands
{
    public class DisassociateFromSelectionCommandHandler : IRequestHandler<DisassociateFromSelectionCommand>
    {
        private IExecutionContext _context;
        public DisassociateFromSelectionCommandHandler(IExecutionContext context)
        {
            _context = context;
        }
        public async Task Handle(DisassociateFromSelectionCommand request, CancellationToken cancellationToken)
        {
            var repository = (IMovieSelectionRepository)_context.RepositoryFactory.GetRepository<MovieSelection>();

            await repository.DisassociateMovieAsync(request.SelectionId, request.MovieId);
        }
    }
}
