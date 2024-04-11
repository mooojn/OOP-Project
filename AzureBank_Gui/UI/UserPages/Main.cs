using AzureBank.Utils;
using AzureBankDLL.BL;
using AzureBankDLL.DL;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureBankGui
{
    public partial class Main : Form
    {

        public static Guna2Panel panel;
        public static Form userPage;
        public Main(Form f, Guna2Panel mainPanel)
        {
            InitializeComponent();
            Common.AttachEvents(this);     // for the animation on tab change

            cashAmount.Text = UserPage.user.getCash().ToString();
            
            panel = mainPanel;
            userPage = f;

            string msg = !UserPage.user.getTransactionStatus() ? "Enable" : "Disable";
            guna2Button3.Text = $"{msg} Transactions";
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (!UserPage.user.getTransactionStatus()) 
            {
                MessageUi.ShowMessage("Transaction Disabled", "Can not make a transaction", MessageDialogIcon.Warning);
                return;
            }
            Form f = new DepositWithdraw();
            f.Show();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            if (!UserPage.user.getTransactionStatus())
            {
                MessageUi.ShowMessage("Transaction Disabled", "Can not make a transaction", MessageDialogIcon.Warning);
                return;
            }
            Form f = new Transfer();
            f.Show();
        }
        private void transactionHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AuthPromptForm promptForm = new AuthPromptForm(UserPage.user);
            DialogResult result = promptForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                //MessageBox.Show("Account deleted successfully.");
                ObjectHandler.GetUserDL().Delete(UserPage.user.getName());  // remove from the dataBase 
                UtilDL.LogOut(userPage);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Common.ChangePassword(UserPage.user);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            bool flag = !UserPage.user.getTransactionStatus();  // toggling the status
            UserPage.user.setTransactionStatus(flag);
            ObjectHandler.GetUserDL().Update(UserPage.user);
            
            string msg = !flag ? "Enable" : "Disable";
            guna2Button3.Text = $"{msg} Transactions";
        }
    }
}
