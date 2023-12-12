namespace supermarket
{
    partial class SelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectForm));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.Label_welcomeToSuperMarket = new Guna.UI.WinForms.GunaLabel();
            this.Label_selectRole = new Guna.UI.WinForms.GunaLabel();
            this.Button_Ok = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaElipse3 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaAnimateWindow1 = new Guna.UI.WinForms.GunaAnimateWindow(this.components);
            this.Label_exit = new Guna.UI.WinForms.GunaGradientButton();
            this.SelectBox = new Guna.UI.WinForms.GunaComboBox();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 8;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.TargetControl = this;
            // 
            // Label_welcomeToSuperMarket
            // 
            this.Label_welcomeToSuperMarket.AutoSize = true;
            this.Label_welcomeToSuperMarket.BackColor = System.Drawing.Color.Transparent;
            this.Label_welcomeToSuperMarket.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Label_welcomeToSuperMarket.Font = new System.Drawing.Font("Dubai", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_welcomeToSuperMarket.ForeColor = System.Drawing.Color.White;
            this.Label_welcomeToSuperMarket.Location = new System.Drawing.Point(76, 9);
            this.Label_welcomeToSuperMarket.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_welcomeToSuperMarket.Name = "Label_welcomeToSuperMarket";
            this.Label_welcomeToSuperMarket.Size = new System.Drawing.Size(508, 63);
            this.Label_welcomeToSuperMarket.TabIndex = 3;
            this.Label_welcomeToSuperMarket.Text = "Welcome To SuperMarket App";
            // 
            // Label_selectRole
            // 
            this.Label_selectRole.AutoSize = true;
            this.Label_selectRole.BackColor = System.Drawing.Color.Transparent;
            this.Label_selectRole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Label_selectRole.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_selectRole.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label_selectRole.Location = new System.Drawing.Point(224, 171);
            this.Label_selectRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_selectRole.Name = "Label_selectRole";
            this.Label_selectRole.Size = new System.Drawing.Size(221, 32);
            this.Label_selectRole.TabIndex = 4;
            this.Label_selectRole.Text = "Please Select Role ";
            // 
            // Button_Ok
            // 
            this.Button_Ok.AnimationHoverSpeed = 0.07F;
            this.Button_Ok.AnimationSpeed = 0.03F;
            this.Button_Ok.BackColor = System.Drawing.Color.Transparent;
            this.Button_Ok.BaseColor1 = System.Drawing.Color.CornflowerBlue;
            this.Button_Ok.BaseColor2 = System.Drawing.Color.Indigo;
            this.Button_Ok.BorderColor = System.Drawing.Color.Black;
            this.Button_Ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Ok.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_Ok.FocusedColor = System.Drawing.Color.Empty;
            this.Button_Ok.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Ok.ForeColor = System.Drawing.Color.White;
            this.Button_Ok.Image = null;
            this.Button_Ok.ImageSize = new System.Drawing.Size(20, 20);
            this.Button_Ok.Location = new System.Drawing.Point(261, 335);
            this.Button_Ok.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.OnHoverBaseColor1 = System.Drawing.Color.RoyalBlue;
            this.Button_Ok.OnHoverBaseColor2 = System.Drawing.Color.DarkBlue;
            this.Button_Ok.OnHoverBorderColor = System.Drawing.Color.Black;
            this.Button_Ok.OnHoverForeColor = System.Drawing.Color.White;
            this.Button_Ok.OnHoverImage = null;
            this.Button_Ok.OnPressedColor = System.Drawing.Color.Black;
            this.Button_Ok.Size = new System.Drawing.Size(139, 40);
            this.Button_Ok.TabIndex = 5;
            this.Button_Ok.Text = "Enter";
            this.Button_Ok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
            // 
            // gunaElipse3
            // 
            this.gunaElipse3.Radius = 3;
            this.gunaElipse3.TargetControl = this;
            // 
            // gunaAnimateWindow1
            // 
            this.gunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_CENTER;
            this.gunaAnimateWindow1.Interval = 100;
            this.gunaAnimateWindow1.TargetControl = null;
            // 
            // Label_exit
            // 
            this.Label_exit.AnimationHoverSpeed = 0.07F;
            this.Label_exit.AnimationSpeed = 0.03F;
            this.Label_exit.BackColor = System.Drawing.Color.Transparent;
            this.Label_exit.BaseColor1 = System.Drawing.Color.Red;
            this.Label_exit.BaseColor2 = System.Drawing.Color.DarkRed;
            this.Label_exit.BorderColor = System.Drawing.Color.Black;
            this.Label_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_exit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Label_exit.FocusedColor = System.Drawing.Color.Empty;
            this.Label_exit.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_exit.ForeColor = System.Drawing.Color.White;
            this.Label_exit.Image = null;
            this.Label_exit.ImageSize = new System.Drawing.Size(20, 20);
            this.Label_exit.Location = new System.Drawing.Point(261, 402);
            this.Label_exit.Margin = new System.Windows.Forms.Padding(2);
            this.Label_exit.Name = "Label_exit";
            this.Label_exit.OnHoverBaseColor1 = System.Drawing.Color.Maroon;
            this.Label_exit.OnHoverBaseColor2 = System.Drawing.Color.DarkRed;
            this.Label_exit.OnHoverBorderColor = System.Drawing.Color.Black;
            this.Label_exit.OnHoverForeColor = System.Drawing.Color.White;
            this.Label_exit.OnHoverImage = null;
            this.Label_exit.OnPressedColor = System.Drawing.Color.Black;
            this.Label_exit.Size = new System.Drawing.Size(139, 40);
            this.Label_exit.TabIndex = 7;
            this.Label_exit.Text = "Exit";
            this.Label_exit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Label_exit.Click += new System.EventHandler(this.Button_exit_Click);
            // 
            // SelectBox
            // 
            this.SelectBox.BackColor = System.Drawing.Color.Transparent;
            this.SelectBox.BaseColor = System.Drawing.Color.White;
            this.SelectBox.BorderColor = System.Drawing.Color.Silver;
            this.SelectBox.BorderSize = 1;
            this.SelectBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectBox.FocusedColor = System.Drawing.Color.Empty;
            this.SelectBox.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectBox.ForeColor = System.Drawing.Color.Black;
            this.SelectBox.FormattingEnabled = true;
            this.SelectBox.Items.AddRange(new object[] {
            "Admin",
            "Customer"});
            this.SelectBox.Location = new System.Drawing.Point(229, 206);
            this.SelectBox.Name = "SelectBox";
            this.SelectBox.OnHoverItemBaseColor = System.Drawing.Color.Navy;
            this.SelectBox.OnHoverItemForeColor = System.Drawing.Color.White;
            this.SelectBox.Radius = 8;
            this.SelectBox.Size = new System.Drawing.Size(202, 36);
            this.SelectBox.TabIndex = 2;
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(660, 495);
            this.Controls.Add(this.Label_exit);
            this.Controls.Add(this.Button_Ok);
            this.Controls.Add(this.Label_selectRole);
            this.Controls.Add(this.Label_welcomeToSuperMarket);
            this.Controls.Add(this.SelectBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaGradientButton Button_Ok;
        private Guna.UI.WinForms.GunaLabel Label_selectRole;
        private Guna.UI.WinForms.GunaLabel Label_welcomeToSuperMarket;
        private Guna.UI.WinForms.GunaElipse gunaElipse3;
        private Guna.UI.WinForms.GunaAnimateWindow gunaAnimateWindow1;
        private Guna.UI.WinForms.GunaGradientButton Label_exit;
        private Guna.UI.WinForms.GunaComboBox SelectBox;
    }
}

