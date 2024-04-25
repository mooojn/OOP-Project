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


namespace AzureBankGui
{
    internal class UtilDL
    {
        public static Form activeForm;
        public static Guna2Button activeButton;
        public static bool NullBoxIn(Control container)
        {
            // check if any textbox in the container is empty
            foreach (Control control in container.Controls)
            {
                if (control is Guna2TextBox gunaTextBox && gunaTextBox.Text == "")
                    return true; // return true as soon as an empty textbox is found
                else if (control is Guna2ComboBox guna2ComboBox && guna2ComboBox.Text == "")
                    return true;
            }
            return false;
        }
        public static void openChildForm(Form formToOpen, Guna2Panel mainPanel)
        {
            if (activeForm != null)
                activeForm.Close();
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
            // uncheck the previous button and check the new button
            if (activeButton != null)
                activeButton.Checked = false;
            activeButton = button;
            activeButton.Checked = true;
        }
        public static void LogOut(Form FormToClose)
        {
            FormToClose.Close();
            Form authPage = new AuthenticationPage();
            authPage.Show();    // show the main authentication page
        }
        public static void transactionClose()
        {
            UtilDL.openChildForm(new Main(new Form(), Main.panel), Main.panel);
        }
    }
}
