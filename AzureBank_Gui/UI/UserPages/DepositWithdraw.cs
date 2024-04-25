using AzureBankDLL.BL;
using AzureBankDLL.DL;
using AzureBankGui.Utils;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBank.Utils;

namespace AzureBankGui
{
    public partial class DepositWithdraw : Form
    {
        public DepositWithdraw()
        {
            InitializeComponent();
            Common.AttachEvents(this);     // for the animation on tab change
        }
        
        private void addAmount(int amount)
        {
            amountBox.Text = amount.ToString();
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
            UtilDL.transactionClose();
        }
        private void transactICON_Click(object sender, EventArgs e)
        {
            transactICON.ImageSize = new Size(32, 32);
            int cash = 0;
            if (!Validation.ConvertStringToVar(ref cash, amountBox.Text))
            {
                amountBox.Focus();
                return;      // if the conversion fails, return
            }
            int flag = UserPage.user.DepositCash(cash);
            // if the deposit was successful
            if (flag == 0)
            {
                MessageUi.ShowMessage("Success", "Cash has been deposited successfully", MessageDialogIcon.Information);
                ObjectHandler.GetUserDL().Update(UserPage.user);
                ObjectHandler.GetTransactionDL().Save(UserPage.user.getName(), new History("Deposit", cash));
            }
            // conditions for errors
            else if (flag == -1)
                MessageUi.NegativeAmountError("Deposit");
            else if (flag == -2)
                MessageUi.ZeroAmountError("Deposit");
            else
                MessageUi.UnexpectedError();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            guna2ImageButton1.ImageSize = new Size(32, 32);
            int cash = 0;
            if (!Validation.ConvertStringToVar(ref cash, amountBox.Text))
            {
                amountBox.Focus();
                return;      // if the conversion fails, return
            }
            int flag = UserPage.user.WithdrawCash(cash);
            // if the withdrawal was successful
            if (flag == 0)
            {
                MessageUi.ShowMessage("Success", "Cash Withdrawal was successful", MessageDialogIcon.Information);
                ObjectHandler.GetUserDL().Update(UserPage.user);
                ObjectHandler.GetTransactionDL().Save(UserPage.user.getName(), new History("Withdraw", cash));
            }
            // conditions for errors
            else if (flag == -1)
                MessageUi.NegativeAmountError("Withdraw");
            else if (flag == -2)
                MessageUi.ZeroAmountError("Withdraw");
            else if (flag == -3)
                MessageUi.ShowMessage("Out of Balance", "Withdraw amount was greater than the balance of the Account");
            else
                MessageUi.UnexpectedError();
        }
        private void DepositWithdraw_Load(object sender, EventArgs e) {}
        private void DepositFunc(object sender, EventArgs e)
        {
            
        }
        private void WiithdrawFunc(object sender, EventArgs e)
        {
            
        }
    }
}
