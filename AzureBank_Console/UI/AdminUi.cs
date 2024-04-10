using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.BL;

namespace AzureBankConsole
{
    internal class AdminUi
    {
        public static Asset GetAssetInput()
        {
            Console.Write("Enter the name of the asset: ");
            string name = Console.ReadLine();

            Console.Write("Enter the price of the asset: $");
            int price = int.Parse(Console.ReadLine());

            return new Asset(name, price);
        }
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
        public static void assetInfoHeader() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"id, name, worth");
            Console.ResetColor();
        }
    }
}
