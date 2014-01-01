using System;
using System.Linq;

namespace TableStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TableStorageManager manager = new TableStorageManager();
            manager.CreateNewTable("PostingTwit");
            manager.CreateData("PostingTwit");
            manager.CreateDataByBatch("PostingTwit");
        }
    }
}
