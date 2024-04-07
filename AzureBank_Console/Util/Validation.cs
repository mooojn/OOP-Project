using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankConsole.Util
{
    internal class Validation
    {
        public static bool ValidDepositAmount(int amount)
        {
            if (amount == 0 || amount < 0)
                return false;
            return true;
        }
        public static bool ValidWithdrawAmount(int amount, int balance)
        {
            if (ValidDepositAmount(amount))
                return amount < balance;
            return false;
        }
    }
}
