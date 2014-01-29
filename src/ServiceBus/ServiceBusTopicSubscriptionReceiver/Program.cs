using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using System.Threading;
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
                while (true)
                {
                    BrokeredMessage message = client.Receive();

                    if (message != null)
                    {
                        try
                        {
                            Console.WriteLine("Body: " + message.GetBody<string>());
                            Console.WriteLine("MessageID: " + message.MessageId);
                          

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
