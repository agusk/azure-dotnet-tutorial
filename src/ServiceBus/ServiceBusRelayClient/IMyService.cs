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
    [ServiceContract(Namespace = "urn:ps")]
    interface IMyService
    {
        [OperationContract]
        int Calculate(int a, int b,int c);
    }

    interface IMyServiceChannel : IMyService, IClientChannel { }
}
