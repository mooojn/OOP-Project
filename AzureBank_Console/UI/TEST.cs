using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.BL;

namespace AzureBankConsole
{
    internal class TEST
    {
        public static Account CreateAcc(string name)
        {
            string randomNums = UtilUi.GenerateRandomString(3);

            string number = $"{name.ToLower()}{randomNums}@AzureBank";
            string holderName = name;
            string accType = UserUi.GetAccountType();
        Again:
            int amount = UserUi.GetAmount("Deposit initially: ");
            if (amount < 0 || amount == 0)
                goto Again;

            UtilUi.Success("Your account has been created successfully");
            if (accType == "Saving")
                return new SavingAccount(number+"SAV", holderName, amount);
            else
                return new CurrentAccount(number+"CUR", holderName, amount);
        }
    }
}
