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
            if (amount + balance > 2000)    // default limit of 2k dollars
                return -3;
            return base.Deposit(amount);
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
