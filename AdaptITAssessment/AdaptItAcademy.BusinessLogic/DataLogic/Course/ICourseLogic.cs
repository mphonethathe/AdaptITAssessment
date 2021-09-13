using AdaptItAcademy.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public interface ICourseLogic
    {
        Task<Course> CreateCourse(Course course);
        Task<Course> GetCourse(int id);
        Task DeleteCourse(int id);
        Task<Course> UpdateCourse(Course course);
        Task<IEnumerable<Course>> GetAllCourses();

    }
}