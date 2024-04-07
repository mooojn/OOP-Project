using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureBank
{
    public partial class Portfolio : Form
    {
        public Portfolio()
        {
            InitializeComponent();
            cashAmount.Text = UserPage.user.getCash().ToString();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
