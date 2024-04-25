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
using PassHashingWithSaltsDLL;

namespace AzureBankDLL.DL.DB
{
    public class UserDB : IUser
    {
        private static UserDB instance = null;
        private UserDB() { }
        public static UserDB getInstance()
        {
            if (instance == null)
                instance = new UserDB();
            return instance;
        }

        public bool Create(User user)
        {
            DataBase.openConnection();

            string query = $"INSERT INTO Users VALUES ('{user.getName()}', '{user.getPassword()}', 1, 1)";    // 0 cash, 1 transactionStatus
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            cmd.ExecuteNonQuery();

            DataBase.closeConnection();
            return true;
        }
        public User Read(string userName)
        {
            DataBase.openConnection();
         
            string query = $"SELECT * FROM Users WHERE name = '{userName}'";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            
            // creating user object if found
            User user = null;
            if (reader.Read())
            {
                string name = reader["name"].ToString();
                string pass = reader["password"].ToString();
                int cash = Convert.ToInt32(reader["cash"]);
                bool transactionStatus = Convert.ToBoolean(reader["transactionStatus"]);
               
                user = new User(name, pass, cash, transactionStatus);
            }
            
            DataBase.closeConnection();
            return user;
        }
        public bool Update(User user)
        {
            DataBase.openConnection();
            
            string query = $"UPDATE Users SET cash = {user.getCash()}, password = '{user.getPassword()}', transactionStatus = {Convert.ToInt32(user.getTransactionStatus())} WHERE name = '{user.getName()}'";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            cmd.ExecuteNonQuery();
            
            DataBase.closeConnection();
            return true;
        }
        public bool Delete(string userName)
        {
            DataBase.openConnection();
            
            // deleting from all tables
            string query = $"DELETE FROM Users WHERE name = '{userName}'\n" +
                           $"DELETE FROM Transactions WHERE userName = '{userName}'" +
                           $"DELETE FROM Accounts WHERE userName = '{userName}'";
            
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            cmd.ExecuteNonQuery();
            
            DataBase.closeConnection();
            return true;
        }
        public List<User> ReadAll()
        {
            List<User> users = null;
            
            string query = "SELECT * FROM Users";
            DataBase.openConnection();
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (users == null)
                    users = new List<User>();
                if (reader["name"].ToString() == "admin")    // skipping admin
                    continue;
                
                string name = reader["name"].ToString();
                string pass = reader["password"].ToString();
                int cash = Convert.ToInt32(reader["cash"]);
                bool transactionStatus = Convert.ToBoolean(reader["transactionStatus"]);
                users.Add(new User(name, pass, cash, transactionStatus));
            }
            DataBase.closeConnection();
            return users;
        }
        public int FindUser(User usr)
        {
            DataBase.openConnection();
            
            bool flag = false;
            string query = $"SELECT * FROM Users WHERE name = '{usr.getName()}' AND password = '{usr.getPassword()}'";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            // user found
            if (reader.Read())
                flag = true;
            
            DataBase.closeConnection();
            // returning 1 if admin, 2 if user, 0 if invalid password
            if (flag) 
                return usr.getName() == "admin" ? 1 : 2;
            else
                return 0;     // zero means invalid password
        }
        public bool UserNameExists(string name)
        {
            DataBase.openConnection();
            
            bool flag = false;
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE name = '{name}'", DataBase.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            
            // checking if user exists
            if (reader.Read())
                flag = true;   // user found
            
            DataBase.closeConnection();
            return flag;
        }
        public List<string> ReadAllNames(string nameToExclude) 
        {
            DataBase.openConnection();
            
            List<string> userNames = new List<string>();
            string query = $"SELECT name FROM Users WHERE name != 'admin' AND name != '{nameToExclude}'";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                
                userNames.Add(name);
            }
            DataBase.closeConnection();
            return userNames;
        }
        // this func removes all of the data from all tables
        public void NUKE()
        {
            DataBase.openConnection();
            string query = "DELETE FROM Users DELETE FROM Transactions DELETE FROM Assets DELETE FROM Accounts";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            cmd.ExecuteNonQuery();
            DataBase.closeConnection();
        }
    }
}
