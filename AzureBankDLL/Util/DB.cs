using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AzureBankDLL
{
    public static class DataBase
    {
        public static SqlConnection connection = new SqlConnection("Server=DESKTOP-AJHCE58\\MOOOJN;DataBase=Azure-Bank;Trusted_Connection=True;");
        public static void openConnection()
        {
            connection.Open();
        }
        public static void closeConnection()
        {
            connection.Close();
        }
    }
}
