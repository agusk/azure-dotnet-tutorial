using System;
using System.Linq;

namespace BlobStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BlobStorageManager blob = new BlobStorageManager();
            string containerName = "myblob";
            blob.CreateContainer(containerName);
            blob.UploadBlob(containerName, "myfile", "d:/data.xlsx");
        }
    }
}
