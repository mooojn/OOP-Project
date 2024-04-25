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
using AzureBank.Utils;

namespace AzureBankGui
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            Common.AttachEvents(this);    // for the animation on tab change
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            guna2ImageButton1.ImageSize = new Size(32, 32);
            if (!Validation.IsValid("Username", nameBox.Text))
            {
                nameBox.Focus();
                return;    // name is invalid
            }
            if (!Validation.IsValid("Password", passBox.Text, false))
            {
                passBox.Focus();
                return;    // password is invalid
            }
            if (ObjectHandler.GetUserDL().UserNameExists(nameBox.Text))
            {
                nameBox.Focus();
                MessageUi.ShowMessage("User exists", "User with this name already exists try a different one");
                return;    // username already exists
            }
            // create the user as all conditions are met
            ObjectHandler.GetUserDL().Create(new User(nameBox.Text, passBox.Text));
            MessageUi.ShowMessage("Success", "User created successfully", MessageDialogIcon.Information);
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            guna2ImageButton2.ImageSize = new Size(32, 32);
            Form f = new DeleteUser();
            f.Show();
        }

        private void guna2ImageButton2_Leave(object sender, EventArgs e)
        {
            
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e) {}
    }
}
