using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankConsole
{
    internal class AdminUi
    {
        public static int GetIndex()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter the index of User to delete: ");
            Console.ResetColor();
            return int.Parse(Console.ReadLine());
        }
        public static int GetAnotherInput()
        {
            int num = -1;
            while (num != 0 && num != 1)
            {
                Console.Write("Do you want to add(1) another user or continue(0): ");
                num = int.Parse(Console.ReadLine());
            }
            return num;
        }
        public static void userInfoHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"index, userName, cashHoldings, transactionStatus");
            Console.ResetColor();
        }
    }
}
