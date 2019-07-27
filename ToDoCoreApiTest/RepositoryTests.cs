using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoCoreApi;
using ToDoCoreApi.Models;

namespace ToDoCoreApiTest
{
    [TestClass]
    public class RepositoryTests
    {
        IRepository<ToDoItem> _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = new ToDoItemRepository();
        }

        [TestMethod]
        public void SaveItem(ToDoItem item)
        {

        }
    }
}
