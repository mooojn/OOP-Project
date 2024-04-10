using AzureBankGui.Utils;
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
using Guna.UI2.WinForms;
using AzureBank;

namespace AzureBankGui
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!Validation.IsValid("Username", nameBox.Text)) 
            {
                return;
            }
            if (!Validation.IsValid("Password", passBox.Text, false))
            {
                return;
            }
            if (ObjectHandler.GetUserDL().UserNameExists(nameBox.Text))
            {
                MessageUi.ShowMessage("User exists", "User with this name already exists try a different one");
                return;
            }
            ObjectHandler.GetUserDL().Create(new User(nameBox.Text, passBox.Text));
            MessageUi.ShowMessage("Success", "User created successfully", MessageDialogIcon.Information);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void passBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form f = new DeleteUser();
            f.Show();
        }
    }
}
