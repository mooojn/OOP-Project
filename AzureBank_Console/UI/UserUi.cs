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
        public static string GetName()
        {
            Console.Write("Enter name: ");
            return Console.ReadLine();
        }
        public static User GetUserInput()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            string password = UtilUi.GetMaskedInput();
            return new User(name, password);
        }
        public static int GetDepositAmount()
        {
            Console.Write("Enter amount you want to deposit: $");
            return int.Parse(Console.ReadLine());
        }
        public static int GetWithdrawAmount()
        {
            Console.Write("Enter the amount you want to withdraw: $");
            return int.Parse(Console.ReadLine());
        }
    }
}
