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
        private static AssetDB instance = null;
        private AssetDB() { }
        public static AssetDB getInstance()
        {
            if (instance == null)
                instance = new AssetDB();
            return instance;
        }
        public bool Create(Asset asset) 
        {
            DataBase.openConnection();
            
            string query = $"INSERT INTO Assets values('{asset.getName()}', {asset.getWorth()})";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            cmd.ExecuteNonQuery();
            
            DataBase.connection.Close();
            return true;
        }
        public List<Asset> ReadAll() 
        {
            DataBase.openConnection();
            
            List<Asset> assets = new List<Asset>();
            string query = "SELECT * FROM Assets";
            SqlCommand cmd = new SqlCommand(query, DataBase.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            
            // read all assets from db and add them to the list
            while (reader.Read()) 
            {
                string name = reader["name"].ToString();
                int worth = Convert.ToInt32(reader["worth"]);

                assets.Add(new Asset(name, worth));
            }
            
            DataBase.connection.Close();
            return assets;
        }
    }
}
