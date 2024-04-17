namespace AzureBankGui
{
    partial class AuthenticationPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationPage));
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.typeOfLogin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.passBoxBtn = new System.Windows.Forms.Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.passBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainPanel.Controls.Add(this.typeOfLogin);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.nameBox);
            this.mainPanel.Controls.Add(this.passBoxBtn);
            this.mainPanel.Controls.Add(this.guna2HtmlLabel1);
            this.mainPanel.Controls.Add(this.passBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.guna2Button1);
            this.mainPanel.Location = new System.Drawing.Point(-237, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1127, 880);
            this.mainPanel.TabIndex = 15;
            // 
            // typeOfLogin
            // 
            this.typeOfLogin.AutoSize = true;
            this.typeOfLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.typeOfLogin.Font = new System.Drawing.Font("OCR A Extended", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeOfLogin.ForeColor = System.Drawing.Color.Red;
            this.typeOfLogin.Location = new System.Drawing.Point(756, 508);
            this.typeOfLogin.Name = "typeOfLogin";
            this.typeOfLogin.Size = new System.Drawing.Size(114, 23);
            this.typeOfLogin.TabIndex = 26;
            this.typeOfLogin.Text = "Register";
            this.typeOfLogin.Click += new System.EventHandler(this.ToggleMethodType);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(441, 507);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "Don\'t have an account?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Bebas Neue", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(661, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 153);
            this.label4.TabIndex = 24;
            this.label4.Text = "Bank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(430, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 41);
            this.label3.TabIndex = 23;
            this.label3.Text = "UserName";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 41);
            this.label2.TabIndex = 22;
            this.label2.Text = "Password";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // nameBox
            // 
            this.nameBox.Animated = true;
            this.nameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.nameBox.AutoRoundedCorners = true;
            this.nameBox.BorderRadius = 30;
            this.nameBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameBox.CustomizableEdges.BottomLeft = false;
            this.nameBox.CustomizableEdges.BottomRight = false;
            this.nameBox.CustomizableEdges.TopLeft = false;
            this.nameBox.CustomizableEdges.TopRight = false;
            this.nameBox.DefaultText = "";
            this.nameBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nameBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameBox.Location = new System.Drawing.Point(435, 292);
            this.nameBox.Margin = new System.Windows.Forms.Padding(6);
            this.nameBox.Name = "nameBox";
            this.nameBox.PasswordChar = '\0';
            this.nameBox.PlaceholderText = "";
            this.nameBox.SelectedText = "";
            this.nameBox.Size = new System.Drawing.Size(457, 63);
            this.nameBox.TabIndex = 0;
            // 
            // passBoxBtn
            // 
            this.passBoxBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.passBoxBtn.FlatAppearance.BorderSize = 0;
            this.passBoxBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passBoxBtn.ForeColor = System.Drawing.Color.Black;
            this.passBoxBtn.Image = global::AzureBank.Properties.Resources.view;
            this.passBoxBtn.Location = new System.Drawing.Point(897, 433);
            this.passBoxBtn.Name = "passBoxBtn";
            this.passBoxBtn.Size = new System.Drawing.Size(77, 52);
            this.passBoxBtn.TabIndex = 4;
            this.passBoxBtn.UseVisualStyleBackColor = true;
            this.passBoxBtn.Click += new System.EventHandler(this.passBox_StateChange);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(571, 255);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel1.TabIndex = 19;
            this.guna2HtmlLabel1.Text = "<div>";
            // 
            // passBox
            // 
            this.passBox.Animated = true;
            this.passBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.passBox.BorderRadius = 5;
            this.passBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passBox.CustomizableEdges.BottomLeft = false;
            this.passBox.CustomizableEdges.BottomRight = false;
            this.passBox.CustomizableEdges.TopLeft = false;
            this.passBox.CustomizableEdges.TopRight = false;
            this.passBox.DefaultText = "";
            this.passBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passBox.Location = new System.Drawing.Point(435, 427);
            this.passBox.Margin = new System.Windows.Forms.Padding(6);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '●';
            this.passBox.PlaceholderText = "";
            this.passBox.SelectedText = "";
            this.passBox.Size = new System.Drawing.Size(457, 63);
            this.passBox.TabIndex = 1;
            this.passBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bebas Neue", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(385, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 153);
            this.label1.TabIndex = 16;
            this.label1.Text = "Azure";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(571, 567);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 70);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "SignIn";
            this.guna2Button1.Click += new System.EventHandler(this.SignIn);
            // 
            // AuthenticationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 894);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(914, 965);
            this.MinimumSize = new System.Drawing.Size(914, 965);
            this.Name = "AuthenticationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzureBank";
            this.Load += new System.EventHandler(this.AuthenticationPage_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox nameBox;
        private System.Windows.Forms.Button passBoxBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox passBox;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label typeOfLogin;
    }
}