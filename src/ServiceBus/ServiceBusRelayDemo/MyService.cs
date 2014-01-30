//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;

namespace ServiceBusRelayDemo
{
    class MyService : IMyService
    {
        public int Calculate(int a, int b, int c)
        {
            return a * b + c;
        }
    }
}
