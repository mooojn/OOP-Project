using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using AzureBankDLL.BL;
using AzureBankDLL.DL;
using Guna.UI2.AnimatorNS;
using System.Runtime.Remoting.Messaging;
using AzureBankDLL.DLInterfaces;
using AzureBankGui.Utils;
using AzureBank.Utils;

namespace AzureBankGui
{
    public partial class AuthenticationPage : Form
    {
        public AuthenticationPage()
        {
            InitializeComponent();
            Common.AttachEvents(this);     // for the animation on tab change
        }
        private void SignUp(object sender, EventArgs e)
        {
            User user = InitializeUser();
            if (user == null)
                return;
            else if (ObjectHandler.GetUserDL().UserNameExists(user.getName())) {
                MessageUi.ShowMessage("User Exists", "User with this username Already exists please use a different one");
                nameBox.Focus();
                return;
            }
            ObjectHandler.GetUserDL().Create(user);
            MessageUi.ShowMessage("Success", "Your account has successfully been registered with us", MessageDialogIcon.Information);
        }
        private void SignIn(object sender, EventArgs e)
        {
            User usr = InitializeUser();
            if (usr == null)
                return;
            if (!ObjectHandler.GetUserDL().UserNameExists(usr.getName())) {     // user not found
                MessageUi.ShowMessage("Invalid User", "User does not Exist", MessageDialogIcon.Error);
                return;
            }
            int userId = ObjectHandler.GetUserDL().FindUser(usr);
            if (userId == 0)   // 0 means invalid password
            {
                MessageUi.ShowMessage("Authentication Error", "Incorrect Password", MessageDialogIcon.Error);
                return;
            }
            usr = ObjectHandler.GetUserDL().Read(usr.getName());
            if (userId == 1)      // userId '2' represents admin 
            {
                LoadPage(new AdminPage(usr));
                return;
            }
            LoadPage(new UserPage(usr));
        }
        private User InitializeUser()
        {
            if (UtilDL.NullBoxIn(mainPanel))
            {
                MessageUi.NullBoxError();
                return null;
            }
            else if (!Validation.IsValid("Username", nameBox.Text)) {
                return null;
            }
            else if (!Validation.IsValid("Password", passBox.Text, false))
            {
                return null;
            }
            return new User(nameBox.Text, passBox.Text);
        }
        private void passBox_StateChange(object sender, EventArgs e)
        {
            if (passBox.PasswordChar == '●')
            {
                passBoxBtn.Image = AzureBankGui.Properties.Resources.hide1;
                passBox.UseSystemPasswordChar = false;
                passBox.PasswordChar = '\0';
            }
            else
            {
                passBoxBtn.Image = AzureBankGui.Properties.Resources.view1;
                passBox.UseSystemPasswordChar = true;
                passBox.PasswordChar = '●';
            }
        }
        private void LoadPage(Form form)
        {
            this.Hide();
            form.Size = new Size(850, 550);
            form.Show();
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text == "Register")
                changeSuit("Register", Color.FromArgb(80, 200, 120), "Already", "SignIn");
            else
                changeSuit("SignIn", Color.FromArgb(94, 148, 255), "Don't", "Register");
        }
        private void changeSuit(string type, Color hex, string a, string head)
        {
            if (type == "Register")
            {
                label2.Text = "Set Password";
                guna2Button1.Click -= SignIn;
                guna2Button1.Click += SignUp;
            }
            else
            {
                label2.Text = "Password";
                guna2Button1.Click -= SignUp;
                guna2Button1.Click += SignIn;
            }
            guna2Button1.Text = type;
            guna2Button1.FillColor = hex;

            //label2.Text = "Set Password";
            //label3.Text = "Set UserName";

            label5.Text = $"{a} have an account?";
            label6.Text = head;
        }
    }
}
