using AzureBankDLL.BL;
using AzureBankGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureBank
{
    public partial class ViewUsers : Form
    {
        
        public ViewUsers()
        {
            InitializeComponent();
        }
        private void ViewUsers_Load(object sender, EventArgs e)
        {
            List<User> users= ObjectHandler.GetUserDL().ReadAll();
            DataTable dt = new DataTable();
            
            // add columns to the table
            dt.Columns.Add("Name");
            dt.Columns.Add("Cash");
            dt.Columns.Add("Transaction Status");
            
            // add the users to the table
            foreach (User user in users)
                dt.Rows.Add(user.getName(), user.getCash(), user.getTransactionStatus());
            
            this.usersTable.Width = 450;
            this.usersTable.DataSource = dt;
        }
    }   
}
