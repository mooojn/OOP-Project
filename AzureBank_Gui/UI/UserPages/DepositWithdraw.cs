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

namespace AzureBankGui
{
    public partial class DepositWithdraw : Form
    {
        public DepositWithdraw()
        {
            InitializeComponent();
        }
        private void addAmount(int amount)
        {
            amountBox.Text = amount.ToString();
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

        private void WiithdrawFunc(object sender, EventArgs e)
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
        public void fifty(object sender, EventArgs e)
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

        private void DepositWithdraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UtilDL.openChildForm(new Main(new Form(), Main.panel), Main.panel);
            UtilDL.transactionClose();
        }

        private void DepositWithdraw_Load(object sender, EventArgs e)
        {

        }
    }
}
