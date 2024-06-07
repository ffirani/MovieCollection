using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Repository.Base
{
    public interface IRepository<T>
    {
        public T GetById(Guid id);
        public void Update(T entity);
        public void Delete(Guid id);
        public Guid Create(T entity);
    }
}
