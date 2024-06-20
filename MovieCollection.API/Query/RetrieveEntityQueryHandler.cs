using MediatR;
using MovieCollection.API.Core;
using MovieCollection.Domain.Models.Base;

namespace MovieCollection.API.Query
{
    public class RetrieveEntityQueryHandler<T, TEntity> : IRequestHandler<RetrieveEntityQuery<T>, RetrieveEntityResponse<T>> where T : class where TEntity : Entity
    {
        private readonly IExecutionContext _executionContext;

        public RetrieveEntityQueryHandler(IExecutionContext executionContext) 
        {
            _executionContext = executionContext;
        }
        public async Task<RetrieveEntityResponse<T>> Handle(RetrieveEntityQuery<T> request, CancellationToken cancellationToken)
        {
            var repository = _executionContext.RepositoryFactory.GetRepository<TEntity>();
            var entity = await repository.GetById(request.Id);
            var dto = _executionContext.Mapper.Map<TEntity,T>(entity);

            return new RetrieveEntityResponse<T> { Entity = dto };
        }
    }
}
