using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Training
{
   public interface ITrainingService
    {
        Task<string> Create(Trainings training);
        Task<List<Trainings>> GetAll();
        Task<Trainings> GetByID(int id);
        Task<string> Update(Trainings training);
        Task<string> Delete(int id);
        Task<List<Trainings>> GetUpComingTraining();
        Task<List<TrainingRegistration>> GetDelegateOwnTraining(int id);
    }
}
