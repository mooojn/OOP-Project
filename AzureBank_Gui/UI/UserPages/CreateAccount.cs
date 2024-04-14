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
using System.Xml.Linq;
using Guna.UI2.WinForms;
using System.Security.AccessControl;
using AzureBankDLL.DLInterfaces;
using AzureBankGui.Utils;
using System.Runtime.Remoting.Messaging;

namespace AzureBank
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        private void CreateAcc(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(type.Text))
            {
                MessageUi.ShowMessage("Error", "Please provide the type of account", MessageDialogIcon.Warning);
                return;
            }
            string name = UserPage.user.getName();
            string randomNums = GenerateRandomString(3);

            string accountNumber = $"{name.ToLower()}{randomNums}@AzureBank"; ;
            string accountType = type.Text;
            string holderName = UserPage.user.getName();

            int amount = 0;
            Validation.ConvertStringToVar(ref amount, cashBox.Text);
            if (!Validation.ValidDepositAmount(amount))
            {
                cashBox.Focus();
                return;
            }

            Account account = null;
            if (accountType == "Saving")
                account = new SavingAccount(accountNumber + "SAV", holderName, amount);
            else
                account = new CurrentAccount(accountNumber + "CUR", holderName, amount);
            
            UserPage.user.setAccount(account);
            ObjectHandler.GetAccountDL().Create(account);

            MessageUi.ShowMessage("Success","Your account has been created successfully", MessageDialogIcon.Information);
            this.Close();
        }
        private string GenerateRandomString(int length)
        {
            Random rand = new Random();
            string result = "";

            for (int i = 0; i < length; i++)
            {
                int num = rand.Next(0, 10);
                result += num.ToString();
            }
            return result;
        }
    }
}
