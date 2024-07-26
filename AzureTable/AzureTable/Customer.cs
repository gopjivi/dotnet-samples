using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace AzureTable
{
    public class Customer:TableEntity
    {
        public string CustomerName { get; set; }

        public Customer(string cusName,string cusID,string city)
        {
            PartitionKey = city;
            RowKey = cusID;
            CustomerName = cusName;
        }
    }
}
