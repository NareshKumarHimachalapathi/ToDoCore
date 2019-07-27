using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using ToDoCoreApi;
using ToDoCoreApi.Models;
using ToDoCoreApiTest;

public class ToDoItemRepository : IRepository<ToDoItem>
{

    CosmosClient cosmosClient;
    Database database;
    Container container;


	public ToDoItemRepository()
	{
        cosmosClient = new CosmosClient(AppConfig.ConnectionString);
        database = cosmosClient.GetDatabase(AppConfig.DbId);
        container = database.GetContainer(AppConfig.ContainerId);
    }

    public async Task<ToDoItem> CreateAsync(string text)
    {
        var item = new ToDoItem(text)
        {
            Id = Guid.NewGuid().ToString(),
            Text = text
        };

        return await container.CreateItemAsync<ToDoItem>(item);
    }

    public async Task DeleteAsync(string id)
    {
        //ItemResponse<ToDoItem> response = await container.DeleteItemAsync<ToDoItem>(id, new PartitionKey(AppConfig.PartitionKey));
        //return response.Resource.
        //    ;
        
    }

    public IEnumerable<ToDoItem> GetAsync(Predicate<ToDoItem> match)
    {
        throw new NotImplementedException();
    }

    public async Task<ToDoItem> GetAsync(string id)
    {

        FeedIterator<ToDoItem> results = container.GetItemQueryIterator<ToDoItem>("select * from Items where id == " + id);

        FeedResponse<ToDoItem> item = await results.ReadNextAsync();

        return item.Resource.FirstOrDefault();
    }

    public async Task<ToDoItem> UpsertAsync(ToDoItem item)
    {
        ItemResponse<ToDoItem> response = await container.UpsertItemAsync<ToDoItem>(item);
        return response.Resource;
    }
}
