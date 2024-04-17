using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using System.IO;
using System.Windows.Forms.Design;

namespace AzureBankDLL.DL.FH
{
    public class AssetFH : IAsset
    {
        internal static string fileName;
        private static AssetFH instance = null;
        private AssetFH(string file)
        {
            fileName = file;
        }
        public static AssetFH getInstance(string fileName)
        {
            if (instance == null)
                instance = new AssetFH(fileName);
            return instance;
        }
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
            catch (IOException)
            {
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
            catch (IOException)
            {
                return assets;
            }
            return assets;
        }
    }
}
