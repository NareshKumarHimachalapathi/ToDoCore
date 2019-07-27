using System;
using System.Collections.Generic;
using ToDoCoreApi.Models;
using ToDoCoreApiTest;

public class ToDoItemRepository : IRepository<ToDoItem>
{
	public ToDoItemRepository()
	{
           	    
	}

    public ToDoItem Create(string text)
    {
        return new ToDoItem() {
            Id = Guid.NewGuid(),
            Text = text
        };
    }

    public ToDoItem Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ToDoItem> Get(Predicate<ToDoItem> match)
    {
        throw new NotImplementedException();
    }

    public ToDoItem Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public ToDoItem Upsert(ToDoItem item)
    {
        throw new NotImplementedException();
    }
}
