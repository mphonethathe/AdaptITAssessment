using AdaptItAcademy.DataAccess.Services.delegates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdaptItAcademy.BusinessLogic.Utilities
{
    public class Validations
    {

        private readonly IDelegateRepository _delegateRepository;

        public Validations(IDelegateRepository delegateRepository)
        {
            _delegateRepository = delegateRepository;
        }
        //validate phone number 
        public bool IsValidPhoneNumber(string phone)
        {

            string strRegex = @"^\+27[0-9]{9}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(phone))
                return (true);
            else
                return (false);
        }
        // check if email does not exist on the database
        public bool EmailExist(string email)
        {
            bool EmailExist = _delegateRepository.EmailExist(email);

            if (EmailExist)
            {
                return true;
            }

            return false;
        }
        // checked if email is field
        public bool IsValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
    }
}
