using Data.DataLayer.Implementation;
using Data.DataLayer.API;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace Data.DataLayer.Implementation;

internal class DataContext : IDataContext
{
    public DataContext(string? connectionString = null)
    {
        if (connectionString == null)
        {
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string _DBRelativePath = @"Data\Database\Library.mdf";
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            this.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }
        else
        {
            this.ConnectionString = connectionString;
        }
    }
    private readonly string ConnectionString;

    #region User 

    public async Task AddUser(IUser user)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User entity = new Database.User()
            {
                UserId = user.UserId,
                UserName = user.UserName,
            };

            context.Users.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task DeleteUser(int UserId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User toDelete = (from u in context.Users where u.UserId == UserId select u).FirstOrDefault()!;
            context.Users.DeleteOnSubmit(toDelete);
            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task UpdateUser(IUser user)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User toUpdate = context.Users.Where(u => u.UserId == user.UserId).FirstOrDefault()!;
            toUpdate.UserName = user.UserName;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IUser?> GetUser(int UserId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User? user = await Task.Run(() =>
                context.Users.Where(u => u.UserId == UserId).FirstOrDefault()
            );

            return user is not null ? new User(user.UserId, user.UserName) : null;
        }
    }

    public async Task<Dictionary<int, IUser>> GetAllUsers()
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            IQueryable<IUser> itemQuery = from u in context.Users
                                          select
                                                     new User(u.UserId, u.UserName) as IUser;

            return await Task.Run(() => itemQuery.ToDictionary(k => k.UserId));
        }
    }
    #endregion User 

    #region CatalogItem
    public async Task AddCatalogItem(ICatalogItem item)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.CatalogItem entity = new Database.CatalogItem()
            {
                ItemId = item.ItemId,
                Description = item.Description,
            };

            context.CatalogItems.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }
    public async Task DeleteCatalogItem(int itemId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.CatalogItem toDelete = context.CatalogItems.Where(c => c.ItemId == itemId).FirstOrDefault()!;

            context.CatalogItems.DeleteOnSubmit(toDelete);

            await Task.Run(() => context.SubmitChanges());
        }
    }
    public async Task UpdateCatalogItem(ICatalogItem item)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.CatalogItem toUpdate = context.CatalogItems.Where(c => c.ItemId == item.ItemId).FirstOrDefault()!;

            toUpdate.Description = item.Description;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<ICatalogItem?> GetCatalogItem(int itemId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.CatalogItem? item = await Task.Run(() =>
                context.CatalogItems.Where(c => c.ItemId == itemId).FirstOrDefault()
            );

            return item is not null ? new CatalogItem(item.ItemId, item.Description) : null;
        }
    }

    public async Task<Dictionary<int, ICatalogItem>> GetAllCatalogItems()
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            IQueryable<ICatalogItem> itemQuery = from c in context.CatalogItems
                                                 select
                                                     new CatalogItem(c.ItemId, c.Description) as ICatalogItem;

            return await Task.Run(() => itemQuery.ToDictionary(k => k.ItemId));
        }
    }
    #endregion CatalogItem

    #region ProcessState

    public async Task AddProcessState(IProcessState processState)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.ProcessState entity = new Database.ProcessState()
            {
                StateId = processState.StateId,
                Description = processState.Description,
            };
            context.ProcessStates.InsertOnSubmit(entity);
            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task DeleteProcessState(int StateId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.ProcessState toDelete = context.ProcessStates.Where(ps => ps.StateId == StateId).FirstOrDefault()!;
            context.ProcessStates.DeleteOnSubmit(toDelete);
            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task UpdateProcessState(IProcessState processState)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.ProcessState toUpdate = context.ProcessStates.Where(ps => ps.StateId == processState.StateId).FirstOrDefault()!;

            toUpdate.StateId = processState.StateId;
            toUpdate.Description = processState.Description;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IProcessState?> GetProcessState(int StateId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.ProcessState? pstate = await Task.Run(() =>
                context.ProcessStates.Where(ps => ps.StateId == StateId).FirstOrDefault()
            );

            return pstate is not null ? new ProcessState(pstate.StateId, pstate.Description) : null;
        }
    }

    public async Task<Dictionary<int, IProcessState>> GetAllProcessStates()
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            IQueryable<IProcessState> itemQuery = from ps in context.ProcessStates
                                                  select
                                                      new ProcessState(ps.StateId, ps.Description) as IProcessState;

            return await Task.Run(() => itemQuery.ToDictionary(k => k.StateId));
        }
    }
    #endregion ProcessState

    #region Event

    public async Task AddEvent(IEvent even)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.Event entity = new Database.Event()
            {
                EventId = even.EventId,
                Description = even.Description,
                StateId = even.StateId,
                UserId = even.UserId,
                Type = even.Type
            };

            context.Events.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task DeleteEvent(int EventId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.Event toDelete = context.Events.Where(e => e.EventId == EventId).FirstOrDefault()!;
            context.Events.DeleteOnSubmit(toDelete);
            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task UpdateEvent(IEvent even)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.Event toUpdate = context.Events.Where(e => e.EventId == even.EventId).FirstOrDefault()!;
            toUpdate.Description = even.Description;
            toUpdate.StateId = even.StateId;
            toUpdate.UserId = even.UserId;
            toUpdate.Type = even.Type;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IEvent?> GetEvent(int EventId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.Event? even = await Task.Run(() =>
                context.Events.Where(e => e.EventId == EventId).FirstOrDefault()
            );

            return even is not null ? new Event(even.EventId, even.Description, even.StateId, even.UserId, even.Type) : null;
        }
    }

    public async Task<Dictionary<int, IEvent>> GetAllEvents()
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            IQueryable<IEvent> itemQuery = from e in context.Events
                                           select
                                               new Event(e.EventId, e.Description, e.StateId, e.UserId, e.Type) as IEvent;

            return await Task.Run(() => itemQuery.ToDictionary(k => k.EventId));
        }
    }
    #endregion Event

    public async Task<bool> CheckIfUserExists(int userId)
    {
        return (await this.GetUser(userId)) != null;
    }

    public async Task<bool> CheckIfCatalogItemExists(int itemId)
    {
        return (await this.GetCatalogItem(itemId)) != null;
    }

    public async Task<bool> CheckIfProcessStateExists(int stateId)
    {
        return (await this.GetProcessState(stateId)) != null;
    }

    public async Task<bool> CheckIfEventExists(int eventId, string type)
    {
        return (await this.GetEvent(eventId)) != null;
    }
}
