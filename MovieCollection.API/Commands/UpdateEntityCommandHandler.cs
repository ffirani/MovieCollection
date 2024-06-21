using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Infrastructure.Error;
using System.Reflection;

namespace MovieCollection.API.Commands
{
    public class UpdateEntityCommandHandler<T,TEntity> : IRequestHandler<UpdateEntityCommand<T>> where T : class where TEntity : Entity
    {
        private IExecutionContext _context;

        public UpdateEntityCommandHandler(IExecutionContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var repository = _context.RepositoryFactory.GetRepository<TEntity>();

            if (repository == null)
            {
                throw new AppException("ERR3002",$"Repository not found for type {typeof(TEntity).Name}");
            }

            var entity = _context.Mapper.Map<T, TEntity>(request.Data);
            await repository.UpdateAsync(entity);
        }
    }
}
