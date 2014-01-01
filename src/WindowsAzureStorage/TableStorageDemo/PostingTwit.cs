using System;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableStorageDemo
{
    public class PostingTwit : TableEntity
    {
        public PostingTwit() 
        {
            Guid guid = Guid.NewGuid();
            this.PartitionKey = guid.ToString();
            this.RowKey = guid.ToString();
        }

        public string Posting { get; set; }
        public string Email { get; set; }
    }
}
