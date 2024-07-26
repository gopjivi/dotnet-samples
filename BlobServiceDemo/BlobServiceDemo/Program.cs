using System;
using System.Collections.Generic;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;

namespace BlobServiceDemo
{
    class Program
    {
        private static string containerName = "datafromvs";
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageforvs;AccountKey=dKTegDw7TehHAKVAetq0HZXI2WvIQ3aZ3e0cmqYhdqNeOiWSur7vcSCqKJk2NkMXaC2mlcP9CCA9+AStLWVWBw==;EndpointSuffix=core.windows.net";
        private static string blobName = "databasequery";
        private static string location = "C:\\Users\\gopal\\Documents\\databasequery.txt";

        static void Main(string[] args)
        {

            BlobServiceClient serviceClinet = new BlobServiceClient(connectionString);

            BlobContainerClient containerClient = serviceClinet.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);


            MemoryStream memory = new MemoryStream();
            blobClient.DownloadTo(memory);

            memory.Position = 0;
            StreamReader reader = new StreamReader(memory);
            Console.WriteLine(reader.ReadToEnd());

            BlobLeaseClient leaseClient = blobClient.GetBlobLeaseClient();
            BlobLease lease = leaseClient.Acquire(TimeSpan.FromSeconds(30));

            Console.WriteLine(lease.LeaseId);

            StreamWriter writer =new StreamWriter(memory);
            writer.WriteLine("This is a change for lease example");
            writer.Flush();

            BlobUploadOptions blobUpload = new BlobUploadOptions()
            {
                Conditions = new BlobRequestConditions()
                {
                    LeaseId = lease.LeaseId
                }
            };

            memory.Position = 0;
            blobClient.Upload(memory, blobUpload);
            leaseClient.Release();

            //BlobProperties blobProperties = blobClient.GetProperties();
            
            //IDictionary<string,string> metaData= blobProperties.Metadata;
           

            //metaData.Add("test", "1");
            //blobClient.SetMetadata(metaData);

            //foreach (var item in metaData)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value);
            //}

            //Uri sasuri = GenerateSAS();
            //BlobClient client = new BlobClient(sasuri);
            //client.DownloadTo(location);

            //  blobClient.Upload(location);

            //foreach(BlobItem item in containerClient.GetBlobs())
            //{
            //    Console.WriteLine(item.Name);
            //}


            //serviceClinet.CreateBlobContainer(containerName);
           Console.WriteLine("success");
            Console.ReadKey();
        }

        //static Uri GenerateSAS()
        //{
        //    BlobServiceClient serviceClinet = new BlobServiceClient(connectionString);

        //    BlobContainerClient containerClient = serviceClinet.GetBlobContainerClient(containerName);
        //    BlobClient blobClient = containerClient.GetBlobClient(blobName);
        //    BlobSasBuilder bulider = new BlobSasBuilder()
        //    {
        //        BlobContainerName = containerName,
        //        BlobName = blobName,
        //        Resource = "b"
        //    };
        //    bulider.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);
        //    bulider.ExpiresOn = DateTimeOffset.UtcNow.AddHours(5);

        //    return blobClient.GenerateSasUri(bulider);


        //}
    }
}
