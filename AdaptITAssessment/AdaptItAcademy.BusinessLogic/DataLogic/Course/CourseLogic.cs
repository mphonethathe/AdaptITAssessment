using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public class CourseLogic : ICourseLogic
    {

        private readonly ICourseRepository _courseRepository;

        public CourseLogic(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        //check if all required field are true
        public async Task<Course> CreateCourse(Course course)
        {
            return await _courseRepository.Add(course);
        }

        public async Task DeleteCourse(int id)
        {
             await _courseRepository.Delete(id);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _courseRepository.GetById(id);
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            return await _courseRepository.Update(course);
        }
    }
}
