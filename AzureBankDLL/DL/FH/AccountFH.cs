using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using System.Management.Instrumentation;


namespace AzureBankDLL.DL.FH
{
    public class AccountFH : IAccount
    {

        internal static string fileName;
        private static AccountFH instance = null;
        private AccountFH(string file)
        {
            fileName = file;
        }
        public static AccountFH getInstance(string fileName)
        {
            if (instance == null)
                instance = new AccountFH(fileName);
            return instance;
        }


        public bool Create(Account account)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{account.getNumber()},{account.getHolderName()},{account.getBalance()}");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Account Read(string name)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[1] == name)
                        {
                            string number = parts[0];
                            string holderName = parts[1];
                            int balance = int.Parse(parts[2]);

                            if (number.Contains("CUR"))
                                return new CurrentAccount(number, holderName, balance);
                            else
                                return new SavingAccount(number, holderName, balance);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public bool Update(Account account)
        {
            try
            {
                string tempFile = Path.GetTempFileName();
                using (StreamReader reader = new StreamReader(fileName))
                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[0] == account.getNumber())
                        {
                            writer.WriteLine($"{account.getNumber()},{account.getHolderName()},{account.getBalance()}");
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                File.Delete(fileName);
                File.Move(tempFile, fileName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
