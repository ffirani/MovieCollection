
using AutoMapper;
using MovieCollection.API.Core.Authentication;
using MovieCollection.Infrastructure.Repositories.Base;

namespace MovieCollection.API.Core
{
    public class ExecutionContext : IExecutionContext
    {
        public Guid UserId { get ; }
        public ILogger Logger { get ; private set ; }

        public IRepositoryFactory RepositoryFactory { get ; private set ; }

        public IMapper Mapper { get; private set; }

        public ExecutionContext(IIdentityService identityService,ILogger logger, IRepositoryFactory repositoryFactory,IMapper mapper) 
        {
            UserId = identityService.GetUserIdentity();
            Logger = logger;
            RepositoryFactory = repositoryFactory;
            Mapper = mapper;

        }
    }
}
