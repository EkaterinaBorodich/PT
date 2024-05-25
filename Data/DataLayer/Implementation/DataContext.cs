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

    public async Task RemoveUser(int UserId)
    {
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.User toRemove = (from  u in context.Users  where u.UserId == UserId select u).FirstOrDefault()!;
            context.Users.DeleteOnSubmit(toRemove);
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

    public async Task RemoveProcessState(int StateId)
    {
        using (LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.ProcessState toRemove = (from ps in context.ProcessStates where ps.StateId == StateId select ps).FirstOrDefault()!;
            context.ProcessStates.DeleteOnSubmit(toRemove);
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
                UserId = even.UserId
            };

            context.Events.InsertOnSubmit(entity);

            await Task.Run(() => context.SubmitChanges());
        }
    }

    public async Task RemoveEvent(int EventId)
    {
        using(LibraryDataContext context = new LibraryDataContext(this.ConnectionString))
        {
            Database.Event toRemove = (from e in context.Events where e.EventId == EventId select e).FirstOrDefault()!;
            context.Events.DeleteOnSubmit(toRemove);
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

    /*public async Task<bool> CheckIfCtalogItemExists(int itemId)
    {
        return (await this.GetCatalogItem(itemId)) != null;
    }*/

    public async Task<bool> CheckIfProcessStateExists(int stateId)
    {
        return (await this.GetProcessState(stateId)) != null;
    }

    public async Task<bool> CheckIfEventExists(int eventId, string type)
    {
        return (await this.GetEvent(eventId)) != null;
    }
}
