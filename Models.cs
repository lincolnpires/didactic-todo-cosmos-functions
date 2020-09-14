using System;
using Newtonsoft.Json;

namespace TodoApp
{
    public class Todo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("created")]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }

    public class TodoCreateModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class TodoUpdateModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
