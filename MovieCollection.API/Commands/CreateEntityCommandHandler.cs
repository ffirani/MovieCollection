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
    public class CreateEntityCommandHandler : IRequestHandler<ICreateEntityCommand,CreateEntityResponse>
    {
        private IExecutionContext _context;
        public CreateEntityCommandHandler(IExecutionContext context) 
        {
            _context = context;
        }
        public async Task<CreateEntityResponse> Handle(ICreateEntityCommand request, CancellationToken cancellationToken)
        {
            var type = request.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CreateEntityCommand<>))
            {
                Type[] genericArguments = type.GetGenericArguments();
                var domainEquivalenAttribute = genericArguments[0].GetCustomAttribute<DomainEquivalentAttribute>();
                if (domainEquivalenAttribute == null)
                {
                    throw new Exception("Could not map create request to domain model");
                }

                var repository = _context.RepositoryFactory.GetRepository(domainEquivalenAttribute.DomainModelType);

                if (repository == null)
                {
                    throw new Exception($"Repository not found for type {domainEquivalenAttribute.DomainModelType}");
                }

                var repositoryType = repository.GetType();
                var methodInfo = repositoryType.GetMethod("Create");
                if (methodInfo != null)
                {
                    
                    var dataProperty = request.GetType().GetProperty("Data");
                    if (dataProperty == null) 
                    {
                        throw new Exception("Data property not found");
                    }
                    var dataPropertyValue = Convert.ChangeType(dataProperty.GetValue(request), genericArguments[0]);
                    var entity = _context.Mapper.Map(dataPropertyValue, genericArguments[0], domainEquivalenAttribute.DomainModelType);
                    var task = methodInfo.Invoke(repository, new object[] { entity }) as Task<Guid>;
                    var id = await task;
                    return await Task.FromResult(new CreateEntityResponse(id));
                }
                else
                {
                    throw new NotImplementedException("Create method not implemented in repository");
                }
            }
            else
            {
                throw new ArgumentException("Invalid request type");
            }
            
        }
    }
}
