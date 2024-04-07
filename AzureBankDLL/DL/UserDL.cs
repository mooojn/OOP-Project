using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Guna.UI2.WinForms;
using AzureBankDLL.BL;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using AzureBankDLL.Util;
using System.Windows.Forms;


namespace AzureBankDLL.DL
{
    public class UserDL
    {
        public static List<User> users = new List<User>();
        public static void LoadUsers()
        {
            Program.connection.Open();

            string query = "SELECT * FROM Users"; 
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string pass = reader["password"].ToString();
                int cash = Convert.ToInt32(reader["cash"]);
                
                
                //List<History> history = HistoryDL.GetTransactionHistory(name);
                //User user = new User(name, pass, cash, history);

                User user = new User(name, pass, cash);

                users.Add(user);
            }
            Program.connection.Close();
        }
        public static void UpdateInfo(User user)
        {
            Program.connection.Open();
            string query = $"UPDATE Users SET cash = {user.getCash()}, password = '{user.getPassword()}' WHERE name = '{user.getName()}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
        }
        public static bool SignUp(User user)
        {
            if (UserExists(user.getName()))
            {
                MessageUi.ShowMessage("User Exists", "User with this user name already exists\nPlease use a different user name");
                return false;
            }
            users.Add(user);
            // insert vals into db
            string query = $"INSERT INTO Users VALUES ('{user.getName()}', '{user.getPassword()}', 0)";
            SqlCommand cmd = new SqlCommand(query, Program.connection);

            return ExecuteNonQuery(cmd, "Error while signing up...");
        }
        
        public static int CredentialsValid(User user)
        {
            if (!UserDL.UserExists(user.getName()))
            {
                MessageUi.ShowMessage("User Not Found", "User with this user name does not exist\nPlease Register your account first");
                return -2;
            }
            int i = 0;
            foreach (User usr in users)
            {
                if (usr.getName() == user.getName() && usr.getPassword() == user.getPassword())
                    return i;      // index of user found
                i++;
            }
            return -1;

            

            //// from db
            ///
            //int id = -1;
            //Program.connection.Open();

            //string query = $"SELECT * FROM Users WHERE name = '{name}' AND password = '{pass}'";

            //SqlCommand cmd = new SqlCommand(query, Program.connection);

            //SqlDataReader reader = cmd.ExecuteReader();

            //if (reader.Read()) {
            //    id = Convert.ToInt32(reader["id"]);  // setting current user id
            //}
            //Program.connection.Close();

            //return id;
        }
        public static User GetUserFromName(string name)
        {
            foreach (User usr in users)
                if (usr.getName() == name)
                    return usr;
            return null;






            //User user = null;
            //Program.connection.Open();

            //string query = $"SELECT * FROM Users WHERE id = {id}";

            //SqlCommand cmd = new SqlCommand(query, Program.connection);

            //SqlDataReader reader = cmd.ExecuteReader();

            //if (reader.Read())
            //{
            //    int cash = 0;
            //    string name = reader["name"].ToString();
            //    string pass = reader["password"].ToString();
            //    if (id != 1)
            //    {
            //        cash = Convert.ToInt32(reader["cash"]);
            //    }
            //    user = new User(name, pass, cash);
            //}
            //Program.connection.Close();


            //return user;
        }
        public static bool UserExists(string name)
        {
            return users.Any(user => user.getName() == name);



            /// from db
            
            //bool flag = false;
            //Program.connection.Open();
            //SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE name = '{name}'", Program.connection);

            //SqlDataReader reader = cmd.ExecuteReader();
            //// checking if user exists
            //if (reader.Read())
            //{
            //    flag = true;
            //}
            //Program.connection.Close();
            //return flag;
        }
        public static bool ExecuteNonQuery(SqlCommand command, string errorMessage)
        {
            bool flag = true;
            Program.connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageUi.ShowMessage("Error", errorMessage + "\n" + e.Message);
                flag = false;   // error generated
            }
            Program.connection.Close();
            return flag;
        }
        public static void DeleteUser(string name)
        {
            Program.connection.Open();
            // deleting from both tables
            string query = $"DELETE FROM Users WHERE name = '{name}'\n" +
                $"DELETE FROM Transactions WHERE userName = '{name}'";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
        }
        public static bool ValidateIndex(int indexToValidate)
        {
            return false;
        }
    }
}
