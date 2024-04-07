using AzureBankDLL.BL;
using AzureBankDLL.DL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBank
{
    public class HistoryACC
    {       
        public static DataTable Load()
        {
            UserPage.user.setHistory(HistoryDL.LoadTransactionHistory(UserPage.user.getName()));
            
            DataTable dt = new DataTable();

            dt.Columns.Add("Type");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Date");


            foreach (History history in UserPage.user.getHistory())
            {
                dt.Rows.Add(history.getType(), history.getAmount(), history.getDate());
            }
            //transactionHistory.DataSource = dt;
            return dt;
        }
    }
}
