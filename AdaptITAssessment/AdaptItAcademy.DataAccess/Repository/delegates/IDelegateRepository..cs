using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.DataAccess.Services.delegates
{
    public  interface IDelegateRepository : IGenericRepository<Delegates>
    {
        bool EmailExist(string Email);
    }
}
