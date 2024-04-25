using AzureBankDLL.BL;
using AzureBankDLL.DL.DB;
using AzureBankDLL.DLInterfaces;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using AzureBankGui.Utils;
using Guna.UI2.WinForms;
using AzureBankDLL.DL.FH;
using Guna.UI2.AnimatorNS;


namespace AzureBank
{
    public partial class ViewAccount : Form
    {
        Account acc = UserPage.user.getAccount();
        public ViewAccount()
        {
            InitializeComponent();
            header.Text = acc.getType();
        }

        private void ViewAccount_Load(object sender, EventArgs e)
        {
            balance.Text = Convert.ToString(acc.getBalance());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void transactICON_Click(object sender, EventArgs e)
        {
            transactICON.ImageSize = new Size(32, 32);
            int amount = 0;
            Validation.ConvertStringToVar(ref amount, cashBox.Text);
            if (!Validation.ValidDepositAmount(amount))
            {
                cashBox.Focus();
                return;
            }

            int status = UserPage.user.getAccount().Deposit(amount);
            // err msgs
            if (status == -1)
                MessageUi.ShowMessage("Error", "Invalid Amount", MessageDialogIcon.Warning);
            else if (status == -2)
                MessageUi.ShowMessage("Error", "Deposit Amount can't be Zero", MessageDialogIcon.Warning);
            else if (status == -3)
            {
                cashBox.Focus();
                MessageUi.ShowMessage("Error", "Account can't have more than $1k", MessageDialogIcon.Warning);
            }
            // success msg
            else
            {
                MessageUi.ShowMessage("Success", "Cash Deposited Successfully", MessageDialogIcon.Information);
                ObjectHandler.GetAccountDL().Update(UserPage.user.getAccount());
                balance.Text = Convert.ToString(UserPage.user.getAccount().getBalance());
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            guna2ImageButton1.ImageSize = new Size(32, 32);
            int amount = 0;
            Validation.ConvertStringToVar(ref amount, cashBox.Text);
            if (!Validation.ValidDepositAmount(amount))
            {
                cashBox.Focus();
                return;
            }

            if (UserPage.user.getAccount().getType() == "Saving" ? true : false)
                MessageBox.Show($"Balance: {UserPage.user.getAccount().getBalance()}\nAfter Profit: {UserPage.user.getAccount().getProfit()}");

            int status = UserPage.user.getAccount().Withdraw(amount);
            // err msgs
            if (status == -1)
                MessageUi.ShowMessage("Error", "Invalid Amount", MessageDialogIcon.Warning);
            else if (status == -2)
                MessageUi.ShowMessage("Error", "Withdraw Amount can't be Zero", MessageDialogIcon.Warning);
            else if (status == -3)
                MessageUi.ShowMessage("Error", "Withdraw Amount was greater than available Balance", MessageDialogIcon.Warning);
            // success msg
            else
            {
                MessageUi.ShowMessage("Success", "Cash Withdrawal Successful", MessageDialogIcon.Information);
                ObjectHandler.GetAccountDL().Update(UserPage.user.getAccount());
                balance.Text = Convert.ToString(UserPage.user.getAccount().getBalance());
            }
        }
    }
}
