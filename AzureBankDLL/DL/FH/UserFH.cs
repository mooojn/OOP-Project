using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using System.IO;

namespace AzureBankDLL.DL.FH
{
    public class UserFH  : IUser           
    {
        private string fileName = "users.csv";
        private string tempFileName = "temp_users.csv";   // for updation and deletion
        public bool Create(User user)
        {
            try {
                // Open or create the file to write user information
                using (StreamWriter writer = new StreamWriter(fileName, true)) {
                    // Write user information to the file
                    writer.WriteLine($"{user.getName()}, {user.getPassword()}, 0, True");
                }
                return true; // Operation succeeded
            }
            catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Operation failed
            }
        }
        public User Read(string userName)
        {
            try {
                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        // Split the line by comma to extract user information
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();
                        int cash = int.Parse(parts[2].Trim());
                        bool transactionStatus = bool.Parse(parts[3].Trim());

                        // Check if the current line corresponds to the requested user
                        if (name == userName) {
                            return new User(name, pass, cash, transactionStatus);
                        }
                    }
                }
                // User not found
                return null;
            }
            catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public bool Update(User user)
        {
            try {
                

                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) {
                    // Open a temporary file to write updated user information
                    using (StreamWriter writer = new StreamWriter(tempFileName)) {
                        string line;
                        while ((line = reader.ReadLine()) != null) {
                            // Split the line by comma to extract user information
                            string[] parts = line.Split(',');
                            string name = parts[0].Trim();

                            // Check if the current line corresponds to the user being updated
                            if (name == user.getName()) {
                                // Write the updated user information to the temporary file
                                writer.WriteLine($"{user.getName()}, {user.getPassword()}, {user.getCash()}, {Convert.ToBoolean(user.getTransactionStatus())}");
                            }
                            else {
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
            catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Update failed
            }
        }
        public bool Delete(string userName)
        {
            try {
                

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
            catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Deletion failed
            }
        }
        public List<User> ReadAll()
        {
            List<User> users = new List<User>();

            try {

                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
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
            catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public int FindUser(User usr)
        {
            try {

                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        // Split the line by comma to extract user information
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        string pass = parts[1].Trim();

                        // Check if the current line corresponds to the user being searched for
                        if (name == usr.getName() && pass == usr.getPassword()) {
                            // If user is admin, return 1; otherwise, return 2
                            return name == "admin" ? 1 : 2;
                        }
                    }
                }
                // User not found
                return 0;
            }
            catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // Return -1 to indicate an error
            }
        }
        public bool UserNameExists(string name)
        {
            try {

                // Open the file to read user information
                using (StreamReader reader = new StreamReader(fileName)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        // Split the line by comma to extract user name
                        string[] parts = line.Split(',');
                        string userName = parts[0].Trim();

                        // Check if the current line corresponds to the user being searched for
                        if (userName == name) {
                            return true; // User name exists
                        }
                    }
                }

                // User name not found
                return false;
            }
            catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Return false to indicate an error
            }
        }
    }
}
