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
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{asset.getName()}, {asset.getWorth()}");
                }
                return true; // successfully written    :)
            }
            catch (IOException)
            {
                return false; // failed to write   :{
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
                    while ((line = reader.ReadLine()) != null)
                    {
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
