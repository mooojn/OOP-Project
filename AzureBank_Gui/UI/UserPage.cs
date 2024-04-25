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
using AzureBank;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace AzureBankGui
{
    public partial class UserPage : Form
    {
        public static User user;
        public UserPage(User usr)
        {
            InitializeComponent();
            user = usr;    // set the user who logged in
            
            AccountCheck();

            Common.AttachEvents(this);     // for the animation on tab change
            // open the user dashboard
            UtilDL.activeButtonStateChange(guna2Button1);
            UtilDL.openChildForm(new Main(this, mainPanel), mainPanel);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button1);
            UtilDL.openChildForm(new Main(this, mainPanel), mainPanel);    // user dashboard
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

        
        private void AccountCheck()
        {
            // if account exists, set the account of the user
            Account acc = ObjectHandler.GetAccountDL().Read(user.getName());
            if (acc != null)
                user.setAccount(acc);
            else
            {
                Form f = new CreateAccount();
                f.Show();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button2);
            UtilDL.openChildForm(new ViewAccount(), mainPanel);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UtilDL.activeButtonStateChange(guna2Button4);
            AuthPromptForm promptForm = new AuthPromptForm(UserPage.user);
            //UtilDL.openChildForm(promptForm, mainPanel);
            DialogResult result = promptForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                //MessageBox.Show("Account deleted successfully.");
                ObjectHandler.GetUserDL().Delete(UserPage.user.getName());  // remove from the dataBase 
                UtilDL.LogOut(this);
            }
        }
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
