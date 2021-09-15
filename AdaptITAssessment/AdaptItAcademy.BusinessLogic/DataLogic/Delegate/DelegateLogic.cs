using AdaptItAcademy.BusinessLogic.Utilities;
using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.delegates;
using AdaptItAcademy.DataAccess.Services.registration;
using AdaptItAcademy.DataAccess.Services.trainings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public class DelegateLogic : IDelegateLogic
    {



        private readonly IDelegateRepository _delegateRepository;
        private readonly IRegistrationRepository _registrationRepository;
        public DelegateLogic(IDelegateRepository delegateRepository, IRegistrationRepository registrationRepository)
        {
            _delegateRepository = delegateRepository;
            _registrationRepository = registrationRepository;
        }

        public async Task<Delegates> CreateDelegate(Delegates delegates)
        {
            Validations validations = new Validations(_delegateRepository);

            if (validations.EmailExist(delegates.Email))
            {
                throw new Exception("EmailExist");

            }
            else if (!validations.IsValidPhoneNumber(delegates.PhoneNumber))
            {
                throw new Exception("InvalidNumber");
            }
            else if (!validations.IsValidEmail(delegates.Email))
            {
                throw new Exception("InvalidEmail");
            }
            else
            {
             return await _delegateRepository.Add(delegates);
            }
        }

        public async Task<Delegates> GetDelegate(int id)
        {
            return await _delegateRepository.GetById(id);
        }
         public async Task DeleteDelegate(int id)
        {
            try
            {
                await _delegateRepository.Delete(id);
            }catch(Exception ex)
            {
                throw new Exception("registered");
            }
        }


        public async Task<Delegates> UpdateDelegate(Delegates delegates)
        {
            return await _delegateRepository.Update(delegates);
        }

        public async Task<IEnumerable<Delegates>> GetAllDelegate()
        {
            return await _delegateRepository.GetAll();
        }
    }

}
