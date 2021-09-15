using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.courses;
using AdaptItAcademy.DataAccess.Services.trainings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public class CourseLogic : ICourseLogic
    {

        private readonly ICourseRepository _courseRepository;
        private readonly ITrainingRepository _trainingRepository;

        public CourseLogic(ICourseRepository courseRepository, ITrainingRepository trainingRepository)
        {
            _courseRepository = courseRepository;
            _trainingRepository = trainingRepository;
        }

        public async Task<Course> CreateCourse(Course course)
        {                     
            return await _courseRepository.Add(course);
        }

        public async Task DeleteCourse(int id)
        {
            //check if there is training for this course

            IEnumerable<Training> trainings = _trainingRepository.GetUpComungCourse();

            bool CourseRegistered = false;

            foreach(var training in trainings)
            {
               if(training.CourseId == id)
                {
                    CourseRegistered = true;
                }
            }

            if (!CourseRegistered)
            {
                await _courseRepository.Delete(id);
            }
            else
            {
                throw new Exception("CourseRegistered");
            }
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
