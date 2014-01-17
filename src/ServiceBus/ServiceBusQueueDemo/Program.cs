//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;

namespace ServiceBusQueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusQueueManager service = new ServiceBusQueueManager();
            string queueName = "myservicebus";

            service.CreateQueue(queueName);
            service.CreateQueue("testqueue", 1024, new TimeSpan(0, 1, 0));
            service.SendMessageQueue(queueName, "welcome to service bus");
            string msg = service.ReceiveMessageQueue(queueName);
            Console.WriteLine(msg);
            service.DeleteQueue(queueName);
            
        }
    }
}
