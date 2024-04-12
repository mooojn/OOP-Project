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
using System.Xml.Linq;

namespace AzureBankGui
{
    public partial class ViewHistory : Form
    {
        public ViewHistory()
        {
            InitializeComponent();
            List<History> history = ObjectHandler.GetTransactionDL().ReadAll(UserPage.user.getName());
            UserPage.user.setHistory(history);
        }

        private void ViewHIstory_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            // add columns to the table
            dt.Columns.Add("Type");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Date");

            // add the history of the user to the table
            foreach (History history in UserPage.user.getHistory())
                dt.Rows.Add(history.getType(), history.getAmount(), history.getDate());

            transactionHistory.DataSource = dt;
        }
        private void transactionHistory_CellContentClick(object sender, DataGridViewCellEventArgs e) {}
        private void guna2Button1_Click(object sender, EventArgs e) {}
        private void transactionHistory_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {}
    }
}
