using MediatR;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
using MovieCollection.API.Mapper;
using System.Reflection;

namespace MovieCollection.API.Commands
{
    public class UpdateEntityCommandHandler : IRequestHandler<IUpdateEntityCommand>
    {
        private IExecutionContext _context;

        public UpdateEntityCommandHandler(IExecutionContext context)
        {
            _context = context;
        }

        public async Task Handle(IUpdateEntityCommand request, CancellationToken cancellationToken)
        {
            var type = request.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(UpdateEntityCommand<>))
            {
                Type[] genericArguments = type.GetGenericArguments();
                var domainEquivalenAttribute = genericArguments[0].GetCustomAttribute<DomainEquivalentAttribute>();
                if (domainEquivalenAttribute == null)
                {
                    throw new Exception("Could not map update  request to domain model");
                }

                var repository = _context.RepositoryFactory.GetRepository(domainEquivalenAttribute.DomainModelType);

                if (repository == null)
                {
                    throw new Exception($"Repository not found for type {domainEquivalenAttribute.DomainModelType}");
                }

                var repositoryType = repository.GetType();
                var methodInfo = repositoryType.GetMethod("Update");
                if (methodInfo != null)
                {

                    var dataProperty = request.GetType().GetProperty("Data");
                    if (dataProperty == null)
                    {
                        throw new Exception("Data property not found");
                    }
                    var dataPropertyValue = Convert.ChangeType(dataProperty.GetValue(request), genericArguments[0]);
                    var entity = _context.Mapper.Map(dataPropertyValue, genericArguments[0], domainEquivalenAttribute.DomainModelType);
                    methodInfo.Invoke(repository, new object[] { entity });
                    return;
                }
                else
                {
                    throw new NotImplementedException("Update method not implemented in repository");
                }
            }
            else
            {
                throw new ArgumentException("Invalid request type");
            }
        }
    }
}
