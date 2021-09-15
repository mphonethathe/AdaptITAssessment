using AdaptItAcademy.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public interface ITrainingRegistrationLogic
    {
        Task<TrainingRegistration> CreateTrainingRegistration(TrainingRegistration trainingRegistration);
        Task<TrainingRegistration> GetTrainingRegistration(int id);
        Task DeleteTrainingRegistration(int id);
        Task<TrainingRegistration> UpdateTrainingRegistration(TrainingRegistration trainingRegistration);
        Task<IEnumerable<TrainingRegistration>> GetAllTrainingRegistration();

        IEnumerable<TrainingRegistration> GetAllDeleteRegistration(int id);
    }
}
