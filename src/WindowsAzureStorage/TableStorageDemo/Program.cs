using System;
using System.Linq;

namespace TableStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TableStorageManager manager = new TableStorageManager();
            string tableName = "PostingTwit";

            manager.CreateNewTable(tableName);
            manager.CreateData(tableName);
            manager.CreateDataByBatch(tableName);
            manager.RetrieveAll(tableName);
        }
    }
}
