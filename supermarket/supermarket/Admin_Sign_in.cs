using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace supermarket
{
    public partial class Admin_Sign_in : Form
    {
        public Admin_Sign_in()
        {
            InitializeComponent();
        }

        #region method to check if admin's email and password is exist in database
        private bool ValidateAdminCredentials(string email, string password)
        {
            string connectionString = @"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT COUNT(*) FROM ADMIN WHERE email = @Email AND password = @Password";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int matchingRecordsCount = (int)command.ExecuteScalar();

                    return matchingRecordsCount > 0;
                }
            }
        }
        #endregion

        #region button login 
        private void button_login_Click(object sender, EventArgs e)
        {
            string adminEmail = TextBox_email.Text;
            string adminPassword = TextBox_password.Text;

            // Validate the admin credentials against the database
            bool isValidAdmin = ValidateAdminCredentials(adminEmail, adminPassword);

            if (isValidAdmin)
            {
                // Redirect to another page or form (e.g., AdminDashboardForm)
                AdminDashboardForm adminDashboardForm = new AdminDashboardForm();
                adminDashboardForm.CurrentAdminEmail = adminEmail; // Set the current admin's email
                adminDashboardForm.Show();
                this.Hide();
            }
            else
            {
                label_information.Text = "Invalid Admin Information. Please try again!";
                label_information.Visible = true;
                picture_wrong.Visible = true;
            }
        }
        #endregion

        #region pictures and textboxes and labels
        private void pictur_hide_eye_Click(object sender, EventArgs e)
        {
            if (TextBox_password.PasswordChar == '●')
            {
                picture_eye.BringToFront();
                TextBox_password.PasswordChar = '\0';
            }
        }
        private void picture_eye_Click(object sender, EventArgs e)
        {
            if (TextBox_password.PasswordChar == '\0')
            {
                picture_hide_eye.BringToFront();
                TextBox_password.PasswordChar = '●';
            }
        }
        private void TextBox_email_TextChanged(object sender, EventArgs e)
        {
            label_information.Visible = false;
            picture_wrong.Visible = false;
        }
        private void TextBox_password_TextChanged(object sender, EventArgs e)
        {
            label_information.Visible = false;
            picture_wrong.Visible = false;
        }
        private void Label_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to exit application ?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Label_exit_MouseEnter(object sender, EventArgs e)
        {
            Label_exit.ForeColor = Color.Red;
        }
        private void Label_exit_MouseLeave(object sender, EventArgs e)
        {
            Label_exit.ForeColor = SystemColors.HotTrack;
        }
        #endregion
    }
}