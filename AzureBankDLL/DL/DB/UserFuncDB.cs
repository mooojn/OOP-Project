using AzureBankDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.DL.DB
{
    public class UserFuncDB : IUserFunc
    {
        public int CheckPortfolio(string userName)
        {
            Program.connection.Open();
            int cash = 0;
            string query = $"SELECT cash FROM Users WHERE name = '{userName}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cash = Convert.ToInt32(reader["cash"]);
            }
            Program.connection.Close();
            return cash;
        }
        public void DepositCash(string userName, int amount)
        {
            int cash = CheckPortfolio(userName);
            cash += amount;

            Program.connection.Open();
            string query = $"UPDATE Users SET cash = {cash} WHERE name = '{userName}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
        }
        public void WithdrawCash(string userName, int amount)
        {
            int cash = CheckPortfolio(userName);
            cash -= amount;

            Program.connection.Open();
            string query = $"UPDATE Users SET cash = {cash} WHERE name = '{userName}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
        }
        public void TransferCash(string sender, string reciever, int amount)
        {
            WithdrawCash(sender, amount);
            DepositCash(reciever, amount);
        }
    }
}
