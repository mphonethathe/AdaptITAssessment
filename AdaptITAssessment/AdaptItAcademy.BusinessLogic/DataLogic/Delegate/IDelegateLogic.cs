using AdaptItAcademy.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinessLogic.DataLogic
{
    public interface IDelegateLogic
    {
        Task<Delegates> CreateDelegate(Delegates delegates);
        Task<Delegates> GetDelegate(int id);
        Task DeleteDelegate(int id);
        Task<Delegates> UpdateDelegate(Delegates delegates);
        Task<IEnumerable<Delegates>> GetAllDelegate();

    }
}