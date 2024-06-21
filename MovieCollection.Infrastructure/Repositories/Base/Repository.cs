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

        public async virtual Task<Guid> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveAsync();
            return entity.Id;
        }

        public async virtual Task DeleteAsync(Guid id)
        {
            var entityToDelete = (TEntity)Activator.CreateInstance(typeof(TEntity));
            entityToDelete.Id = id;
            var attachedEntity = _dbSet.Attach(entityToDelete);
            attachedEntity.State = EntityState.Deleted;
            await SaveAsync();
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);

            foreach (var property in entity.UpdatedProperties)
            {
                _dbContext.Entry(entity).Property(property.Key).IsModified = true;
            }
            await this.SaveAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected async virtual Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
