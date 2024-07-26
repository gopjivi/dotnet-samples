using System;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace AzureStorageQueue
{
    class Program
    {

        private static string connection_string = "DefaultEndpointsProtocol=https;AccountName=storedemo123;AccountKey=gE6VcfHCdLAT9hRYouid9sdHy0oQklX7pMVB0k3mgmIqVu/UFsHz+4rY7jhcQCSrtjWyzavUMeDV+AStzUgOlA==;EndpointSuffix=core.windows.net";
        private static string queue_name = "appdata";


        static void Main(string[] args)
        {
            QueueClient client = new QueueClient(connection_string, queue_name);

            string message, temp_message;
              
            if (client.Exists())
            {
                for (int i = 1; i < 5; i++)
                {
                    temp_message = $"This is a  test message {i}";

                    var txtbyts = System.Text.Encoding.UTF8.GetBytes(temp_message);
                    message = System.Convert.ToBase64String(txtbyts);
                    client.SendMessage(message);
                    Console.WriteLine("success");
                }
                //PeekedMessage[] msg = client.PeekMessage();

                // PeekedMessage message1 = client.PeekMessage();

                //PeekedMessage[] messages = client.PeekMessages(2);
                //foreach(PeekedMessage message in messages)
                //{
                //    Console.WriteLine($"the message id is{message.MessageId}");
                //    Console.WriteLine($"the mesage body is{message.Body.ToString()}");
                //    Console.WriteLine($"the message inserted on{message.InsertedOn}");
                //}


                //QueueMessage msg = client.ReceiveMessage();
                //Console.WriteLine(msg.Body.ToString());
                //client.DeleteMessage(msg.MessageId, msg.PopReceipt);
                Console.WriteLine("all message are sent");

            }
            Console.ReadKey();
        }
    }
}
