using Presentation.Model.API;
using Services.API;

namespace Presentation.Model.Implementation
{
    internal class ProcessStateOperations : IProcessStateOperations
    {
        private IProcessStateCRUD _stateCrud;

        public ProcessStateOperations(IProcessStateCRUD? stateCrud = null)
        {
            this._stateCrud = stateCrud ?? IProcessStateCRUD.CreateStateCRUD();
        }

        private IProcessStateModel Map(IProcessStateDTO state)
        {
            return new ProcessStateModel(state.stateId, state.description);
        }

        public async Task AddProcessState(int stateId, string description)
        {
            await _stateCrud.AddProcessState(stateId, description);
        }
        public async Task UpdateProcessState(int stateId, string description)
        {
            await this._stateCrud.UpdateProcessState(stateId, description);
        }
        public async Task DeleteProcessState(int stateId)
        {
            await this._stateCrud.DeleteProcessState(stateId);
        }
        public async Task<IProcessStateModel> GetProcessState(int stateId)
        {
            return this.Map(await this._stateCrud.GetProcessState(stateId));
        }
    }
}
