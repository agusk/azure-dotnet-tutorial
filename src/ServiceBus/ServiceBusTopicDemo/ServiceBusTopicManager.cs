using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
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
        public void CreateTopic(string topicName, long maxMaxSizeInMegabytes, TimeSpan defaultMessageTimeToLive)
        {
            try
            {
                var namespaceManager = NamespaceManager.CreateFromConnectionString(cloudString);

                if (!namespaceManager.TopicExists(topicName))
                {
                    TopicDescription td = new TopicDescription(topicName);
                    td.MaxSizeInMegabytes = maxMaxSizeInMegabytes;
                    td.DefaultMessageTimeToLive = defaultMessageTimeToLive;

                    namespaceManager.CreateTopic(td);
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
