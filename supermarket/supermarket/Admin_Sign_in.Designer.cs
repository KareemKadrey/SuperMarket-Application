namespace supermarket
{
    partial class Admin_Sign_in
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Sign_in));
            this.picture_hide_eye = new Guna.UI.WinForms.GunaPictureBox();
            this.picture_wrong = new Guna.UI.WinForms.GunaPictureBox();
            this.Label_exit = new Guna.UI.WinForms.GunaLabel();
            this.button_login = new Guna.UI.WinForms.GunaButton();
            this.picture_email = new Guna.UI.WinForms.GunaPictureBox();
            this.picture_login = new Guna.UI.WinForms.GunaPictureBox();
            this.TextBox_password = new Guna.UI.WinForms.GunaTextBox();
            this.TextBox_email = new Guna.UI.WinForms.GunaTextBox();
            this.picture_circle2 = new Guna.UI.WinForms.GunaCircleButton();
            this.picture_circle1 = new Guna.UI.WinForms.GunaCircleButton();
            this.label_password = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_sign_in = new System.Windows.Forms.Label();
            this.label_welcomeAdmin = new System.Windows.Forms.Label();
            this.picture_eye = new Guna.UI.WinForms.GunaPictureBox();
            this.label_information = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_hide_eye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_wrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_eye)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_hide_eye
            // 
            this.picture_hide_eye.BackColor = System.Drawing.Color.Transparent;
            this.picture_hide_eye.BaseColor = System.Drawing.Color.White;
            this.picture_hide_eye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_hide_eye.Image = ((System.Drawing.Image)(resources.GetObject("picture_hide_eye.Image")));
            this.picture_hide_eye.Location = new System.Drawing.Point(424, 261);
            this.picture_hide_eye.Name = "picture_hide_eye";
            this.picture_hide_eye.Size = new System.Drawing.Size(25, 24);
            this.picture_hide_eye.TabIndex = 28;
            this.picture_hide_eye.TabStop = false;
            this.picture_hide_eye.Click += new System.EventHandler(this.pictur_hide_eye_Click);
            // 
            // picture_wrong
            // 
            this.picture_wrong.BaseColor = System.Drawing.Color.White;
            this.picture_wrong.Image = ((System.Drawing.Image)(resources.GetObject("picture_wrong.Image")));
            this.picture_wrong.Location = new System.Drawing.Point(189, 303);
            this.picture_wrong.Name = "picture_wrong";
            this.picture_wrong.Size = new System.Drawing.Size(25, 24);
            this.picture_wrong.TabIndex = 33;
            this.picture_wrong.TabStop = false;
            this.picture_wrong.Visible = false;
            // 
            // Label_exit
            // 
            this.Label_exit.AutoSize = true;
            this.Label_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_exit.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_exit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label_exit.Location = new System.Drawing.Point(611, 461);
            this.Label_exit.Name = "Label_exit";
            this.Label_exit.Size = new System.Drawing.Size(44, 25);
            this.Label_exit.TabIndex = 32;
            this.Label_exit.Text = "Exit";
            this.Label_exit.Click += new System.EventHandler(this.Label_exit_Click);
            this.Label_exit.MouseEnter += new System.EventHandler(this.Label_exit_MouseEnter);
            this.Label_exit.MouseLeave += new System.EventHandler(this.Label_exit_MouseLeave);
            // 
            // button_login
            // 
            this.button_login.AnimationHoverSpeed = 0.07F;
            this.button_login.AnimationSpeed = 0.03F;
            this.button_login.BackColor = System.Drawing.Color.Transparent;
            this.button_login.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.button_login.BorderColor = System.Drawing.Color.Black;
            this.button_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_login.DialogResult = System.Windows.Forms.DialogResult.None;
            this.button_login.FocusedColor = System.Drawing.Color.Empty;
            this.button_login.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Image = null;
            this.button_login.ImageSize = new System.Drawing.Size(20, 20);
            this.button_login.Location = new System.Drawing.Point(292, 345);
            this.button_login.Name = "button_login";
            this.button_login.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.button_login.OnHoverBorderColor = System.Drawing.Color.Black;
            this.button_login.OnHoverForeColor = System.Drawing.Color.White;
            this.button_login.OnHoverImage = null;
            this.button_login.OnPressedColor = System.Drawing.Color.Black;
            this.button_login.Radius = 15;
            this.button_login.Size = new System.Drawing.Size(76, 32);
            this.button_login.TabIndex = 31;
            this.button_login.TabStop = false;
            this.button_login.Text = "Login";
            this.button_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // picture_email
            // 
            this.picture_email.BackColor = System.Drawing.Color.Transparent;
            this.picture_email.BaseColor = System.Drawing.Color.White;
            this.picture_email.Image = ((System.Drawing.Image)(resources.GetObject("picture_email.Image")));
            this.picture_email.Location = new System.Drawing.Point(424, 171);
            this.picture_email.Name = "picture_email";
            this.picture_email.Size = new System.Drawing.Size(25, 24);
            this.picture_email.TabIndex = 29;
            this.picture_email.TabStop = false;
            // 
            // picture_login
            // 
            this.picture_login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture_login.BackColor = System.Drawing.Color.Transparent;
            this.picture_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picture_login.BaseColor = System.Drawing.Color.White;
            this.picture_login.Image = ((System.Drawing.Image)(resources.GetObject("picture_login.Image")));
            this.picture_login.Location = new System.Drawing.Point(305, 12);
            this.picture_login.Name = "picture_login";
            this.picture_login.Size = new System.Drawing.Size(49, 55);
            this.picture_login.TabIndex = 27;
            this.picture_login.TabStop = false;
            // 
            // TextBox_password
            // 
            this.TextBox_password.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_password.BaseColor = System.Drawing.Color.White;
            this.TextBox_password.BorderColor = System.Drawing.Color.Silver;
            this.TextBox_password.BorderSize = 1;
            this.TextBox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_password.FocusedBaseColor = System.Drawing.Color.White;
            this.TextBox_password.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.TextBox_password.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.TextBox_password.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_password.Location = new System.Drawing.Point(206, 250);
            this.TextBox_password.Name = "TextBox_password";
            this.TextBox_password.PasswordChar = '●';
            this.TextBox_password.Radius = 5;
            this.TextBox_password.SelectedText = "";
            this.TextBox_password.Size = new System.Drawing.Size(249, 44);
            this.TextBox_password.TabIndex = 23;
            this.TextBox_password.TextChanged += new System.EventHandler(this.TextBox_password_TextChanged);
            // 
            // TextBox_email
            // 
            this.TextBox_email.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_email.BaseColor = System.Drawing.Color.White;
            this.TextBox_email.BorderColor = System.Drawing.Color.Silver;
            this.TextBox_email.BorderSize = 1;
            this.TextBox_email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_email.FocusedBaseColor = System.Drawing.Color.White;
            this.TextBox_email.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.TextBox_email.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.TextBox_email.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TextBox_email.Location = new System.Drawing.Point(206, 161);
            this.TextBox_email.Name = "TextBox_email";
            this.TextBox_email.PasswordChar = '\0';
            this.TextBox_email.Radius = 5;
            this.TextBox_email.SelectedText = "";
            this.TextBox_email.Size = new System.Drawing.Size(249, 44);
            this.TextBox_email.TabIndex = 22;
            this.TextBox_email.TextChanged += new System.EventHandler(this.TextBox_email_TextChanged);
            // 
            // picture_circle2
            // 
            this.picture_circle2.AnimationHoverSpeed = 0.07F;
            this.picture_circle2.AnimationSpeed = 0.03F;
            this.picture_circle2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.picture_circle2.BorderColor = System.Drawing.Color.Black;
            this.picture_circle2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.picture_circle2.FocusedColor = System.Drawing.Color.Empty;
            this.picture_circle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.picture_circle2.ForeColor = System.Drawing.Color.White;
            this.picture_circle2.Image = null;
            this.picture_circle2.ImageSize = new System.Drawing.Size(52, 52);
            this.picture_circle2.Location = new System.Drawing.Point(-147, 244);
            this.picture_circle2.Name = "picture_circle2";
            this.picture_circle2.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.picture_circle2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.picture_circle2.OnHoverForeColor = System.Drawing.Color.White;
            this.picture_circle2.OnHoverImage = null;
            this.picture_circle2.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.picture_circle2.Size = new System.Drawing.Size(226, 341);
            this.picture_circle2.TabIndex = 16;
            this.picture_circle2.TabStop = false;
            // 
            // picture_circle1
            // 
            this.picture_circle1.AnimationHoverSpeed = 0.07F;
            this.picture_circle1.AnimationSpeed = 0.03F;
            this.picture_circle1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.picture_circle1.BorderColor = System.Drawing.Color.Black;
            this.picture_circle1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.picture_circle1.FocusedColor = System.Drawing.Color.Empty;
            this.picture_circle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.picture_circle1.ForeColor = System.Drawing.Color.White;
            this.picture_circle1.Image = null;
            this.picture_circle1.ImageSize = new System.Drawing.Size(52, 52);
            this.picture_circle1.Location = new System.Drawing.Point(577, -86);
            this.picture_circle1.Name = "picture_circle1";
            this.picture_circle1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.picture_circle1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.picture_circle1.OnHoverForeColor = System.Drawing.Color.White;
            this.picture_circle1.OnHoverImage = null;
            this.picture_circle1.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.picture_circle1.Size = new System.Drawing.Size(226, 341);
            this.picture_circle1.TabIndex = 20;
            this.picture_circle1.TabStop = false;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label_password.Location = new System.Drawing.Point(203, 230);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(64, 17);
            this.label_password.TabIndex = 25;
            this.label_password.Text = "Password";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.BackColor = System.Drawing.Color.White;
            this.label_email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_email.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label_email.Location = new System.Drawing.Point(203, 141);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(39, 17);
            this.label_email.TabIndex = 24;
            this.label_email.Text = "Email";
            // 
            // label_sign_in
            // 
            this.label_sign_in.AutoSize = true;
            this.label_sign_in.BackColor = System.Drawing.Color.White;
            this.label_sign_in.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_sign_in.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sign_in.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label_sign_in.Location = new System.Drawing.Point(259, 100);
            this.label_sign_in.Name = "label_sign_in";
            this.label_sign_in.Size = new System.Drawing.Size(141, 16);
            this.label_sign_in.TabIndex = 17;
            this.label_sign_in.Text = "Sign in to your account";
            // 
            // label_welcomeAdmin
            // 
            this.label_welcomeAdmin.AutoSize = true;
            this.label_welcomeAdmin.BackColor = System.Drawing.Color.White;
            this.label_welcomeAdmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_welcomeAdmin.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcomeAdmin.Location = new System.Drawing.Point(225, 59);
            this.label_welcomeAdmin.Name = "label_welcomeAdmin";
            this.label_welcomeAdmin.Size = new System.Drawing.Size(210, 32);
            this.label_welcomeAdmin.TabIndex = 19;
            this.label_welcomeAdmin.Text = "Welcome Admin!";
            // 
            // picture_eye
            // 
            this.picture_eye.BackColor = System.Drawing.Color.Transparent;
            this.picture_eye.BaseColor = System.Drawing.Color.White;
            this.picture_eye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_eye.Image = ((System.Drawing.Image)(resources.GetObject("picture_eye.Image")));
            this.picture_eye.Location = new System.Drawing.Point(424, 261);
            this.picture_eye.Name = "picture_eye";
            this.picture_eye.Size = new System.Drawing.Size(25, 24);
            this.picture_eye.TabIndex = 30;
            this.picture_eye.TabStop = false;
            this.picture_eye.Click += new System.EventHandler(this.picture_eye_Click);
            // 
            // label_information
            // 
            this.label_information.AutoSize = true;
            this.label_information.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_information.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_information.ForeColor = System.Drawing.Color.Red;
            this.label_information.Location = new System.Drawing.Point(210, 304);
            this.label_information.Name = "label_information";
            this.label_information.Size = new System.Drawing.Size(241, 22);
            this.label_information.TabIndex = 18;
            this.label_information.Text = "Invalid Admin Information. Please try again!";
            this.label_information.Visible = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(660, 495);
            this.Controls.Add(this.picture_hide_eye);
            this.Controls.Add(this.picture_wrong);
            this.Controls.Add(this.Label_exit);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.picture_email);
            this.Controls.Add(this.picture_login);
            this.Controls.Add(this.TextBox_password);
            this.Controls.Add(this.TextBox_email);
            this.Controls.Add(this.picture_circle2);
            this.Controls.Add(this.picture_circle1);
            this.Controls.Add(this.label_information);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_sign_in);
            this.Controls.Add(this.label_welcomeAdmin);
            this.Controls.Add(this.picture_eye);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.picture_hide_eye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_wrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_eye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox picture_hide_eye;
        private Guna.UI.WinForms.GunaPictureBox picture_wrong;
        private Guna.UI.WinForms.GunaLabel Label_exit;
        private Guna.UI.WinForms.GunaButton button_login;
        private Guna.UI.WinForms.GunaPictureBox picture_email;
        private Guna.UI.WinForms.GunaPictureBox picture_login;
        private Guna.UI.WinForms.GunaTextBox TextBox_password;
        private Guna.UI.WinForms.GunaTextBox TextBox_email;
        private Guna.UI.WinForms.GunaCircleButton picture_circle2;
        private Guna.UI.WinForms.GunaCircleButton picture_circle1;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_sign_in;
        private System.Windows.Forms.Label label_welcomeAdmin;
        private Guna.UI.WinForms.GunaPictureBox picture_eye;
        private System.Windows.Forms.Label label_information;
    }
}