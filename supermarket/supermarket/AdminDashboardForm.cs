using Guna.UI.WinForms;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace supermarket
{
    public partial class AdminDashboardForm : Form
    {
        #region connection to database
        private string connectionString = "Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True";
        #endregion

        public AdminDashboardForm()
        {
            InitializeComponent();
            customizeDesign();
            LoadCategory();
            LoadBrand();
            LoadCategory_update();
            LoadBrand_update();
            searchTextBox_remove_customer.ForeColor = Color.Gray;
            searchTextBox_view_customer.ForeColor = Color.Gray;
            searchTextBox_remove_admin.ForeColor = Color.Gray;
            searchTextBox_remove_product.ForeColor = Color.Gray;
            searchTextBox_update_product.ForeColor = Color.Gray;
            searchTextBox_browse_product.ForeColor = Color.Gray;
            searchTextBox_remove_category.ForeColor = Color.Gray;
            searchTextBox_remove_brand.ForeColor = Color.Gray;
            searchTextBox_remove_stock.ForeColor = Color.Gray;
            searchTextBox_update_stock.ForeColor = Color.Gray;
            searchTextBox_remove_customer.Text = "Search...";
            searchTextBox_view_customer.Text = "Search...";
            searchTextBox_remove_admin.Text = "Search...";
            searchTextBox_remove_product.Text = "Search...";
            searchTextBox_update_product.Text = "Search...";
            searchTextBox_browse_product.Text = "Search...";
            searchTextBox_remove_category.Text = "Search...";
            searchTextBox_remove_brand.Text = "Search...";
            searchTextBox_remove_stock.Text = "Search...";
            searchTextBox_update_stock.Text = "Search...";
            searchTextBox_remove_customer.Enter += SearchTextBox_remove_customer_Enter;
            searchTextBox_remove_customer.Leave += SearchTextBox_remove_customer_Leave;
            searchTextBox_view_customer.Enter += SearchTextBox_view_customer_Enter;
            searchTextBox_view_customer.Leave += SearchTextBox_view_customer_Leave;
            searchTextBox_remove_admin.Enter += SearchTextBox_remove_admin_Enter;
            searchTextBox_remove_admin.Leave += SearchTextBox_remove_admin_Leave;
            searchTextBox_remove_product.Enter += searchTextBox_remove_product_Enter;
            searchTextBox_remove_product.Leave += searchTextBox_remove_product_Leave;
            searchTextBox_update_product.Enter += searchTextBox_update_product_Enter;
            searchTextBox_update_product.Leave += searchTextBox_update_product_Leave;
            searchTextBox_browse_product.Enter += searchTextBox_browse_product_Enter;
            searchTextBox_browse_product.Leave += searchTextBox_browse_product_Leave;
            searchTextBox_remove_category.Enter += SearchTextBox_remove_category_Enter;
            searchTextBox_remove_category.Leave += SearchTextBox_remove_category_Leave;
            searchTextBox_remove_brand.Enter += SearchTextBox_remove_brand_Enter;
            searchTextBox_remove_brand.Leave += SearchTextBox_remove_brand_Leave;
            searchTextBox_remove_stock.Enter += SearchTextBox_remove_stock_Enter;
            searchTextBox_remove_stock.Leave += SearchTextBox_remove_stock_Leave;
            searchTextBox_update_stock.Enter += SearchTextBox_update_stock_Enter;
            searchTextBox_update_stock.Leave += SearchTextBox_update_stock_Leave;
            PopulateCategoryComboBox();
            PopulateBrandComboBox();
            PopulateStockComboBox();
            rmPopulateCategoryComboBox();
            rmPopulateBrandComboBox();
            rmPopulateStockComboBox();
            uPopulateCategoryComboBox();
            uPopulateBrandComboBox();
            uPopulateStockComboBox();
            bPopulateCategoryComboBox();
            bPopulateBrandComboBox();
            bPopulateStockComboBox();
            ComboBox_category_remove.SelectedIndexChanged += ComboBox_category_remove_SelectedIndexChanged;
            ComboBox_brand_remove.SelectedIndexChanged += ComboBox_brand_remove_SelectedIndexChanged;
            ComboBox_stock_remove.SelectedIndexChanged += ComboBox_stock_remove_SelectedIndexChanged;
            ComboBox_category_view.SelectedIndexChanged += ComboBox_category_view_SelectedIndexChanged;
            ComboBox_brand_view.SelectedIndexChanged += ComboBox_brand_view_SelectedIndexChanged;
            ComboBox_stock_view.SelectedIndexChanged += ComboBox_stock_view_SelectedIndexChanged;
            ComboBox_category_browse.SelectedIndexChanged += ComboBox_category_browse_SelectedIndexChanged;
            ComboBox_brand_browse.SelectedIndexChanged += ComboBox_brand_browse_SelectedIndexChanged;
            ComboBox_stock_browse.SelectedIndexChanged += ComboBox_stock_browse_SelectedIndexChanged;
        }

        // Add a property to store the current admin's email
        public string CurrentAdminEmail { get; set; }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'superMarketDataSet17.STOCK' table. You can move, or remove it, as needed.
            this.sTOCKTableAdapter3.Fill(this.superMarketDataSet17.STOCK);
            // TODO: This line of code loads data into the 'superMarketDataSet16.STOCK' table. You can move, or remove it, as needed.
            this.sTOCKTableAdapter2.Fill(this.superMarketDataSet16.STOCK);
            // TODO: This line of code loads data into the 'superMarketDataSet15.STOCK' table. You can move, or remove it, as needed.
            this.sTOCKTableAdapter1.Fill(this.superMarketDataSet15.STOCK);
            // TODO: This line of code loads data into the 'superMarketDataSet14.STOCK' table. You can move, or remove it, as needed.
            this.sTOCKTableAdapter.Fill(this.superMarketDataSet14.STOCK);
            // TODO: This line of code loads data into the 'superMarketDataSet9.PRODUCT' table. You can move, or remove it, as needed.
            this.pRODUCTTableAdapter.Fill(this.superMarketDataSet9.PRODUCT);
            // TODO: This line of code loads data into the 'superMarketDataSet8.BRANDS' table. You can move, or remove it, as needed.
            this.bRANDSTableAdapter1.Fill(this.superMarketDataSet8.BRANDS);
            // TODO: This line of code loads data into the 'superMarketDataSet7.BRANDS' table. You can move, or remove it, as needed.
            this.bRANDSTableAdapter.Fill(this.superMarketDataSet7.BRANDS);
            // TODO: This line of code loads data into the 'superMarketDataSet6.CATEGORIES' table. You can move, or remove it, as needed.
            this.cATEGORIESTableAdapter1.Fill(this.superMarketDataSet6.CATEGORIES);
            // TODO: This line of code loads data into the 'superMarketDataSet3.CATEGORIES' table. You can move, or remove it, as needed.
            this.cATEGORIESTableAdapter.Fill(this.superMarketDataSet3.CATEGORIES);
            //originalformsize = new Rectangle(this.Location.X, this.Location.Y,this.Width, this.Height);
            //buttondelete = new Rectangle (remove_customer_panel.Location.X, remove_customer_panel.Location.Y, remove_customer_panel.Width , remove_customer_panel.Height);
            //buttondelete2 = new Rectangle(DeleteCustomer_button.Location.X, DeleteCustomer_button.Location.Y, DeleteCustomer_button.Width, DeleteCustomer_button.Height);
            //buttondelete3 = new Rectangle(Label_remove_customer.Location.X, Label_remove_customer.Location.Y, Label_remove_customer.Width, Label_remove_customer.Height);
            //buttondelete4 = new Rectangle(progressBar_remove_customer.Location.X, progressBar_remove_customer.Location.Y, progressBar_remove_customer.Width, progressBar_remove_customer.Height);
            //buttondelete5 = new Rectangle(searchTextBox_remove_customer.Location.X, searchTextBox_remove_customer.Location.Y, searchTextBox_remove_customer.Width, searchTextBox_remove_customer.Height);
            //buttondelete6 = new Rectangle(searchButton_remove_customer.Location.X, searchButton_remove_customer.Location.Y, searchButton_remove_customer.Width, searchButton_remove_customer.Height);
            //buttondelete7 = new Rectangle(DataGridView_removeCustomer.Location.X, DataGridView_removeCustomer.Location.Y, DataGridView_removeCustomer.Width, DataGridView_removeCustomer.Height);
            //buttondelete8 = new Rectangle(PanelSideMenu.Location.X, PanelSideMenu.Location.Y, PanelSideMenu.Width, PanelSideMenu.Height);
            // TODO: This line of code loads data into the 'superMarketDataSet2.ADMIN' table. You can move, or remove it, as needed.
            this.aDMINTableAdapter.Fill(this.superMarketDataSet2.ADMIN);
            // TODO: This line of code loads data into the 'superMarketDataSet5.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter3.Fill(this.superMarketDataSet5.CUSTOMER);
            // TODO: This line of code loads data into the 'superMarketDataSet4.ORDERS' table. You can move, or remove it, as needed.
            this.oRDERSTableAdapter1.Fill(this.superMarketDataSet4.ORDERS);
            // TODO: This line of code loads data into the 'superMarketDataSet4.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter2.Fill(this.superMarketDataSet4.CUSTOMER);
            // TODO: This line of code loads data into the 'superMarketDataSet.ORDERS' table. You can move, or remove it, as needed.
            this.oRDERSTableAdapter.Fill(this.superMarketDataSet.ORDERS);
            // TODO: This line of code loads data into the 'superMarketDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter1.Fill(this.superMarketDataSet.CUSTOMER);
            // TODO: This line of code loads data into the 'supermarketDataSet2.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.SuperMarketDataSet1.CUSTOMER);
            DataGridView_removeCustomer.CurrentCell = null;
            DataGridView_removeAdmin.CurrentCell = null;
            DataGridView_addStock.DataSource = null;
            UpdateDataGridViewWithFilters();
            UpdateDataGridViewWithFilters_view();
            UpdateDataGridViewWithFilters_browse();
            UpdateDataGridViewWithFilters_addStock();
            ToolTip toolTip = new ToolTip();

            // Set the tooltip text for the button
            toolTip.SetToolTip(query1_button, "The Most Bought Product(that had maximum number of customers)");
            toolTip.SetToolTip(query2_button, "The Product that has no customers for a specific month(12/2023)(never bought)");
            toolTip.SetToolTip(query3_button, "The Customer that didnt buy any product since one year");
            toolTip.SetToolTip(query4_button, "The Customer that made the highest purchase this month)");
            toolTip.SetToolTip(query5_button, "Compare of Selling of the two categories (Electric Appliances,Food Products)");
            toolTip.SetToolTip(query6_button, "All information about the products");
        }

        

        #region Admin

        #region add new admin panel

        #region methods for add new admin panel
        private bool IsEmailExists_admin(string email)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ADMIN WHERE email = @Email", cn);
            cmd.Parameters.AddWithValue("@Email", email);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count > 0;
        }
        private void UpdateTextBoxBorders_admin()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_username_admin.Text))
                text_username_admin.BorderColor = Color.Red;
            else
                text_username_admin.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_email_admin.Text))
                text_email_admin.BorderColor = Color.Red;
            else
                text_email_admin.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_password_admin.Text))
                text_password_admin.BorderColor = Color.Red;
            else
                text_password_admin.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_admin()
        {
            return !string.IsNullOrWhiteSpace(text_username_admin.Text)
                && !string.IsNullOrWhiteSpace(text_email_admin.Text)
                && !string.IsNullOrWhiteSpace(text_password_admin.Text);
        }
        #endregion

        #region textBoxes and pictures of add new customer panel
        private void AddAdmin_button_Click(object sender, EventArgs e)
        {
            string adminEmail = text_email_admin.Text;
            if (AreAllFieldsFilled_admin())
            {
                if (IsEmailExists_admin(text_email_admin.Text))
                {
                    MessageBox.Show("Email already exists. Please use a different email.", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");

                cn.Open();
                // Create the SQL query
                SqlCommand MyCommand = new SqlCommand("insert into ADMIN (username,email,password) values('" + text_username_admin.Text.ToString() + "','" + text_email_admin.Text.ToString() + "','" + text_password_admin.Text.ToString() + "')", cn);
                MyCommand.ExecuteNonQuery();
                MessageBox.Show("Admin Added Successfully!", "Add Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show_admin();
            }
            else
            {
                Label_information_admin.Visible = true;
                Picture_information_admin.Visible = true;
                UpdateTextBoxBorders_admin();
            }
        }
        private void picture_hide_eye_admin_Click(object sender, EventArgs e)
        {
            if (text_password_admin.PasswordChar == '●')
            {
                picture_eye_admin.BringToFront();
                text_password_admin.PasswordChar = '\0';
            }
        }

        private void picture_eye_admin_Click(object sender, EventArgs e)
        {
            if (text_password_admin.PasswordChar == '\0')
            {
                picture_hide_eye_admin.BringToFront();
                text_password_admin.PasswordChar = '●';
            }
        }

        private void text_username_admin_TextChanged(object sender, EventArgs e)
        {
            Label_information_admin.Visible = false;
            Picture_information_admin.Visible = false;
            text_username_admin.BorderColor = Color.Silver;
        }

        private void text_email_admin_TextChanged(object sender, EventArgs e)
        {
            Label_information_admin.Visible = false;
            Picture_information_admin.Visible = false;
            text_email_admin.BorderColor = Color.Silver;
        }

        private void text_password_admin_TextChanged(object sender, EventArgs e)
        {
            Label_information_admin.Visible = false;
            Picture_information_admin.Visible = false;
            text_password_admin.BorderColor = Color.Silver;
        }
        #endregion

        #endregion

        #region remove admin panel

        #region search and delete buttons

        private void SearchTextBox_remove_admin_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_remove_admin.Text == "Search...")
            {
                searchTextBox_remove_admin.Text = "";
                searchTextBox_remove_admin.ForeColor = Color.Black;
            }
        }
        private void SearchTextBox_remove_admin_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_remove_admin.Text))
            {
                searchTextBox_remove_admin.Text = "Search...";
                searchTextBox_remove_admin.ForeColor = Color.Gray;
            }
        }
        private void SearchTextBox_remove_admin_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_remove_admin.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                show_admin();
            }
            else
            {
                show_admin(searchQuery);
            }
        }
        private void DeleteAdmin_button_Click(object sender, EventArgs e)
        {
            // Check if at least one customer is selected
            bool anyAdminSelected = false;

            foreach (DataGridViewRow row in DataGridView_removeAdmin.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select_admin"].Value);
                if (isChecked)
                {
                    anyAdminSelected = true;
                    break; // Exit the loop as soon as one customer is selected
                }
            }

            if (!anyAdminSelected)
            {
                MessageBox.Show("Please choose at least one admin to remove.", "Remove Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without deleting customers
            }

            if (MessageBox.Show("Are you sure you want to remove the selected admins?", "Remove Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveAdmin();
            }
        }

        #endregion

        #region methods for remove admin

        private void RemoveAdmin()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in DataGridView_removeAdmin.Rows)
                    {
                        bool isChecked = Convert.ToBoolean(row.Cells["Select_admin"].Value); // Assuming the checkbox column is named "select"
                        if (isChecked)
                        {
                            string email = row.Cells["email_admin"].Value.ToString(); // Assuming the email column is named "email"

                            // Check if the admin being deleted is the currently logged-in admin
                            if (email.Equals(CurrentAdminEmail, StringComparison.OrdinalIgnoreCase))
                            {
                                // Admin is deleting their own account, perform logout operation
                                MessageBox.Show("You have deleted your own account. Logging out...", "Remove Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string deleteQuery = "DELETE FROM ADMIN WHERE email = @email";
                                SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                                deleteCmd.Parameters.AddWithValue("@email", email);
                                deleteCmd.ExecuteNonQuery();
                                // Redirect to the sign-in form
                                Admin_Sign_in signInForm = new Admin_Sign_in();
                                signInForm.Show();
                                this.Hide();
                                return;
                            }

                            // Delete the admin account
                            string query = "DELETE FROM ADMIN WHERE email = @email";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Admin removed successfully.", "Remove Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show_admin(); // Refresh the DataGridView after removing the admins
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Remove Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region DataGridView remove admin

        private void show_admin(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT * FROM ADMIN";
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE username LIKE @searchQuery OR email LIKE @searchQuery OR admin_id LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_removeAdmin.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataGridView_removeAdmin_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_removeAdmin.Cursor = Cursors.Hand;
        }
        private void DataGridView_removeAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Find the column index with the header text "Select"
                int selectColumnIndex = -1;
                foreach (DataGridViewColumn column in DataGridView_removeAdmin.Columns)
                {
                    if (column.HeaderText.Equals("Select", StringComparison.OrdinalIgnoreCase))
                    {
                        selectColumnIndex = column.Index;
                        break;
                    }
                }

                if (selectColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)DataGridView_removeAdmin.Rows[e.RowIndex].Cells[selectColumnIndex];
                    selectedCell.Value = !Convert.ToBoolean(selectedCell.Value); // Toggle the value of the checkbox
                }
                else
                {
                    MessageBox.Show("Column 'Select' not found in the DataGridView.", "Remove Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DataGridView_removeAdmin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value ?? false; // Set the default value to false if it is null
            }
        }
        private void DataGridView_removeAdmin_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || !(bool)cell.Value)
                {
                    cell.Value = false;
                }
            }
        }

        #endregion

        #endregion

        #region update admin panel

        #region method to load admin data in the textboxes for update profile
        private void LoadAdminInformation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT admin_id ,Username, Email, Password FROM ADMIN WHERE Email = @email";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@email", CurrentAdminEmail);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox_Id_admin.Text = reader["admin_id"].ToString();
                        textBox_Username_admin.Text = reader["Username"].ToString();
                        textBox_email_admin.Text = reader["Email"].ToString();
                        textBox_password_admin.Text = reader["Password"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Admin not found in the database.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region textBoxes and pictures of update admin panel

        private void Button_update_profile_admin_Click(object sender, EventArgs e)
        {
            UpdateAdminProfile();
        }

        private void textBox_Username_admin_TextChanged(object sender, EventArgs e)
        {
            Label_information_admin2.Visible = false;
            Picture_information_admin2.Visible = false;
            textBox_Username_admin.BorderColor = Color.Silver;
        }

        private void textBox_password_admin_TextChanged(object sender, EventArgs e)
        {
            Label_information_admin2.Visible = false;
            Picture_information_admin2.Visible = false;
            textBox_password_admin.BorderColor = Color.Silver;
        }

        #endregion

        #region method to update admin profile

        private void UpdateAdminProfile()
        {
            string username = textBox_Username_admin.Text;
            string password = textBox_password_admin.Text;
            if (AreAllFieldsFilled_admin2())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE ADMIN SET Username = @username, Password = @password WHERE Email = @email";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@email", CurrentAdminEmail);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Admin information updated successfully.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            show_admin();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Admin not found in the database.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                Label_information_admin2.Visible = true;
                Picture_information_admin2.Visible = true;
                UpdateTextBoxBorders_admin2();
            }
        }
        private bool AreAllFieldsFilled_admin2()
        {
            return !string.IsNullOrWhiteSpace(textBox_Username_admin.Text)
                && !string.IsNullOrWhiteSpace(textBox_password_admin.Text);
        }
        private void UpdateTextBoxBorders_admin2()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(textBox_Username_admin.Text))
                textBox_Username_admin.BorderColor = Color.Red;
            else
                textBox_Username_admin.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(textBox_password_admin.Text))
                textBox_password_admin.BorderColor = Color.Red;
            else
                textBox_password_admin.BorderColor = Color.Silver;
        }

        #endregion

        #endregion

        #endregion

        #region Customer

        #region remove customer panel

        #region search and delete buttons
        private void SearchTextBox_remove_customer_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_remove_customer.Text == "Search...")
            {
                searchTextBox_remove_customer.Text = "";
                searchTextBox_remove_customer.ForeColor = Color.Black;
            }
        }
        private void SearchTextBox_remove_customer_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_remove_customer.Text))
            {
                searchTextBox_remove_customer.Text = "Search...";
                searchTextBox_remove_customer.ForeColor = Color.Gray;
            }
        }
        private void SearchTextBox_remove_customer_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_remove_customer.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                show_customer();
            }
            else
            {
                show_customer(searchQuery);
            }
        }
        private void DeleteCustomer_button_Click(object sender, EventArgs e)
        {
            // Check if at least one customer is selected
            bool anyCustomerSelected = false;

            foreach (DataGridViewRow row in DataGridView_removeCustomer.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isChecked)
                {
                    anyCustomerSelected = true;
                    break; // Exit the loop as soon as one customer is selected
                }
            }

            if (!anyCustomerSelected)
            {
                MessageBox.Show("Please choose at least one customer to remove.", "Remove Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without deleting customers
            }

            if (MessageBox.Show("Are you sure you want to remove the selected customers?", "Remove Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveCustomer();
            }
        }

        #endregion

        #region methods for remove customer
        private void RemoveCustomer()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in DataGridView_removeCustomer.Rows)
                    {
                        bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value); // Assuming the checkbox column is named "select"
                        if (isChecked)
                        {
                            string Email = row.Cells["email"].Value.ToString(); // Assuming the email column is named "email"
                            string query = "DELETE FROM CUSTOMER WHERE email = @email";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@email", Email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Customers removed successfully.", "Remove Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show_customer(); // Refresh the DataGridView after removing the customers
                    loadCustomerData_inDataGridView();
                    loadVoucher_inDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Remove Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DataGridView remove cutomer
        private void show_customer(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT * FROM CUSTOMER";
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE username LIKE @searchQuery OR email LIKE @searchQuery OR address LIKE @searchQuery OR customer_id LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_removeCustomer.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataGridView_removeCustomer_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_removeCustomer.Cursor = Cursors.Hand;
        }
        private void DataGridView_removeCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Find the column index with the header text "Select"
                int selectColumnIndex = -1;
                foreach (DataGridViewColumn column in DataGridView_removeCustomer.Columns)
                {
                    if (column.HeaderText.Equals("Select", StringComparison.OrdinalIgnoreCase))
                    {
                        selectColumnIndex = column.Index;
                        break;
                    }
                }

                if (selectColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)DataGridView_removeCustomer.Rows[e.RowIndex].Cells[selectColumnIndex];
                    selectedCell.Value = !Convert.ToBoolean(selectedCell.Value); // Toggle the value of the checkbox
                }
                else
                {
                    MessageBox.Show("Column 'Select' not found in the DataGridView.", "Remove Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DataGridView_removeCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value ?? false; // Set the default value to false if it is null
            }
        }
        private void DataGridView_removeCustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || !(bool)cell.Value)
                {
                    cell.Value = false;
                }
            }
        }
        #endregion

        #endregion

        #region update customer panel

        #region search and update buttons 

        private void SearchTextBox_view_customer_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_view_customer.Text == "Search...")
            {
                searchTextBox_view_customer.Text = "";
                searchTextBox_view_customer.ForeColor = Color.Black;
            }
        }
        private void SearchTextBox_view_customer_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_view_customer.Text))
            {
                searchTextBox_view_customer.Text = "Search...";
                searchTextBox_view_customer.ForeColor = Color.Gray;
            }
        }
        private void SearchTextBox_view_customer_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_view_customer.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                loadCustomerData_inDataGridView();
            }
            else
            {
                loadCustomerData_inDataGridView(searchQuery);
            }
        }
        private void UpdateTextBoxBorders_customers()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(Address_TextBox.Text))
                Address_TextBox.BorderColor = Color.Red;
            else
                Address_TextBox.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(Phone_TextBox.Text))
                Phone_TextBox.BorderColor = Color.Red;
            else
                Phone_TextBox.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_customers()
        {
            return !string.IsNullOrWhiteSpace(Address_TextBox.Text)
                && !string.IsNullOrWhiteSpace(Phone_TextBox.Text);
        }
        private void UpdateTextBoxBorders_order()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(OrderStatus_TextBox.Text))
                OrderStatus_TextBox.BorderColor = Color.Red;
            else
                OrderStatus_TextBox.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_order()
        {
            return !string.IsNullOrWhiteSpace(OrderStatus_TextBox.Text);
        }
        private void UpdateCustomer_button_Click(object sender, EventArgs e)
        {
            // Assuming "customer_id" is the column name in DataGridView_removeCustomer
            int selectedID = Convert.ToInt32(DataGridView_updateCustomers.CurrentRow.Cells["customer_id"].Value);

            DataTable customerData = GetCustomerData(selectedID);

            // Bind the retrieved data to your DataGridView in the update_customer_panel
            dataGridView_updateCustomer.DataSource = customerData;

            // Make the DataGridView in the update_customer_panel editable as needed
            dataGridView_updateCustomer.ReadOnly = false;
            dataGridView_updateCustomer.Columns["order_id"].ReadOnly = true;
            dataGridView_updateCustomer.Columns["order_status"].ReadOnly = true;
            CustomerID_TextBox.ReadOnly = true;
            CustomerName_TextBox.ReadOnly = true;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = true;
            update_customers_panel.Visible = false;
            hideSubMenu();
            LoadCustomerInformation_inTheTextBoxes();
        }
        private void button_UpdateCustomer_order_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("Please select a order to update.", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Assuming you have a primary key (e.g., customer_id) to identify the customer
            int orderId = Convert.ToInt32(dataGridView_updateCustomer.Rows[index].Cells["order_id"].Value);

            // Retrieve the updated data from the DataGridView and TextBoxes
            string updatedOrderStatus = OrderStatus_TextBox.Text; // Assuming you have a TextBox for order_status
                                                                  // Update the data in the database
            if (AreAllFieldsFilled_order())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        // Update the order_status in the ORDERS table
                        string updateOrderStatusQuery = "UPDATE ORDERS SET order_status = @orderStatus WHERE order_id = @orderId";
                        SqlCommand orderStatusCmd = new SqlCommand(updateOrderStatusQuery, connection);
                        orderStatusCmd.Parameters.AddWithValue("@orderStatus", updatedOrderStatus);
                        orderStatusCmd.Parameters.AddWithValue("@orderId", orderId);
                        int orderStatusRowsAffected = orderStatusCmd.ExecuteNonQuery();

                        if (orderStatusRowsAffected > 0)
                        {
                            MessageBox.Show("Order Status updated successfully.", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Update the DataGridView with the new data
                            DataGridViewRow selectedRow = dataGridView_updateCustomer.Rows[index];
                            selectedRow.Cells["order_status"].Value = updatedOrderStatus;
                            show_customer();
                            loadCustomerData_inDataGridView();
                            loadVoucher_inDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Customer not found in the database.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Label_information_order.Visible = true;
                Picture_information_order.Visible = true;
                UpdateTextBoxBorders_order();
            }
        }
        private void button_UpdateCustomer_data_Click(object sender, EventArgs e)
        {
            int selectedID = Convert.ToInt32(DataGridView_updateCustomers.CurrentRow.Cells["customer_id"].Value);
            string address = Address_TextBox.Text;
            string phone = Phone_TextBox.Text;
            if (AreAllFieldsFilled_customers())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE CUSTOMER SET address = @address, phone = @phone WHERE customer_id = @selectedID";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@selectedID", selectedID);
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            MessageBox.Show("Customer information updated successfully.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            show_customer();
                            loadCustomerData_inDataGridView();
                            loadVoucher_inDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Customer not found in the database.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Label_information_customers.Visible = true;
                Picture_information_customers.Visible = true;
                UpdateTextBoxBorders_customers();
            }
        }
        private void Address_TextBox_TextChanged(object sender, EventArgs e)
        {
            Label_information_customers.Visible = false;
            Picture_information_customers.Visible = false;
            Address_TextBox.BorderColor = Color.Silver;
        }
        private void Phone_TextBox_TextChanged(object sender, EventArgs e)
        {
            Label_information_customers.Visible = false;
            Picture_information_customers.Visible = false;
            Phone_TextBox.BorderColor = Color.Silver;
        }
        private void OrderStatus_TextBox_TextChanged(object sender, EventArgs e)
        {
            Label_information_order.Visible = false;
            Picture_information_order.Visible = false;
            OrderStatus_TextBox.BorderColor = Color.Silver;
        }

        #endregion

        #region DataGridView Update customer

        private DataTable GetCustomerData(int selectedID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            o.order_id,
                            o.order_status
                        FROM
                            CUSTOMER c
                        INNER JOIN
                            ORDERS o
                        ON
                            c.customer_id = o.customer_id
                        WHERE
                            c.customer_id = @selectedID;
                    ";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@selectedID", selectedID);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return dataTable;
        }

        private int index = -1;
        private void dataGridView_updateCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                DataGridViewRow row = dataGridView_updateCustomer.Rows[index];
                OrderStatus_TextBox.Text = row.Cells[1].Value.ToString();
                OrderID_TextBox.Text = row.Cells[0].Value.ToString();
                OrderID_TextBox.ReadOnly = true;
            }

        }

        private void loadCustomerData_inDataGridView(string searchQuery = "")
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "SELECT customer_id , username , address , phone FROM CUSTOMER";
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                sql += " WHERE customer_id LIKE @searchQuery OR username LIKE @searchQuery OR address LIKE @searchQuery OR phone LIKE @searchQuery";
            }

            SqlCommand cmd = new SqlCommand(sql, connection);

            // Add parameters for the search query
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DataGridView_updateCustomers.DataSource = dataTable;
        }

        private void LoadCustomerInformation_inTheTextBoxes()
        {
            int selectedID = Convert.ToInt32(DataGridView_updateCustomers.CurrentRow.Cells["customer_id"].Value);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT customer_id, username, address, phone FROM CUSTOMER WHERE customer_id = @selectedID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@selectedID", selectedID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        CustomerID_TextBox.Text = reader["customer_id"].ToString();
                        CustomerName_TextBox.Text = reader["username"].ToString();
                        Address_TextBox.Text = reader["address"].ToString();
                        Phone_TextBox.Text = reader["phone"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found in the database.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        #endregion

        #endregion

        #region add new customer panel

        #region methods for add new customer panel
        private bool IsEmailExists_customer(string email)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CUSTOMER WHERE email = @Email", cn);
            cmd.Parameters.AddWithValue("@Email", email);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count > 0;
        }
        private void UpdateTextBoxBorders_customer()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_username_customer.Text))
                text_username_customer.BorderColor = Color.Red;
            else
                text_username_customer.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_email_customer.Text))
                text_email_customer.BorderColor = Color.Red;
            else
                text_email_customer.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_password_customer.Text))
                text_password_customer.BorderColor = Color.Red;
            else
                text_password_customer.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_address_customer.Text))
                text_address_customer.BorderColor = Color.Red;
            else
                text_address_customer.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(text_phone_customer.Text))
                text_phone_customer.BorderColor = Color.Red;
            else
                text_phone_customer.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_customer()
        {
            return !string.IsNullOrWhiteSpace(text_username_customer.Text)
                && !string.IsNullOrWhiteSpace(text_email_customer.Text)
                && !string.IsNullOrWhiteSpace(text_password_customer.Text)
                && !string.IsNullOrWhiteSpace(text_address_customer.Text)
                && !string.IsNullOrWhiteSpace(text_phone_customer.Text);
        }
        #endregion

        #region textBoxes and pictures of add new customer panel
        private void AddCustomer_button_Click(object sender, EventArgs e)
        {
            string customerEmail = text_email_customer.Text;
            if (AreAllFieldsFilled_customer())
            {
                if (IsEmailExists_customer(text_email_customer.Text))
                {
                    MessageBox.Show("Email already exists. Please use a different email.", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");

                cn.Open();
                // Create the SQL query
                SqlCommand MyCommand = new SqlCommand("insert into CUSTOMER (username,email,password,address,phone) values('" + text_username_customer.Text.ToString() + "','" + text_email_customer.Text.ToString() + "','" + text_password_customer.Text.ToString() + "','" + text_address_customer.Text.ToString() + "','" + text_phone_customer.Text.ToString() + "')", cn);
                MyCommand.ExecuteNonQuery();
                MessageBox.Show("Customer Added Successfully!", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show_customer();
                loadCustomerData_inDataGridView();
            }
            else
            {
                Label_information_customer.Visible = true;
                picture_information_customer.Visible = true;
                UpdateTextBoxBorders_customer();
            }
        }
        private void picture_hide_eye_customer_Click(object sender, EventArgs e)
        {
            if (text_password_customer.PasswordChar == '●')
            {
                picture_eye_customer.BringToFront();
                text_password_customer.PasswordChar = '\0';
            }
        }

        private void picture_eye_customer_Click(object sender, EventArgs e)
        {
            if (text_password_customer.PasswordChar == '\0')
            {
                picture_hide_eye_customer.BringToFront();
                text_password_customer.PasswordChar = '●';
            }
        }

        private void text_username_customer_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            picture_information_customer.Visible = false;
            text_username_customer.BorderColor = Color.Silver;
        }

        private void text_email_customer_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            picture_information_customer.Visible = false;
            text_email_customer.BorderColor = Color.Silver;
        }

        private void text_password_customer_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            picture_information_customer.Visible = false;
            text_password_customer.BorderColor = Color.Silver;
        }

        private void text_address_customer_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            picture_information_customer.Visible = false;
            text_address_customer.BorderColor = Color.Silver;
        }

        private void text_phone_customer_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            picture_information_customer.Visible = false;
            text_phone_customer.BorderColor = Color.Silver;
        }
        #endregion

        #endregion

        #region discount voucher panel

        #region DataGridView List of discount voucher

        private void loadVoucher_inDataGridView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = @"SELECT c.customer_id as'Customer ID',d.voucher_id as 'Voucher ID', c.username as'Username' ,c.phone as 'Phone', d.amount_discount as 'Discount', 
                            d.expiry_date_of_discount as 'End at',COUNT(o.order_id) as 'No. of Orders' 
                            FROM DISCOUNT_VOUCHER as d INNER JOIN CUSTOMER as c
                            ON c.customer_id = d.customer_id
                            INNER JOIN ORDERS as o
                            ON c.customer_id = o.customer_id
                            GROUP BY c.customer_id,d.voucher_id, c.username ,c.phone, d.amount_discount, 
                            d.expiry_date_of_discount;";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DataGridView_dicountVoucher.DataSource = dataTable;
        }

        #endregion

        #endregion

        #endregion

        #region Product

        #region add new product panel

        private int GetAdminId(string adminEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string adminIdQuery = "SELECT admin_id FROM ADMIN WHERE email = @AdminEmail";

                using (SqlCommand adminIdCommand = new SqlCommand(adminIdQuery, connection))
                {
                    adminIdCommand.Parameters.AddWithValue("@AdminEmail", adminEmail);
                    object result = adminIdCommand.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int adminId))
                    {
                        return adminId;
                    }
                }
                return -1;
            }
        }

        private void PopulateCategoryComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string categoryQuery = "SELECT category_name FROM CATEGORIES";

                using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                {
                    using (SqlDataReader categoryReader = categoryCommand.ExecuteReader())
                    {
                        ComboBox_category.Items.Clear();
                        while (categoryReader.Read())
                        {
                            ComboBox_category.Items.Add(categoryReader["category_name"].ToString());
                        }
                    }
                }
            }
        }

        private void PopulateBrandComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string brandQuery = "SELECT brand_name FROM BRANDS"; // Update "BRANDS" to your actual table name

                using (SqlCommand brandCommand = new SqlCommand(brandQuery, connection))
                {
                    using (SqlDataReader brandReader = brandCommand.ExecuteReader())
                    {
                        ComboBox_brand.Items.Clear();
                        while (brandReader.Read())
                        {
                            ComboBox_brand.Items.Add(brandReader["brand_name"].ToString());
                        }
                    }
                }
            }
        }

        private void PopulateStockComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string stockQuery = "SELECT stock_location FROM STOCK";

                using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                {
                    using (SqlDataReader stockReader = stockCommand.ExecuteReader())
                    {
                        ComboBox_stock.Items.Clear();
                        while (stockReader.Read())
                        {
                            ComboBox_stock.Items.Add(stockReader["stock_location"].ToString());
                        }
                    }
                }
            }
        }

        private void add_product_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected values from the ComboBoxes
                string productName = text_product_name.Text;
                float price = float.Parse(text_product_price.Text);
                int quantity = int.Parse(text_product_quantity.Text);
                DateTime productionDate = DateTimePicker_productionDate.Value;
                DateTime expiryDate = DateTimePicker_expiryDate.Value;
                string category = ComboBox_category.SelectedItem.ToString();
                string brand = ComboBox_brand.SelectedItem.ToString();
                string stockLocation = ComboBox_stock.SelectedItem.ToString();
                string formattedTotalPrice = price.ToString("0.00");

                // Get the admin_id associated with the current admin's email
                int adminId = GetAdminId(CurrentAdminEmail);

                // Insert the new product into the PRODUCT table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertProductQuery = "INSERT INTO PRODUCT (product_name, price, quantity, production_date, expiry_date, admin_id, category_id, stock_id, brand_id) " +
                                                "VALUES (@ProductName, @Price, @Quantity, @ProductionDate, @ExpiryDate, @AdminId, " +
                                                "(SELECT category_id FROM CATEGORIES WHERE category_name = @Category), " +
                                                "(SELECT stock_id FROM STOCK WHERE stock_location = @StockLocation), " +
                                                "(SELECT brand_id FROM BRANDS WHERE brand_name = @Brand))";

                    using (SqlCommand insertProductCommand = new SqlCommand(insertProductQuery, connection))
                    {
                        insertProductCommand.Parameters.AddWithValue("@ProductName", productName);
                        insertProductCommand.Parameters.AddWithValue("@Price", formattedTotalPrice);
                        insertProductCommand.Parameters.AddWithValue("@Quantity", quantity);
                        insertProductCommand.Parameters.AddWithValue("@ProductionDate", productionDate);
                        insertProductCommand.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                        insertProductCommand.Parameters.AddWithValue("@AdminId", adminId);
                        insertProductCommand.Parameters.AddWithValue("@Category", category);
                        insertProductCommand.Parameters.AddWithValue("@StockLocation", stockLocation);
                        insertProductCommand.Parameters.AddWithValue("@Brand", brand);

                        int rowsAffected = insertProductCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product added successfully.");
                            UpdateDataGridViewWithFilters();
                            UpdateDataGridViewWithFilters_view();
                            UpdateDataGridViewWithFilters_browse();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the product.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        #endregion

        #region remove product panel

        #region methods to show the category and the brand and the stock in the comboBoxes
        private void rmPopulateCategoryComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string categoryQuery = "SELECT category_name FROM CATEGORIES";

                using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                {
                    using (SqlDataReader categoryReader = categoryCommand.ExecuteReader())
                    {
                        ComboBox_category_remove.Items.Clear();
                        while (categoryReader.Read())
                        {
                            ComboBox_category_remove.Items.Add(categoryReader["category_name"].ToString());
                        }
                    }
                }
            }
        }

        private void rmPopulateBrandComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string brandQuery = "SELECT brand_name FROM BRANDS"; // Update "BRANDS" to your actual table name

                using (SqlCommand brandCommand = new SqlCommand(brandQuery, connection))
                {
                    using (SqlDataReader brandReader = brandCommand.ExecuteReader())
                    {
                        ComboBox_brand_remove.Items.Clear();
                        while (brandReader.Read())
                        {
                            ComboBox_brand_remove.Items.Add(brandReader["brand_name"].ToString());
                        }
                    }
                }
            }
        }

        private void rmPopulateStockComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string stockQuery = "SELECT stock_location FROM STOCK";

                using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                {
                    using (SqlDataReader stockReader = stockCommand.ExecuteReader())
                    {
                        ComboBox_stock_remove.Items.Clear();
                        while (stockReader.Read())
                        {
                            ComboBox_stock_remove.Items.Add(stockReader["stock_location"].ToString());
                        }
                    }
                }
            }
        }

        private void ComboBox_category_remove_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters();
        }

        private void ComboBox_brand_remove_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters();
        }

        private void ComboBox_stock_remove_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters();
        }

        #endregion

        #region search and delete buttons

        private void show_product(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT P.product_id AS ID, P.product_name AS Name, P.price AS Price, P.quantity AS Quantity, C.category_name AS Category, B.brand_name AS Brand, S.stock_location as Stock " +
                        "FROM PRODUCT AS P " +
                        "INNER JOIN CATEGORIES AS C ON P.category_id = C.category_id " +
                        "INNER JOIN STOCK AS S ON P.stock_id = S.stock_id " +
                        "INNER JOIN BRANDS AS B ON P.brand_id = B.brand_id ";

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE P.product_name LIKE @searchQuery OR P.product_id LIKE @searchQuery OR P.price LIKE @searchQuery OR P.quantity LIKE @searchQuery OR C.category_name LIKE @searchQuery OR B.brand_name LIKE @searchQuery OR S.stock_location LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);
                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_removeProduct.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void searchTextBox_remove_product_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_remove_product.Text == "Search...")
            {
                searchTextBox_remove_product.Text = "";
                searchTextBox_remove_product.ForeColor = Color.Black;
            }
        }
        private void searchTextBox_remove_product_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_remove_product.Text))
            {
                searchTextBox_remove_product.Text = "Search...";
                searchTextBox_remove_product.ForeColor = Color.Gray;
            }
        }
        private void searchTextBox_remove_product_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_remove_product.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                UpdateDataGridViewWithFilters();
            }
            else
            {
                show_product(searchQuery);
            }
        }
        private void DeleteProduct_button_Click(object sender, EventArgs e)
        {
            // Check if at least one product is selected
            bool anyProductSelected = false;

            foreach (DataGridViewRow row in DataGridView_removeProduct.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select_product"].Value);
                if (isChecked)
                {
                    anyProductSelected = true;
                    break; // Exit the loop as soon as one product is selected
                }
            }

            if (!anyProductSelected)
            {
                MessageBox.Show("Please choose at least one product to remove.", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without deleting customers
            }

            if (MessageBox.Show("Are you sure you want to remove the selected products?", "Remove Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveProduct();
            }
        }

        #endregion

        #region methods for remove product

        private void RemoveProduct()
        {
            // Check if a product is selected in the DataGridView
            if (DataGridView_removeProduct.SelectedRows.Count > 0)
            {
                // Get the selected product's ID (assuming the product ID is in the second column)
                int selectedProductID = (int)DataGridView_removeProduct.SelectedRows[0].Cells[1].Value;

                // Construct an SQL query to delete the product based on the ID
                string deleteQuery = "DELETE FROM PRODUCT WHERE product_id = @productID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@productID", selectedProductID);

                        // Execute the SQL query to delete the product
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // The product was successfully deleted
                            // You may want to show a success message or refresh the DataGridView
                            MessageBox.Show("Product deleted successfully.");
                            UpdateDataGridViewWithFilters();
                            UpdateDataGridViewWithFilters_view();// Refresh the DataGridView
                            UpdateDataGridViewWithFilters_browse();
                        }
                        else
                        {
                            // No rows were affected, indicating the product wasn't found or an error occurred
                            MessageBox.Show("Failed to delete the product.");
                        }
                    }
                }
            }
            else
            {
                // No product is selected in the DataGridView
                MessageBox.Show("Please select a product to delete.");
            }
        }

        #endregion

        #region DataGridView remove product

        private void DataGridView_removeProduct_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_removeProduct.Cursor = Cursors.Hand;
        }
        private void DataGridView_removeProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Find the column index with the header text "Select"
                int selectColumnIndex = -1;
                foreach (DataGridViewColumn column in DataGridView_removeProduct.Columns)
                {
                    if (column.HeaderText.Equals("Select", StringComparison.OrdinalIgnoreCase))
                    {
                        selectColumnIndex = column.Index;
                        break;
                    }
                }

                if (selectColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)DataGridView_removeProduct.Rows[e.RowIndex].Cells[selectColumnIndex];
                    selectedCell.Value = !Convert.ToBoolean(selectedCell.Value); // Toggle the value of the checkbox
                }
                else
                {
                    MessageBox.Show("Column 'Select' not found in the DataGridView.", "Remove Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DataGridView_removeProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeProduct.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value ?? false; // Set the default value to false if it is null
            }
        }
        private void DataGridView_removeProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeProduct.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || !(bool)cell.Value)
                {
                    cell.Value = false;
                }
            }
        }
        private void UpdateDataGridViewWithFilters()
        {
            string category = ComboBox_category_remove.SelectedItem?.ToString();
            string brand = ComboBox_brand_remove.SelectedItem?.ToString();
            string stock = ComboBox_stock_remove.SelectedItem?.ToString();

            // Check if any of the ComboBoxes are empty, and don't update if they are
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(stock))
            {
                return;
            }

            // Construct your SQL query and retrieve and filter data based on selected values
            string query = "SELECT P.product_id AS ID, P.product_name AS Name, P.price AS Price, P.quantity AS Quantity, C.category_name AS Category, B.brand_name AS Brand, S.stock_location as Stock " +
                           "FROM PRODUCT AS P " +
                           "INNER JOIN CATEGORIES AS C ON P.category_id = C.category_id " +
                           "INNER JOIN STOCK AS S ON P.stock_id = S.stock_id " +
                           "INNER JOIN BRANDS AS B ON P.brand_id = B.brand_id " +
                           "WHERE C.category_name = @category " +
                           "AND B.brand_name = @brand " +
                           "AND S.stock_location = @stock";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the filtered data to the DataGridView
                    DataGridView_removeProduct.DataSource = dataTable;
                }
            }
        }

        #endregion

        #endregion

        #region update product panel

        #region methods to show the category and the brand and the stock in the comboBoxes
        private void uPopulateCategoryComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string categoryQuery = "SELECT category_name FROM CATEGORIES";

                using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                {
                    using (SqlDataReader categoryReader = categoryCommand.ExecuteReader())
                    {
                        ComboBox_category_view.Items.Clear();
                        while (categoryReader.Read())
                        {
                            ComboBox_category_view.Items.Add(categoryReader["category_name"].ToString());
                        }
                    }
                }
            }
        }

        private void uPopulateBrandComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string brandQuery = "SELECT brand_name FROM BRANDS"; // Update "BRANDS" to your actual table name

                using (SqlCommand brandCommand = new SqlCommand(brandQuery, connection))
                {
                    using (SqlDataReader brandReader = brandCommand.ExecuteReader())
                    {
                        ComboBox_brand_view.Items.Clear();
                        while (brandReader.Read())
                        {
                            ComboBox_brand_view.Items.Add(brandReader["brand_name"].ToString());
                        }
                    }
                }
            }
        }

        private void uPopulateStockComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string stockQuery = "SELECT stock_location FROM STOCK";

                using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                {
                    using (SqlDataReader stockReader = stockCommand.ExecuteReader())
                    {
                        ComboBox_stock_view.Items.Clear();
                        while (stockReader.Read())
                        {
                            ComboBox_stock_view.Items.Add(stockReader["stock_location"].ToString());
                        }
                    }
                }
            }
        }

        private void ComboBox_category_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters_view();
        }

        private void ComboBox_brand_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters_view();
        }

        private void ComboBox_stock_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters_view();
        }

        #endregion

        #region search and update buttons

        private void view_product(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT P.product_id AS ID, P.product_name AS Name, P.price AS Price, P.quantity AS Quantity, C.category_name AS Category, B.brand_name AS Brand, S.stock_location as Stock " +
                        "FROM PRODUCT AS P " +
                        "INNER JOIN CATEGORIES AS C ON P.category_id = C.category_id " +
                        "INNER JOIN STOCK AS S ON P.stock_id = S.stock_id " +
                        "INNER JOIN BRANDS AS B ON P.brand_id = B.brand_id ";

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE P.product_name LIKE @searchQuery OR P.product_id LIKE @searchQuery OR P.price LIKE @searchQuery OR P.quantity LIKE @searchQuery OR C.category_name LIKE @searchQuery OR B.brand_name LIKE @searchQuery OR S.stock_location LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);
                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_updateProduct.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void searchTextBox_update_product_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_update_product.Text == "Search...")
            {
                searchTextBox_update_product.Text = "";
                searchTextBox_update_product.ForeColor = Color.Black;
            }
        }
        private void searchTextBox_update_product_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_update_product.Text))
            {
                searchTextBox_update_product.Text = "Search...";
                searchTextBox_update_product.ForeColor = Color.Gray;
            }
        }
        private void searchTextBox_update_product_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_update_product.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                UpdateDataGridViewWithFilters_view();
            }
            else
            {
                view_product(searchQuery);
            }
        }
        private void updateProduct_button_viewProduct_Click(object sender, EventArgs e)
        {
            // Check if at least one customer is selected
            bool anyProductSelected = false;

            foreach (DataGridViewRow row in DataGridView_updateProduct.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select_product_view"].Value);
                if (isChecked)
                {
                    anyProductSelected = true;
                    break; // Exit the loop as soon as one customer is selected
                }
            }

            if (!anyProductSelected)
            {
                MessageBox.Show("Please choose at least one product to update.", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without deleting customers
            }
            // Assuming "customer_id" is the column name in DataGridView_removeCustomer
            int selectedID = Convert.ToInt32(DataGridView_updateProduct.SelectedRows[0].Cells[1].Value);

            // Make the DataGridView in the update_customer_panel editable as needed
            DataGridView_updateProduct.ReadOnly = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            view_product_panel.Visible = false;
            update_product_panel.Visible = true;
            discountVoucher_panel.Visible = false;
            add_admin_panel.Visible = false;
            remove_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            hideSubMenu();
            LoadProductInformation_inTheTextBoxes();
        }

        #endregion

        #region DataGridView update product

        private void DataGridView_updateProduct_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_updateProduct.Cursor = Cursors.Hand;
        }
        private void DataGridView_updateProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Find the column index with the header text "Select"
                int selectColumnIndex = -1;
                foreach (DataGridViewColumn column in DataGridView_updateProduct.Columns)
                {
                    if (column.HeaderText.Equals("Select", StringComparison.OrdinalIgnoreCase))
                    {
                        selectColumnIndex = column.Index;
                        break;
                    }
                }

                if (selectColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)DataGridView_updateProduct.Rows[e.RowIndex].Cells[selectColumnIndex];
                    selectedCell.Value = !Convert.ToBoolean(selectedCell.Value); // Toggle the value of the checkbox
                }
                else
                {
                    MessageBox.Show("Column 'Select' not found in the DataGridView.", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DataGridView_updateProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_updateProduct.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value ?? false; // Set the default value to false if it is null
            }
        }
        private void DataGridView_updateProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_updateProduct.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || !(bool)cell.Value)
                {
                    cell.Value = false;
                }
            }
        }
        private void UpdateDataGridViewWithFilters_view()
        {
            string category = ComboBox_category_view.SelectedItem?.ToString();
            string brand = ComboBox_brand_view.SelectedItem?.ToString();
            string stock = ComboBox_stock_view.SelectedItem?.ToString();

            // Check if any of the ComboBoxes are empty, and don't update if they are
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(stock))
            {
                return;
            }

            // Construct your SQL query and retrieve and filter data based on selected values
            string query = "SELECT P.product_id AS ID, P.product_name AS Name, P.price AS Price, P.quantity AS Quantity, C.category_name AS Category, B.brand_name AS Brand, S.stock_location as Stock " +
                           "FROM PRODUCT AS P " +
                           "INNER JOIN CATEGORIES AS C ON P.category_id = C.category_id " +
                           "INNER JOIN STOCK AS S ON P.stock_id = S.stock_id " +
                           "INNER JOIN BRANDS AS B ON P.brand_id = B.brand_id " +
                           "WHERE C.category_name = @category " +
                           "AND B.brand_name = @brand " +
                           "AND S.stock_location = @stock";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the filtered data to the DataGridView
                    DataGridView_updateProduct.DataSource = dataTable;
                }
            }
        }

        #endregion

        #region methods to show products information in the textboxes

        private void LoadProductInformation_inTheTextBoxes()
        {
            int selectedID = Convert.ToInt32(DataGridView_updateProduct.SelectedRows[0].Cells[1].Value);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //PopulateCategoryComboBox();

                    string query = "SELECT P.product_name, P.price, P.quantity, P.production_date, P.expiry_date, " +
                        "C.category_name AS Category, S.stock_location AS StockLocation, B.brand_name AS Brand " +
                        "FROM PRODUCT AS P " +
                        "INNER JOIN CATEGORIES AS C ON P.category_id = C.category_id " +
                        "INNER JOIN STOCK AS S ON P.stock_id = S.stock_id " +
                        "INNER JOIN BRANDS AS B ON P.brand_id = B.brand_id " +
                        "WHERE P.product_id = @selectedID";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@selectedID", selectedID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        text_product_name_update.Text = reader["product_name"].ToString();
                        text_product_price_update.Text = reader["price"].ToString();
                        text_product_quantity_update.Text = reader["quantity"].ToString();
                        // Read production_date and expiry_date as DateTime objects
                        DateTime productionDate = Convert.ToDateTime(reader["production_date"]);
                        DateTime expiryDate = Convert.ToDateTime(reader["expiry_date"]);

                        // Set DateTimePicker controls with the retrieved dates
                        DateTimePicker_productionDate_update.Value = productionDate;
                        DateTimePicker_expiryDate_update.Value = expiryDate;

                        // Set the selected category in the combo box
                        ComboBox_category_update.DataSource = GetCategoryDataFromDatabase();
                        ComboBox_category_update.DisplayMember = "Category";
                        ComboBox_category_update.Text = reader["Category"].ToString();
                        ComboBox_brand_update.DataSource = GetBrandDataFromDatabase();
                        ComboBox_brand_update.DisplayMember = "Brand";
                        ComboBox_brand_update.SelectedItem = reader["Brand"].ToString();
                        ComboBox_stock_update.DataSource = GetStockDataFromDatabase();
                        ComboBox_stock_update.DisplayMember = "StockLocation";
                        ComboBox_stock_update.SelectedItem = reader["StockLocation"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product not found in the database.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private List<string> GetStockDataFromDatabase()
        {
            List<string> stockLocations = new List<string>();

            // Fetch data from the database and populate stockLocations list
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string stockQuery = "SELECT stock_location FROM STOCK"; // Update "STOCK" to your actual table name

                using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                {
                    using (SqlDataReader stockReader = stockCommand.ExecuteReader())
                    {
                        while (stockReader.Read())
                        {
                            stockLocations.Add(stockReader["stock_location"].ToString());
                        }
                    }
                }
            }

            return stockLocations;
        }

        private List<string> GetCategoryDataFromDatabase()
        {
            List<string> category_name = new List<string>();

            // Fetch data from the database and populate stockLocations list
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string categoryQuery = "SELECT category_name FROM CATEGORIES"; // Update "STOCK" to your actual table name

                using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                {
                    using (SqlDataReader categoryReader = categoryCommand.ExecuteReader())
                    {
                        while (categoryReader.Read())
                        {
                            category_name.Add(categoryReader["category_name"].ToString());
                        }
                    }
                }
            }

            return category_name;
        }

        private List<string> GetBrandDataFromDatabase()
        {
            List<string> brandNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string brandQuery = "SELECT brand_name FROM BRANDS"; // Update "BRANDS" to your actual table name

                using (SqlCommand brandCommand = new SqlCommand(brandQuery, connection))
                {
                    using (SqlDataReader brandReader = brandCommand.ExecuteReader())
                    {
                        while (brandReader.Read())
                        {
                            brandNames.Add(brandReader["brand_name"].ToString());
                        }
                    }
                }
            }

            return brandNames;
        }

        #endregion

        #region method to update product after click update button

        private void UpdateProduct_button_Click(object sender, EventArgs e)
        {
            int selectedID = Convert.ToInt32(DataGridView_updateProduct.SelectedRows[0].Cells[1].Value);

            // Retrieve the selected values from the ComboBoxes and other controls
            string productName = text_product_name_update.Text;
            float price = float.Parse(text_product_price_update.Text);
            int quantity = int.Parse(text_product_quantity_update.Text);
            DateTime productionDate = DateTimePicker_productionDate_update.Value;
            DateTime expiryDate = DateTimePicker_expiryDate_update.Value;
            string category = ComboBox_category_update.SelectedItem.ToString();
            string brand = ComboBox_brand_update.SelectedItem.ToString();
            string stockLocation = ComboBox_stock_update.SelectedItem.ToString();
            string formattedTotalPrice = price.ToString("0.00");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE PRODUCT SET product_name = @product_name, price = @price, quantity = @quantity, " +
                        "production_date = @production_date, expiry_date = @expiry_date, " +
                        "category_id = (SELECT category_id FROM CATEGORIES WHERE category_name = @Category), " +
                        "stock_id = (SELECT stock_id FROM STOCK WHERE stock_location = @StockLocation), " +
                        "brand_id = (SELECT brand_id FROM BRANDS WHERE brand_name = @Brand) " +
                        "WHERE product_id = @selectedID";


                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@product_name", productName);
                    cmd.Parameters.AddWithValue("@price", formattedTotalPrice);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@production_date", productionDate);
                    cmd.Parameters.AddWithValue("@expiry_date", expiryDate);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@StockLocation", stockLocation);
                    cmd.Parameters.AddWithValue("@Brand", brand);
                    cmd.Parameters.AddWithValue("@selectedID", selectedID);

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Product information updated successfully.", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Reload the product data in DataGridView
                        UpdateDataGridViewWithFilters_view();
                        UpdateDataGridViewWithFilters();
                        UpdateDataGridViewWithFilters_browse();
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Product not found in the database.", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region browse product panel

        #region methods to show the category and the brand and the stock in the comboBoxes
        private void bPopulateCategoryComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string categoryQuery = "SELECT category_name FROM CATEGORIES";

                using (SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection))
                {
                    using (SqlDataReader categoryReader = categoryCommand.ExecuteReader())
                    {
                        ComboBox_category_browse.Items.Clear();
                        while (categoryReader.Read())
                        {
                            ComboBox_category_browse.Items.Add(categoryReader["category_name"].ToString());
                        }
                    }
                }
            }
        }

        private void bPopulateBrandComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string brandQuery = "SELECT brand_name FROM BRANDS"; // Update "BRANDS" to your actual table name

                using (SqlCommand brandCommand = new SqlCommand(brandQuery, connection))
                {
                    using (SqlDataReader brandReader = brandCommand.ExecuteReader())
                    {
                        ComboBox_brand_browse.Items.Clear();
                        while (brandReader.Read())
                        {
                            ComboBox_brand_browse.Items.Add(brandReader["brand_name"].ToString());
                        }
                    }
                }
            }
        }

        private void bPopulateStockComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string stockQuery = "SELECT stock_location FROM STOCK";

                using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                {
                    using (SqlDataReader stockReader = stockCommand.ExecuteReader())
                    {
                        ComboBox_stock_browse.Items.Clear();
                        while (stockReader.Read())
                        {
                            ComboBox_stock_browse.Items.Add(stockReader["stock_location"].ToString());
                        }
                    }
                }
            }
        }

        private void ComboBox_category_browse_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters_browse();
        }

        private void ComboBox_brand_browse_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters_browse();
        }

        private void ComboBox_stock_browse_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilters_browse();
        }

        #endregion

        #region search button

        private void browse_product(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT P.product_id AS ID, P.product_name AS Name, P.price AS Price, P.quantity AS Quantity, C.category_name AS Category, B.brand_name AS Brand, S.stock_location as Stock " +
                        "FROM PRODUCT AS P " +
                        "INNER JOIN CATEGORIES AS C ON P.category_id = C.category_id " +
                        "INNER JOIN STOCK AS S ON P.stock_id = S.stock_id " +
                        "INNER JOIN BRANDS AS B ON P.brand_id = B.brand_id ";

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE P.product_name LIKE @searchQuery OR P.product_id LIKE @searchQuery OR P.price LIKE @searchQuery OR P.quantity LIKE @searchQuery OR C.category_name LIKE @searchQuery OR B.brand_name LIKE @searchQuery OR S.stock_location LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);
                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_browseProduct.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void searchTextBox_browse_product_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_browse_product.Text == "Search...")
            {
                searchTextBox_browse_product.Text = "";
                searchTextBox_browse_product.ForeColor = Color.Black;
            }
        }
        private void searchTextBox_browse_product_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_browse_product.Text))
            {
                searchTextBox_browse_product.Text = "Search...";
                searchTextBox_browse_product.ForeColor = Color.Gray;
            }
        }
        private void searchTextBox_browse_product_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_browse_product.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                UpdateDataGridViewWithFilters_browse();
            }
            else
            {
                browse_product(searchQuery);
            }
        }

        #endregion

        #region DataGridView update product

        private void DataGridView_browseProduct_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_browseProduct.Cursor = Cursors.Hand;
        }
        private void UpdateDataGridViewWithFilters_browse()
        {
            string category = ComboBox_category_browse.SelectedItem?.ToString();
            string brand = ComboBox_brand_browse.SelectedItem?.ToString();
            string stock = ComboBox_stock_browse.SelectedItem?.ToString();

            // Check if any of the ComboBoxes are empty, and don't update if they are
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(stock))
            {
                return;
            }

            // Construct your SQL query and retrieve and filter data based on selected values
            string query = "SELECT P.product_id AS ID, P.product_name AS Name, P.price AS Price, P.quantity AS Quantity, C.category_name AS Category, B.brand_name AS Brand, S.stock_location as Stock " +
                           "FROM PRODUCT AS P " +
                           "INNER JOIN CATEGORIES AS C ON P.category_id = C.category_id " +
                           "INNER JOIN STOCK AS S ON P.stock_id = S.stock_id " +
                           "INNER JOIN BRANDS AS B ON P.brand_id = B.brand_id " +
                           "WHERE C.category_name = @category " +
                           "AND B.brand_name = @brand " +
                           "AND S.stock_location = @stock";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the filtered data to the DataGridView
                    DataGridView_browseProduct.DataSource = dataTable;
                }
            }
        }

        #endregion

        #endregion

        #endregion

        #region Categories

        #region add category

        #region method to load category in the datagridview

        private void LoadCategory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT category_id, category_name FROM CATEGORIES";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "dataGridViewProducts"
                    DataGridView_addCategory.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region methods for add new category
        private bool IsCategoryExists(string category_name)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CATEGORIES WHERE category_name = @category_name", cn);
            cmd.Parameters.AddWithValue("@category_name", category_name);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count > 0;
        }
        private void UpdateTextBoxBorders_category()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_category_name.Text))
                text_category_name.BorderColor = Color.Red;
            else
                text_category_name.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_category()
        {
            return !string.IsNullOrWhiteSpace(text_category_name.Text);
        }
        #endregion

        #region textBoxes and pictures of add new category panel
        private void AddCategory_button_Click(object sender, EventArgs e)
        {
            string categoriName = text_category_name.Text;
            if (AreAllFieldsFilled_category())
            {
                if (IsCategoryExists(text_category_name.Text))
                {
                    MessageBox.Show("Category already exists. Please Enter a different category.", "Category Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");

                cn.Open();
                // Create the SQL query
                SqlCommand MyCommand = new SqlCommand("insert into CATEGORIES (category_name) values('" + text_category_name.Text.ToString()+ "')", cn);
                MyCommand.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategory();
                LoadCategory_update();
                PopulateCategoryComboBox();
                rmPopulateCategoryComboBox();
                uPopulateCategoryComboBox();
                bPopulateCategoryComboBox();
                show_category();
                text_category_name.Text = null;
            }
            else
            {
                Label_information_category.Visible = true;
                Picture_information_category.Visible = true;
                UpdateTextBoxBorders_category();
            }
        }
        private void text_category_name_TextChanged(object sender, EventArgs e)
        {
            Label_information_category.Visible = false;
            Picture_information_category.Visible = false;
            text_category_name.BorderColor = Color.Silver;
        }

        #endregion

        #endregion

        #region remove category 

        #region search and delete buttons
        private void SearchTextBox_remove_category_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_remove_category.Text == "Search...")
            {
                searchTextBox_remove_category.Text = "";
                searchTextBox_remove_category.ForeColor = Color.Black;
            }
        }
        private void SearchTextBox_remove_category_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_remove_category.Text))
            {
                searchTextBox_remove_category.Text = "Search...";
                searchTextBox_remove_category.ForeColor = Color.Gray;
            }
        }
        private void SearchTextBox_remove_category_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_remove_category.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                show_category();
            }
            else
            {
                show_category(searchQuery);
            }
        }
        private void DeleteCategory_button_Click(object sender, EventArgs e)
        {
            // Check if at least one customer is selected
            bool anyCategorySelected = false;

            foreach (DataGridViewRow row in DataGridView_removeCategory.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select_category"].Value);
                if (isChecked)
                {
                    anyCategorySelected = true;
                    break; // Exit the loop as soon as one customer is selected
                }
            }

            if (!anyCategorySelected)
            {
                MessageBox.Show("Please choose at least one category to remove.", "Remove Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without deleting customers
            }

            if (MessageBox.Show("Are you sure you want to remove the selected categories?", "Remove Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveCategory();
            }
        }

        #endregion

        #region methods for remove category
        private void RemoveCategory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in DataGridView_removeCategory.Rows)
                    {
                        bool isChecked = Convert.ToBoolean(row.Cells["Select_category"].Value); // Assuming the checkbox column is named "select"
                        if (isChecked)
                        {
                            string category_id = row.Cells["category_id"].Value.ToString(); // Assuming the email column is named "email"
                            string query = "DELETE FROM CATEGORIES WHERE category_id = @category_id";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("category_id", category_id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Category removed successfully.", "Remove Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show_category(); // Refresh the DataGridView after removing the customers
                    LoadCategory();
                    LoadCategory_update();
                    PopulateCategoryComboBox();
                    rmPopulateCategoryComboBox();
                    uPopulateCategoryComboBox();
                    bPopulateCategoryComboBox();
                    text_category_name_update.Text = null;
                    text_category_id_update.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Remove Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DataGridView remove category
        private void show_category(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT * FROM CATEGORIES";
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE category_id LIKE @searchQuery OR category_name LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_removeCategory.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataGridView_removeCategory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_removeCategory.Cursor = Cursors.Hand;
        }
        private void DataGridView_removeCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Find the column index with the header text "Select"
                int selectColumnIndex = -1;
                foreach (DataGridViewColumn column in DataGridView_removeCategory.Columns)
                {
                    if (column.HeaderText.Equals("Select", StringComparison.OrdinalIgnoreCase))
                    {
                        selectColumnIndex = column.Index;
                        break;
                    }
                }

                if (selectColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)DataGridView_removeCategory.Rows[e.RowIndex].Cells[selectColumnIndex];
                    selectedCell.Value = !Convert.ToBoolean(selectedCell.Value); // Toggle the value of the checkbox
                }
                else
                {
                    MessageBox.Show("Column 'Select' not found in the DataGridView.", "Remove Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DataGridView_removeCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeCategory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value ?? false; // Set the default value to false if it is null
            }
        }
        private void DataGridView_removeCategory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeCategory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || !(bool)cell.Value)
                {
                    cell.Value = false;
                }
            }
        }
        #endregion

        #endregion

        #region update category

        #region method to load category in the datagridview
        private void LoadCategory_update()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT category_id, category_name FROM CATEGORIES";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "dataGridViewProducts"
                    DataGridView_updateCategory.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region methods for update category
        private bool IsCategoryExists_update(string category_name_up)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CATEGORIES WHERE category_name = @category_name_up", cn);
            cmd.Parameters.AddWithValue("@category_name_up", category_name_up);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count > 0;
        }
        private void UpdateTextBoxBorders_category_update()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_category_name_update.Text))
                text_category_name_update.BorderColor = Color.Red;
            else
                text_category_name_update.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_category_update()
        {
            return !string.IsNullOrWhiteSpace(text_category_name_update.Text);
        }
        private void DataGridView_updateCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                DataGridViewRow row = DataGridView_updateCategory.Rows[index];
                text_category_name_update.Text = row.Cells[1].Value.ToString();
                text_category_id_update.Text = row.Cells[0].Value.ToString();
                text_category_id_update.ReadOnly = true;
            }

        }

        #endregion

        #region textBoxes and pictures of add new category panel
        private void UpdateCategory_button_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("Please select a category to update.", "Update Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string categoryName = text_category_name_update.Text;
            int categoryId = Convert.ToInt32(DataGridView_updateCategory.Rows[index].Cells["category_id_up"].Value);
            if (AreAllFieldsFilled_category_update())
            {
                if (IsCategoryExists_update(text_category_name_update.Text))
                {
                    MessageBox.Show("Category already exists. Please Enter a different category.", "Category Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");

                cn.Open();
                // Create the SQL query
                string query = "UPDATE CATEGORIES SET category_name = @categoryName WHERE category_id = @categoryID";
                SqlCommand orderStatusCmd = new SqlCommand(query, cn);
                orderStatusCmd.Parameters.AddWithValue("@categoryName", categoryName);
                orderStatusCmd.Parameters.AddWithValue("@categoryID", categoryId);
                int orderStatusRowsAffected = orderStatusCmd.ExecuteNonQuery();
                MessageBox.Show("Category Updated Successfully!", "Update Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                index = -1;
                LoadCategory();
                LoadCategory_update();
                PopulateCategoryComboBox();
                rmPopulateCategoryComboBox();
                uPopulateCategoryComboBox();
                bPopulateCategoryComboBox();
                show_category();
                text_category_id_update.Text = null;
                text_category_name_update.Text = null;
            }
            else
            {
                Label_information_category_update.Visible = true;
                Picture_information_category_update.Visible = true;
                UpdateTextBoxBorders_category_update();
            }
        }
        private void text_category_name_update_TextChanged(object sender, EventArgs e)
        {
            Label_information_category_update.Visible = false;
            Picture_information_category_update.Visible = false;
            text_category_name_update.BorderColor = Color.Silver;
        }

        #endregion


        #endregion

        #endregion

        #region Brands

        #region add brand

        #region method to load brand in the datagridview

        private void LoadBrand()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT brand_id, brand_name FROM BRANDS";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "dataGridViewProducts"
                    DataGridView_addBrand.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region methods for add new brand
        private bool IsBrandExists(string brand_name)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM BRANDS WHERE brand_name = @brand_name", cn);
            cmd.Parameters.AddWithValue("@brand_name", brand_name);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count > 0;
        }
        private void UpdateTextBoxBorders_brand()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_brand_name.Text))
                text_brand_name.BorderColor = Color.Red;
            else
                text_brand_name.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_brand()
        {
            return !string.IsNullOrWhiteSpace(text_brand_name.Text);
        }
        #endregion

        #region textBoxes and pictures of add new brand panel
        private void AddBrand_button_Click(object sender, EventArgs e)
        {
            string brandName = text_brand_name.Text;
            if (AreAllFieldsFilled_brand())
            {
                if (IsBrandExists(text_brand_name.Text))
                {
                    MessageBox.Show("Brand already exists. Please Enter a different brand.", "Brand Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");

                cn.Open();
                // Create the SQL query
                SqlCommand MyCommand = new SqlCommand("insert into BRANDS (brand_name) values('" + text_brand_name.Text.ToString() + "')", cn);
                MyCommand.ExecuteNonQuery();
                MessageBox.Show("Brand Added Successfully!", "Add Brand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBrand();
                LoadBrand_update();
                PopulateBrandComboBox();
                rmPopulateBrandComboBox();
                uPopulateBrandComboBox();
                bPopulateBrandComboBox();
                show_brand();
                text_brand_name.Text = null;
            }
            else
            {
                Label_information_brand.Visible = true;
                Picture_information_brand.Visible = true;
                UpdateTextBoxBorders_brand();
            }
        }
        private void text_brand_name_TextChanged(object sender, EventArgs e)
        {
            Label_information_brand.Visible = false;
            Picture_information_brand.Visible = false;
            text_brand_name.BorderColor = Color.Silver;
        }

        #endregion

        #endregion

        #region remove brand

        #region search and delete buttons
        private void SearchTextBox_remove_brand_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_remove_brand.Text == "Search...")
            {
                searchTextBox_remove_brand.Text = "";
                searchTextBox_remove_brand.ForeColor = Color.Black;
            }
        }
        private void SearchTextBox_remove_brand_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_remove_brand.Text))
            {
                searchTextBox_remove_brand.Text = "Search...";
                searchTextBox_remove_brand.ForeColor = Color.Gray;
            }
        }
        private void SearchTextBox_remove_brand_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_remove_brand.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                show_brand();
            }
            else
            {
                show_brand(searchQuery);
            }
        }
        private void DeleteBrand_button_Click(object sender, EventArgs e)
        {
            // Check if at least one customer is selected
            bool anyBrandSelected = false;

            foreach (DataGridViewRow row in DataGridView_removeBrand.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select_brand"].Value);
                if (isChecked)
                {
                    anyBrandSelected = true;
                    break; // Exit the loop as soon as one customer is selected
                }
            }

            if (!anyBrandSelected)
            {
                MessageBox.Show("Please choose at least one brand to remove.", "Remove Brand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without deleting customers
            }

            if (MessageBox.Show("Are you sure you want to remove the selected brands?", "Remove Brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveBrand();
            }
        }

        #endregion

        #region methods for remove brand
        private void RemoveBrand()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in DataGridView_removeBrand.Rows)
                    {
                        bool isChecked = Convert.ToBoolean(row.Cells["Select_brand"].Value); // Assuming the checkbox column is named "select"
                        if (isChecked)
                        {
                            string brand_id = row.Cells["brand_id_rm"].Value.ToString(); // Assuming the email column is named "email"
                            string query = "DELETE FROM BRANDS WHERE brand_id = @brand_id_rm";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("brand_id_rm", brand_id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Brand removed successfully.", "Remove Brand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show_brand(); // Refresh the DataGridView after removing the customers
                    LoadBrand();
                    LoadBrand_update();
                    PopulateBrandComboBox();
                    rmPopulateBrandComboBox();
                    uPopulateBrandComboBox();
                    bPopulateBrandComboBox();
                    text_brand_name_update.Text = null;
                    text_brand_id_update.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Remove Brand", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DataGridView remove brand
        private void show_brand(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT * FROM BRANDS";
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE brand_id LIKE @searchQuery OR brand_name LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_removeBrand.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataGridView_removeBrand_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_removeBrand.Cursor = Cursors.Hand;
        }
        private void DataGridView_removeBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Find the column index with the header text "Select"
                int selectColumnIndex = -1;
                foreach (DataGridViewColumn column in DataGridView_removeBrand.Columns)
                {
                    if (column.HeaderText.Equals("Select", StringComparison.OrdinalIgnoreCase))
                    {
                        selectColumnIndex = column.Index;
                        break;
                    }
                }

                if (selectColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)DataGridView_removeBrand.Rows[e.RowIndex].Cells[selectColumnIndex];
                    selectedCell.Value = !Convert.ToBoolean(selectedCell.Value); // Toggle the value of the checkbox
                }
                else
                {
                    MessageBox.Show("Column 'Select' not found in the DataGridView.", "Remove Brand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DataGridView_removeBrand_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeBrand.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value ?? false; // Set the default value to false if it is null
            }
        }
        private void DataGridView_removeBrand_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeBrand.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || !(bool)cell.Value)
                {
                    cell.Value = false;
                }
            }
        }
        #endregion

        #endregion

        #region update brand

        #region method to load brand in the datagridview
        private void LoadBrand_update()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT brand_id, brand_name FROM BRANDS";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "dataGridViewProducts"
                    DataGridView_updateBrand.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region methods for update brand
        private bool IsBrandExists_update(string brand_name_upd)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM BRANDS WHERE brand_name = @brand_name_upd", cn);
            cmd.Parameters.AddWithValue("@brand_name_upd", brand_name_upd);
            int count = (int)cmd.ExecuteScalar();
            cn.Close();
            return count > 0;
        }
        private void UpdateTextBoxBorders_brand_update()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_brand_name_update.Text))
                text_brand_name_update.BorderColor = Color.Red;
            else
                text_brand_name_update.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_brand_update()
        {
            return !string.IsNullOrWhiteSpace(text_brand_name_update.Text);
        }
        private void DataGridView_updateBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                DataGridViewRow row = DataGridView_updateBrand.Rows[index];
                text_brand_name_update.Text = row.Cells[1].Value.ToString();
                text_brand_id_update.Text = row.Cells[0].Value.ToString();
                text_brand_id_update.ReadOnly = true;
            }

        }

        #endregion

        #region textBoxes and pictures of update brand panel
        private void UpdateBrand_button_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("Please select a brand to update.", "Update Brand", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string brandName = text_brand_name_update.Text;
            int brandId = Convert.ToInt32(DataGridView_updateBrand.Rows[index].Cells["brand_id_upd"].Value);
            if (AreAllFieldsFilled_brand_update())
            {
                if (IsBrandExists_update(text_brand_name_update.Text))
                {
                    MessageBox.Show("Brand already exists. Please Enter a different brand.", "Brand Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");

                cn.Open();
                // Create the SQL query
                string query = "UPDATE BRANDS SET brand_name = @brandName WHERE brand_id = @brandID";
                SqlCommand orderStatusCmd = new SqlCommand(query, cn);
                orderStatusCmd.Parameters.AddWithValue("@brandName", brandName);
                orderStatusCmd.Parameters.AddWithValue("@brandID", brandId);
                int orderStatusRowsAffected = orderStatusCmd.ExecuteNonQuery();
                MessageBox.Show("Brand Updated Successfully!", "Update Brand", MessageBoxButtons.OK, MessageBoxIcon.Information);
                index = -1;
                LoadBrand();
                LoadBrand_update();
                PopulateBrandComboBox();
                rmPopulateBrandComboBox();
                uPopulateBrandComboBox();
                bPopulateBrandComboBox();
                show_brand();
                text_brand_id_update.Text = null;
                text_brand_name_update.Text = null;
            }
            else
            {
                Label_information_brand_update.Visible = true;
                Picture_information_brand_update.Visible = true;
                UpdateTextBoxBorders_brand_update();
            }
        }
        private void text_brand_name_update_TextChanged(object sender, EventArgs e)
        {
            Label_information_brand_update.Visible = false;
            Picture_information_brand_update.Visible = false;
            text_brand_name_update.BorderColor = Color.Silver;
        }

        #endregion


        #endregion

        #endregion

        #region Stock

        #region add stock

        #region methods to show the category and the brand and the stock in the comboBoxes

        private void UpdateDataGridViewWithFilters_addStock()
        {
            // Construct your SQL query and retrieve and filter data based on selected values
            string query = "SELECT S.stock_id AS 'Stock ID', S.stock_location AS 'Stock Location' " +
                            "FROM STOCK AS S";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the filtered data to the DataGridView
                    DataGridView_addStock.DataSource = dataTable;
                }
            }
        }

        private void add_stock_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected values from the ComboBoxes
                string stockLocation = text_stock_location_addStock.Text;

                if (AreAllFieldsFilled_stock())
                {
                    // Check if the product already exists in the specified stock location
                    if (IsThereStock(stockLocation))
                    {
                        MessageBox.Show("Stock already exists in this stock location.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Get the admin_id associated with the current admin's email
                    int adminId = GetAdminId(CurrentAdminEmail);

                    // Insert the new product into the STOCK table
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertProductQuery = "INSERT INTO STOCK (stock_location) " +
                                                    "VALUES (@stockLocation)";

                        using (SqlCommand insertProductCommand = new SqlCommand(insertProductQuery, connection))
                        {
                            insertProductCommand.Parameters.AddWithValue("@stockLocation", stockLocation);

                            int rowsAffected = insertProductCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Stock added successfully.");
                                UpdateDataGridViewWithFilters();
                                UpdateDataGridViewWithFilters_view();
                                UpdateDataGridViewWithFilters_browse();
                                UpdateDataGridViewWithFilters_addStock();
                                PopulateStockComboBox();
                                rmPopulateStockComboBox();
                                uPopulateStockComboBox();
                                bPopulateStockComboBox();
                                show_stock();
                                loadStockData_inDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Failed to add the stock.");
                            }
                        }
                    }
                }
                else
                {
                    Label_information_stock.Visible = true;
                    Picture_information_stock.Visible = true;
                    UpdateTextBoxBorders_stock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Check if the product already exists in the specified stock location
        private bool IsThereStock(string stockLocation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM STOCK WHERE stock_location = @stockLocation";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@stockLocation", stockLocation);

                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }
        private void UpdateTextBoxBorders_stock()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(text_stock_location_addStock.Text))
                text_stock_location_addStock.BorderColor = Color.Red;
            else
                text_stock_location_addStock.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_stock()
        {
            return !string.IsNullOrWhiteSpace(text_stock_location_addStock.Text);
        }
        private void text_stock_location_addStock_TextChanged(object sender, EventArgs e)
        {
            Label_information_stock.Visible = false;
            Picture_information_stock.Visible = false;
            text_stock_location_addStock.BorderColor = Color.Silver;
        }

        #endregion

        #endregion

        #region remove stock

        #region search and delete buttons
        private void SearchTextBox_remove_stock_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_remove_stock.Text == "Search...")
            {
                searchTextBox_remove_stock.Text = "";
                searchTextBox_remove_stock.ForeColor = Color.Black;
            }
        }
        private void SearchTextBox_remove_stock_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_remove_stock.Text))
            {
                searchTextBox_remove_stock.Text = "Search...";
                searchTextBox_remove_stock.ForeColor = Color.Gray;
            }
        }
        private void SearchTextBox_remove_stock_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_remove_stock.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                show_stock();
            }
            else
            {
                show_stock(searchQuery);
            }
        }
        private void DeleteStock_button_Click(object sender, EventArgs e)
        {
            // Check if at least one customer is selected
            bool anyStockSelected = false;

            foreach (DataGridViewRow row in DataGridView_removeStock.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select_stock"].Value);
                if (isChecked)
                {
                    anyStockSelected = true;
                    break; // Exit the loop as soon as one customer is selected
                }
            }

            if (!anyStockSelected)
            {
                MessageBox.Show("Please choose at least one stock to remove.", "Remove Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without deleting customers
            }

            if (MessageBox.Show("Are you sure you want to remove the selected stocks?", "Remove Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveStock();
            }
        }

        #endregion

        #region methods for remove customer
        private void RemoveStock()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in DataGridView_removeStock.Rows)
                    {
                        bool isChecked = Convert.ToBoolean(row.Cells["Select_stock"].Value); // Assuming the checkbox column is named "select"
                        if (isChecked)
                        {
                            string Stock = row.Cells["stock_id"].Value.ToString(); // Assuming the email column is named "email"
                            string query = "DELETE FROM STOCK WHERE stock_id = @stock_id";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@stock_id", Stock);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Stocks removed successfully.", "Remove Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateDataGridViewWithFilters();
                    UpdateDataGridViewWithFilters_view();
                    UpdateDataGridViewWithFilters_browse();
                    UpdateDataGridViewWithFilters_addStock();
                    PopulateStockComboBox();
                    rmPopulateStockComboBox();
                    uPopulateStockComboBox();
                    bPopulateStockComboBox();
                    show_stock();
                    loadStockData_inDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Remove Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DataGridView remove cutomer
        private void show_stock(string searchQuery = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Build the query based on the search query (if provided)
                    string query = "SELECT * FROM STOCK";
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query += " WHERE stock_id LIKE @searchQuery OR stock_location LIKE @searchQuery";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameters for the search query
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming you have a DataGridView named "DataGridView_removeCustomer"
                    DataGridView_removeStock.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataGridView_removeStock_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Set the cursor to hand when the mouse enters any cell in the DataGridView
            DataGridView_removeStock.Cursor = Cursors.Hand;
        }
        private void DataGridView_removeStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Find the column index with the header text "Select"
                int selectColumnIndex = -1;
                foreach (DataGridViewColumn column in DataGridView_removeStock.Columns)
                {
                    if (column.HeaderText.Equals("Select", StringComparison.OrdinalIgnoreCase))
                    {
                        selectColumnIndex = column.Index;
                        break;
                    }
                }

                if (selectColumnIndex != -1)
                {
                    DataGridViewCheckBoxCell selectedCell = (DataGridViewCheckBoxCell)DataGridView_removeStock.Rows[e.RowIndex].Cells[selectColumnIndex];
                    selectedCell.Value = !Convert.ToBoolean(selectedCell.Value); // Toggle the value of the checkbox
                }
                else
                {
                    MessageBox.Show("Column 'Select' not found in the DataGridView.", "Remove Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DataGridView_removeStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeStock.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = cell.Value ?? false; // Set the default value to false if it is null
            }
        }
        private void DataGridView_removeStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assuming the checkbox column is the first column (index 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_removeStock.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || !(bool)cell.Value)
                {
                    cell.Value = false;
                }
            }
        }
        #endregion

        #endregion

        #region update stock

        #region search and update buttons 

        private void SearchTextBox_update_stock_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when the TextBox gets focus
            if (searchTextBox_update_stock.Text == "Search...")
            {
                searchTextBox_update_stock.Text = "";
                searchTextBox_update_stock.ForeColor = Color.Black;
            }
        }
        private void SearchTextBox_update_stock_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the TextBox loses focus and is empty
            if (string.IsNullOrWhiteSpace(searchTextBox_update_stock.Text))
            {
                searchTextBox_update_stock.Text = "Search...";
                searchTextBox_update_stock.ForeColor = Color.Gray;
            }
        }
        private void SearchTextBox_update_stock_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox_update_stock.Text.Trim(); // Remove leading and trailing spaces
            if (searchQuery == "Search...")
            {
                // If the search query is empty or contains only the placeholder text, show all admins.
                loadStockData_inDataGridView();
            }
            else
            {
                loadStockData_inDataGridView(searchQuery);
            }
        }
        private void UpdateTextBoxBorders_stock_up()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(StockLocation_TextBox.Text))
                StockLocation_TextBox.BorderColor = Color.Red;
            else
                StockLocation_TextBox.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled_stock_up()
        {
            return !string.IsNullOrWhiteSpace(StockLocation_TextBox.Text);
        }
        private void StockLocation_TextBox_TextChanged(object sender, EventArgs e)
        {
            Label_information_stock_up.Visible = false;
            Picture_information_stock_up.Visible = false;
            StockLocation_TextBox.BorderColor = Color.Silver;
        }
        private void button_UpdateStock_Click(object sender, EventArgs e)
        {
            if (sindex == -1)
            {
                MessageBox.Show("Please select a stock to update.", "Update Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedID = Convert.ToInt32(dataGridView_updateStock.CurrentRow.Cells["stockidDataGridViewTextBoxColumn"].Value);
            string stockId = StockID_TextBox.Text;
            string stockLocation = StockLocation_TextBox.Text;
            if (AreAllFieldsFilled_stock_up())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Check if the entered stock location already exists
                        if (StockLocationExists(stockLocation, connection, selectedID))
                        {
                            MessageBox.Show("A stock with the same location already exists.", "Update Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string query = "UPDATE STOCK SET stock_location = @stock_location WHERE stock_id = @selectedID";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@stock_id", stockId);
                        cmd.Parameters.AddWithValue("@stock_location", stockLocation);
                        cmd.Parameters.AddWithValue("@selectedID", selectedID);
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            MessageBox.Show("Stock information updated successfully.", "Update Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Update DataGridView
                            UpdateDataGridViewWithFilters();
                            UpdateDataGridViewWithFilters_view();
                            UpdateDataGridViewWithFilters_browse();
                            UpdateDataGridViewWithFilters_addStock();
                            PopulateStockComboBox();
                            rmPopulateStockComboBox();
                            uPopulateStockComboBox();
                            bPopulateStockComboBox();
                            show_stock();
                            loadStockData_inDataGridView();
                            StockID_TextBox.Text = null;
                            StockLocation_TextBox.Text = null;
                            // Reset index
                            sindex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Stock not found in the database.", "Update Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Update Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Label_information_stock_up.Visible = true;
                Picture_information_stock_up.Visible = true;
                UpdateTextBoxBorders_stock_up();
            }
        }

        // Method to check if a stock with the given location already exists
        private bool StockLocationExists(string stockLocation, SqlConnection connection, int selectedID)
        {
            string query = "SELECT COUNT(*) FROM STOCK WHERE stock_location = @stock_location AND stock_id != @selectedID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@stock_location", stockLocation);
            cmd.Parameters.AddWithValue("@selectedID", selectedID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        #endregion

        #region DataGridView Update stock

        private int sindex = -1;
        private void dataGridView_updateStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                sindex = e.RowIndex;
                DataGridViewRow row = dataGridView_updateStock.Rows[sindex];  // Change 'index' to 'sindex'
                StockLocation_TextBox.Text = row.Cells[1].Value.ToString();
                StockID_TextBox.Text = row.Cells[0].Value.ToString();
                StockID_TextBox.ReadOnly = true;
            }
        }

        private void loadStockData_inDataGridView(string searchQuery = "")
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "SELECT stock_id, stock_location FROM STOCK";
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                sql += " WHERE stock_id LIKE @searchQuery OR stock_location LIKE @searchQuery";
            }

            SqlCommand cmd = new SqlCommand(sql, connection);

            // Add parameters for the search query
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridView_updateStock.Columns[0].DataPropertyName = "stock_id";
            dataGridView_updateStock.Columns[1].DataPropertyName = "stock_location";

            // Set the new data source
            dataGridView_updateStock.DataSource = dataTable;
        }

        #endregion

        #endregion

        #endregion

        #region Information       
        private string GetQuery(string buttonName)
        {
            switch (buttonName)
            {
                case "query1_button":
                    return "SELECT TOP 1 P.product_id AS [Product ID], P.product_name AS [Product Name], COUNT(DISTINCT O.customer_id) AS [Number of Customers] FROM PRODUCT P JOIN ORDER_ITEMS OI ON P.product_id = OI.product_id JOIN ORDERS O ON OI.order_id = O.order_id GROUP BY P.product_id, P.product_name ORDER BY [Number of Customers] DESC;";
                case "query2_button":
                    return "SELECT P.product_id AS [Product ID], P.product_name AS [Product Name] FROM PRODUCT P WHERE NOT EXISTS (SELECT 1 FROM ORDER_ITEMS OI JOIN ORDERS O ON OI.order_id = O.order_id WHERE OI.product_id = P.product_id AND MONTH(O.order_date) = 12);";
                case "query3_button":
                    return "SELECT C.customer_id AS [Customer ID], C.username AS [Customer Name] FROM CUSTOMER C WHERE NOT EXISTS (SELECT 1 FROM ORDERS O WHERE O.customer_id = C.customer_id AND O.order_date >= DATEADD(YEAR, -1, GETDATE()));";
                case "query4_button":
                    return "SELECT TOP 1 C.customer_id AS [Cutomer ID], C.username AS [Customer Name], SUM(OI.price) AS [Total Purchase] FROM CUSTOMER C JOIN ORDERS O ON C.customer_id = O.customer_id JOIN ORDER_ITEMS OI ON O.order_id = OI.order_id WHERE MONTH(O.order_date) = MONTH(GETDATE()) AND YEAR(O.order_date) = YEAR(GETDATE()) GROUP BY C.customer_id, C.username ORDER BY [Total Purchase] DESC;";
                case "query5_button":
                    return @"WITH ProductSales AS (
                        SELECT
                            P.product_id,
                            CASE WHEN P.category_id = (SELECT category_id FROM CATEGORIES WHERE category_name = 'Electric Appliances') THEN 'Electric Appliances'
                                 WHEN P.category_id = (SELECT category_id FROM CATEGORIES WHERE category_name = 'Food Products') THEN 'Food Products'
                            END AS [Category],
                            OI.quantity
                        FROM
                            PRODUCT P
                        JOIN
                            ORDER_ITEMS OI ON P.product_id = OI.product_id
                        JOIN
                            ORDERS O ON OI.order_id = O.order_id
                        WHERE
                            P.category_id IN (
                                (SELECT category_id FROM CATEGORIES WHERE category_name = 'Electric Appliances'),
                                (SELECT category_id FROM CATEGORIES WHERE category_name = 'Food Products')
                            )
                    )
                    SELECT
                        [Category],
                        SUM(quantity) AS [Total Sold]
                    FROM
                        ProductSales
                    GROUP BY
                        [Category];";
                case "query6_button":
                    return "SELECT P.product_id AS [Product ID], P.product_name AS [Product], P.price AS [Price], P.quantity AS [Qnt], P.production_date AS [P_Date], P.expiry_date as [Ex_Date], B.brand_name AS [Brand], C.category_name AS [Category], S.stock_location AS [Stock], COUNT(DISTINCT O.customer_id) AS [#of Customers] FROM PRODUCT P JOIN BRANDS B ON P.brand_id = B.brand_id JOIN CATEGORIES C ON P.category_id = C.category_id JOIN STOCK S ON P.stock_id = S.stock_id LEFT JOIN ORDER_ITEMS OI ON P.product_id = OI.product_id LEFT JOIN ORDERS O ON OI.order_id = O.order_id GROUP BY P.product_id, P.product_name, P.price, P.quantity, P.production_date, P.expiry_date, B.brand_name, C.category_name, S.stock_location;";
                default:
                    return "";
            }
        }
        private void ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DataGridView_query.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing query: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void query1_button_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaButton clickedButton = (Guna.UI.WinForms.GunaButton)sender;

            // Clear previous data in the DataGridView
            DataGridView_query.DataSource = null;

            // Get the query based on the clicked button
            string query = GetQuery(clickedButton.Name);

            // Execute the query and update the DataGridView
            ExecuteQuery(query);
        }
        private void query2_button_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaButton clickedButton = (Guna.UI.WinForms.GunaButton)sender;

            // Clear previous data in the DataGridView
            DataGridView_query.DataSource = null;

            // Get the query based on the clicked button
            string query = GetQuery(clickedButton.Name);

            // Execute the query and update the DataGridView
            ExecuteQuery(query);
        }
        private void query3_button_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaButton clickedButton = (Guna.UI.WinForms.GunaButton)sender;

            // Clear previous data in the DataGridView
            DataGridView_query.DataSource = null;

            // Get the query based on the clicked button
            string query = GetQuery(clickedButton.Name);

            // Execute the query and update the DataGridView
            ExecuteQuery(query);
        }
        private void query4_button_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaButton clickedButton = (Guna.UI.WinForms.GunaButton)sender;

            // Clear previous data in the DataGridView
            DataGridView_query.DataSource = null;

            // Get the query based on the clicked button
            string query = GetQuery(clickedButton.Name);

            // Execute the query and update the DataGridView
            ExecuteQuery(query);
        }
        private void query5_button_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaButton clickedButton = (Guna.UI.WinForms.GunaButton)sender;

            // Clear previous data in the DataGridView
            DataGridView_query.DataSource = null;

            // Get the query based on the clicked button
            string query = GetQuery(clickedButton.Name);

            // Execute the query and update the DataGridView
            ExecuteQuery(query);
        }
        private void query6_button_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaButton clickedButton = (Guna.UI.WinForms.GunaButton)sender;

            // Clear previous data in the DataGridView
            DataGridView_query.DataSource = null;

            // Get the query based on the clicked button
            string query = GetQuery(clickedButton.Name);

            // Execute the query and update the DataGridView
            ExecuteQuery(query);
        }

        #endregion

        #region show and hide submenus methods
        private void customizeDesign()
        {
            Panel_admin.Visible = false;
            Panel_customer.Visible = false;
            Panel_product.Visible = false;
            Panel_stock.Visible = false;
            Panel_categories.Visible = false;
            Panel_brands.Visible = false;
        }

        private void hideSubMenu()
        {
            if (Panel_admin.Visible == true)
                Panel_admin.Visible = false;
            if (Panel_customer.Visible == true)
                Panel_customer.Visible = false;
            if (Panel_product.Visible == true)
                Panel_product.Visible = false;
            if (Panel_stock.Visible == true)
                Panel_stock.Visible = false;
            if (Panel_categories.Visible == true)
                Panel_categories.Visible = false;
            if (Panel_brands.Visible == true)
                Panel_brands.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }
        #endregion

        #region sidemenu panels buttons

        #region main buttons
        private void MainButton_admin_Click(object sender, EventArgs e)
        {
            showSubMenu(Panel_admin);
        }

        private void MainButton_customer_Click(object sender, EventArgs e)
        {
            showSubMenu(Panel_customer);
        }

        private void MainButton_product_Click(object sender, EventArgs e)
        {
            showSubMenu(Panel_product);
        }

        private void MainButton_stock_Click(object sender, EventArgs e)
        {
            showSubMenu(Panel_stock);
        }

        private void MainButton_categories_Click(object sender, EventArgs e)
        {
            showSubMenu(Panel_categories);
        }

        private void MainButton_brands_Click(object sender, EventArgs e)
        {
            showSubMenu(Panel_brands);
        }

        private void MainButton_information_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = true;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        #endregion

        #region submain admin buttons

        private void subMainButton_addNewAdmin_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_admin_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            update_category_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            browse_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            update_product_panel.Visible = false;
            view_product_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            update_admin_panel.Visible = false;
            add_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_removeAdmin_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            remove_admin_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            update_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            browse_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            view_product_panel.Visible = false;
            update_product_panel.Visible = false;
            add_admin_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            update_admin_panel.Visible = false;
            add_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_updateAdmin_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            update_admin_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            update_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            browse_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            view_product_panel.Visible = false;
            remove_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            add_admin_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            add_product_panel.Visible = false;
            hideSubMenu();
            LoadAdminInformation();
        }



        #endregion

        #region submain customer buttons
        private void subMainButton_addNewCustomer_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_customer_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            update_category_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            browse_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            view_product_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            add_product_panel.Visible = false;
            hideSubMenu();
        }
        private void subMainButton_removeCustomer_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            remove_customer_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            update_category_panel.Visible = false;
            add_category_panel.Visible = false;
            browse_product_panel.Visible = false;
            remove_category_panel.Visible = false;
            add_customer_panel.Visible = false;
            view_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            add_product_panel.Visible = false;
            hideSubMenu();
        }
        private void subMainButton_updateCustomer_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            remove_customer_panel.Visible = false;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            update_category_panel.Visible = false;
            add_category_panel.Visible = false;
            browse_product_panel.Visible = false;
            remove_category_panel.Visible = false;
            add_customer_panel.Visible = false;
            view_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = true;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            add_product_panel.Visible = false;
            hideSubMenu();
        }
        private void subMainButton_makeVoucher_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            remove_customer_panel.Visible = false;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            update_category_panel.Visible = false;
            add_category_panel.Visible = false;
            browse_product_panel.Visible = false;
            remove_category_panel.Visible = false;
            add_customer_panel.Visible = false;
            view_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = true;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            add_product_panel.Visible = false;
            hideSubMenu();
            loadVoucher_inDataGridView();
        }

        #endregion

        #region submain product buttons

        private void subMainButton_addProduct_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_product_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            update_category_panel.Visible = false;
            remove_product_panel.Visible = false;
            remove_category_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_removeProduct_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            remove_product_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_updateProduct_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            view_product_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            update_admin_panel.Visible = false;
            browse_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_browseProduct_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            browse_product_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            view_product_panel.Visible = false;
            update_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            update_admin_panel.Visible = false;
            hideSubMenu();
        }

        #endregion

        #region submain categories buttons

        private void subMainButton_addCategory_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_category_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_removeCategory_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            remove_category_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_updateCategory_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            update_category_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            remove_category_panel.Visible = false;
            add_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        #endregion

        #region submain brands buttons

        private void subMainButton_addBrand_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_brand_panel.Visible = true;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_removeBrand_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = true;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_updateBrand_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = true;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        #endregion

        #region submain stock buttons

        private void subMainButton_addStock_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = true;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_removeStock_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = false;
            remove_stock_panel.Visible = true;
            add_stock_panel.Visible = false;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        private void subMainButton_updateStock_Click(object sender, EventArgs e)
        {
            Panel_information.Visible = false;
            update_stock_panel.Visible = true;
            remove_stock_panel.Visible = false;
            add_stock_panel.Visible = false;
            add_brand_panel.Visible = false;
            remove_brand_panel.Visible = false;
            update_brand_panel.Visible = false;
            add_category_panel.Visible = false;
            remove_category_panel.Visible = false;
            update_category_panel.Visible = false;
            add_product_panel.Visible = false;
            remove_product_panel.Visible = false;
            add_customer_panel.Visible = false;
            remove_customer_panel.Visible = false;
            update_customer_panel.Visible = false;
            update_customers_panel.Visible = false;
            discountVoucher_panel.Visible = false;
            remove_admin_panel.Visible = false;
            add_admin_panel.Visible = false;
            update_admin_panel.Visible = false;
            update_product_panel.Visible = false;
            browse_product_panel.Visible = false;
            view_product_panel.Visible = false;
            hideSubMenu();
        }

        #endregion

        #region exit and logout buttons
        private void Label_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to exit application ?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Lable_logout_Click(object sender, EventArgs e)
        {
            Admin_Sign_in logAdmin = new Admin_Sign_in();
            logAdmin.Show();
            this.Hide();
        }
        private void Label_logout_MouseEnter(object sender, EventArgs e)
        {
            Label_logout.ForeColor = Color.Gold;
        }
        private void Label_logout_MouseLeave(object sender, EventArgs e)
        {
            Label_logout.ForeColor = Color.White;
        }
        private void Label_exit_MouseEnter(object sender, EventArgs e)
        {
            Label_exit.ForeColor = Color.Red;
        }
        private void Label_exit_MouseLeave(object sender, EventArgs e)
        {
            Label_exit.ForeColor = Color.White;
        }
        #endregion

        #endregion
    }
}