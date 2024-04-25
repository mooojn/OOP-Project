using AzureBankGui;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankDLL.BL;
using System.Drawing;


namespace AzureBank.Utils
{
    internal class Common
    {
        public static void ChangePassword(User user) 
        {
            AuthPromptForm promptForm = new AuthPromptForm(user);

            promptForm.label2.Text = "Set new Password";

            // event handlers
            promptForm.guna2Button1.Click -= promptForm.validatePass;
            promptForm.guna2Button1.Click += promptForm.changePass;
            
            // result of the prompt form
            DialogResult result = promptForm.ShowDialog();
            if (result == DialogResult.OK)
                MessageUi.ShowMessage("Success", "Password changed successfully", MessageDialogIcon.Information);
            else
                MessageUi.ShowMessage("Failed", "Password change was not successful");
        }
        public static void LoadComboBox(Guna2ComboBox box, User user)
        {
            box.Items.Clear();
            // get all names from the user's data 
            List<string> names = ObjectHandler.GetUserDL().ReadAllNames(user.getName());
            foreach (string name in names)
                box.Items.Add(name);
        }
        public static void AttachEvents(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // assign event handlers to controls
                if (control is Guna2ImageButton imgButton)
                {
                    imgButton.Enter += ButtonIE;
                    imgButton.Leave += ButtonIL;
                }
                else if (control is Guna2Button button)
                {
                    button.Enter += Button_Enter;
                    button.Leave += Button_Leave;
                }
                else if (control.HasChildren)
                    AttachEvents(control); // recursive call for child controls
            }
        }
        private static void ButtonIE(object sender, EventArgs e)
        {
            Guna2ImageButton button = (Guna2ImageButton)sender;
            button.ImageSize = new Size(64, 64);    
        }

        // event handler for button Leave event
        private static void ButtonIL(object sender, EventArgs e)
        {
            Guna2ImageButton button = (Guna2ImageButton)sender;
            button.ImageSize = new Size(32, 32);
        }
        // event handler for button Enter event
        private static void Button_Enter(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            
            if (button.FillColor == Color.FromArgb(210, 43, 43)) 
                button.BorderColor = Color.Black;  // as red so changing to black
            else
                button.BorderColor = Color.Red; // change border color
            
            button.BorderThickness = 2; // increase border size
        }

        // event handler for button Leave event
        private static void Button_Leave(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            button.BorderThickness = 0;
        }

    }
}
