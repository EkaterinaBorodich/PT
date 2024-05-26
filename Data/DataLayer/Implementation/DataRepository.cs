using Castle.Components.DictionaryAdapter;
using Data.DataLayer.API;
using Microsoft.Extensions.Logging;
using static Data.DataLayer.API.IDataRepository;

namespace Data.DataLayer.Implementation
{
    internal class DataRepository : IDataRepository

    {
        private IDataContext _context;

        public DataRepository(IDataContext context)
        {
            this._context = context;
        }

        #region User

        public async Task AddUser(int userId, string userName)
        {
            IUser user = new User(userId, userName);

            await this._context.AddUser(user);
        }

        public async Task DeleteUser(int userId)
        {
            if(!await this.CheckIfUserExists(userId))
                throw new Exception("This user does not exist");
            await this._context.DeleteUser(userId);
        }

        public async Task UpdateUser(int userId,string userName)
        {
            IUser user = new User(userId, userName);
            if (!await this.CheckIfUserExists(user.UserId))
                throw new Exception("This user does not exist");
            await this._context.UpdateUser(user);
        }

        public async Task<IUser> GetUser(int userId)
        {
            IUser? user = await this._context.GetUser(userId);

            if (user is null)
                throw new Exception("This user does not exist!");
            return user;

        }
        public async Task<bool> CheckIfUserExists(int userId)
        {
            return await this._context.CheckIfUserExists(userId);
        }
        #endregion User

        #region CatalogItem

        public async Task AddCatalogItem(int itemId, string description)
        {
            ICatalogItem item = new CatalogItem(itemId,description);

            await this._context.AddCatalogItem(item);
        }

        public async Task DeleteCatalogItem(int itemId)
        {
            if (!await this.CheckIfCatalogItemExists(itemId))
                throw new Exception("This item does not exist");

            await this._context.DeleteCatalogItem(itemId);
        }

        public async Task UpdateCatalogItem(int itemId, string description)
        {
            ICatalogItem item = new CatalogItem(itemId,description);

            if (!await this.CheckIfCatalogItemExists(item.ItemId))
                throw new Exception("This item does not exist");

            await this._context.UpdateCatalogItem(item);
        }

        public async Task<ICatalogItem> GetCatalogItem(int itemId)
        {
            ICatalogItem? item = await this._context.GetCatalogItem(itemId);

            if (item is null)
                throw new Exception("This item does not exist!");

            return item;
        }

        public async Task<bool> CheckIfCatalogItemExists(int itemId)
        {
            return await this._context.CheckIfCatalogItemExists(itemId);
        }
        

        #endregion CatalogItem

        #region ProcessState

        public async Task AddProcessState(int stateId, string description)
        {
            IProcessState state = new ProcessState(stateId,description);

            await this._context.AddProcessState(state);
        }

        public async Task DeleteProcessState(int stateId)
        {
            if (!await this.CheckIfProcessStateExists(stateId))
                throw new Exception("This state does not exist");

            await this._context.DeleteProcessState(stateId);
        }

        public async Task UpdateProcessState(int stateId, string description)
        {               
                IProcessState state = new ProcessState(stateId, description);
                if (!await this.CheckIfProcessStateExists(state.StateId))
                throw new Exception("This state does not exist");
            await this._context.UpdateProcessState(state);           
        }

        public async Task<IProcessState> GetProcessState(int stateId)
        {
            IProcessState? state = await this._context.GetProcessState(stateId);
            if (state is null)
                throw new Exception("This state does not exist!");
            return state;
        }

        public async Task<bool> CheckIfProcessStateExists(int id)
        {
            return await this._context.CheckIfProcessStateExists(id);
        }

        #endregion ProcessState

        #region Event

        public async Task AddEvent(int eventId, string description,int stateId,int userId,string type)
        {
            description = description.Trim();
            type = type.Trim();

            IProcessState state = await this.GetProcessState(stateId);
            IUser user = await this.GetUser(userId);

            IEvent newEvent = new Event(eventId,description,stateId,userId,type);

            await this._context.AddEvent(newEvent);
        }

        public async Task DeleteEvent(int eventId)
        {
            if (!await this.CheckIfEventExists(eventId,"Rent"))
                throw new Exception("This event does not exist");
            await this._context.DeleteEvent(eventId);

        }

        public async Task UpdateEvent(int eventId,string description, int stateId, int userId,string type )
        {
            description = description.Trim();
            type = type.Trim();

            IEvent newEvent = new Event(eventId,description, stateId, userId, type);

            if (!await this.CheckIfEventExists(newEvent.EventId,type))
                throw new Exception("This event does not exist");

            await this._context.UpdateEvent(newEvent);
        }

        public async Task<IEvent> GetEvent(int eventId)
        {
            IEvent? even = await this._context.GetEvent(eventId); 

            if (even is null)
                throw new Exception("This event does not exist!");

            even.Description = even.Description.Trim();
            even.Type = even.Type.Trim();

            return even;
        }

        public async Task<bool> CheckIfEventExists(int eventId,string type)
        {
            return await this._context.CheckIfEventExists(eventId,type);
        }

        #endregion Event

    }
}