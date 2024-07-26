using System;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace AzureTable
{
    class Program
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageforvs;AccountKey=dKTegDw7TehHAKVAetq0HZXI2WvIQ3aZ3e0cmqYhdqNeOiWSur7vcSCqKJk2NkMXaC2mlcP9CCA9+AStLWVWBw==;EndpointSuffix=core.windows.net";
        private static string tableName = "customer";

        static void Main(string[] args)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
            CloudTableClient tableClient = account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);
            //  table.CreateIfNotExists();
            //Customer customer = new Customer("userA", "C1", "pollachi");
            //TableOperation operation = TableOperation.Insert(customer);
            //TableResult result = table.Execute(operation);

            List<Customer> customers = new List<Customer>
            {
                new Customer("userB", "C2", "pollachi"),
                new Customer("userC", "C3", "pollachi"),
                new Customer("userD", "C4", "pollachi"),
        }; 
            TableBatchOperation operations = new TableBatchOperation();

            foreach(Customer customer in customers)
            {
                operations.Insert(customer);
            }
            TableBatchResult tableResults = table.ExecuteBatch(operations);
            Console.WriteLine("Table values are inserted");
            Console.ReadKey();
        }
    }
}
