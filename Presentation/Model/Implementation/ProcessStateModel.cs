using Presentation.Model.API;

namespace Presentation.Model.Implementation
{
    internal class ProcessStateModel : IProcessStateModel
    {
        public int stateId { get; set; }
        public string description { get; set; }
        public ProcessStateModel(int stateId, string description)
        {
            this.stateId = stateId;
            this.description = description;
        }
    }
}
