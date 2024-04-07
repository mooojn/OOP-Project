using AzureBankDLL.BL;
using AzureBankDLL.DL;
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

namespace AzureBank
{
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }
        private void addAmount(int amount)
        {
            amountBox.Text = amount.ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addAmount(50);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            addAmount(100);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            addAmount(150);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            addAmount(200);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            addAmount(500);
        }

        private void transferBtn_Click(object sender, EventArgs e)
        {
            int cash = Convert.ToInt32(amountBox.Text);

            User user = UserDL.GetUserFromName(transferName.Text);
            if (user == null)
            {
                MessageUi.ShowMessage("Invalid User", "User not found in the database");
                return;
            }

            int flag = UserPage.user.TransferCash(user, cash);
            if (flag == 0)
            {
                MessageUi.ShowMessage("Success", $"Cash has been Transfered to {transferName.Text}", MessageDialogIcon.Information);
                UserDL.UpdateInfo(UserPage.user);  // Update the user info who is sending the money
                UserDL.UpdateInfo(user);          // Update the user info who is receiving the money
            }
            else if (flag == -1)
                MessageUi.NegativeAmountError("Transfer");
            else if (flag == -2)
                MessageUi.ZeroAmountError("Transfer");
            else if (flag == -3)
                MessageUi.ShowMessage("Out of Balance", "Transfer amount was greater than the balance of the Account");
            else
                MessageUi.UnexpectedError();
        }

        private void Transfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UtilDL.openChildForm(new Main(new Form(), Main.panel), Main.panel);
            UtilDL.transactionClose();
        }
    }
}
