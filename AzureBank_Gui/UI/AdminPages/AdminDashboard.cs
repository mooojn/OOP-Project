using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBank.Utils;
using AzureBankDLL.BL;
using AzureBankGui;

namespace AzureBank
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void cashAmount_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            int totalCash = 0;
            int totalUsers = 0; 
            List<Asset> assets = ObjectHandler.GetAssetDL().ReadAll();
            List<User> users = ObjectHandler.GetUserDL().ReadAll();

            // calculate total cash available in the bank
            assets.ForEach(a => totalCash += a.getWorth());
            users.ForEach(u => totalCash += u.getCash());

            totalUsers = users.Count;
            
            cashAmount.Text = totalCash.ToString();
            userAmount.Text = totalUsers.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Common.ChangePassword(AdminPage.admin);
        }
    }
}
