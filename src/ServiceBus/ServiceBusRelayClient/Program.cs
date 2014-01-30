//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;
using System.ServiceModel;

namespace ServiceBusRelayClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelFactory = new ChannelFactory<ServiceBusRelayDemo.IMyServiceChannel>("myservice");
            using (var channel = channelFactory.CreateChannel())
            {
                Console.WriteLine("Result: " + channel.Calculate(10,15,5));
            }

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
