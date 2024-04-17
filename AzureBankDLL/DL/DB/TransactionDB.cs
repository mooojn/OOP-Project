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
    public class TransactionDB : ITransaction
    {
        private static TransactionDB instance = null;
        private TransactionDB() { }
        public static TransactionDB getInstance()
        {
            if (instance == null)
                instance = new TransactionDB();
            return instance;
        }
        public bool Save(string name, History history)
        {
            DataBase.openConnection();
            
            string query = $"INSERT INTO Transactions VALUES ('{name}', '{history.getType()}', {history.getAmount()}, @historyDate)";
            SqlCommand command = new SqlCommand(query, DataBase.connection);
            command.Parameters.AddWithValue("@historyDate", history.getDate());    // add date to the query
            command.ExecuteNonQuery();

            DataBase.closeConnection();
            return true;
        }
        public List<History> ReadAll(string name)
        {
            DataBase.openConnection();
            
            List<History> history = new List<History>();
            string query = $"SELECT * FROM Transactions WHERE userName = '{name}'";
            SqlCommand command = new SqlCommand(query, DataBase.connection);
            SqlDataReader reader = command.ExecuteReader();

            // read all transactions from db and add them to the list
            while (reader.Read())
            {
                string type = reader["type"].ToString();
                int amount = Convert.ToInt32(reader["amount"]);
                DateTime date = Convert.ToDateTime(reader["date"]);

                history.Add(new History(type, amount, date));
            }
            
            DataBase.closeConnection();
            return history;
        }
    }
}
