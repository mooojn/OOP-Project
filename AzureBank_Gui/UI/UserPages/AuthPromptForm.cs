using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankDLL.DL;
using AzureBankDLL.BL;
using AzureBankGui.Utils;
using AzureBank.Utils;

namespace AzureBankGui
{
    public partial class AuthPromptForm : Form
    {
        public User user = null;
        public AuthPromptForm(User user)
        {
            InitializeComponent();
            Common.AttachEvents(this);
            this.user = user;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void validatePass(object sender, EventArgs e)
        {
            // Authentication successful
            if (passBox.Text == UserPage.user.getPassword())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // Authentication failed
            else
                MessageBox.Show("Invalid password.");
        }
        public void changePass(object sender, EventArgs e)
        {
            if (!Validation.IsValid("Password", passBox.Text, false))
                return;     // if password is invalid
            // update the password in the database
            user.setPassword(passBox.Text);
            ObjectHandler.GetUserDL().Update(user);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void AuthPromptForm_Load(object sender, EventArgs e) {}
        private void btnLogin_Click(object sender, EventArgs e) {}
    }
}
