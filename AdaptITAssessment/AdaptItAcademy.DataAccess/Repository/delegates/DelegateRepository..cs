using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptItAcademy.DataAccess.Services.delegates
{
    public class DelegateRepository : GenericRepository<Delegates>, IDelegateRepository
    {
        private readonly AdaptItAcademyContext _appDbContext;

        public DelegateRepository(AdaptItAcademyContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool EmailExist(string Email)
        {
          var found =  _appDbContext.Delegates.FirstOrDefault(d => d.Email == Email);

            if (found!= null)
            {
                return true;
            }

            return false;

        }

    }
}
