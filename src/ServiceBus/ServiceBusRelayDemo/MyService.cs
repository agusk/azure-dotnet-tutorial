using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
