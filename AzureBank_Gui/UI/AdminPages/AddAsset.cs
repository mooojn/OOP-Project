using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureBankGui;
using AzureBankDLL.BL;
using Guna.UI2.WinForms;

namespace AzureBank
{
    public partial class AddAsset : Form
    {
        public AddAsset()
        {
            InitializeComponent();
        }

        private void AddAsset_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            int worth = Convert.ToInt32(worthBox.Text);
            ObjectHandler.GetAssetDL().Create(new Asset(name, worth));
            MessageUi.ShowMessage("Success", "Asset created successfully", MessageDialogIcon.Information);
        }
    }
}
