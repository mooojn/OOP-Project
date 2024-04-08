using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.BL;

namespace AzureBankConsole
{
    internal class UserUi
    {
        public static string GetName(string msg = "Enter name: ")
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
        public static User GetUserInput()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            string password = UtilUi.GetMaskedInput();
            return new User(name, password);
        }
        public static int GetAmount(string type)
        {
            Console.Write($"Enter the amount you want to {type}: $");
            return int.Parse(Console.ReadLine());
        }
        public static void TransactionHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"type, amount, date");
            Console.ResetColor();
        }
    }
}
