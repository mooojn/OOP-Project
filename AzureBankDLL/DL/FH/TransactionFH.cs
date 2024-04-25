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
        internal static string fileName;
        private static TransactionFH instance = null;
        private TransactionFH(string file)
        {
            fileName = file;
        }
        public static TransactionFH getInstance(string fileName)
        {
            if (instance == null)
                instance = new TransactionFH(fileName);
            return instance;
        }

        public bool Save(string name, History history)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    string line = $"{name},{history.getType()},{history.getAmount()},{history.getDate()}";

                    writer.WriteLine(line);
                }

                return true; // saving is successful
            }
            catch (Exception)
            {
                return false; // error occurs
            }
        }
        public List<History> ReadAll(string name)
        {
            List<History> history = new List<History>();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length >= 4 && parts[0] == name)
                        {
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
