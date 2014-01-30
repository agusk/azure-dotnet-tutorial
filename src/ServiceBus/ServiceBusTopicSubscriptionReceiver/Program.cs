//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;

namespace ServiceBusTopicSubscriptionReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            string cloudString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string topicName = "mytopic";
            string subscriptionName = "mysubscription";
            try
            {
                SubscriptionClient client = SubscriptionClient.CreateFromConnectionString(cloudString, topicName, subscriptionName);
                Console.WriteLine("Waiting message from Service Bus Topic Subscription....Please press CTRL-C to exit.");
                while (true)
                {
                    BrokeredMessage message = client.Receive();

                    if (message != null)
                    {
                        try
                        {
                            Console.WriteLine("Incoming a message...");
                            Console.WriteLine("Body: " + message.GetBody<string>());
                            Console.WriteLine("MessageID: " + message.MessageId);
                            Console.WriteLine("");

                            // Remove message from subscription
                            message.Complete();
                        }
                        catch (Exception)
                        {
                            // unlock message in subscription
                            message.Abandon();
                        }
                    }
                } 

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
