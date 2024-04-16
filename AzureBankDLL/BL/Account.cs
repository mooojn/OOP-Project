using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.BL
{
    public class Account
    {
        protected string number;
        protected string holderName;
        protected int balance;
        public Account(string number, string holderName, int balance)
        {
            this.number = number;
            this.holderName = holderName;
            this.balance = balance;
        }
        public string getNumber()
        {
            return number;
        }
        public string getHolderName()
        {
            return holderName;
        }
        public int getBalance()
        {
            return balance;
        }
        public void setNumber(string number)
        {
            this.number = number;
        }
        public void setHolderName(string holderName)
        {
            this.holderName = holderName;
        }
        public void setBalance(int balance)
        {
            this.balance = balance;
        }
        public string toString()
        {
            return $"AccountNumber: {number}\nBalance: ${balance}";
        }
        public virtual float getProfit() { return 0; }
        public virtual int Deposit(int amount)
        {
            // error encountered so returning   
            if (amount < 0)
                return -1;
            else if (amount == 0)
                return -2;

            // adding cash
            balance += amount;
            return 0;   // success
        }
        public virtual int Withdraw(int amount)
        {
            // error encountered so returning
            if (amount < 0)
                return -1;
            else if (amount == 0)
                return -2;
            else if (amount > balance)
                return -3;

            // withdrawing cash
            balance -= amount;
            return 0;   // success
        }
        public virtual string getType()
        {
            return "Account";
        }
    }
}
