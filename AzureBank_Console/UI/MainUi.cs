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
            UtilUi.ShowWord("...... ", ConsoleColor.DarkGreen);
            
            UtilUi.ShowWord("Azure ", ConsoleColor.DarkCyan);
            UtilUi.ShowWord("Bank ");
            
            UtilUi.ShowWord("......", ConsoleColor.DarkGreen);
            
            Console.WriteLine("\n");
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
        public static string UserMenu()
        {
            Header();
            // menu
            Console.WriteLine("1. View Portfolio");
            Console.WriteLine("2. View Account");
            Console.WriteLine("3. Deposit Cash");
            Console.WriteLine("4. Withdraw Cash");
            Console.WriteLine("5. Transfer Cash");
            Console.WriteLine("6. View Transactions");
            Console.WriteLine("7. Block/Unblock Transactions");
            Console.WriteLine("8. Change Password");
            Console.WriteLine("9. Delete Account");
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("10. Logout");
            Console.ResetColor();
            // getting input
            return UtilUi.GetChoice();
        }
        public static string AccountMenu()
        {
            Header();
            // menu
            Console.WriteLine("1. View Information");
            Console.WriteLine("2. Deposit Cash");
            Console.WriteLine("3. Withdraw Cash");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5. Go Back");
            Console.ResetColor();
            // getting input
            return UtilUi.GetChoice();
        }
    }
}
