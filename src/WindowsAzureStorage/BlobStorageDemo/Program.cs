//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

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
            blob.UploadBlob(containerName, "data.xlsx", "d:/data.xlsx");
            blob.UploadText(containerName, "mystring", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua");
            blob.DownloadBlob(containerName, "data.xlsx", "d:/data-temp.xlsx");            
            blob.GetListofBlob(containerName);
            blob.DeleteBlob(containerName, "data.xlsx");
        }
    }
}
