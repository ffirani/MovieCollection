using MediatR;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.API.Mapper;
using System.Reflection;

namespace MovieCollection.API.Commands
{
    public class DeleteEntityCommandHandler : IRequestHandler<IDeleteEntityCommand>
    {
        private IExecutionContext _context;

        public DeleteEntityCommandHandler(IExecutionContext context) 
        {  
            _context = context;
        }
        public Task Handle(IDeleteEntityCommand request, CancellationToken cancellationToken)
        {
            var type = request.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DeleteEntityCommand<>))
            {
                Type[] genericArguments = type.GetGenericArguments();
                var domainEquivalenAttribute = genericArguments[0].GetCustomAttribute<DomainEquivalentAttribute>();
                if (domainEquivalenAttribute == null)
                {
                    throw new Exception("Could not map delete request to domain model");
                }

                var repository = _context.RepositoryFactory.GetRepository(domainEquivalenAttribute.DomainModelType);

                if (repository == null)
                {
                    throw new Exception($"Repository not found for type {domainEquivalenAttribute.DomainModelType}");
                }

                var repositoryType = repository.GetType();
                var methodInfo = repositoryType.GetMethod("Delete");
                if (methodInfo != null)
                {
                    var idProperty = request.GetType().GetProperty("Id");
                    if (idProperty == null)
                    {
                        throw new Exception("Id property not found");
                    }
                    var idPropertyValue = Convert.ChangeType(idProperty.GetValue(request), typeof(Guid));
                    if(idPropertyValue == null || (Guid)idPropertyValue == Guid.Empty)
                    {
                        throw new Exception("Invalid entity id value");
                    }
                    methodInfo.Invoke(repository, new object[] { idPropertyValue });
                    return Task.CompletedTask;
                }
                else
                {
                    throw new NotImplementedException("Delete method not implemented in repository");
                }
            }
            else
            {
                throw new ArgumentException("Invalid request type");
            }
        }
    }
}
