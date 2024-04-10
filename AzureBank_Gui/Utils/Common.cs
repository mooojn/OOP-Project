using AzureBankGui;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankDLL.BL;


namespace AzureBank.Utils
{
    internal class Common
    {
        public static void ChangePassword(User user) 
        {
            AuthPromptForm promptForm = new AuthPromptForm(user);

            promptForm.label2.Text = "Set new Password";

            promptForm.guna2Button1.Click -= promptForm.validatePass;
            promptForm.guna2Button1.Click += promptForm.changePass;


            DialogResult result = promptForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageUi.ShowMessage("Success", "Password changed successfully", MessageDialogIcon.Information);
            }
            else
            {
                MessageUi.ShowMessage("Failed", "Password change was not successful");
                // Authentication failed or canceled, handle accordingly
            }

        }
        public static void LoadComboBox(Guna2ComboBox box, User user)
        {
            box.Items.Clear();
            List<string> names = ObjectHandler.GetUserDL().ReadAllNames(user.getName());
            foreach (string name in names)
            {
                box.Items.Add(name);
            }
        }

    }
}
