namespace AzureBank
{
    partial class Transact
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.amountBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.goBackBtn = new Guna.UI2.WinForms.Guna2Button();
            this.transPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.transferBoxPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.transferName = new Guna.UI2.WinForms.Guna2TextBox();
            this.transferBtn = new Guna.UI2.WinForms.Guna2Button();
            this.depositBtn = new Guna.UI2.WinForms.Guna2Button();
            this.withdrawBtn = new Guna.UI2.WinForms.Guna2Button();
            this.transPanel.SuspendLayout();
            this.transferBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(187, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 41);
            this.label3.TabIndex = 26;
            this.label3.Text = "Amount";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // amountBox
            // 
            this.amountBox.Animated = true;
            this.amountBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.amountBox.AutoRoundedCorners = true;
            this.amountBox.BorderRadius = 30;
            this.amountBox.BorderThickness = 0;
            this.amountBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.amountBox.CustomizableEdges.BottomLeft = false;
            this.amountBox.CustomizableEdges.BottomRight = false;
            this.amountBox.CustomizableEdges.TopLeft = false;
            this.amountBox.CustomizableEdges.TopRight = false;
            this.amountBox.DefaultText = "";
            this.amountBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.amountBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.amountBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.amountBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.amountBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.amountBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.amountBox.Location = new System.Drawing.Point(187, 241);
            this.amountBox.Margin = new System.Windows.Forms.Padding(6);
            this.amountBox.Name = "amountBox";
            this.amountBox.PasswordChar = '\0';
            this.amountBox.PlaceholderText = "";
            this.amountBox.SelectedText = "";
            this.amountBox.Size = new System.Drawing.Size(457, 63);
            this.amountBox.TabIndex = 0;
            this.amountBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(323, 203);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel1.TabIndex = 25;
            this.guna2HtmlLabel1.Text = "<div>";
            // 
            // goBackBtn
            // 
            this.goBackBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.goBackBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.goBackBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.goBackBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.goBackBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.goBackBtn.ForeColor = System.Drawing.Color.White;
            this.goBackBtn.Location = new System.Drawing.Point(323, 504);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(196, 72);
            this.goBackBtn.TabIndex = 29;
            this.goBackBtn.Text = "Go Back";
            this.goBackBtn.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // transPanel
            // 
            this.transPanel.Controls.Add(this.withdrawBtn);
            this.transPanel.Controls.Add(this.depositBtn);
            this.transPanel.Location = new System.Drawing.Point(187, 409);
            this.transPanel.Name = "transPanel";
            this.transPanel.Size = new System.Drawing.Size(463, 103);
            this.transPanel.TabIndex = 30;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(135, 27);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel2.TabIndex = 32;
            this.guna2HtmlLabel2.Text = "<div>";
            // 
            // transferBoxPanel
            // 
            this.transferBoxPanel.Controls.Add(this.label1);
            this.transferBoxPanel.Controls.Add(this.transferName);
            this.transferBoxPanel.Controls.Add(this.guna2HtmlLabel2);
            this.transferBoxPanel.Location = new System.Drawing.Point(182, 27);
            this.transferBoxPanel.Name = "transferBoxPanel";
            this.transferBoxPanel.Size = new System.Drawing.Size(455, 127);
            this.transferBoxPanel.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 41);
            this.label1.TabIndex = 35;
            this.label1.Text = "Transfer To";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // transferName
            // 
            this.transferName.Animated = true;
            this.transferName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.transferName.AutoRoundedCorners = true;
            this.transferName.BorderRadius = 30;
            this.transferName.BorderThickness = 0;
            this.transferName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.transferName.CustomizableEdges.BottomLeft = false;
            this.transferName.CustomizableEdges.BottomRight = false;
            this.transferName.CustomizableEdges.TopLeft = false;
            this.transferName.CustomizableEdges.TopRight = false;
            this.transferName.DefaultText = "";
            this.transferName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.transferName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.transferName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.transferName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.transferName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.transferName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.transferName.Location = new System.Drawing.Point(-1, 62);
            this.transferName.Margin = new System.Windows.Forms.Padding(6);
            this.transferName.Name = "transferName";
            this.transferName.PasswordChar = '\0';
            this.transferName.PlaceholderText = "";
            this.transferName.SelectedText = "";
            this.transferName.Size = new System.Drawing.Size(457, 63);
            this.transferName.TabIndex = 34;
            // 
            // transferBtn
            // 
            this.transferBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.transferBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.transferBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.transferBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.transferBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.transferBtn.ForeColor = System.Drawing.Color.White;
            this.transferBtn.Location = new System.Drawing.Point(323, 333);
            this.transferBtn.Name = "transferBtn";
            this.transferBtn.Size = new System.Drawing.Size(196, 72);
            this.transferBtn.TabIndex = 3;
            this.transferBtn.Text = "Transfer";
            this.transferBtn.Click += new System.EventHandler(this.TransferFunc);
            // 
            // depositBtn
            // 
            this.depositBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.depositBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.depositBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.depositBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.depositBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.depositBtn.ForeColor = System.Drawing.Color.White;
            this.depositBtn.Location = new System.Drawing.Point(-5, 15);
            this.depositBtn.Name = "depositBtn";
            this.depositBtn.Size = new System.Drawing.Size(196, 72);
            this.depositBtn.TabIndex = 1;
            this.depositBtn.Text = "Deposit";
            this.depositBtn.Click += new System.EventHandler(this.DepositFunc);
            // 
            // withdrawBtn
            // 
            this.withdrawBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.withdrawBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.withdrawBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.withdrawBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.withdrawBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.withdrawBtn.ForeColor = System.Drawing.Color.White;
            this.withdrawBtn.Location = new System.Drawing.Point(271, 15);
            this.withdrawBtn.Name = "withdrawBtn";
            this.withdrawBtn.Size = new System.Drawing.Size(196, 72);
            this.withdrawBtn.TabIndex = 2;
            this.withdrawBtn.Text = "Withdraw";
            this.withdrawBtn.Click += new System.EventHandler(this.WithdrawFunc);
            // 
            // Transact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 897);
            this.Controls.Add(this.transferBtn);
            this.Controls.Add(this.transferBoxPanel);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.transPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "Transact";
            this.Text = "Transact";
            this.transPanel.ResumeLayout(false);
            this.transferBoxPanel.ResumeLayout(false);
            this.transferBoxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox amountBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button goBackBtn;
        private Guna.UI2.WinForms.Guna2Panel transPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel transferBoxPanel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox transferName;
        private Guna.UI2.WinForms.Guna2Button transferBtn;
        private Guna.UI2.WinForms.Guna2Button withdrawBtn;
        private Guna.UI2.WinForms.Guna2Button depositBtn;
    }
}