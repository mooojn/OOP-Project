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
using AzureBankGui.Utils;
using AzureBank.Utils;

namespace AzureBank
{
    public partial class AddAsset : Form
    {
        public AddAsset()
        {
            InitializeComponent();
            Common.AttachEvents(this);    // for the animation on tab change
        }
        

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            guna2ImageButton1.ImageSize = new Size(32, 32);
            string name = nameBox.Text;
            int worth = 0;
            if (!Validation.IsValid("Asset Name", name))
            {
                nameBox.Focus();
                return;    // name is invalid
            }
            if (!Validation.ConvertStringToVar(ref worth, worthBox.Text))
            {
                worthBox.Focus();
                return;    // worth is invalid
            }
            if (!Validation.ValidDepositAmount(Convert.ToInt32(worthBox.Text)))
            {
                worthBox.Focus();
                MessageUi.ShowMessage("Invalid Amount", "Please provide a real amount", MessageDialogIcon.Warning);
                return;    // worth is invalid
            }
            // create the asset as all conditions are met
            ObjectHandler.GetAssetDL().Create(new Asset(name, worth));
            MessageUi.ShowMessage("Success", "Asset created successfully", MessageDialogIcon.Information);
        }

        private void AddAsset_Load(object sender, EventArgs e)
        {
             
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
