using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.delegates;
using AdaptItAcademy.DataAccess.Services.registration;
using AdaptItAcademy.DataAccess.Services.trainings;
using AdaptItAcademy.DataAccess.Services.traningCost;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public class TrainingRegistrationLogic : ITrainingRegistrationLogic
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly ITrainingRepository _trainingRepository;
        private readonly ITrainingCostRepository _totalAmountRepository;

        public TrainingRegistrationLogic(IRegistrationRepository registrationRepository, ITrainingRepository trainingRepository, ITrainingCostRepository totalAmountRepository)
        {
            _registrationRepository = registrationRepository;
            _trainingRepository = trainingRepository;
            _totalAmountRepository = totalAmountRepository;
        }

        public async Task<TrainingRegistration> CreateTrainingRegistration(TrainingRegistration trainingRegistration)
        {
            Training training = new Training();

            training = await _trainingRepository.GetById(trainingRegistration.TrainingId);
            
            //if the number of seats is 0 then dont allow the user to register
            if (training.NumberOfSeats == 0)
            {
                throw new Exception("NoSeats");

            //check if already registered
            }
            else if (CheckTrainingRegistration(trainingRegistration.DelegateId, trainingRegistration.TrainingId))
            {
                throw new Exception("AlreadyRegistered");
            }
            else
            {

                var created = await _registrationRepository.Add(trainingRegistration);

                if (created.Id > 0)
                {

                    training.NumberOfSeats = await UpdateAvailableSeats(created.TrainingId);
                    training.TotalTrainingCostPaid = CalculateTotalAmount(created.TrainingId);
                    await _trainingRepository.Update(training);
                }
                return created;
            }
        }

        public  decimal CalculateTotalAmount(int trainingId)
        {
            Training training = new Training();

            IEnumerable<TrainingRegistration> Trainings = _registrationRepository.GetRegistratioByTrainingID(trainingId);

            decimal totalMount = 0;

            foreach (var amount in Trainings)
            {

                totalMount += amount.Training.TrainingCost;
            }

            return totalMount;



        }

        public async Task<int> UpdateAvailableSeats(int trainingId)
        {
            int AvailableSeats = 0;

            Training Training = await _trainingRepository.GetById(trainingId);

            if (Training != null)
            {
                AvailableSeats = Training.NumberOfSeats - 1;
            }
            else
            {
                AvailableSeats = Training.NumberOfSeats;
            }



            return AvailableSeats;
        }

        public bool CheckTrainingRegistration(int id, int trainingId)
        {
            var chekdelegate = _registrationRepository.GetDelegateTraining(id);

            foreach (var check in chekdelegate)
            {

                if (check.DelegateId == id & check.TrainingId == trainingId)
                {
                    return true;

                }
            }
            return false;
        }

        public async Task DeleteTrainingRegistration(int id)
        {
            await _registrationRepository.Delete(id);
        }

        public IEnumerable<TrainingRegistration> GetAllDeleteRegistration(int id)
        {
            return _registrationRepository.GetDelegateTraining(id);
        }

        public async Task<IEnumerable<TrainingRegistration>> GetAllTrainingRegistration()
        {
           return await _registrationRepository.GetAll();
        }


        public async Task<TrainingRegistration> GetTrainingRegistration(int id)
        {
            return await _registrationRepository.GetById(id);
        }

        public async Task<TrainingRegistration> UpdateTrainingRegistration(TrainingRegistration trainingRegistration)
        {
            return await _registrationRepository.Update(trainingRegistration);
        }
    }
}
