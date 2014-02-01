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

        public void CreateData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(sqlConnString);
                conn.Open();
                Console.WriteLine("Connected to SQL Azure");

                string query = "insert into dbo.employees(firstname,lastname,email,country,created) " + 
                                "values(@firstname,@lastname,@email, @country, @now)";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter[] pars = new SqlParameter[5];

                pars[0] = new SqlParameter("@firstname", SqlDbType.NVarChar, 10);
                pars[1] = new SqlParameter("@lastname", SqlDbType.NVarChar, 20);
                pars[2] = new SqlParameter("@email", SqlDbType.NVarChar, 30);
                pars[3] = new SqlParameter("@country", SqlDbType.NVarChar, 15);
                pars[4] = new SqlParameter("@now", SqlDbType.DateTime);

                cmd.Parameters.AddRange(pars);
                Console.Write("Inserting data....");
                // bulk insert
                DateTime now = DateTime.Now;
                for (int i = 1; i <= 10;i++ )
                {
                    
                    pars[0].Value = "Employee";
                    pars[1].Value = i.ToString();
                    pars[2].Value = "email" + i.ToString() + "@myemail.com";

                    if(i<=5)
                        pars[3].Value = "UK";
                    else
                        pars[3].Value = "USA";

                    pars[4].Value = now;
                    
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Done");

                conn.Close();
                Console.WriteLine("Closed connection");


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

    }
}
