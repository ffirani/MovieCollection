using MovieCollection.Domain.Models.Base;
using MovieCollection.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Repositories.Base
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IRepository<T> GetRepository<T>() where T : Entity
        {
            return (IRepository<T>)_serviceProvider.GetService(typeof(IRepository<T>));
        }

        public object GetRepository(Type entityType)
        {
            return _serviceProvider.GetService(typeof(IRepository<>).MakeGenericType(entityType));
        }
    }
}
