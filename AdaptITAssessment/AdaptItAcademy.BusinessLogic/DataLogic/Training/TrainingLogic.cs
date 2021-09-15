using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.registration;
using AdaptItAcademy.DataAccess.Services.trainings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public class TrainingLogic : ITrainingLogic
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public TrainingLogic(ITrainingRepository trainingRepository , IRegistrationRepository registrationRepository)
        {
            _trainingRepository = trainingRepository;
            _registrationRepository = registrationRepository;
        }

        public async Task<Training> CreateTraining(Training training)
        {
            if ( await CheckTrainingDate(training))
            {
                throw new Exception("TrainingExist");
            }else if (!ValidDate(training))
            {
                throw new Exception("InValidDate");
            }
            else if (!ValidClosingDate(training))
            {
                throw new Exception("InValidClosingDate");
            }
            else
            {
                return await _trainingRepository.Add(training);
            }

            
        }


        public async Task <bool> CheckTrainingDate(Training training)
        {
            var trainings =  await _trainingRepository.GetAll();

            foreach(var t in trainings)
            {
                if(t.CourseId == training.CourseId)
                {
                    //check if the dates are the same

                    if(t.TrainingDate.ToShortDateString() == training.TrainingDate.ToShortDateString())
                    {
                        return true;
                    }

                  

                }
            }

            return false;
        }

        public  bool ValidDate(Training training)
        {
               if (training.TrainingDate > DateTime.Now)
                {
                    return true;
                }
            
            return false;
        }

        public bool ValidClosingDate(Training training)
        {
            if (training.RegistrationClosingDate >= DateTime.Now & training.RegistrationClosingDate < training.TrainingDate)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteTraining(int id)
        {


            IEnumerable<TrainingRegistration> trainings = await _registrationRepository.GetAll();

            bool CourseRegistered = false;

            foreach (var training in trainings)
            {
                if (training.TrainingId == id)
                {
                    CourseRegistered = true;
                }
            }

            if (!CourseRegistered)
            {

                await _trainingRepository.Delete(id);
            }
            else
            {
                throw new Exception("registered");
            }
        }


        public async Task<IEnumerable<Training>> GetAllTraining()
        {
            return await _trainingRepository.GetAll();
        }

        public IEnumerable<Training> GetCourseUpComingTraining()
        {
            return _trainingRepository.GetUpComungCourse();
        }

        public async Task<Training> GetTraining(int id)
        {
            return await _trainingRepository.GetById(id);
        }

        public async Task<Training> UpdateTraining(Training training)
        {
             if (!ValidDate(training))
            {
                throw new Exception("InValidDate");
            }
            else if (!ValidClosingDate(training))
            {
                throw new Exception("InValidClosingDate");
            }
            else
            {

                return await _trainingRepository.Update(training);
            }
        }
    }
}
