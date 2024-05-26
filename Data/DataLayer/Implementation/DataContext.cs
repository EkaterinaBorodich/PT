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
            this.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={{_DBPath}};Integrated Security = True; Connect Timeout = 30;";
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
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
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
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User toDelete = (from  u in context.Users  where u.UserId == UserId select u).FirstOrDefault()!;
            context.Users.DeleteOnSubmit(toDelete);
            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task UpdateUser(IUser user)
    {
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User toUpdate = (from u in context.Users where u.UserId == user.UserId select u).FirstOrDefault()!;
            toUpdate.UserName = user.UserName;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IUser?> GetUser(int UserId)
    {
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User? user = await Task.Run(() =>
            {
                IQueryable<Database.User> query =
                from u in context.Users
                where u.UserId == UserId
                select u;

                return query.FirstOrDefault();
            });

            return user is not null ? new User(user.UserId, user.UserName) : null;
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
            Database.CatalogItem toDelete = (from c in context.CatalogItems where c.ItemId == itemId select c).FirstOrDefault()!;

            context.CatalogItems.DeleteOnSubmit(toDelete);

            await Task.Run(() => context.SubmitChanges());
        }
    }
    public async Task UpdateCatalogItem(ICatalogItem item)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.CatalogItem toUpdate = (from c in context.CatalogItems where c.ItemId == item.ItemId select c).FirstOrDefault()!;

            toUpdate.Description = item.Description;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<ICatalogItem?> GetCatalogItem(int itemId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.CatalogItem? item = await Task.Run(() =>
            {
                IQueryable<Database.CatalogItem> query =
                    from c in context.CatalogItems
                    where c.ItemId == itemId
                    select c;

                return query.FirstOrDefault();
            });

            return item is not null ? new CatalogItem(item.ItemId,item.Description) : null;
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
            Database.ProcessState toDelete = (from ps in context.ProcessStates where ps.StateId == StateId select ps).FirstOrDefault()!;
            context.ProcessStates.DeleteOnSubmit(toDelete);
            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task UpdateProcessState(IProcessState processState)
    {
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.ProcessState toUpdate = (from ps in context.ProcessStates where ps.StateId == processState.StateId select ps).FirstOrDefault()!;

            toUpdate.StateId = processState.StateId;
            toUpdate.Description = processState.Description;

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task<IProcessState?> GetProcessState(int StateId)
    {
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.ProcessState? pstate = await Task.Run(() =>
            {
                IQueryable<Database.ProcessState> query =
                from ps in context.ProcessStates
                where ps.StateId == StateId 
                select ps;

                return query.FirstOrDefault();
            });

            return pstate is not null ? new ProcessState(pstate.StateId, pstate.Description) : null;
        }
    }

    #endregion ProcessState

    #region Event

    public async Task AddEvent(IEvent even)
    {
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
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
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.Event toDelete = (from e in context.Events where e.EventId == EventId select e).FirstOrDefault()!;
            context.Events.DeleteOnSubmit(toDelete);
            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task UpdateEvent(IEvent even)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.Event toUpdate = (from e in context.Events where e.EventId == even.EventId select e).FirstOrDefault()!;
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
            {
                IQueryable<Database.Event> query =
                from e in context.Events
                where e.EventId == EventId
                select e;

                return query.FirstOrDefault();
            });

            return even is not null ? new Event(even.EventId, even.Description, even.StateId, even.UserId,even.Type) : null;
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
