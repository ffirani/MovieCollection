using MediatR;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Repository;

namespace MovieCollection.API.Commands
{
    public class AssociateToSelectionCommandHandler : IRequestHandler<AssociateToSelectionCommand>
    {
        private IExecutionContext _context;
        public AssociateToSelectionCommandHandler(IExecutionContext context)
        {
            _context = context;
        }
        public async Task Handle(AssociateToSelectionCommand request, CancellationToken cancellationToken)
        {
            var repository = (IMovieSelectionRepository)_context.RepositoryFactory.GetRepository<MovieSelection>();

            await repository.AssociateMovieAsync(request.SelectionId, request.MovieId);
            
        }
    }
}
