using System;

namespace ToDoCoreApi.Models
{
    public class ToDoItem
    {
        private string v;
        private object message;

        public ToDoItem()
        {
        }

        public ToDoItem(string v, object message)
        {
            this.v = v;
            this.message = message;
        }

        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}