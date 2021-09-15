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
            try
            {
                var result = await entities.AddAsync(entity);
                await appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex )
            {
                throw new Exception("Error when trying to save data on db", ex.InnerException);
            }
        }

        public virtual async Task Delete(int Id)
        {
            try
            {
                var result = await entities.FindAsync(Id);
                if (result != null)
                {
                    entities.Remove(result);
                    await appDbContext.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                throw new Exception("Error",ex.InnerException);
            }

        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await entities.ToListAsync();
            }catch(Exception ex)
            {
                throw new Exception("Error", ex.InnerException);
            }

        }

        public virtual async Task<TEntity> GetById(int Id)
        {
            try
            {
                return await entities.FindAsync(Id);
            }catch(Exception ex)
            {
                throw new Exception("Error", ex.InnerException);
            }
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            try
            {

                appDbContext.Set<TEntity>().Update(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }catch(Exception ex)
            {
                throw new Exception("Error", ex.InnerException);
            }
        }
    }
}
