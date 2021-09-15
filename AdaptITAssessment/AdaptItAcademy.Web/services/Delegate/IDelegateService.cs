using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Delegate
{
   public interface IDelegateService
    {
        Task<string> Create(Delegates delegates);
        Task<Delegates> Get(int Id);
        Task<List<Delegates>> GetAll();
        Task<Delegates> GetByID(int id);
        Task<Delegates> Update(Delegates course);
        Task <string> Delete(int id);
    }
}
