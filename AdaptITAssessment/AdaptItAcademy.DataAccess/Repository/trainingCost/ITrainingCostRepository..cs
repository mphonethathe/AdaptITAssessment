using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.Services.traningCost
{
    public interface ITrainingCostRepository : IGenericRepository<TrainingCourseTotalAmount>
    {

        Task<TrainingCourseTotalAmount> GetByTrainingID(int id);
    }
}
