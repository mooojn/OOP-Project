using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using System.IO;

namespace AzureBankDLL.DL.FH
{
    public class AssetFH : IAsset
    {
        public string fileName = "assets.csv";
        public bool Create(Asset asset)
        {
            try
            {
                // Open the file for appending
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    // Write asset information to the file
                    writer.WriteLine($"{asset.getName()}, {asset.getWorth()}");
                }
                return true; // Successfully written
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while writing to the file: {e.Message}");
                return false; // Failed to write
            }
        }
        public List<Asset> ReadAll()
        {
            List<Asset> assets = new List<Asset>();
            try
            {
                // Open the file for reading
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    // Read each line until the end of the file
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into name and worth
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string name = parts[0].Trim();
                            int worth = int.Parse(parts[1].Trim());
                            assets.Add(new Asset(name, worth));
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
            return assets;
        }
    }
}
