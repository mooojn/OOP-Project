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

namespace AzureBankGui
{
    // this class is responsible for displaying messages to the user
    internal class MessageUi
    {
        public static void UnexpectedError()
        {
            MessageUi.ShowMessage("Unexpected Error", "An unexpected error occured");
        }
        public static void NegativeAmountError(string type)
        {
            MessageUi.ShowMessage("Invalid Amount", $"{type} amount can't be Negative", MessageDialogIcon.Warning);
        }
        public static void ZeroAmountError(string type)
        {
            MessageUi.ShowMessage("Invalid Amount", $"{type} amount can't be Zero", MessageDialogIcon.Warning);
        }
        public static void NullBoxError()
        {
            ShowMessage("Field Empty", "One of the fields is empty\nPlease fill all the fields", MessageDialogIcon.Warning);
        }
        public static void ShowMessage(string title, string msg, MessageDialogIcon icon = MessageDialogIcon.Error)
        {
            Guna2MessageDialog guna2MessageDialog = new Guna2MessageDialog();
            // styles
            guna2MessageDialog.Caption = title;
            guna2MessageDialog.Text = msg;
            guna2MessageDialog.Buttons = MessageDialogButtons.OK; // Set the buttons you want to display
            guna2MessageDialog.Icon = icon; // Set the icon you want to display
            //guna2MessageDialog.Style = MessageDialogStyle.Dark; // Set the style you want to display

            guna2MessageDialog.Show();
        }
        public static void Error(string msg, string title = "Invalid Input")
        {
            Guna2MessageDialog guna2MessageDialog = new Guna2MessageDialog();
            // styles
            guna2MessageDialog.Caption = title;
            guna2MessageDialog.Text = msg;
            guna2MessageDialog.Buttons = MessageDialogButtons.OK; // Set the buttons you want to display
            guna2MessageDialog.Icon = MessageDialogIcon.Error; // Set the icon you want to display
            //guna2MessageDialog.Style = MessageDialogStyle.Dark; // Set the style you want to display
            
            guna2MessageDialog.Show();
        }
    }
}
