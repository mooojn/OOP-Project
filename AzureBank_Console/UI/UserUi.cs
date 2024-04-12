using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AzureBankConsole.Util;
using AzureBankDLL.BL;
using AzureBankDLL.DLInterfaces;

namespace AzureBankConsole
{
    internal class UserUi
    {
        public static string GetName(string msg = "Enter name: ", string type = "Username")
        {
            string name;
            do {
                Console.Write(msg);
                name = Console.ReadLine();

                if (Validation.IsValid(type, name))
                    break;    // exit loop if all conditions pass
                else
                    continue;

            } while (true);

            return name;
        }
        public static int GetAmount(string type)
        {
            int num = 0;
        Again:
            Console.Write($"Enter the amount you want to {type}: $");

            if (Validation.IsValidNumber(ref num)) 
                return num;    // return amount if all conditions pass
            else 
                goto Again;
        }
        public static void TransactionHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"type, amount, date");
            Console.ResetColor();
        }
        public static void AccountDeletionWarning(int cash) 
        {
            Console.WriteLine($"Your funds '${cash}' would be lost");
            UtilUi.ShowWord($"Go Back", ConsoleColor.Green);
            Console.Write($"(press 1) or press any key to ");
            UtilUi.ShowWord($"Delete ", ConsoleColor.DarkRed);
            Console.Write($"your account permanently: ");
        }
    }
}
