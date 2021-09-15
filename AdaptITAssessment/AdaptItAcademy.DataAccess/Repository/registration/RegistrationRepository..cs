using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptItAcademy.DataAccess.Services.registration
{
    public class RegistrationRepository : GenericRepository<TrainingRegistration>, IRegistrationRepository
    {
        private readonly AdaptItAcademyContext _appDbContext;

        public RegistrationRepository(AdaptItAcademyContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TrainingRegistration> GetDelegateTraining(int id)
        {
            return _appDbContext.TrainingRegistrations
                .Include(t => t.Delegate)
                .Include(t => t.Training)
                .Include(t => t.Training.Course)
                .Where(t => t.DelegateId == id);
        }

        public IEnumerable<TrainingRegistration> GetRegistratioByTrainingID(int id)
        {
            return _appDbContext.TrainingRegistrations
                .Include(t => t.Training)
                .Where(t => t.TrainingId == id);
        }

    }
}
