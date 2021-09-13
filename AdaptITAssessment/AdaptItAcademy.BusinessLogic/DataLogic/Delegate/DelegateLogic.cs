using AdaptItAcademy.BusinessLogic.Utilities;
using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.delegates;
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

        public DelegateLogic(IDelegateRepository delegateRepository)
        {
            _delegateRepository = delegateRepository;
        }

        public async Task<Delegates> CreateDelegate(Delegates delegates)
        {
            Validations validations = new Validations(_delegateRepository);

            if (validations.EmailExist(delegates.Email))
            {
                throw new Exception("Email already exist");

            }
            else if (!validations.IsValidPhoneNumber(delegates.PhoneNumber))
            {
                throw new Exception("Invalid Phone Number");
            }
            else if (!validations.IsValidEmail(delegates.Email))
            {
                throw new Exception("Please provide Valid Email Address");
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
            await _delegateRepository.Delete(id);
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
