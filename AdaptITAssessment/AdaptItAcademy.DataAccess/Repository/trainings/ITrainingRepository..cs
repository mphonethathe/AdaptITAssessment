using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.Services.trainings
{
    public interface ITrainingRepository : IGenericRepository<Training>
    {
        IEnumerable<Training> GetUpComungCourse();
    }
      
}
