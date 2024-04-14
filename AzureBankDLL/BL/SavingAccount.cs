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
        
        public override int Withdraw(int amount)
        {
            amount = 0;      // no use
            
            
            Console.WriteLine($"Balance: {balance}");
            balance = Convert.ToInt32(CheckProfit());
            Console.WriteLine($"After Profit: {balance}");
            Console.WriteLine($"Press any key to Withdraw");
            Console.ReadKey();
            balance = 0;      // as cash is withdrawn

            return 0;
        }
        private float CheckProfit()
        {
            return balance * interestRate + balance;
        }
        public override string getType()
        {
            return "Saving";
        }
    }
}
