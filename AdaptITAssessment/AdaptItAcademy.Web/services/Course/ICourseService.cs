using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Course
{
    public interface ICourseService
    {
        Task<Courses> Create(Courses courses);
        Task<List<Courses>> GetAll();
        Task Delete(int id);
        Task<Courses> GetByID(int id);
    }
}
