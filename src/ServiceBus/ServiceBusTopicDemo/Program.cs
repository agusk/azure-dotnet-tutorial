using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
