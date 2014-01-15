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
            
        }
    }
}
