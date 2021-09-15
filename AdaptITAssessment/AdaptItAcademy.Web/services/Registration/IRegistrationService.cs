using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Course
{
    public interface IRegistrationService
    {
        Task<string> Create(TrainingRegistration registration);
        Task<List<TrainingRegistration>> GetAll();
        Task<TrainingRegistration> GetByID(int id);
        Task<TrainingRegistration> Update(TrainingRegistration registration);
        Task Delete(int id);
   
    }
}
