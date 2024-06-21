using MediatR;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Infrastructure.Error;
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
                throw new AppException("ERR3003", $"Repository not found for type {typeof(TEntity).Name}");
            }

            await repository.DeleteAsync(request.Id);
        }
    }
}
