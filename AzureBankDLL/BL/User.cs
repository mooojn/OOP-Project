using AzureBankDLL.DL;
using PassHashingWithSaltsDLL;
using System;
using System.Collections.Generic;
using System.Data.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AzureBankDLL.BL
{
    public class User
    {
        // attributes
        private string name;
        private string password;
        private int cash;
        private bool transactionStatus;
        private Account account;
        private List<History> history;
        // constructor for initializing
        public User(string name, string pass)
        {
            this.name = name;
            this.password = pass;
            this.cash = 0;  // default val
            this.history = new List<History>();
            this.account = null;
        }
        public User(string name, string pass, int cash, bool status)
        {
            this.name = name;
            this.password = pass;
            this.cash = cash;  // default val
            this.transactionStatus = status;
            this.history = new List<History>();
            this.account = null;
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
            return 0;   // success
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
            return 0;   // success
        }
        public int TransferCash(User user, int transferAmount)
        {
            // transferring cash
            int res = WithdrawCash(transferAmount);
            if (res == 0)
                return user.DepositCash(transferAmount);    // if deposit was successful then return deposit status
            return res;
        }
        public string getName()
        {
            return name;
        }
        public string getPassword()
        {
            return password;
        }
        public int getCash()
        {
            return cash;
        }
        public Account getAccount()
        {
            return account;
        }
        public List<History> getHistory()
        {
            return history;
        }
        public bool getTransactionStatus()
        {
            return transactionStatus;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setPassword(string pass)
        {
            this.password = pass;   
        }
        public void setCash(int cash)
        {
            this.cash = cash;
        }
        public void setHistory(List<History> history)
        {
            this.history = history;
        }
        public void setAccount(Account account)
        {
            this.account = account;
        }
        public void setTransactionStatus(bool status)
        {
            this.transactionStatus = status;
        }
        public string toString()
        {
             return $"{name}, {cash}, {transactionStatus.ToString()}";
        }
    }
}
