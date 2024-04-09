using AzureBankDLL.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureBankGui
{
    public partial class EditInformation : Form
    {
        public EditInformation()
        {
            InitializeComponent();
        }

        private void passBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserPage.user.setPassword(passBox.Text);
            //UserDL.UpdateInfo(UserPage.user);
        }
    }
}
