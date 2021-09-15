using AdaptItAcademy.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
   public interface ITrainingLogic
    {
        Task<Training> CreateTraining(Training training);
        Task<Training> GetTraining(int id);
        Task DeleteTraining(int id);
        Task<Training> UpdateTraining(Training training);
        Task<IEnumerable<Training>> GetAllTraining();
        IEnumerable<Training> GetCourseUpComingTraining();
    }
}
