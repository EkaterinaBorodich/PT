using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataLayer.Implementation;

namespace Data.DataLayer.API;

public interface IDataContext
{
    static IDataContext CreateContext(string? connectionString = null)
    {
        return new DataContext(connectionString);
    }

    #region User 

    Task AddUser(IUser user);
    Task RemoveUser(int UserId);
    Task UpdateUser(IUser user);
    Task <IUser?> GetUser(int UserId);

    #endregion User 

   /* #region CatalogItem 

    Task AddCatalogItem(ICatalogItem catalogItem);
    Task RemoveCatalogItem(int ItemId);
    Task UpdateCatalogItem(ICatalogItem catalogItem);
    Task <ICatalogItem?> GetCatalogItem(int ItemId);

    #endregion CatalogItem */

    #region ProcessState 

    Task AddProcessState(IProcessState processState);

    Task RemoveProcessState(int StateId);

    Task UpdateProcessState(IProcessState processState);

    Task <IProcessState?> GetProcessState(int StateId);


    #endregion ProcessState 

    #region Event 

    Task AddEvent(IEvent even);
    Task RemoveEvent(int EventId);
    Task UpdateEvent(IEvent even);
    Task<IEvent?> GetEvent(int EventId);


    #endregion Event 

    Task<bool> CheckIfUserExists(int id);

    /*Task<bool> CheckIfCatalogItemExists(int id);*/

    Task<bool> CheckIfProcessStateExists(int id);

    Task<bool> CheckIfEventExists(int id,string type);


}
