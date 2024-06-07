using MovieCollection.Domain.Models.Base;
using MovieCollection.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Repositories.Base
{
    public interface IRepositoryFactory
    {
        public IRepository<T> GetRepository<T>() where T : Entity;
        public object GetRepository(Type entityType);
    }
}
