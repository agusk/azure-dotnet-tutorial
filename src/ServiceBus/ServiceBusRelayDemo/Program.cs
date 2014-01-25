using System;
using System.Linq;
using System.ServiceModel;

namespace ServiceBusRelayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost service = new ServiceHost(typeof(MyService));
            service.Open();
            Console.WriteLine("Service was started.");

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            service.Close();
        }
    }
}
