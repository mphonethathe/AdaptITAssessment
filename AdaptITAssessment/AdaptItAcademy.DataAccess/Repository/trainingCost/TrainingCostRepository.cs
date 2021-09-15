using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.Services.traningCost
{
    public class TrainingCostRepository : GenericRepository<TrainingCourseTotalAmount>, ITrainingCostRepository
    {
        private readonly AdaptItAcademyContext appDbContext;

        public TrainingCostRepository(AdaptItAcademyContext appDbContext)
            : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TrainingCourseTotalAmount> GetByTrainingID(int id)
        {
            return await appDbContext.TrainingCourseTotalAmount.AsNoTracking().FirstOrDefaultAsync(t => t.TrainingId == id);
        }
    }
}
