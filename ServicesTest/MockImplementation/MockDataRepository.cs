using Data.DataLayer.API;

namespace ServicesTest.MockImplementation;

internal class MockDataRepository : IDataRepository
{
    public Dictionary<int, IUser> Users = new Dictionary<int, IUser>();
    public Dictionary<int, ICatalogItem> Items = new Dictionary<int, ICatalogItem>();
    public Dictionary<int, IProcessState> States = new Dictionary<int, IProcessState>();
    public Dictionary<int, IEvent> Events = new Dictionary<int, IEvent>();

    #region User CRUD
    public async Task AddUser(int userId, string userName)
    {
        Users.Add(userId, new MockUser(userId, userName));
    }
    public async Task UpdateUser(int userId, string userName)
    {
        Users[userId].UserName = userName;
    }
    public async Task DeleteUser(int userId)
    {
        Users.Remove(userId);
    }
    public async Task<IUser> GetUser(int userId)
    {
        return await Task.FromResult(Users[userId]);
    }

    public async Task<Dictionary<int, IUser>> GetAllUsers()
    {
        return await Task.FromResult(Users);
    }
    #endregion User CRUD

    #region CatalogItem CRUD

    public async Task AddCatalogItem(int itemId, string description)
    {
        Items.Add(itemId, new MockCatalogItem(itemId, description));
    }

    public async Task UpdateCatalogItem(int itemId, string description)
    {
        Items[itemId].Description = description;
    }
    public async Task DeleteCatalogItem(int itemId)
    {
        Items.Remove(itemId);
    }
    public async Task<ICatalogItem> GetCatalogItem(int itemId)
    {
        return await Task.FromResult(Items[itemId]);
    }
    public async Task<Dictionary<int, ICatalogItem>> GetAllCatalogItems()
    {
        return await Task.FromResult(Items);
    }
    #endregion CatalogItem CRUD

    #region ProcessState CRUD

    public async Task AddProcessState(int stateId, string description)
    {
        States.Add(stateId, new MockProcessState(stateId, description));
    }
    public async Task UpdateProcessState(int stateId, string description)
    {
        States[stateId].Description = description;
    }
    public async Task DeleteProcessState(int stateId)
    {
        States.Remove(stateId);
    }
    public async Task<IProcessState> GetProcessState(int stateId)
    {
        return await Task.FromResult(States[stateId]);
    }
    public async Task<Dictionary<int, IProcessState>> GetAllProcessStates()
    {
        return await Task.FromResult(States);
    }
    #endregion ProcessStateCRUD

    #region Event CRUD

    public async Task AddEvent(int eventId, string description, int stateId, int userId, string type)
    {
        IUser user = await GetUser(userId);
        IProcessState state = await GetProcessState(stateId);

        Events.Add(eventId, new MockEvent(eventId, description,stateId, userId, type));
    }
    public async Task UpdateEvent(int eventId, string description, int stateId, int userId, string type)
    {
        ((MockEvent)Events[eventId]).Description = description;
        ((MockEvent)Events[eventId]).StateId = stateId;
        ((MockEvent)Events[eventId]).UserId = userId;
        ((MockEvent)Events[eventId]).Type = type;
    }

    public async Task DeleteEvent(int eventId)
    {
        Events.Remove(eventId);
    }
    public async Task<IEvent> GetEvent(int eventId)
    {
        return await Task.FromResult(Events[eventId]);
    }
    public async Task<Dictionary<int, IEvent>> GetAllEvents()
    {
        return await Task.FromResult(Events);
    }
    #endregion Event CRUD
}
