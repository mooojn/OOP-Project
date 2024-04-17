using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using AzureBankDLL.BL;
using System.Data.SqlClient;


namespace AzureBankDLL.DL.DB
{
    public class AccountDB : IAccount
    {
        private static AccountDB instance = null;
        private AccountDB() { }
        public static AccountDB getInstance()
        {
            if (instance == null)
                instance = new AccountDB();
            return instance;
        }
        public bool Create(Account account)
        {
            DataBase.openConnection();
            
            string query = $"INSERT INTO Accounts VALUES ('{account.getNumber()}', '{account.getHolderName()}', {account.getBalance()})";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            cmd.ExecuteNonQuery();
            
            DataBase.closeConnection();
            return true;
        }
        public Account Read(string name)
        {
            DataBase.openConnection();
            
            string query = $"SELECT * FROM Accounts WHERE userName = '{name}'";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            
            // creating account object if found
            Account acc = null;
            while (reader.Read())
            {
                string number = reader["number"].ToString();
                string holderName = reader["userName"].ToString();
                int balance = Convert.ToInt32(reader["amount"]);
                
                if (number.Contains("CUR"))
                    acc = new CurrentAccount(number, holderName, balance);
                else
                    acc = new SavingAccount(number, holderName, balance);
            }
            DataBase.closeConnection();
            return acc;
        }
        public bool Update(Account account) 
        {
            DataBase.openConnection();
            string query = $"UPDATE Accounts SET amount = {account.getBalance()} WHERE number = '{account.getNumber()}'";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            cmd.ExecuteNonQuery();
            DataBase.closeConnection();
            return true;
        }
    }
}
