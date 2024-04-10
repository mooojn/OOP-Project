using AzureBankGui;
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
using AzureBank.Utils;

namespace AzureBank
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
            Common.LoadComboBox(nameBox, AdminPage.admin);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ObjectHandler.GetUserDL().Delete(nameBox.Text);
            MessageUi.ShowMessage("Success", "User deleted Successfully", MessageDialogIcon.Information);
            Common.LoadComboBox(nameBox, AdminPage.admin);
        }

    }
}
