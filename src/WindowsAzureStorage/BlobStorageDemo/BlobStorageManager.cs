using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                using (var fileStream = File.OpenRead(file))
                {                    
                    blockBlob.UploadFromStream(fileStream);
                } 
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
    }
}
