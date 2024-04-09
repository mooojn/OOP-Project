﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankDLL.DL;
using AzureBankGui.Utils;

namespace AzureBankGui
{
    public partial class AuthPromptForm : Form
    {
        public AuthPromptForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void AuthPromptForm_Load(object sender, EventArgs e)
        {

        }
        public void validatePass(object sender, EventArgs e)
        {
            if (passBox.Text == UserPage.user.getPassword())
            {
                // Authentication successful
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Invalid password.");
            }
        }
        public void changePass(object sender, EventArgs e)
        {
            if (!Validation.IsValid("Password", passBox.Text, false))
                return;
            UserPage.user.setPassword(passBox.Text);
            ObjectHandler.GetUserDL().Update(UserPage.user);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}