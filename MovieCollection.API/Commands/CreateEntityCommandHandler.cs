using AutoMapper;
using MediatR;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.API.Mapper;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Domain.Repository.Base;
using System.Reflection;

namespace MovieCollection.API.Commands
{
    public class CreateEntityCommandHandler<T,TEntity> : IRequestHandler<CreateEntityCommand<T>,CreateEntityResponse> where T:class  where TEntity : Entity
    {
        private IExecutionContext _context;
        public CreateEntityCommandHandler(IExecutionContext context) 
        {
            _context = context;
        }

        public async Task<CreateEntityResponse> Handle(CreateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var repository = _context.RepositoryFactory.GetRepository<TEntity>();

            if (repository == null)
            {
                throw new Exception($"Repository not found for type {nameof(TEntity)}");
            }

            var entity = _context.Mapper.Map<T, TEntity>(request.Data);
            var id = await repository.CreateAsync(entity);
            return new CreateEntityResponse(id);
        }
    }
}
