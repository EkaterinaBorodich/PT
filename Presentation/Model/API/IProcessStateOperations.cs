using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.API;
using Presentation.Model.Implementation;

namespace Presentation.Model.API
{
    public interface IProcessStateOperations
    {
        static IProcessStateOperations CreateModelOperation(IProcessStateCRUD? stateCrud = null)
        {
            return new ProcessStateOperations(stateCrud ?? IProcessStateCRUD.CreateStateCRUD());
        }

        Task AddProcessState(int stateId, string description);
        Task DeleteProcessState(int stateId);
        Task UpdateProcessState(int stateId, string description);
        Task<IProcessStateModel> GetProcessState(int stateId);
    }
}
