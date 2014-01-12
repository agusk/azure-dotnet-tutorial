using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BlobStorageManager blob = new BlobStorageManager();
            string containerName = "myblob";
            blob.CreateContainer(containerName);
        }
    }
}
