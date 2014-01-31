using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SQLAzureDemo
{
    class SQLAzureManager
    {
        private string sqlConnString;

        public SQLAzureManager()
        {
            sqlConnString = ConfigurationManager.AppSettings["SQLAzure"];
        }

        public void TestConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(sqlConnString);
                conn.Open();
                Console.WriteLine("Connected to SQL Azure");

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

    }
}
