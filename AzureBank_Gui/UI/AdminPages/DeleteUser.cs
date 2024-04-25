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
            Common.LoadComboBox(nameBox, AdminPage.admin);    // load the users in the combobox
            Common.AttachEvents(this);    // for the animation on tab change
        }

        

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            guna2ImageButton1.ImageSize = new Size(32, 32);
            if (string.IsNullOrEmpty(nameBox.Text))
            {
                MessageUi.ShowMessage("Empty Name", "Please select a user to remove", MessageDialogIcon.Warning);
                return;    // name is empty
            }
            // delete the user from the database
            ObjectHandler.GetUserDL().Delete(nameBox.Text);
            MessageUi.ShowMessage("Success", "User deleted Successfully", MessageDialogIcon.Information);
            Common.LoadComboBox(nameBox, AdminPage.admin);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
