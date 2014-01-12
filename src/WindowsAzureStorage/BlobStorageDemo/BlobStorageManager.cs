﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace BlobStorageDemo
{
    public class BlobStorageManager
    {
        private string cloudString;
        private CloudStorageAccount storageAccount;
        private CloudBlobClient blobClient;

        public BlobStorageManager()
        {
            cloudString = ConfigurationManager.ConnectionStrings["WindowsAzureStorage"].ConnectionString;
            storageAccount = CloudStorageAccount.Parse(cloudString);
            blobClient = storageAccount.CreateCloudBlobClient();
        }

        public void CreateContainer(string containerName)
        {
            try
            {
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

                if (blobContainer.CreateIfNotExists())
                {
                    Console.WriteLine("Blob Container " + containerName + " was created");
                }
                else
                {
                    Console.WriteLine("Blob Container " + containerName + " has already created");
                }
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
