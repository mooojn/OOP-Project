using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankDLL.BL;
using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using AzureBankDLL.DL;

namespace AzureBankGui
{
    public partial class Transact : Form
    {
        public Transact()
        {
            InitializeComponent();
            transferBoxPanel.Visible = false;
            goBackBtn.Visible = false;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            transPanel.Visible = true;
            transferBoxPanel.Visible = false;
            goBackBtn.Visible = false;
            transferBtn.Text = "Transfer";
            amountBox.Text = "";
            amountBox.Focus();
        }
        private void DepositFunc(object sender, EventArgs e)
        {
            int cash = Convert.ToInt32(amountBox.Text);
            int flag = UserPage.user.DepositCash(cash);
            if (flag == 0)
            {
                MessageUi.ShowMessage("Success", "Cash has been deposited successfully", MessageDialogIcon.Information);
                //UserDL.UpdateInfo(UserPage.user);
            }
            else if (flag == -1)
                MessageUi.NegativeAmountError("Deposit");
            else if (flag == -2)
                MessageUi.ZeroAmountError("Deposit");
            else
                MessageUi.UnexpectedError();
        }

        private void WithdrawFunc(object sender, EventArgs e)
        {
            int cash = Convert.ToInt32(amountBox.Text);
            int flag = UserPage.user.WithdrawCash(cash);
            if (flag == 0)
            {
                MessageUi.ShowMessage("Success", "Cash Withdrawal was successful", MessageDialogIcon.Information);
                //UserDL.UpdateInfo(UserPage.user);
            }
            else if (flag == -1)
                MessageUi.NegativeAmountError("Withdraw");
            else if (flag == -2)
                MessageUi.ZeroAmountError("Withdraw");
            else if (flag == -3)
                MessageUi.ShowMessage("Out of Balance", "Withdraw amount was greater than the balance of the Account");
            else
                MessageUi.UnexpectedError();
        }

        private void TransferFunc(object sender, EventArgs e)
        {
            if (transferBtn.Text == "Transfer")
            {
                goBackBtn.Visible = true;
                transPanel.Visible = false;
                transferBoxPanel.Visible = true;
                transferBtn.Text = "Transfer Now";
                transferName.Focus();
            }
            else if (transferBtn.Text == "Transfer Now")
            {
                int cash = Convert.ToInt32(amountBox.Text);

                //User user = UserDL.GetUserFromName(transferName.Text);
                //if (user == null)
                //{
                //    MessageUi.ShowMessage("Invalid User", "User not found in the database");
                //    return;
                //}

                //int flag = UserPage.user.TransferCash(user, cash);
                int flag = 1; /// removeee
                if (flag == 0)
                {
                    MessageUi.ShowMessage("Success", $"Cash has been Transfered to {transferName.Text}", MessageDialogIcon.Information);
                    //UserDL.UpdateInfo(UserPage.user);  // Update the user info who is sending the money
                    //UserDL.UpdateInfo(user);          // Update the user info who is receiving the money
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
        }
    }
}
