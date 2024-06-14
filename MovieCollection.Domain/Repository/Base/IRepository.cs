using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Repository.Base
{
    public interface IRepository<T> where T : Entity
    {
        public Task<Guid> Create(T entity);
        public Task Update(T entity);
        public Task Delete(Guid id);
        public Task<T> GetById(Guid id);
    }
}
