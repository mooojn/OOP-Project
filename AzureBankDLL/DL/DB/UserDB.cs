using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Xml.Linq;
using AzureBankDLL.BL;
using AzureBankDLL.DL.FH;
using AzureBankDLL.DLInterfaces;
using AzureBankDLL.Util;
using PassHashingWithSaltsDLL;

namespace AzureBankDLL.DL.DB
{
    public class UserDB : IUser
    {
        public bool Create(User user)
        {
            // insert vals into db
            Program.connection.Open();
            //string salt = Hashing.GenerateSalt();
            //string hashedPass = Hashing.ComputeSha256Hash(user.getPassword(), salt);
            string query = $"INSERT INTO Users VALUES ('{user.getName()}', '{user.getPassword()}', 0, 1)";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            return true;
        }
        public User Read(string userName)
        {
            Program.connection.Open();
            string query = $"SELECT * FROM Users WHERE name = '{userName}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            User user = null;
            if (reader.Read())
            {
                string name = reader["name"].ToString();
                string pass = reader["password"].ToString();
                int cash = Convert.ToInt32(reader["cash"]);
                bool transactionStatus = Convert.ToBoolean(reader["transactionStatus"]);
                user = new User(name, pass, cash, transactionStatus);
            }
            Program.connection.Close();
            return user;
        }
        public bool Update(User user)
        {
            Program.connection.Open();
            string query = $"UPDATE Users SET cash = {user.getCash()}, password = '{user.getPassword()}', transactionStatus = {Convert.ToInt32(user.getTransactionStatus())} WHERE name = '{user.getName()}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            return true;
        }
        public bool Delete(string userName)
        {
            Program.connection.Open();
            // deleting from both tables
            string query = $"DELETE FROM Users WHERE name = '{userName}'\n" +
                $"DELETE FROM Transactions WHERE userName = '{userName}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            return true;
        }
        public List<User> ReadAll()
        {
            List<User> users = null;
            string query = "SELECT * FROM Users";
            Program.connection.Open();
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();      // skipping admin
            while (reader.Read())
            {
                if (users == null)
                    users = new List<User>();
                string name = reader["name"].ToString();
                string pass = reader["password"].ToString();
                int cash = Convert.ToInt32(reader["cash"]);
                bool transactionStatus = Convert.ToBoolean(reader["transactionStatus"]);
                users.Add(new User(name, pass, cash, transactionStatus));
            }
            Program.connection.Close();
            return users;
        }
        public int FindUser(User usr)
        {
            bool flag = false;
            Program.connection.Open();
            string query = $"SELECT * FROM Users WHERE name = '{usr.getName()}' AND password = '{usr.getPassword()}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                flag = true;
            }
            Program.connection.Close();
            if (flag) {
                return usr.getName() == "admin" ? 1 : 2;
            }
            else
                return 0;     // zero means invalid password
        }
        public bool UserNameExists(string name)
        {
            bool flag = false;
            Program.connection.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE name = '{name}'", Program.connection);

            SqlDataReader reader = cmd.ExecuteReader();
            // checking if user exists
            if (reader.Read())
            {
                flag = true;   // user found
            }
            Program.connection.Close();
            return flag;
        }
        public List<string> ReadAllNames(string nameToExclude) 
        {
            Program.connection.Open();
            
            List<string> userNames = new List<string>();

            string query = $"SELECT name FROM Users WHERE name != 'admin' AND name != '{nameToExclude}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                
                userNames.Add(name);
            }
            Program.connection.Close();

            return userNames;
        }
    }
}
