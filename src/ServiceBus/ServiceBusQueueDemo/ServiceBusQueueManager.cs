using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
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
    }
}
