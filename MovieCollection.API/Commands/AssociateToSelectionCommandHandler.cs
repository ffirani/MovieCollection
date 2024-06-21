using MediatR;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Domain.Repository;
using MovieCollection.Infrastructure.Error;

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
            var repository = _context.RepositoryFactory.GetRepository<MovieSelection>() as IMovieSelectionRepository;

            if (repository == null)
            {
                throw new AppException("ERR3004", $"Repository not found for type {typeof(MovieSelection).Name}");
            }

            await repository.AssociateMovieAsync(request.SelectionId, request.MovieId);
            
        }
    }
}
