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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Exit");
            Console.ResetColor();
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
            Console.WriteLine("5. View Transactions");
            Console.WriteLine("6. Block/Unblock Transactions");
            Console.WriteLine("7. Change Password");
            Console.WriteLine("8. Delete Account");
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("9. Logout");
            Console.ResetColor();
            // getting input
            return UtilUi.GetChoice();
        }
        public static string AdminMenu()
        {
            Header();
            // menu
            Console.WriteLine("1. Check Banks Liquidity");
            Console.WriteLine("2. Add User");
            Console.WriteLine("3. Add An Asset");
            Console.WriteLine("4. View Users");
            Console.WriteLine("5. View Assets");
            Console.WriteLine("6. Delete User");
            Console.WriteLine("7. Change Admin Password");


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Logout");
            Console.ResetColor();

            // getting input
            return UtilUi.GetChoice();
        }
    }
}
