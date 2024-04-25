using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankDLL.BL;
using AzureBankDLL.DL;

namespace AzureBankGui
{
    internal static class Program
    {
        public static SqlConnection connection = new SqlConnection("Server=localhost\\MOOOJN;Initial Catalog=Azure-Bank;Integrated Security=True");
        public static int currentUserId = -1;   // -1 means no user is logged in
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthenticationPage());
        }
    }
}
