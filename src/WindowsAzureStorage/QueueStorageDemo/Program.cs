//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;

namespace QueueStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueStorageManager queue = new QueueStorageManager();
            string queueName = "myqueue";

            queue.CreateNewQueue(queueName);
            queue.CreateNewMessageQueue(queueName, "this is my message");
            string message = queue.PeekMessageQueue(queueName);
            Console.WriteLine("message: " + message);
            message = queue.Dequeue(queueName);
            Console.WriteLine("message: " + message);
        }
    }
}
