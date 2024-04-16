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

namespace AzureBankDLL.DL.FH
{
    public class UserFH  : IUser           
    {
        private string fileName = "users.csv";
        private string tempFileName = "temp_users.csv";   // for updation and deletion
        public bool Create(User user)
        {
            try 
            {
                // Open or create the file to write user information
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    // Write user information to the file
                    writer.WriteLine($"{user.getName()}, {user.getPassword()}, 0, True");
                }
                return true; // Operation succeeded
            }
            catch (Exception) 
            {
                return false; // Operation failed
            }
        }
        public User Read(string userName)
        {
            try 
            {
                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        // Split the line by comma to extract user information
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();
                        int cash = int.Parse(parts[2].Trim());
                        bool transactionStatus = bool.Parse(parts[3].Trim());

                        // Check if the current line corresponds to the requested user
                        if (name == userName) 
                        {
                            return new User(name, pass, cash, transactionStatus);
                        }
                    }
                }
                // User not found
                return null;
            }
            catch (Exception) {
                return null;
            }
        }
        public bool Update(User user)
        {
            try 
            {
                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    // Open a temporary file to write updated user information
                    using (StreamWriter writer = new StreamWriter(tempFileName)) 
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) 
                        {
                            // Split the line by comma to extract user information
                            string[] parts = line.Split(',');
                            string name = parts[0].Trim();

                            // Check if the current line corresponds to the user being updated
                            if (name == user.getName())
                            {
                                // Write the updated user information to the temporary file
                                writer.WriteLine($"{user.getName()}, {user.getPassword()}, {user.getCash()}, {Convert.ToBoolean(user.getTransactionStatus())}");
                            }
                            else 
                            {
                                // Write the unchanged user information to the temporary file
                                writer.WriteLine(line);
                            }
                        }
                    }
                }
                // Replace the original file with the temporary file
                File.Delete(fileName);
                File.Move(tempFileName, fileName);

                return true; // Update succeeded
            }
            catch (Exception) 
            {
                return false; // Update failed
            }
        }
        public bool Delete(string userName)
        {
            try 
            {
                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName))
                {
                    // Open a temporary file to write user information excluding the user to delete
                    using (StreamWriter writer = new StreamWriter(tempFileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Split the line by comma to extract user information
                            string[] parts = line.Split(',');
                            string name = parts[0].Trim();

                            // Check if the current line corresponds to the user being deleted
                            if (name != userName)
                            {
                                // Write the user information (excluding the user to delete) to the temporary file
                                writer.WriteLine(line);
                            }
                        }
                    }
                }
                // Replace the original file with the temporary file
                File.Delete(fileName);
                File.Move(tempFileName, fileName);

                return true; // Deletion succeeded
            }
            catch (Exception) 
            {
                return false; // Deletion failed
            }
        }
        public List<User> ReadAll()
        {
            List<User> users = new List<User>();

            try 
            {
                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        // Split the line by comma to extract user information
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();
                        int cash = int.Parse(parts[2].Trim());
                        bool transactionStatus = bool.Parse(parts[3].Trim());

                        // Skip admin user if needed
                        if (name.Equals("admin", StringComparison.OrdinalIgnoreCase))
                            continue;

                        // Add the user to the list
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
                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line by comma to extract user information
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();

                        // Check if the current line corresponds to the user being searched for
                        if (name == usr.getName() && pass == usr.getPassword())
                        {
                            // If user is admin, return 1; otherwise, return 2
                            return name == "admin" ? 1 : 2;
                        }
                    }
                }
                // User not found
                return 0;
            }
            catch (Exception) 
            {
                return -1; // Return -1 to indicate an error
            }
        }
        public bool UserNameExists(string name)
        {
            try 
            {
                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        // Split the line by comma to extract user name
                        string[] parts = line.Split(',');
                        string userName = parts[0].Trim();

                        // Check if the current line corresponds to the user being searched for
                        if (userName == name) 
                        {
                            return true; // User name exists
                        }
                    }
                }
                // User name not found
                return false;
            }
            catch (Exception) 
            {
                return false; // Return false to indicate an error
            }
        }
        public List<string> ReadAllNames(string nameToExclude)
        {
            List<string> userNames = new List<string>();

            // Check if the file exists
            if (File.Exists(fileName))
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(fileName);

                // Iterate through each line
                foreach (string line in lines)
                {
                    // Split the line by comma (assuming CSV format) and get the name from the 0th index
                    string[] parts = line.Split(',');
                    string name = parts[0].Trim();

                    // Skip the name if it's 'admin' or matches the name to exclude
                    if (name != "admin" && name != nameToExclude)
                    {
                        userNames.Add(name);
                    }
                }
            }
            else
            {
                return null;
            }
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
