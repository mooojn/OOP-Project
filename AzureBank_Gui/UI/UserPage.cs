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


namespace AzureBankGui
{
    public partial class UserPage : Form
    {
        public static User user;
        public UserPage(User usr)
        {
            InitializeComponent();
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
            //UserDL.UpdateInfo(user);
            UtilDL.LogOut(this);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button2);
            UtilDL.openChildForm(new Transact(), mainPanel);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button3);
            UtilDL.openChildForm(new ViewHistory(), mainPanel);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button4);
            UtilDL.openChildForm(new EditInformation(), mainPanel);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button5);


            //Guna2TextBox box = new Guna2TextBox();
            //box.PlaceholderText = "Enter your password";
            //box.PasswordChar = '*';
            //box.Width = 200;
            //box.Height = 30;
            //box.Location = new Point(100, 100);
            //mainPanel.Controls.Add(box);
            //box.Focus();


            //if (box.Text == "admin")
            //{

                
            //UserDL.users.Remove(user);
            // remove from the dataBase 
            //UserDL.DeleteUser(user.getName());
            UtilDL.LogOut(this);
            //}

            // as acc removed
        }
    }
}
