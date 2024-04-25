using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using System.IO;
using PassHashingWithSaltsDLL;
using System.Runtime.Remoting.Messaging;
using System.Management.Instrumentation;

namespace AzureBankDLL.DL.FH
{
    public class UserFH  : IUser           
    {
        private string fileName;
        private string tempFileName = "temp_users.csv";   // for updation and deletion
        private static UserFH instance = null;
        private UserFH(string fileName)
        {
            this.fileName = fileName;
        }
        public static UserFH getInstance(string fileName)
        {
            if (instance == null)
                instance = new UserFH(fileName);
            return instance;
        }
        public bool Create(User user)
        {
            try 
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine($"{user.getName()}, {user.getPassword()}, 0, True");
                }
                return true; // success     :)
            }
            catch (Exception) 
            {
                return false; // failed     :(
            }
        }
        public User Read(string userName)
        {
            try 
            {
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();
                        int cash = int.Parse(parts[2].Trim());
                        bool transactionStatus = bool.Parse(parts[3].Trim());

                        // current line matches with param 
                        if (name == userName) 
                            return new User(name, pass, cash, transactionStatus);
                    }
                }
                return null;    // user not found
            }
            catch (Exception) {
                return null;
            }
        }
        public bool Update(User user)
        {
            try 
            {
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    using (StreamWriter writer = new StreamWriter(tempFileName)) 
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) 
                        {
                            string[] parts = line.Split(',');
                            string name = parts[0].Trim();

                            if (name == user.getName())
                                writer.WriteLine($"{user.getName()}, {user.getPassword()}, {user.getCash()}, {Convert.ToBoolean(user.getTransactionStatus())}");
                            else 
                                writer.WriteLine(line);
                        }
                    }
                }
                // replace og file with temp file
                File.Delete(fileName);
                File.Move(tempFileName, fileName);

                return true; // success
            }
            catch (Exception) 
            {
                return false; // failed
            }
        }
        public bool Delete(string userName)
        {
            try
            {
                string[] users = File.ReadAllLines(fileName);
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (string user in users)
                    {
                        string[] userInfo = user.Split(',');
                        if (userInfo[0] != userName)
                            writer.WriteLine(user);
                    }
                }
                string[] transactions = File.ReadAllLines(TransactionFH.fileName);
                using (StreamWriter writer = new StreamWriter(TransactionFH.fileName))
                {
                    foreach (string transaction in transactions)
                    {
                        string[] transactionInfo = transaction.Split(',');
                        if (transactionInfo[0] != userName)
                            writer.WriteLine(transaction);
                    }
                }
                string[] accounts = File.ReadAllLines(AccountFH.fileName);
                using (StreamWriter writer = new StreamWriter(AccountFH.fileName))
                {
                    foreach (string account in accounts)
                    {
                        string[] accountInfo = account.Split(',');
                        if (accountInfo[1] != userName)
                            writer.WriteLine(account);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }
        public List<User> ReadAll()
        {
            List<User> users = new List<User>();

            try 
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();
                        int cash = int.Parse(parts[2].Trim());
                        bool transactionStatus = bool.Parse(parts[3].Trim());

                        // skip admin user as no need to read it
                        if (name.Equals("admin", StringComparison.OrdinalIgnoreCase))
                            continue;

                        users.Add(new User(name, pass, cash, transactionStatus));
                    }
                }
                return users;
            }
            catch (Exception) 
            {
                return null;
            }
        }
        public int FindUser(User usr)
        {
            try 
            {
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();

                        // If user is admin, return 1; otherwise, return 2
                        if (name == usr.getName() && pass == usr.getPassword())
                            return name == "admin" ? 1 : 2;
                    }
                }
                return 0;   // not found
            }
            catch (Exception) 
            {
                return -1; // -1 to indicate an error
            }
        }
        public bool UserNameExists(string name)
        {
            try 
            {
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        string[] parts = line.Split(',');
                        string userName = parts[0].Trim();

                        if (userName == name) 
                            return true; // User name exists
                    }
                }
                return false;   // User name not found
            }
            catch (Exception) 
            {
                return false; // false to indicate an error
            }
        }
        public List<string> ReadAllNames(string nameToExclude)
        {
            List<string> userNames = new List<string>();

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0].Trim();

                    // skip the name if it's 'admin' or matches the name to exclude
                    if (name != "admin" && name != nameToExclude)
                        userNames.Add(name);
                }
            }
            else
                return null;
            return userNames;
        }
        // this func removes all of the data from all tables
        public void NUKE()
        {
            try 
            {
                // Delete all the file
                File.Delete(fileName);
                File.Delete(tempFileName);
                File.Delete(TransactionFH.fileName);
                File.Delete(AssetFH.fileName);
                File.Delete(AccountFH.fileName);
            }
            catch (Exception) 
            {
                return;
            }
        }
    }
}
