using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AzureBankDLL
{
    internal class Program
    {
        public static SqlConnection connection = new SqlConnection("Server=DESKTOP-AJHCE58\\MOOOJN;DataBase=Azure-Bank;Trusted_Connection=True;");
    }
}
