using System.Collections.Generic;
using System.Threading.Tasks;


namespace AdaptItAcademy.DataAccess.Services.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int Id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int Id);
    }
}
