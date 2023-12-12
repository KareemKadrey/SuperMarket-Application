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
using Org.BouncyCastle.Utilities.Encoders;
using Guna.UI.WinForms;
using Org.BouncyCastle.Asn1.Cms;

namespace supermarket
{
    public partial class Customer_Sign_in : Form
    {
        public Customer_Sign_in()
        {
            InitializeComponent();
        }

        #region method to check if customer's email and password is exist in database
        private bool ValidateCustomerCredentials(string email, string password)
        {
            string connectionString = @"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE email = @Email AND password = @Password";
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

        #region buttons create account and login
        private void button_login_Click(object sender, EventArgs e)
        {
            string customerEmail = TextBox_email.Text;
            string customerPassword = TextBox_password.Text;

            // Validate the admin credentials against the database
            bool isValidCustomer = ValidateCustomerCredentials(customerEmail, customerPassword);

            if (isValidCustomer)
            {
                // Redirect to another page or form (e.g., AdminDashboardForm)
                CustomerDashboardForm customerDashboardForm = new CustomerDashboardForm(customerEmail);
                customerDashboardForm.Show();
                this.Hide();
            }
            else
            {
                label_information.Text = "Invalid Customer Information. Please try again!";
                label_information.Visible = true;
                picture_wrong.Visible = true;
            }
        }
        private void button_create_account_Click(object sender, EventArgs e)
        {
            RegisterCustomerForm regCustomer = new RegisterCustomerForm();
            regCustomer.Show();
            this.Hide();
        }
        private void button_create_account_MouseEnter(object sender, EventArgs e)
        {
            button_create_account.ForeColor = Color.SkyBlue;
        }
        private void button_create_account_MouseLeave(object sender, EventArgs e)
        {
            button_create_account.ForeColor = SystemColors.MenuHighlight;
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
        #endregion

    }
}