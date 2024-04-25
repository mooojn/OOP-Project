using AzureBankDLL.BL;
using AzureBankDLL.DL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBank.Utils;
using AzureBankGui.Utils;

namespace AzureBankGui
{
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
            Common.LoadComboBox(transferNames, UserPage.user);
            Common.AttachEvents(this);     // for the animation on tab change
        }
        private void transferBtn_Click(object sender, EventArgs e)
        {
            
        }
        private void Transfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            UtilDL.transactionClose();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            addAmount(UserPage.user.getCash());
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
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            addAmount(500);
        }
        private void transferNames_SelectedIndexChanged(object sender, EventArgs e) {}
        private void Transfer_Load(object sender, EventArgs e) {}

        private void transactICON_Click(object sender, EventArgs e)
        {
            transactICON.ImageSize = new Size(32, 32);
            int cash = 0;
            if (!Validation.ConvertStringToVar(ref cash, amountBox.Text))
            {
                amountBox.Focus();
                return;      // conversion fails, return
            }
            if (string.IsNullOrEmpty(transferNames.Text))
            {
                transferNames.Focus();
                return;    // empty box for transfer name
            }

            User user = ObjectHandler.GetUserDL().Read(transferNames.Text);
            int flag = UserPage.user.TransferCash(user, cash);
            // if the transfer was successful
            if (flag == 0)
            {
                MessageUi.ShowMessage("Success", $"Cash has been Transfered to {transferNames.Text}", MessageDialogIcon.Information);

                // update the balance of the user who made the transfer
                ObjectHandler.GetUserDL().Update(UserPage.user);
                ObjectHandler.GetTransactionDL().Save(UserPage.user.getName(), new History("Withdraw", cash));

                // update the balance of the user who received the transfer
                ObjectHandler.GetUserDL().Update(user);
                ObjectHandler.GetTransactionDL().Save(user.getName(), new History("Deposit", cash));
            }
            // conditions for errors
            else if (flag == -1)
                MessageUi.NegativeAmountError("Transfer");
            else if (flag == -2)
                MessageUi.ZeroAmountError("Transfer");
            else if (flag == -3)
                MessageUi.ShowMessage("Out of Balance", "Transfer amount was greater than the balance of the Account");
            else
                MessageUi.UnexpectedError();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
