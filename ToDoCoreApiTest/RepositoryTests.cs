using System;
using System.Threading.Tasks;
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
            var item = await _repo.CreateAsync("test item");

            Assert.AreNotEqual(Guid.Empty, item.Id);
            Assert.AreEqual("test item", item.Text);
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
        public async Task DeleteAsync()
        {
            ToDoItem item = await _repo.CreateAsync("initial text");
            var foo = await _repo.DeleteAsync(item.Id);





            
        }
    }
}