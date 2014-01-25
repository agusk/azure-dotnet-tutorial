using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServiceBusRelayDemo
{
    [ServiceContract(Namespace = "urn:ps")]
    interface IMyService
    {
        [OperationContract]
        int Calculate(int a, int b,int c);
    }

    interface IMyServiceChannel : IMyService, IClientChannel { }
}
