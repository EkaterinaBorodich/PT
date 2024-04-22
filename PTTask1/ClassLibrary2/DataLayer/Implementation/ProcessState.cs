namespace BusinessProcessLibrary.Data.Implementation
{
    internal class ProcessState : IProcessState
    {
        public int StateId { get; }
        public string Description { get; set; }

        public ProcessState(int stateId, string description)
        {
            StateId = stateId;
            Description = description;
        }
    }
}
