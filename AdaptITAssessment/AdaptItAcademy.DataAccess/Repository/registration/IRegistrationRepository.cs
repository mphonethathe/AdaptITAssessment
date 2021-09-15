using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.DataAccess.Services.registration
{
    public  interface IRegistrationRepository : IGenericRepository<TrainingRegistration>
    {
        IEnumerable<TrainingRegistration> GetDelegateTraining(int id);

        IEnumerable<TrainingRegistration> GetRegistratioByTrainingID(int id);
    }
}
