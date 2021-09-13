using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.DataAccess.Services.trainings
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        private readonly AdaptItAcademyContext appDbContext;

        public TrainingRepository(AdaptItAcademyContext appDbContext)
            : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
