﻿using Guna.UI2.WinForms;
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


namespace AzureBank
{
    public partial class AdminPage : Form
    {
        public static User admin = null;
        public AdminPage(User adm)
        {
            InitializeComponent();
            this.Size = new Size(1200, 1200);
            admin = adm;
        }

        private void iconToolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button1);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button2);
            UtilDL.openChildForm(new UserManager(), mainPanel);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button3);

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button4);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button5);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UtilDL.LogOut(this);
        }
    }
}
