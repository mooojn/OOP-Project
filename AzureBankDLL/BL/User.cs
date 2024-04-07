using AzureBankDLL.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AzureBankDLL.BL
{
    public class User
    {
        // objs
        private string name;
        private string password;
        private int cash;
        private List<History> history;
        // constructor for initializing
        public User(string name, string pass)
        {
            this.name = name;
            this.password = pass;
            this.cash = 0;  // default val
            this.history = new List<History>();
        }
        public User(string name, string pass, int cash)
        {
            this.name = name;
            this.password = pass;
            this.cash = cash;  // default val
            this.history = new List<History>();
        }
        public User(string name, string pass, int cash, List<History> history)
        {
            this.name = name;
            this.password = pass;
            this.cash = cash;  // default val
            this.history = history;
        }
        public int DepositCash(int depositAmount)
        {
            // error encountered so returning   
            if (depositAmount < 0)
                return -1;
            else if (depositAmount == 0)
                return -2;
            // adding cash
            cash += depositAmount;
            HistoryDL.SaveTransactionHistory(name, new History("Deposit", depositAmount));
            return 0;        // success
        }
        public int WithdrawCash(int withdrawAmount)
        {
            // error encountered so returning
            if (withdrawAmount < 0)
                return -1;
            else if (withdrawAmount == 0) 
                return -2;
            else if (withdrawAmount > cash)
                return -3;
            // withdrawing cash
            cash -= withdrawAmount;
            HistoryDL.SaveTransactionHistory(name, new History("Withdraw", withdrawAmount));
            return 0;        // success
        }
        public int TransferCash(User user, int transferAmount)
        {
            // error encountered so returning
            if (transferAmount < 0)
                return -1;
            else if (transferAmount == 0)
                return -2;
            else if (transferAmount > cash)
                return -3;
            // transferring cash
            cash -= transferAmount;
            user.DepositCash(transferAmount);
            HistoryDL.SaveTransactionHistory(name, new History("Transfer", transferAmount));
            return 0;        // success
        }
        public void ShowCash()
        {
            Console.Write($"Your total cash holdings holding: ${cash}");
        }
        public int getCash()
        {
            return cash;
        }
        public string getName()
        {
            return name;
        }
        public string getPassword()
        {
            return password;
        }
        public void setPassword(string pass)
        {
            password = pass;
        }
        public void setHistory(List<History> history)
        {
            this.history = history;
        }
        public List<History> getHistory()
        {
            return history;
        }
    }
}
