using Microsoft.EntityFrameworkCore;
using MovieCollection.Domain.Models.Base;
using MovieCollection.Domain.Repository.Base;
using MovieCollection.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Repositories.Base
{
    public abstract class Repository<TEntity>:IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(AppDbContext dbContext) 
        { 
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async virtual Task<Guid> Create(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveAsync();
            return entity.Id;
        }

        public async virtual Task Delete(Guid id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete == null)
            {
                throw new Exception($"Entity of type {nameof(TEntity)} with id {id} not found");
            }
            _dbSet.Remove(entityToDelete);
            await SaveAsync();
        }

        public async virtual Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async virtual Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
