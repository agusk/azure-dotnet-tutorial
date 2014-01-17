using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;

namespace ServiceBusQueueDemo
{
    class ServiceBusQueueManager
    {
        private string cloudString;

        public ServiceBusQueueManager()
        {
            cloudString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
        }

        public void CreateQueue(string queueName)
        {
            try
            {
                var namespaceManager = NamespaceManager.CreateFromConnectionString(cloudString);

                if (!namespaceManager.QueueExists(queueName))
                {
                    namespaceManager.CreateQueue(queueName);
                    Console.WriteLine("queue " + queueName + " was created");
                }
                else
                {
                    Console.WriteLine("queue " + queueName + " has already created");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            

        }
        public void CreateQueue(string queueName, long maxSizeInMegabytes, TimeSpan messageTimeToLive)
        {
            try
            {
                var namespaceManager = NamespaceManager.CreateFromConnectionString(cloudString);
                QueueDescription qd = new QueueDescription(queueName);
                qd.MaxSizeInMegabytes = maxSizeInMegabytes;
                qd.DefaultMessageTimeToLive = messageTimeToLive;

                if (!namespaceManager.QueueExists(queueName))
                {
                    namespaceManager.CreateQueue(qd);
                    Console.WriteLine("queue " + queueName + " was created");
                }
                else
                {
                    Console.WriteLine("queue " + queueName + " has already created");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            

        }
        public void SendMessageQueue(string queueName, string message)
        {
            try
            {
                QueueClient client = QueueClient.CreateFromConnectionString(cloudString, queueName);
                BrokeredMessage msg = new BrokeredMessage(message);

                Console.Write("Sending message....");
                client.Send(msg);
                Console.WriteLine("Done");  
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
                   
        }
    }
}
