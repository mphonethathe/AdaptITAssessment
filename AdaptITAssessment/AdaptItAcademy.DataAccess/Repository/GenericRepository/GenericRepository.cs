using AdaptItAcademy.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.Services.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AdaptItAcademyContext appDbContext;
        private readonly DbSet<TEntity> entities;

        public GenericRepository(AdaptItAcademyContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.entities = appDbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            var result = await entities.AddAsync(entity);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<TEntity> Delete(int Id)
        {
            var result = await entities.FindAsync(Id);
            if (result != null)
            {
                entities.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int Id)
        {
            return await entities.FindAsync(Id);
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            appDbContext.Set<TEntity>().Update(entity);
            await appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
