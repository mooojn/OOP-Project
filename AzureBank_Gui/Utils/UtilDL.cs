using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.AnimatorNS;


namespace AzureBank
{
    internal class UtilDL
    {
        public static Form activeForm;
        public static Guna2Button activeButton;
        //public static void ExecuteNonQuery(SqlCommand command, string errorMessage)
        //{
        //    Program.connection.Open();
        //    try {
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception e) {
        //        MessageBox.Show(e.Message);
        //    }   
        //    Program.connection.Close();
        //}
        public static bool NullBoxIn(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is Guna2TextBox gunaTextBox && gunaTextBox.Text == "")
                {
                    return true; // Return true as soon as an empty textbox is found
                }
                if (control is Guna2ComboBox guna2ComboBox && guna2ComboBox.Text == "")
                {
                    return true;
                }
            }
            return false;
        }
        public static void openChildForm(Form formToOpen, Guna2Panel mainPanel)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = formToOpen;

            formToOpen.TopLevel = false;
            formToOpen.FormBorderStyle = FormBorderStyle.None;
            formToOpen.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(formToOpen);
            mainPanel.Tag = formToOpen;

            formToOpen.BringToFront();
            formToOpen.Show();
        }
        public static void activeButtonStateChange(Guna2Button button)
        {
            if (activeButton != null)
            {
                activeButton.Checked = false;
            }
            activeButton = button;
            activeButton.Checked = true;
        }
        public static void LogOut(Form FormToClose)
        {
            FormToClose.Close();
            Form authPage = new AuthenticationPage();
            authPage.Show();
        }
        public static void transactionClose()
        {
            UtilDL.openChildForm(new Main(new Form(), Main.panel), Main.panel);
        }
    }
}
