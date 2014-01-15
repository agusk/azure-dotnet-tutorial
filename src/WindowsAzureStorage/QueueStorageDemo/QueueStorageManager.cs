//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Configuration;

namespace QueueStorageDemo
{
    class QueueStorageManager
    {
        private string cloudString;
        private CloudStorageAccount storageAccount;
        private CloudQueueClient queueClient;

        public QueueStorageManager()
        {
            cloudString = ConfigurationManager.ConnectionStrings["WindowsAzureStorage"].ConnectionString;
            storageAccount = CloudStorageAccount.Parse(cloudString);
            queueClient = storageAccount.CreateCloudQueueClient();
        }

        public void CreateNewQueue(string queueName)
        {
            try
            {
                CloudQueue queue = queueClient.GetQueueReference(queueName);

                if (queue.CreateIfNotExists())
                {
                    Console.WriteLine("Blob Container " + queueName + " was created");                   
                }
                else
                {
                    Console.WriteLine("Blob Container " + queueName + " has already created");
                }
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void CreateNewMessageQueue(string queueName,string message)
        {
            try
            {
                CloudQueue queue = queueClient.GetQueueReference(queueName);

                Console.Write("Creating message queue.....");
                CloudQueueMessage messageQueue = new CloudQueueMessage(message);
                queue.AddMessage(messageQueue);

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public string PeekMessageQueue(string queueName)
        {
            string msg = "";
            try
            {
                CloudQueue queue = queueClient.GetQueueReference(queueName);

                Console.Write("Getting message queue.....");
                CloudQueueMessage message = queue.PeekMessage();
                msg = message.AsString;

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return msg;
        }
        public string Dequeue(string queueName)
        {
            string msg = "";
            try
            {
                CloudQueue queue = queueClient.GetQueueReference(queueName);

                Console.Write("Dequeue message .....");
                CloudQueueMessage message = queue.GetMessage();
                msg = message.AsString;
                queue.DeleteMessage(message);

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return msg;
        }
        public int GetLengthMessage(string queueName)
        {
            int total = 0;
            try
            {
                CloudQueue queue = queueClient.GetQueueReference(queueName);

                Console.Write("Deleting queue .....");
                queue.FetchAttributes();
                int? count = queue.ApproximateMessageCount;
                total = (int)count;
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return total;
        }
        public void DeleteQueue(string queueName)
        {
            try
            {
                CloudQueue queue = queueClient.GetQueueReference(queueName);

                Console.Write("Deleting queue .....");
                queue.Delete();

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
