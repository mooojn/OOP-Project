using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankConsole
{
    internal class MainUi
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("......Azure Bank......\n");
        }
        public static string Menu()
        {
            Header();
            // menu
            Console.WriteLine("1. Sign-in");
            Console.WriteLine("2. Sign-up as a User");

            Console.WriteLine("3. Exit");

            // input
            return UtilUi.GetChoice();
        }
        public static string UserMenu()
        {
            Header();
            // menu
            Console.WriteLine("1. Check Portfolio");
            Console.WriteLine("2. Deposit Cash");
            Console.WriteLine("3. Withdraw Cash");
            Console.WriteLine("4. Transfer Cash");
            Console.WriteLine("5. Block/Unblock Transactions");
            Console.WriteLine("6. Delete Account");

            Console.WriteLine("7. Logout");

            // getting input
            return UtilUi.GetChoice();
        }
        public static string AdminMenu()
        {
            Header();
            // menu
            Console.WriteLine("1. Add New User");
            Console.WriteLine("2. View Users");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Change Admin Password");

            Console.WriteLine("5. Logout");

            // getting input
            return UtilUi.GetChoice();
        }
    }
}
