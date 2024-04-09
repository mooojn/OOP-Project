using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankDLL.DL;

namespace AzureBankGui
{
    public partial class ViewHistory : Form
    {
        public ViewHistory()
        {
            InitializeComponent();
            List<History> history = LoadHistory(UserPage.user.getName());
            UserPage.user.setHistory(history);
        }

        private void ViewHIstory_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Type");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Date");


            foreach (History history in UserPage.user.getHistory())
            {
                dt.Rows.Add(history.getType(), history.getAmount(), history.getDate());
            }
            transactionHistory.DataSource = dt;
        }

        private void transactionHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<History> LoadHistory(string name)
        {
            //return HistoryDL.LoadTransactionHistory(name);
            return null;      /// removeevev
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();

            //dt.Columns.Add("Type");
            //dt.Columns.Add("Amount");
            //dt.Columns.Add("Date");

            //foreach (History history in UserPage.user.getHistory())
            //{
            //    dt.Rows.Add(history.getType(), history.getAmount(), history.getDate());
            //}
            //transactionHistory.DataSource = dt;
        }
    }
}
