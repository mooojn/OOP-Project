using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.BL
{
    public class CurrentAccount : Account
    {
        private const int fees = 1;      // 1 dollar
        public CurrentAccount(string accountNumber, string accountHolderName, int balance) : base(accountNumber, accountHolderName, balance) { }
        public override int Deposit(int amount)
        {
            // error encountered so returning
            if (amount < 0)
                return -1;
            else if (amount == 0)
                return -2;

            // adding cash
            balance += amount;  // no limit for current account
            return 0;   // success
        }
        public override int Withdraw(int amount)
        {
            amount += fees;
            return base.Withdraw(amount);
        }
        public override string getType()
        {
            return "Current";
        }
    }
}
