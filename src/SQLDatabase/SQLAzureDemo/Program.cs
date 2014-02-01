using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
