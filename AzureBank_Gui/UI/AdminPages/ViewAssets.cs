using AzureBankDLL.BL;
using AzureBankGui;
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
    public partial class ViewAssets : Form
    {
        public ViewAssets()
        {
            InitializeComponent();
        }

        private void ViewAssets_Load(object sender, EventArgs e)
        {
            List<Asset> assets = ObjectHandler.GetAssetDL().ReadAll();
            DataTable dt = new DataTable();
            
            // add columns to the table
            dt.Columns.Add("Name");
            dt.Columns.Add("Worth($)");
            
            // add the assets to the table
            foreach (Asset asset in assets)
                dt.Rows.Add(asset.getName(), asset.getWorth());
            assetsTable.DataSource = dt;
        }
    }
}
