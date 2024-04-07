using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.BL;
using System.Data.SqlClient;

namespace AzureBankDLL.DL
{
    public class HistoryDL
    {
        public static List<History> LoadTransactionHistory(string name)
        {
            Program.connection.Open();
            List<History> history = new List<History>();   
            string query = $"SELECT * FROM Transactions WHERE userName = '{name}'";
            SqlCommand command = new SqlCommand(query, Program.connection);
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string type = reader["type"].ToString();
                int amount = Convert.ToInt32(reader["amount"]);
                DateTime date = Convert.ToDateTime(reader["date"]);
                
                history.Add(new History(type, amount, date));
            }
            Program.connection.Close();
            return history;
        }
        public static void SaveTransactionHistory(string name, History history)
        {
            Program.connection.Open();
            string query = "INSERT INTO Transactions VALUES (@name, @type, @amount, @date)";
            SqlCommand command = new SqlCommand(query, Program.connection);
            
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@type", history.getType());
            command.Parameters.AddWithValue("@amount", history.getAmount());
            command.Parameters.AddWithValue("@date", history.getDate());
            
            command.ExecuteNonQuery();

            Program.connection.Close();
        }
        
    }
}
