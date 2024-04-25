using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AzureBankConsole.Util;
using AzureBankDLL.BL;
using AzureBankDLL.DL.DB;
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
        public static void TransactionHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"type, amount, date");
            Console.ResetColor();
        }
        public static int GetAmount(string type)
        {
            int num = 0;
        Again:
            Console.Write($"Enter the amount you want to {type}: $");

            if (Validation.IsValidNumber(ref num)) 
                return num;    // all conditions pass
            else 
                goto Again;
        }
        public static string GetAccountType()
        {
        Again:
            Console.Write("Enter the type of account Saving(1) or Current(2)\nPress the number key: ");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();    // new line
            if (key == '1')
                return "Saving";
            else if (key == '2')
                return "Current";
            else
                goto Again;
        }
        public static Account CreateAcc(string name)
        {
            // get inputs
            string randomNums = UtilUi.GenerateRandomString(3);

            string number = $"{name.ToLower()}{randomNums}@AzureBank";
            string holderName = name;
            string accType = UserUi.GetAccountType();
        Again:
            int amount = UserUi.GetAmount("Deposit initially: ");
            if (!ValidAmount(amount))
                goto Again;
            // create acc
            UtilUi.Success("Your account has been created successfully");
            if (accType == "Saving")
                return new SavingAccount(number + "SAV", holderName, amount);
            else
                return new CurrentAccount(number + "CUR" , holderName, amount);
        }
        public static void CheckAccount(IAccount accountDL, User user)
        {
            MainUi.Header();
            Account acc = accountDL.Read(user.getName());
            if (acc != null)
                user.setAccount(acc);
            else
            {
                Account account = CreateAcc(user.getName());
                user.setAccount(account);
                accountDL.Create(account);
            }
        }
        private static bool ValidAmount(int amount)
        {
            if (amount < 0 || amount == 0)
            {
                UtilUi.Error("Please provide valid amount", false);
                return false;   // err
            }
            else if (amount > 100)
            {
                UtilUi.Error("Initial deposit must be less than $100", false);
                return false;   // err
            }
            else 
                return true;
        }
        public static void AccountDeletionWarning(int cash, int accountBalance)
        {
            Console.WriteLine($"Your funds '${cash}' and account balance '${accountBalance}' would be lost");
            Console.Write($"Press any key to ");
            UtilUi.ShowWord($"Go Back", ConsoleColor.Green);
            Console.Write($" or Press(1) to ");
            UtilUi.ShowWord($"Delete ", ConsoleColor.DarkRed);
            Console.Write($"your account permanently: ");
        }        
    }
}
