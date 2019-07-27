using System;
using Newtonsoft.Json;

namespace ToDoCoreApi.Models
{
    public class ToDoItem
    {
        public ToDoItem(string text)
        {
            this.Text = text;
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}