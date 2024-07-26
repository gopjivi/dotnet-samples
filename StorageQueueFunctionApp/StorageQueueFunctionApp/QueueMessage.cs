using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace StorageQueueFunctionApp
{
    public class QueueMessage
    {
        [FunctionName("GetMessages")]
        public void Run([QueueTrigger("appqueue", Connection = "storage-connectionstring")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
