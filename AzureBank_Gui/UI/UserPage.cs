using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using AzureBankDLL.BL;
using AzureBankDLL.DL;
using AzureBank.Utils;


namespace AzureBankGui
{
    public partial class UserPage : Form
    {
        public static User user;
        public UserPage(User usr)
        {
            InitializeComponent();
            Common.AttachEvents(this);     // for the animation on tab change
            user = usr;
            UtilDL.activeButtonStateChange(guna2Button1);
            UtilDL.openChildForm(new Main(this, mainPanel), mainPanel);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button1);
            //UtilDL.openChildForm(new Portfolio(), mainPanel);
            UtilDL.openChildForm(new Main(this, mainPanel), mainPanel);
        }
        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            UtilDL.LogOut(this);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button3);
            UtilDL.openChildForm(new ViewHistory(), mainPanel);
        }
    }
}
