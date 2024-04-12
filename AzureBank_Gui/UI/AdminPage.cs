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
using AzureBankDLL.BL;
using AzureBank.Utils;
using AzureBank;


namespace AzureBankGui
{
    public partial class AdminPage : Form
    {
        public static User admin = null;
        public AdminPage(User adm)
        {
            InitializeComponent();
            
            Common.AttachEvents(this);     // for the animation on tab change
            admin = adm;    // set the admin who logged in

            // load admin dashboard
            UtilDL.activeButtonStateChange(guna2Button1);
            UtilDL.openChildForm(new AdminDashboard(), mainPanel);
        }
        // funcs to open different forms
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button1);
            UtilDL.openChildForm(new AdminDashboard(), mainPanel);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button2);
            UtilDL.openChildForm(new AddUser(), mainPanel);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button3);
            UtilDL.openChildForm(new AddAsset(), mainPanel);
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button4);
            UtilDL.openChildForm(new ViewUsers(), mainPanel);
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button5);
            UtilDL.openChildForm(new ViewAssets(), mainPanel);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UtilDL.LogOut(this);
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
