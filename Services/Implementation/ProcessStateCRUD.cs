using Data.DataLayer.API;
using Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class ProcessStateCRUD : IProcessStateCRUD
    {
        private IDataRepository _repository;
        public ProcessStateCRUD(IDataRepository repository)
        {
            _repository = repository;
        }
        private IProcessStateDTO Map(IProcessState processState)
        {
            return new ProcessStateDTO(processState.StateId, processState.Description);
        }
        public async Task AddProcessState(int stateId, string description)
        {
            await _repository.AddProcessState(stateId,description);
        }
        public async Task DeleteProcessState(int stateId)
        {
            await this._repository.DeleteProcessState(stateId);
        }
        public async Task UpdateProcessState(int stateId, string description)
        {
            await this._repository.UpdateProcessState(stateId,description);
        }
        public async Task<IProcessStateDTO> GetProcessState(int stateId)
        {
            return this.Map(await this._repository.GetProcessState(stateId));
        }
        public async Task<Dictionary<int, IProcessStateDTO>> GetAllProcessStates()
        {
            Dictionary<int, IProcessStateDTO> result = new Dictionary<int, IProcessStateDTO>();

            foreach (IProcessState item in (await this._repository.GetAllProcessStates()).Values)
            {
                result.Add(item.StateId, this.Map(item));
            }

            return result;
        }
    }
}
