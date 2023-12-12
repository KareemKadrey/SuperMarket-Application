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
    public partial class RegisterCustomerForm : Form
    {
        
        public RegisterCustomerForm()
        {
            InitializeComponent();
        }

        #region buttons register and login
        private void button_register_Click(object sender, EventArgs e)
        {
            string customerEmail = text_email.Text;
            if (AreAllFieldsFilled())
            {
                if (IsEmailExists(text_email.Text))
                {
                    MessageBox.Show("Email already exists. Please use a different email.", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");

                cn.Open();
                // Create the SQL query
                SqlCommand MyCommand = new SqlCommand("insert into CUSTOMER (username,email,password,address,phone) values('" + text_username.Text.ToString() + "','" + text_email.Text.ToString() + "','" + text_password.Text.ToString() + "','" + text_address.Text.ToString() + "','" + text_phone.Text.ToString() + "')", cn);
                MyCommand.ExecuteNonQuery();
                MessageBox.Show("Account Created Successfully!", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                CustomerDashboardForm customerDashboardForm = new CustomerDashboardForm(customerEmail);
                customerDashboardForm.Show();
                this.Hide();
                this.Close();
            }
            else
            {
                label_information.Visible = true;
                picture_information.Visible = true;
                UpdateTextBoxBorders();
            }
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            Customer_Sign_in logCustomer = new Customer_Sign_in();
            logCustomer.Show();
            this.Hide();
        }
        private void button_login_MouseEnter(object sender, EventArgs e)
        {
            button_login.ForeColor = Color.SkyBlue;
        }
        private void button_login_MouseLeave(object sender, EventArgs e)
        {
            button_login.ForeColor = SystemColors.MenuHighlight;
        }
        #endregion

        #region pictures and labels and textboxes
        private void picture_hide_eye_Click(object sender, EventArgs e)
        {
            if (text_password.PasswordChar == '●')
            {
                picture_eye.BringToFront();
                text_password.PasswordChar = '\0';
            }
        }
        private void picture_eye_Click(object sender, EventArgs e)
        {
            if (text_password.PasswordChar == '\0')
            {
                picture_hide_eye.BringToFront();
                text_password.PasswordChar = '●';
            }
        }
        private void exit_label_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to exit application ?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void exit_label_MouseEnter(object sender, EventArgs e)
        {
            exit_label.ForeColor = Color.Red;
        }
        private void exit_label_MouseLeave(object sender, EventArgs e)
        {
            exit_label.ForeColor = SystemColors.HotTrack;
        }
        private void text_username_TextChanged(object sender, EventArgs e)
        {
            label_information.Visible = false;
            picture_information.Visible = false;
            text_username.BorderColor = Color.Silver;

        }
        private void text_email_TextChanged(object sender, EventArgs e)
        {
            label_information.Visible = false;
            picture_information.Visible = false;
            text_email.BorderColor = Color.Silver;
        }
        private void text_password_TextChanged(object sender, EventArgs e)
        {
            label_information.Visible = false;
            picture_information.Visible = false;
            text_password.BorderColor = Color.Silver;
        }
        private void text_address_TextChanged(object sender, EventArgs e)
        {
            label_information.Visible = false;
            picture_information.Visible = false;
            text_address.BorderColor = Color.Silver;
        }
        private void text_phone_TextChanged(object sender, EventArgs e)
        {
            label_information.Visible = false;
            picture_information.Visible = false;
            text_phone.BorderColor = Color.Silver;
        }
        private void UpdateTextBoxBorders()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_username.Text))
                text_username.BorderColor = Color.Red;
            else
                text_username.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_email.Text))
                text_email.BorderColor = Color.Red;
            else
                text_email.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_password.Text))
                text_password.BorderColor = Color.Red;
            else
                text_password.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_address.Text))
                text_address.BorderColor = Color.Red;
            else
                text_address.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_phone.Text))
                text_phone.BorderColor = Color.Red;
            else
                text_phone.BorderColor = Color.Silver;
        }
        #endregion

        #region method to check if email exist in database to reject it
        private bool IsEmailExists(string email)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CUSTOMER WHERE email = @Email", cn);
            cmd.Parameters.AddWithValue("@Email", email);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count > 0;
        }
        #endregion

        #region method to check if all textboxes are filled
        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(text_username.Text)
                && !string.IsNullOrWhiteSpace(text_email.Text)
                && !string.IsNullOrWhiteSpace(text_password.Text)
                && !string.IsNullOrWhiteSpace(text_address.Text)
                && !string.IsNullOrWhiteSpace(text_phone.Text);
        }
        #endregion
    }

}
