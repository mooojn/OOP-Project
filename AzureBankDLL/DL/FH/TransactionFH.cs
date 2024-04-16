using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;

namespace AzureBankDLL.DL.FH
{
    public class TransactionFH : ITransaction
    {
        public static string fileName = "transactions.csv";
        public bool Save(string name, History history)
        {
            try
            {
                // Open the file in append mode
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    // Format the data as a CSV line
                    string line = $"{name},{history.getType()},{history.getAmount()},{history.getDate()}";

                    // Write the line to the file
                    writer.WriteLine(line);
                }

                return true; // Return true if saving is successful
            }
            catch (Exception)
            {
                return false; // Return false if an error occurs
            }
        }
        public List<History> ReadAll(string name)
        {
            List<History> history = new List<History>();

            try
            {
                // Open the file for reading
                using (StreamReader reader = new StreamReader(fileName))
                {
                    // Read each line from the file
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into parts using comma as the delimiter
                        string[] parts = line.Split(',');

                        // Check if the first part matches the provided name
                        if (parts.Length >= 4 && parts[0] == name)
                        {
                            // Extract data from parts and create a History object
                            string type = parts[1];
                            int amount = int.Parse(parts[2]);
                            DateTime date = DateTime.Parse(parts[3]);

                            history.Add(new History(type, amount, date));
                        }
                    }
                }
            }
            catch (Exception)
            {
                return history;
            }
            return history;
        }
    }
}
