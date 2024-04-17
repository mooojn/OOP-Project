namespace AzureBankGui
{
    partial class AuthPromptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthPromptForm));
            this.label2 = new System.Windows.Forms.Label();
            this.passBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 41);
            this.label2.TabIndex = 25;
            this.label2.Text = "Password";
            this.label2.UseCompatibleTextRendering = true;
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
            this.passBox.Location = new System.Drawing.Point(167, 180);
            this.passBox.Margin = new System.Windows.Forms.Padding(6);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '●';
            this.passBox.PlaceholderText = "";
            this.passBox.SelectedText = "";
            this.passBox.Size = new System.Drawing.Size(457, 63);
            this.passBox.TabIndex = 0;
            this.passBox.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(324, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 28);
            this.label7.TabIndex = 50;
            this.label7.Text = "Proceed";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2Button1.ImageRotate = 0F;
            this.guna2Button1.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2Button1.Location = new System.Drawing.Point(311, 258);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedState.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2Button1.Size = new System.Drawing.Size(128, 128);
            this.guna2Button1.TabIndex = 49;
            this.guna2Button1.Click += new System.EventHandler(this.transactICON_Click);
            // 
            // AuthPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(826, 521);
            this.MinimumSize = new System.Drawing.Size(826, 521);
            this.Name = "AuthPromptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthPromptForm";
            this.Load += new System.EventHandler(this.AuthPromptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2TextBox passBox;
        private System.Windows.Forms.Label label7;
        public Guna.UI2.WinForms.Guna2ImageButton guna2Button1;
    }
}