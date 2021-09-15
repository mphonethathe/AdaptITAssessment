using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

       public IEnumerable<Training> GetUpComungCourse()
        {
            return appDbContext.Training.Include(t => t.Course);
        }


    }
}
