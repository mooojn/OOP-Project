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
            Common.AttachEvents(this);    // for the animation on tab change
        }
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // vars to display
            int totalCash = 0;
            int userFunds= 0;
            int assetFunds = 0;
            int totalUsers = 0;
            
            List<Asset> assets = ObjectHandler.GetAssetDL().ReadAll();
            List<User> users = ObjectHandler.GetUserDL().ReadAll();

            // calculate total cash available in the bank
            assets.ForEach(a => assetFunds += a.getWorth());
            if (users != null) { 
                users.ForEach(u => userFunds += u.getCash());
                totalUsers = users.Count;
            }

            totalCash = userFunds + assetFunds;
            
            //  display the data
            totalLiq.Text = totalCash.ToString();
            userAmount.Text = totalUsers.ToString();
            userLiq.Text = userFunds.ToString();
            assetLiq.Text = assetFunds.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Common.ChangePassword(AdminPage.admin);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // All of the data will be deleted
            AuthPromptForm auth = new AuthPromptForm(AdminPage.admin);
            DialogResult result = auth.ShowDialog();
            if (result == DialogResult.OK) { 

                ObjectHandler.GetUserDL().NUKE();
                MessageUi.ShowMessage("Nuked", "The database have been Nuked");
                Application.Exit();
            }
        }
        private void cashAmount_Click(object sender, EventArgs e) {}
    }
}
