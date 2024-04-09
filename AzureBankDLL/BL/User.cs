using AzureBankDLL.DL;
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
        // objs
        private string name;
        private string password;
        private int cash;
        private bool transactionStatus;
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
        public User(string name, string pass, int cash, bool status)
        {
            this.name = name;
            this.password = pass;
            this.cash = cash;  // default val
            this.transactionStatus = status;
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
            
            return 0;        // success
        }
        public int TransferCash(User user, int transferAmount)
        {
            // transferring cash
            int res = WithdrawCash(transferAmount);
            if (res == 0)
                return user.DepositCash(transferAmount);
            return res;
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
        public void setHistory(List<History> history)
        {
            this.history = history;
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
