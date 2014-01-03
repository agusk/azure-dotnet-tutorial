//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

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
            manager.RetrievebyCriteria(tableName);
            manager.UpdateData(tableName);
        }
    }
}
