using AutoMapper;
using MovieCollection.Infrastructure.Repositories.Base;

namespace MovieCollection.API.Core
{
    public interface IExecutionContext
    {
        public Guid UserId { get;  }
        public ILogger Logger { get;  }
        public IMapper Mapper { get; }
        public IRepositoryFactory RepositoryFactory { get;  }

    }
}
