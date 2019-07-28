using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoCoreApi;
using ToDoCoreApi.Models;

namespace ToDoCoreApiTest
{
    [TestClass]
    public class ToDoItemRepositoryTests
    {
        IRepository<ToDoItem> _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = new ToDoItemRepository();
        }

        [TestMethod]
        public async Task CreateAnItem()
        {
            var item1 = await _repo.CreateAsync("test item");

            Assert.AreNotEqual(Guid.Empty.ToString(), item1.Id);
            Assert.AreEqual("test item", item1.Text);

            ToDoItem item2 = await _repo.GetAsync(item1.Id);
            Assert.AreEqual(item2.Text, item1.Text);


        }

        [TestMethod]
        public async Task UpdateItemText()
        {
            var item1 = await _repo.CreateAsync("initial text");
            item1.Text = "updated text";

            ToDoItem item2 = await _repo.UpsertAsync(item1);

            Assert.AreEqual(item1.Id, item2.Id);
            Assert.AreEqual(item2.Text, "updated text");
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            ToDoItem item1 = await _repo.CreateAsync("initial text");

            ToDoItem item2 = await _repo.GetAsync(item1.Id);

            Assert.AreEqual(item1.Id, item2.Id);
            Assert.AreEqual(item1.Text, item2.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(CosmosException))]
        public async Task DeleteAsync()
        {
            ToDoItem item1 = await _repo.CreateAsync("initial text");

            var item2 = await _repo.DeleteAsync(item1.Id);

            // try to query if the item is gone
            // throws exception if it is gone
            // and this is what we want
            ToDoItem item3 = await _repo.GetAsync(item1.Id);
        }
    }
}



