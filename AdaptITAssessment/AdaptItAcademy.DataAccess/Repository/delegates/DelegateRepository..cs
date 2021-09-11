using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.DataAccess.Services.delegates
{
    public class DelegateRepository : GenericRepository<Delegates>, IDelegateRepository
    {
        private readonly AdaptItAcademyContext appDbContext;

        public DelegateRepository(AdaptItAcademyContext appDbContext)
            : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
