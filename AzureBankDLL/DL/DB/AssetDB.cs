using AzureBankDLL.BL;
using AzureBankDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.DL.DB
{
    public class AssetDB : IAsset
    {
        public bool Create(Asset asset) 
        {
            Program.connection.Open();
            string query = $"INSERT INTO Assets values('{asset.getName()}', {asset.getWorth()})";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.ExecuteNonQuery();
            Program.connection.Close();
            return true;
        }
        public List<Asset> ReadAll() 
        {
            Program.connection.Open();
            List<Asset> assets = new List<Asset>();
            string query = "SELECT * FROM Assets";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                string name = reader["name"].ToString();
                int worth = Convert.ToInt32(reader["worth"]);
                assets.Add(new Asset(name, worth));
            }
            Program.connection.Close();
            return assets;
        }
    }
}
