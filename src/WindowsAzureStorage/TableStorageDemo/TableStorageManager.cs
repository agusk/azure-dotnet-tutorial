//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace TableStorageDemo
{
    class TableStorageManager
    {
        private string cloudString;
        private CloudStorageAccount storageAccount;
        private CloudTableClient tableClient;
        public TableStorageManager()
        {
            cloudString = ConfigurationManager.ConnectionStrings["WindowsAzureStorage"].ConnectionString;
            storageAccount = CloudStorageAccount.Parse(cloudString);
            tableClient = storageAccount.CreateCloudTableClient();
        }

        public void CreateNewTable(string tableName)
        {
            try
            {                
                CloudTable table = tableClient.GetTableReference(tableName);

                if (table.CreateIfNotExists())
                {
                    Console.WriteLine("Table " + tableName + " was created");
                }
                else
                {
                    Console.WriteLine("Table " + tableName + " has already created");
                }
                Console.WriteLine("Done");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void CreateData(string tableName)
        {
            try
            {
                CloudTable table = tableClient.GetTableReference(tableName);

                Console.Write("Creating data.....");
                PostingTwit twit = new PostingTwit();
                twit.Posting = "My Posting ";
                twit.Email = "user@email.com";
                
                TableOperation insertOperation = TableOperation.InsertOrReplace(twit);
                table.Execute(insertOperation);

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void CreateDataByBatch(string tableName)
        {
            CloudTable table = tableClient.GetTableReference(tableName);

            Console.Write("Creating 10 data.....");
            for (int i = 1; i <= 10; i++)
            {
                PostingTwit twit = new PostingTwit();
                twit.Posting = "Posting " + i;
                twit.Email = "user" + i + "@email.com";
                twit.PartitionKey = "twit";
                
                TableOperation insertOperation = TableOperation.InsertOrReplace(twit);
                table.Execute(insertOperation);
            }

            Console.WriteLine("Done");
        }
        public void RetrieveAll(string tableName)
        {
            CloudTable table = tableClient.GetTableReference(tableName);
            TableQuery<PostingTwit> query = new TableQuery<PostingTwit>();

            Console.WriteLine("Retrieving all data....");
            foreach (PostingTwit entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.Email, entity.Posting);
            }
        }
        public void RetrievebyCriteria(string tableName)
        {
            CloudTable table = tableClient.GetTableReference(tableName);
            TableQuery<PostingTwit> query = new TableQuery<PostingTwit>().Where(
                TableQuery.GenerateFilterCondition("Email", QueryComparisons.Equal, "user5@email.com"));

            Console.WriteLine("Retrieving data by data....");
            foreach (PostingTwit entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.Email, entity.Posting);
            }
        }
        public void UpdateData(string tableName)
        {
            // scenario
            // update data twit where email=user7@email.com

            CloudTable table = tableClient.GetTableReference(tableName);   
            TableQuery<PostingTwit> query = new TableQuery<PostingTwit>().Where(
                TableQuery.GenerateFilterCondition("Email", QueryComparisons.Equal, "user7@email.com"));

            IEnumerable<PostingTwit> list = table.ExecuteQuery(query);
            if(list.Count()>0)
            {
                Console.Write("Updating data....");
                PostingTwit entity = list.Single();
                entity.Posting = "updated content";

                // update data
                TableOperation insertOperation = TableOperation.InsertOrReplace(entity);
                table.Execute(insertOperation);
                Console.WriteLine("Done");
            }

        }
        public void DeleteData(string tableName)
        {
            // scenario
            // delte data twit where email=user3@email.com

            CloudTable table = tableClient.GetTableReference(tableName);
            TableQuery<PostingTwit> query = new TableQuery<PostingTwit>().Where(
                TableQuery.GenerateFilterCondition("Email", QueryComparisons.Equal, "user3@email.com"));

            IEnumerable<PostingTwit> list = table.ExecuteQuery(query);
            if (list.Count() > 0)
            {
                Console.Write("Deleting data....");
                PostingTwit entity = list.Single();

                // delete data
                TableOperation insertOperation = TableOperation.Delete(entity);
                table.Execute(insertOperation);
                Console.WriteLine("Done");
            }

        }
    }
}
