//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

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
