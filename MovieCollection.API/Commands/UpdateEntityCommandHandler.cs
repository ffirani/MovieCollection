using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Commands.Dto;
using MovieCollection.API.Core;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Domain.Repository.Base;
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

            if (!await HasUpdatePermission(entity.Id, repository))
            {
                throw new AccessPermissionViolationException("ERR8001", $"User with id {_context.UserId} id not the owner of record with id {entity.Id}");
            }
            await repository.UpdateAsync(entity);
        }

        private async Task<bool> HasUpdatePermission(Guid id, IRepository<TEntity> repository)
        {
            if(typeof(T) == typeof(MovieDto) ||
                typeof(T) == typeof(MovieSelectionDto))
            {
                return await repository.IsRecordOwnerAsync(id,_context.UserId);
            }
            return true;
        }
    }
}
