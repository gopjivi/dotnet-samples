using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace CosmosDBApp
{
    class Program
    {
        private static string connectionstring = "AccountEndpoint=https://testcosmoaccount.documents.azure.com:443/;AccountKey=pu1CHbwuzhg2QlrkWd1Akp2cLfMPtRbJcldIH6EIhkYw6VoQk70LNSbKmZzHnm9SN7w21tHqXscMACDb0fXfSA==;";
        private static string databasename = "appdb";
        private static string containername = "course";
       // private static string partitionkey = "/courseID";

        static void Main(string[] args)
        {
            CosmosClient client = new CosmosClient(connectionstring,new CosmosClientOptions() {AllowBulkExecution=true });

            // client.CreateDatabaseAsync(databasename).GetAwaiter().GetResult();
            //Database db = client.GetDatabase(databasename);
            //db.CreateContainerAsync(containername, partitionkey).GetAwaiter().GetResult();
            Container container = client.GetContainer(databasename, containername);

            //List<Course> list = new List<Course>()
            //{
            //  new Course{ id="1",courseID="c0001",CourseName="Az-204",Rating="4.6"},
            //  new Course{ id="2",courseID="c0002",CourseName="Az-200",Rating="4.6"},
            //  new Course{ id="3",courseID="c0003",CourseName="Az-900",Rating="4.6"},
            //  new Course{ id="4",courseID="c0004",CourseName="Az-230",Rating="4.6"}
            //};

            //List<Task> tsk = new List<Task>();
            //foreach (Course crs in list)
            //{
            //   tsk.Add(container.CreateItemAsync<Course>(crs, new PartitionKey(crs.courseID)));
            //}
            //Task.WhenAll(tsk).GetAwaiter().GetResult();


            //string query = "SELECT * FROM c WHERE c.courseID='c0001'";
            //QueryDefinition definition = new QueryDefinition(query);
            //FeedIterator<Course> iterator = container.GetItemQueryIterator<Course>(definition);
            //while(iterator.HasMoreResults)
            //{
            //    FeedResponse<Course> res = iterator.ReadNextAsync().GetAwaiter().GetResult();
            //    foreach(Course crs in res)
            //    {
            //        Console.WriteLine($"course id is{crs.courseID}");
            //        Console.WriteLine($"course name is{crs.CourseName}");
            //        Console.WriteLine($"course rating is{crs.Rating}");

            //    }
            //}

            string id = "2";
            string partitionkey = "c0002";
        ItemResponse<Course> response=    container.ReadItemAsync<Course>(id, new PartitionKey(partitionkey)).GetAwaiter().GetResult();
            Course crs = response.Resource;
            crs.CourseName = "fundamentals";
            container.ReplaceItemAsync<Course>(crs, id, new PartitionKey(partitionkey)).GetAwaiter().GetResult();
            Console.WriteLine("success");






            Console.ReadKey();
        }
    }
}
