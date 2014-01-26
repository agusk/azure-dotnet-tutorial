using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using System.Configuration;

namespace ServiceBusTopicDemo
{
    class ServiceBusTopicManager
    {
        private string cloudString;

        public ServiceBusTopicManager()
        {
            cloudString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
        }

        public void CreateTopic(string topicName)
        {
            try
            {
                var namespaceManager = NamespaceManager.CreateFromConnectionString(cloudString);

                if (!namespaceManager.TopicExists(topicName))
                {
                    namespaceManager.CreateTopic(topicName);
                    Console.WriteLine("topic " + topicName + " was created");
                }
                else
                {
                    Console.WriteLine("topic " + topicName + " has already created");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
