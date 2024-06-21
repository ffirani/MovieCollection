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
        public Task<Guid> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(Guid id);
        public Task<T> GetByIdAsync(Guid id);
    }
}
