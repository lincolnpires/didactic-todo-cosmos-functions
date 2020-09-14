using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TodoApp
{
    public static class TodoApi
    {
        [FunctionName("Create")]
        public static IActionResult Create(
            [HttpTrigger(
                AuthorizationLevel.Function, "post", Route = "todo")] HttpRequest req,
            [CosmosDB(
                databaseName: "ToDoItems",
                collectionName: "Items",
                PartitionKey = "/id",
                CreateIfNotExists = true,
                ConnectionStringSetting = "CosmosDBConnection")]out dynamic document,
            ILogger log)
        {
            log.LogInformation("Create stuff.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var input = JsonConvert.DeserializeObject<TodoCreateModel>(requestBody);

            document = new Todo() { Description = input.Description };
            
            return new OkObjectResult(document);
        }
    }
}
