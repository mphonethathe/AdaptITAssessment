using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.DataAccess.Services.courses
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly AdaptItAcademyContext appDbContext;

        public CourseRepository(AdaptItAcademyContext appDbContext)
            : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
