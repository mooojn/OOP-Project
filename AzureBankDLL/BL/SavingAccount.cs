using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.BL
{
    public class SavingAccount : Account
    {
        private const float interestRate = 0.04F;      // 4%
        public SavingAccount(string accountNumber, string accountHolderName, int balance) : base(accountNumber, accountHolderName, balance) {}

        public override int Deposit(int amount)
        {
            if (amount + balance > 1000)    // default limit of 1k dollars
                return -3;
            return base.Deposit(amount);
        }
        public override int Withdraw(int amount)
        {
            balance = 0;      // as cash is withdrawn
            return 0;
        }
        public override float getProfit()
        {
            return balance * interestRate + balance;
        }
        public override string getType()
        {
            return "Saving";
        }
    }
}
