//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

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
