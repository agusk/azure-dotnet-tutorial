using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
