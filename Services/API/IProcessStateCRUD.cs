using Data.DataLayer.API;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IProcessStateCRUD
    {
        static IProcessStateCRUD CreateStateCRUD(IDataRepository? dataRepository = null)
        {
            return new ProcessStateCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }
        Task AddProcessState(int stateId, string description);
        Task DeleteProcessState(int stateId);
        Task UpdateProcessState(int stateId, string description);
        Task<IProcessStateDTO> GetProcessState(int stateId);
    }
}
