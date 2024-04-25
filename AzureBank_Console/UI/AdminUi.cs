using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AzureBankConsole.Util;
using AzureBankDLL.BL;

namespace AzureBankConsole
{
    internal class AdminUi
    {
        public static Asset GetAssetInput()
        {
            string name = UserUi.GetName("Enter the name of the asset: ", "Asset Name");

        
        Again: 
            int price = 0;
            Console.Write("Enter the price of the asset: $");
            
            if (Validation.IsValidNumber(ref price))
            {
                if (Validation.IsWorthValid(price))
                    return new Asset(name, price);    // return asset if all conditions pass
                else
                    goto Again;    // amount is invalid 
            }
            else
                goto Again;    // asset name is invalid 
        }
        public static int GetDeletionIndex()
        {
            int num = 0;
        Again: 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter the index of User to delete: ");
            Console.ResetColor();
            if (Validation.IsValidNumber(ref num))
                return num;
            else
                goto Again;
        }
        public static char GetAnotherInput()
        {
            char num = '5';
            while (num != '0' && num != '1')
            {
                Console.Write("Do you want to add(1) another user or continue(0): ");
                num = Console.ReadKey().KeyChar;
                Console.WriteLine();    // new line
            }
            return num;
        }
        public static void UserInfoHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"index, userName, cashHoldings, transactionStatus");
            Console.ResetColor();
        }
        public static void AssetInfoHeader() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"id, name, worth");
            Console.ResetColor();
        }
        public static void DisplayLiquidity(int totalLiquidity, int assetsLiquidity, int usersLiquidity, int userCount)
        {
            Console.WriteLine($"Total available Liquidity: ${totalLiquidity}");
            Console.WriteLine($"Amount in Assets: ${assetsLiquidity}");
            Console.WriteLine($"Amount in User Funds: ${usersLiquidity}");
            Console.WriteLine($"Registered Users: {userCount}");
            UtilUi.PressAnyKey();
        }
    }
}
