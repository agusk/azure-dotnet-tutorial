using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }
    }
}
