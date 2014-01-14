using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
