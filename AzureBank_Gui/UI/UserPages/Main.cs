﻿using AzureBankDLL.BL;
using AzureBankDLL.DL;
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

namespace AzureBank
{
    public partial class Main : Form
    {

        public static Guna2Panel panel;
        public static Form userPage;
        public Main(Form f, Guna2Panel mainPanel)
        {
            InitializeComponent();
            transactionHistory.DataSource =  HistoryACC.Load();
            cashAmount.Text = UserPage.user.getCash().ToString();
            
            panel = mainPanel;
            userPage = f;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form f = new DepositWithdraw();
            f.Show();
            //this.Hide();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            Form f = new Transfer();
            f.Show();
        }
        private void transactionHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AuthPromptForm promptForm = new AuthPromptForm();
            DialogResult result = promptForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                //MessageBox.Show("Account deleted successfully.");
                UserDL.users.Remove(UserPage.user);            
                UserDL.DeleteUser(UserPage.user.getName());  // remove from the dataBase 
                UtilDL.LogOut(userPage);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AuthPromptForm promptForm = new AuthPromptForm();

            promptForm.label2.Text = "Set new Password";

            guna2Button1.Text = "Change";
            promptForm.guna2Button1.Click -= promptForm.validatePass;
            promptForm.guna2Button1.Click += promptForm.changePass;
            

            DialogResult result = promptForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Password changed successfully.");
            }
            else
            {
                MessageBox.Show("fail.");
                // Authentication failed or canceled, handle accordingly
            }

            
        }
    }
}