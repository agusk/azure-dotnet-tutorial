using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using System.Threading;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;

namespace ServiceBusTopicSubscriptionSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string cloudString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string topicName = "mytopic";
            try
            {
                TopicClient client = TopicClient.CreateFromConnectionString(cloudString, topicName);

                for(int i=0;i<10;i++)
                {
                    BrokeredMessage msg = new BrokeredMessage("message " + i.ToString());

                    client.Send(msg);
                    Console.WriteLine("message " + i.ToString() + "was sent");
                    Thread.Sleep(5000);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
