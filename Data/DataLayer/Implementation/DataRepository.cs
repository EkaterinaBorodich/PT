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

        public async Task RemoveUser(int userId)
        {
            if(!await this.CheckIfUserExists(userId))
                throw new Exception("This user does not exist");
            await this._context.RemoveUser(userId);
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

        /*
         
         public async Task<bool> CheckIfProductExists(int itemId)
        {
            return await this._context.CheckIfCatalogItemExists(itemId);
        }
        */

        #endregion CatalogItem

        #region ProcessState

        public async Task AddProcessState(int stateId, string description)
        {
            IProcessState state = new ProcessState(stateId,description);

            await this._context.AddProcessState(state);
        }

        public async Task RemoveProcessState(int stateId)
        {
            if (!await this.CheckIfProcessStateExists(stateId))
                throw new Exception("This state does not exist");

            await this._context.RemoveProcessState(stateId);
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
            IProcessState state = await this.GetProcessState(stateId);
            IUser user = await this.GetUser(userId);

            IEvent newEvent = new Event(eventId,description,stateId,userId,type);

            await this._context.AddEvent(newEvent);
        }

        public async Task RemoveEvent(int eventId)
        {
            if (!await this.CheckIfEventExists(eventId,"Rent"))
                throw new Exception("This event does not exist");
            await this._context.RemoveEvent(eventId);

        }

        public async Task UpdateEvent(int eventId,string description, int stateId, int userId,string type )
        {
            IEvent newEvent = new Event(eventId,description, stateId, userId, type);

            if (!await this.CheckIfEventExists(newEvent.EventId,type))
                throw new Exception("This event does not exist");

            await this._context.UpdateEvent(newEvent);
        }

        public async Task<IEvent> GetEvent(int eventId)
        {
            IEvent? even = await this.GetEvent(eventId);

            if (even is not null)
                throw new Exception("This event does not exist!");

            return even;
        }
        public async Task<bool> CheckIfEventExists(int eventId,string type)
        {
            return await this._context.CheckIfEventExists(eventId,type);
        }

        #endregion Event

    }
}