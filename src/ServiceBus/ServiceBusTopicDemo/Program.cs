//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;

namespace ServiceBusTopicDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusTopicManager service = new ServiceBusTopicManager();
            string topic = "mytopic";

            service.CreateTopic(topic);
            service.CreateTopic(topic, 5120, new TimeSpan(0,1,0));
            service.CreateSubscription(topic, "mysubscription");
            service.SendTopic(topic, "Welcome to servis bus topic");
            service.DeleteTopic(topic);
            service.DeleteSubscription(topic, "mysubscription");
        }
    }
}
