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
            Common.AttachEvents(this);    // for the animation on tab change
        }
        private void SignUp(object sender, EventArgs e)
        {
            User user = InitializeUser();    // initialize user object from the input fields
            if (user == null)
                return;    // if any field is empty, return
            else if (ObjectHandler.GetUserDL().UserNameExists(user.getName()))
            {
                MessageUi.ShowMessage("User Exists", "User with this username Already exists please use a different one");
                nameBox.Focus();
                return;    // if user already exists, return
            }
            // all conditions are met, create the user
            ObjectHandler.GetUserDL().Create(user);
            MessageUi.ShowMessage("Success", "Your account has successfully been registered with us", MessageDialogIcon.Information);
            // as account is created, now user would want to sign in
            ToggleMethodType(sender, e);
        }
        private void SignIn(object sender, EventArgs e)
        {
            User usr = InitializeUser();    // initialize user object from the input fields
            
            if (usr == null)
                return;    // if any field is empty, return
            if (!ObjectHandler.GetUserDL().UserNameExists(usr.getName()))    // user not found
            {
                MessageUi.ShowMessage("Invalid User", "User does not Exist", MessageDialogIcon.Error);
                ToggleMethodType(sender, e);    // as account does not exist, user would want to register
                return;
            }
            
            int userId = ObjectHandler.GetUserDL().FindUser(usr);
            
            if (userId == 0)    // 0 means invalid password
            {
                MessageUi.ShowMessage("Authentication Error", "Incorrect Password", MessageDialogIcon.Error);
                passBox.Focus();
                return;
            }
            usr = ObjectHandler.GetUserDL().Read(usr.getName());
            
            if (userId == 1)      // userId '1' represents admin login
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
                return null;    // one of the box is empty
            }
            else if (!Validation.IsValid("Username", nameBox.Text)) 
            {
                nameBox.Focus();
                return null;    // invalid username
            }
            else if (!Validation.IsValid("Password", passBox.Text, false))
            {
                passBox.Focus();
                return null;    // invalid password
            }
            // all conditions are met, return the user object
            return new User(nameBox.Text, passBox.Text);
        }
        private void passBox_StateChange(object sender, EventArgs e)
        {
            // toggle the password visibility icon
            if (passBox.PasswordChar == '●')
            {
                passBoxBtn.Image = AzureBank.Properties.Resources.hide;
                passBox.UseSystemPasswordChar = false;
                passBox.PasswordChar = '\0';
            }
            else
            {
                passBoxBtn.Image = AzureBank.Properties.Resources.view;
                passBox.UseSystemPasswordChar = true;
                passBox.PasswordChar = '●';
            }
        }
        private void changeSuit(string type, Color hex, string a, string head)
        {
            // change the form functionality to act as register or sign in
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
            guna2Button1.Text = type;   // text for the button
            guna2Button1.FillColor = hex;   // color for the button

            label5.Text = $"{a} have an account?";    // text for the description
            typeOfLogin.Text = head;    // text for the title
        }

        private void ToggleMethodType(object sender, EventArgs e)
        {
            // change the form type to register or sign in
            if (typeOfLogin.Text == "Register")
                changeSuit("Register", Color.FromArgb(80, 200, 120), "Already", "SignIn");
            else
                changeSuit("SignIn", Color.FromArgb(94, 148, 255), "Don't", "Register");
        }
        private void LoadPage(Form form)
        {
            // load the new page for user/admin
            this.Hide();
            form.Size = new Size(850, 550);
            form.Show();
        }

        private void AuthenticationPage_Load(object sender, EventArgs e)
        {

        }
    }
}
