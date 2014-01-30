//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;
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
                Console.WriteLine("Sending 10 messages...");
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
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
