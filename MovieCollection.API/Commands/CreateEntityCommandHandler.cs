using AutoMapper;
using MediatR;
using MovieCollection.API.Commands.Base;
using MovieCollection.API.Core;
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
        public Task<CreateEntityResponse> Handle(ICreateEntityCommand request, CancellationToken cancellationToken)
        {
            var type = request.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CreateEntityCommand<>))
            {
                Type[] genericArguments = type.GetGenericArguments();
                var repository = _context.RepositoryFactory.GetRepository(genericArguments[0]);
                var repositoryType = repository.GetType();
                var methodInfo = repositoryType.GetMethod("Create");
                if (methodInfo != null)
                {
                    _context.Mapper.Map(request.Data, genericArguments[0])
                    var id = (Guid)methodInfo.Invoke(repository, new object[] { new Movie() });
                    return Task.FromResult(new CreateEntityResponse(id));
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
