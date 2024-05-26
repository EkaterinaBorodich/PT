using Data.DataLayer.API;
using Services.API;
using ServicesTest.MockImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    [TestClass]
    public class ServicesTests
    {
        private readonly IDataRepository _repository = new MockDataRepository();

        [TestMethod]
        public async Task UserServicesTests()
        {
            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

            await userCrud.AddUser(1, "Joe");

            IUserDTO user = await userCrud.GetUser(1);

            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.userId);
            Assert.AreEqual("Joe",user.userName);

            await userCrud.UpdateUser(1, "Patrick");

            IUserDTO updatedUser = await userCrud.GetUser(1);

            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(1, updatedUser.userId);
            Assert.AreEqual("Patrick", updatedUser.userName);

            await userCrud.DeleteUser(1);
        }
        [TestMethod]
        public async Task CatalogItemServicesTests()
        {
            ICatalogItemCRUD itemCRUD = ICatalogItemCRUD.CreateCatalogItemCRUD(this._repository);

            await itemCRUD.AddCatalogItem(1, "description");

            ICatalogItemDTO item = await itemCRUD.GetCatalogItem(1);

            Assert.IsNotNull(item);
            Assert.AreEqual(1,item.itemId);
            Assert.AreEqual("description",item.description);

            await itemCRUD.UpdateCatalogItem(1, "other");

            ICatalogItemDTO updatedItem = await itemCRUD.GetCatalogItem(1);

            Assert.IsNotNull(updatedItem);
            Assert.AreEqual(1, updatedItem.itemId);
            Assert.AreEqual("other",updatedItem.description);

            await itemCRUD.DeleteCatalogItem(1);
        }
        [TestMethod]
        public async Task ProcessStateServicesTests()
        {
            IProcessStateCRUD stateCRUD = IProcessStateCRUD.CreateStateCRUD(this._repository);

            await stateCRUD.AddProcessState(1, "description");

            IProcessStateDTO state = await stateCRUD.GetProcessState(1);

            Assert.IsNotNull(state);
            Assert.AreEqual(1,state.stateId);
            Assert.AreEqual("description",state.description);

            await stateCRUD.UpdateProcessState(1, "other");

            IProcessStateDTO updatedState = await stateCRUD.GetProcessState(1);

            Assert.IsNotNull(updatedState);
            Assert.AreEqual (1,updatedState.stateId);
            Assert.AreEqual("other",updatedState.description);

            await stateCRUD.DeleteProcessState(1);
        }
    }
}
