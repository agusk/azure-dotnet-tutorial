//////////////////////////////////////////////////////
// Copyright 2013 Agus Kurniawan
// blog: http://blog.aguskurniawan.net
// email: agusk2007@gmail.com
//////////////////////////////////////////////////////

using System;
using System.Linq;

namespace SQLAzureDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLAzureManager sqlazure = new SQLAzureManager();
            sqlazure.TestConnection();
            sqlazure.CreateData();
            sqlazure.ReadData();
            sqlazure.UpdateData(7); // change this value
            sqlazure.ReadData();
            sqlazure.DeleteData(7);
            sqlazure.ReadData();
        }
    }
}
