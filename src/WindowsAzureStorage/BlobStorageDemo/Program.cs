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
            blob.CreateContainer(containerName,false);
            blob.UploadBlob(containerName, "myfile", "d:/data.xlsx");
            blob.GetListofBlob(containerName);
        }
    }
}
