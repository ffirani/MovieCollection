using MediatR;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models.Base;
using System.Reflection;

namespace MovieCollection.API.Commands
{
    public class DeleteEntityCommandHandler<T,TEntity> : IRequestHandler<DeleteEntityCommand<T>> where T : class where TEntity : Entity
    {
        private IExecutionContext _context;

        public DeleteEntityCommandHandler(IExecutionContext context) 
        {  
            _context = context;
        }
        public async Task Handle(DeleteEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var repository = _context.RepositoryFactory.GetRepository<TEntity>();

            if (repository == null)
            {
                throw new Exception($"Repository not found for type {nameof(TEntity)}");
            }

            await repository.DeleteAsync(request.Id);
        }
    }
}
