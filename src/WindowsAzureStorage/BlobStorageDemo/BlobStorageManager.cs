//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;

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

        public void CreateContainer(string containerName,bool isPublicStorage)
        {
            try
            {
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

                if (blobContainer.CreateIfNotExists())
                {
                    Console.WriteLine("Blob Container " + containerName + " was created");
                    if(isPublicStorage)
                    {
                        blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob }); 
                    }
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
        public void UploadBlob(string containerName,string blobName,string file)
        {
            try
            {
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);
                Console.Write("Uploading file " + file + " to Azure Blob Storage.....");                
                using (var fs = File.OpenRead(file))
                {                    
                    blockBlob.UploadFromStream(fs);
                } 
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void UploadText(string containerName, string blobName, string content)
        {
            try
            {
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);
                Console.Write("Uploading text to Azure Blob Storage.....");
                blockBlob.UploadText(content);               
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void GetListofBlob(string containerName)
        {
            try
            {
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                foreach (IListBlobItem item in blobContainer.ListBlobs(null, false))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        Console.WriteLine("Name: " + blob.Name);
                        Console.WriteLine("Size {0}: {1}", blob.Properties.Length, blob.Uri);
                        Console.WriteLine("--------------------------------------------------");
                    }         
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void DownloadBlob(string containerName, string blobName, string saveFile)
        {
            try
            {
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);
                Console.Write("Downloading file " + blobName + " from Azure Blob Storage.....");

                using (var fs = System.IO.File.OpenWrite(saveFile))
                {
                    blockBlob.DownloadToStream(fs);
                } 
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void DeleteBlob(string containerName, string blobName)
        {
            try
            {
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);
                Console.Write("Deleting file " + blobName + " from Azure Blob Storage.....");
                blockBlob.Delete();
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
