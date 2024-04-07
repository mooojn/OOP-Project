using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.Util
{
    internal class MessageUi
    {
        public static void ShowMessage(string title, string msg, MessageDialogIcon icon = MessageDialogIcon.Error)
        {
            Guna2MessageDialog guna2MessageDialog = new Guna2MessageDialog();

            guna2MessageDialog.Caption = title;
            guna2MessageDialog.Text = msg;
            guna2MessageDialog.Buttons = MessageDialogButtons.OK; // Set the buttons you want to display
            guna2MessageDialog.Icon = icon; // Set the icon you want to display
            //guna2MessageDialog.Style = MessageDialogStyle.Dark; // Set the style you want to display
            //guna2MessageDialog.Show();
        }
    }
}
