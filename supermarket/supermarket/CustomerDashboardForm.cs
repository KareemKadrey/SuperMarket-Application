using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static supermarket.CustomerDashboardForm;

namespace supermarket
{
    public partial class CustomerDashboardForm : Form
    {
        #region objects
        private string connectionString = "Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True";
        private string customerEmail;
        private int customer_id;
        private int selectedProductID;
        private string selectedProductName;
        private float selectedProductPrice;
        private int selectedProductQuantity;
        private List<CartItem> cartItems;
        #endregion
        public CustomerDashboardForm(string email)
        {
            InitializeComponent();
            customerEmail = email;
            LoadCustomerInformation();
            LoadAvailableCategories();
            LoadCartDataGridView();
            customer_id = GetCustomerID(customerEmail);
            cartItems = new List<CartItem>();
            DataGridView_products.DataSource = null;
            searchTextBox_browse_product.ForeColor = Color.Gray;
            searchTextBox_browse_product.Text = "Search...";
            searchTextBox_browse_product.Enter += searchTextBox_browse_product_Enter;
            searchTextBox_browse_product.Leave += searchTextBox_browse_product_Leave;
            bPopulateCategoryComboBox();
            bPopulateBrandComboBox();
            bPopulateStockComboBox();

        }
        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'superMarketDataSet13.PRODUCT' table. You can move, or remove it, as needed.
            this.pRODUCTTableAdapter3.Fill(this.superMarketDataSet13.PRODUCT);
            // TODO: This line of code loads data into the 'superMarketDataSet12.PRODUCT' table. You can move, or remove it, as needed.
            this.pRODUCTTableAdapter2.Fill(this.superMarketDataSet12.PRODUCT);
            // TODO: This line of code loads data into the 'superMarketDataSet11.ORDER_ITEMS' table. You can move, or remove it, as needed.
            this.oRDER_ITEMSTableAdapter.Fill(this.superMarketDataSet11.ORDER_ITEMS);
            // TODO: This line of code loads data into the 'superMarketDataSet10.PRODUCT' table. You can move, or remove it, as needed.
            this.pRODUCTTableAdapter1.Fill(this.superMarketDataSet10.PRODUCT);

        }


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
            Customer_Sign_in logcustomer = new Customer_Sign_in();
            logcustomer.Show();
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

        #region main buttons
        private void MainButton_updateProfile_Click(object sender, EventArgs e)
        {
            Panel_update.Visible = true;
            Panel_remove.Visible = false;
            Panel_browse.Visible = false;
            Panel_history.Visible = false;
            panel_make.Visible = false;

            LoadCustomerInformation();
        }
        private void MainButton_makeOrder_Click(object sender, EventArgs e)
        {
            panel_make.Visible = true;
            Panel_browse.Visible = false;
            Panel_update.Visible = false;
            Panel_remove.Visible = false;
            Panel_history.Visible = false;
        }
        private void MainButton_viewHistory_Click(object sender, EventArgs e)
        {
            Panel_history.Visible = true;
            Panel_browse.Visible = false;
            panel_make.Visible = false;
            Panel_update.Visible = false;
            Panel_remove.Visible = false;
            ViewOrders();
        }
        private void MainButton_browseProducts_Click(object sender, EventArgs e)
        {
            Panel_browse.Visible = true;
            panel_make.Visible = false;
            Panel_update.Visible = false;
            Panel_remove.Visible = false;
            Panel_history.Visible = false;
        }
        private void MainButton_removeAccount_Click(object sender, EventArgs e)
        {
            Panel_remove.Visible = true;
            Panel_update.Visible = false;
            panel_make.Visible = false;
            Panel_browse.Visible = false;
            Panel_history.Visible = false;
        }
        #endregion

        #region panel update profile

        #region method to load customer data in the datagridview for update profile
        private void LoadCustomerInformation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Username, Email, Password, Address, Phone FROM CUSTOMER WHERE Email = @email";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@email", customerEmail);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox_update_Username.Text = reader["Username"].ToString();
                        textBox_update_Email.Text = reader["Email"].ToString();
                        textBox_update_Password.Text = reader["Password"].ToString();
                        textBox_update_Address.Text = reader["Address"].ToString();
                        textBox_update_Phone.Text = reader["Phone"].ToString();
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

        #region method to update customer data
        private void UpdateCustomerInformation()
        {
            string username = textBox_update_Username.Text;
            string password = textBox_update_Password.Text;
            string address = textBox_update_Address.Text;
            string phone = textBox_update_Phone.Text;
            if (AreAllFieldsFilled())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE CUSTOMER SET Username = @username, Password = @password, Address = @address, Phone = @phone WHERE Email = @email";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", customerEmail);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer information updated successfully.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Customer not found in the database.", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Label_information_customer.Visible = true;
                Picture_information_customer.Visible = true;
                UpdateTextBoxBorders();
            }
        }
        private void textBox_update_Username_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            Picture_information_customer.Visible = false;
            textBox_update_Username.BorderColor = Color.Silver;
        }
        private void textBox_update_Password_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            Picture_information_customer.Visible = false;
            textBox_update_Password.BorderColor = Color.Silver;
        }
        private void textBox_update_Address_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            Picture_information_customer.Visible = false;
            textBox_update_Address.BorderColor = Color.Silver;
        }
        private void textBox_update_Phone_TextChanged(object sender, EventArgs e)
        {
            Label_information_customer.Visible = false;
            Picture_information_customer.Visible = false;
            textBox_update_Phone.BorderColor = Color.Silver;
        }
        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(textBox_update_Username.Text)
                && !string.IsNullOrWhiteSpace(textBox_update_Password.Text)
                && !string.IsNullOrWhiteSpace(textBox_update_Address.Text)
                && !string.IsNullOrWhiteSpace(textBox_update_Phone.Text);
        }
        private void UpdateTextBoxBorders()
        {
            // Set the border color to red for empty textboxes
            if (string.IsNullOrWhiteSpace(textBox_update_Username.Text))
                textBox_update_Username.BorderColor = Color.Red;
            else
                textBox_update_Username.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(textBox_update_Password.Text))
                textBox_update_Password.BorderColor = Color.Red;
            else
                textBox_update_Password.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(textBox_update_Address.Text))
                textBox_update_Address.BorderColor = Color.Red;
            else
                textBox_update_Address.BorderColor = Color.Silver;
            if (string.IsNullOrWhiteSpace(textBox_update_Phone.Text))
                textBox_update_Phone.BorderColor = Color.Red;
            else
                textBox_update_Phone.BorderColor = Color.Silver;
        }
        #endregion

        #region button update
        private void Button_update_profile_Click(object sender, EventArgs e)
        {
            UpdateCustomerInformation();
        }
        #endregion

        #endregion

        #region panel remove account

        private void Button_delete_account_Click(object sender, EventArgs e)
        {
            string email = TextBox_remove_email.Text;
            string passowrd = TextBox_remove_password.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM CUSTOMER WHERE Email = @email AND Password = @password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", passowrd);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account deleted Successfuly.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Customer_Sign_in customerform = new Customer_Sign_in();
                        customerform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Account Not found. Please check the email and password.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        #endregion

        #region panel make order
        public class CartItem
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public float TotalPrice { get; set; }
        }
        private int GetCustomerID(string customerEmail)
        {
            int customerID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT customer_id FROM CUSTOMER WHERE email = @email";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@email", customerEmail);

                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        customerID = id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return customerID;
        }
        private void LoadAvailableCategories()
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

                    ComboBoxCategories.DisplayMember = "category_name";
                    ComboBoxCategories.ValueMember = "category_id"; // This will store the product_id as the value
                    ComboBoxCategories.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void ComboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected category ID from the ComboBox
            if (ComboBoxCategories.SelectedItem != null)
            {
                int selectedCategoryId = Convert.ToInt32(ComboBoxCategories.SelectedValue);

                // Modify your SQL query to filter products by category
                string sql = "SELECT product_id,product_name, price ,quantity, production_date , expiry_date FROM PRODUCT WHERE category_id = @category_id;";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@category_id", selectedCategoryId);

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Bind the DataGridView with the updated data
                        DataGridView_products.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void RefreshCartDataGridView()
        {
            DataGridViewCart.DataSource = null; // Clear the previous data source
            DataGridViewCart.DataSource = cartItems; // Bind the DataGridView to the cart items list
        }
        private void LoadCartDataGridView()
        {
            // You can call this method when your form loads or whenever you want to display the cart contents.
            DataGridViewCart.AutoGenerateColumns = true; // Automatically generate columns based on the properties of CartItem
            RefreshCartDataGridView(); // Initialize the DataGridViewCart
        }
        private int GetProductIDByName(string productName)
        {
            // Replace the placeholder with your actual SQL query to fetch the product ID by name
            string query = "SELECT product_id FROM PRODUCT WHERE product_name = @product_name;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@product_name", productName);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }

                return -1; // Return -1 if the product ID is not found
            }
        }
        private void ButtonFinishOrder_Click(object sender, EventArgs e)
        {
            if (DataGridViewCart.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add products to your cart before finishing the order.", "Finish Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int customerId = customer_id;
                    int orderCount = GetOrderCountInCurrentMonth(customerId);

                    // Check if the customer has made more than 4 orders in the current month
                    if (orderCount >= 3)
                    {
                        // Check if the customer already has an active discount voucher
                        if (!HasActiveDiscountVoucher(customerId))
                        {
                            // Calculate the expiration date for the discount voucher (2 weeks from today)
                            DateTime expirationDate = DateTime.Now.AddDays(14);

                            // Insert the discount voucher into the DISCOUNT_VOUCHER table
                            string insertVoucherQuery = "INSERT INTO DISCOUNT_VOUCHER (amount_discount, expiry_date_of_discount, customer_id) " +
                                                        "VALUES (@amount_discount, @expiry_date_of_discount, @customer_id);";

                            SqlCommand cmd = new SqlCommand(insertVoucherQuery, connection);
                            cmd.Parameters.AddWithValue("@amount_discount", 0.10); // 10% discount
                            cmd.Parameters.AddWithValue("@expiry_date_of_discount", expirationDate);
                            cmd.Parameters.AddWithValue("@customer_id", customerId);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("You've qualified for a 10% discount voucher for the next 2 weeks!", "Finish Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("You already have an active discount voucher. You can't receive another one at this time.", "Finish Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Continue with order placement
                    string insertOrderQuery = "INSERT INTO ORDERS (order_date, required_date, shipped_date, order_status, customer_id) " +
                                              "VALUES (@order_date, @required_date, @shipped_date, @order_status, @customer_id); " +
                                              "SELECT SCOPE_IDENTITY();"; // Retrieve the generated order_id

                    SqlCommand cmdOrder = new SqlCommand(insertOrderQuery, connection);
                    cmdOrder.Parameters.AddWithValue("@order_date", DateTime.Now);
                    cmdOrder.Parameters.AddWithValue("@required_date", DateTime.Now.AddDays(3)); // Set required_date as 3 days from now (adjust as needed)
                    cmdOrder.Parameters.AddWithValue("@shipped_date", DateTime.Now.AddDays(4));
                    cmdOrder.Parameters.AddWithValue("@order_status", "Pending"); // Set the initial order status as "Pending"
                    cmdOrder.Parameters.AddWithValue("@customer_id", customerId);

                    int generatedOrderID = Convert.ToInt32(cmdOrder.ExecuteScalar()); // Get the generated order_id

                    // Insert items into ORDER_ITEMS table and update product quantity
                    foreach (DataGridViewRow row in DataGridViewCart.Rows)
                    {
                        int productId = Convert.ToInt32(row.Cells["product_id_cart"].Value);
                        string productName = Convert.ToString(row.Cells["product_name_cart"].Value);
                        int quantity = Convert.ToInt32(row.Cells["quantity_cart"].Value);
                        float totalPrice = Convert.ToSingle(row.Cells["price_cart"].Value);
                        int productToUpdateId = Convert.ToInt32(row.Cells["product_id_cart"].Value);

                        foreach (DataGridViewRow productRow in DataGridView_products.Rows)
                        {
                            if (Convert.ToInt32(productRow.Cells["product_id"].Value) == productToUpdateId)
                            {
                                productRow.Cells["quantity"].Value = GetProductQuantity(productToUpdateId);
                                break;
                            }
                        }

                        // Update product quantity in the database
                        UpdateProductQuantity(productId, quantity, false, true);

                        // Insert item into ORDER_ITEMS table
                        string insertItemQuery = "INSERT INTO ORDER_ITEMS (quantity, price, item_id, order_id, product_id) " +
                                                 "VALUES (@quantity, @price, @itemId, @orderId, @productId);";

                        SqlCommand itemCmd = new SqlCommand(insertItemQuery, connection);
                        itemCmd.Parameters.AddWithValue("@quantity", quantity);
                        itemCmd.Parameters.AddWithValue("@price", totalPrice); // Adjust the price after discount
                        itemCmd.Parameters.AddWithValue("@itemId", productId * generatedOrderID); // You can use a better logic to generate item_id
                        itemCmd.Parameters.AddWithValue("@orderId", generatedOrderID);
                        itemCmd.Parameters.AddWithValue("@productId", productId);

                        itemCmd.ExecuteNonQuery();
                    }

                    // Refresh the DataGridViewCart with the updated cart items
                    RefreshCartDataGridView();

                    MessageBox.Show("Order placed successfully!", "Finish Order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ComboBoxCategories_SelectedIndexChanged(sender, e);
                    // Clear the cart and update the UI
                    DataGridViewCart.DataSource = null;
                    TextBox_Quantity_new.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Finish Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            if (DataGridView_products.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridView_products.SelectedRows[0];
                int selectedProductID = GetProductIDByName(selectedRow.Cells["product_name"].Value.ToString());
                int customerId = customer_id;

                // Check if the quantity is a valid positive integer
                if (int.TryParse(TextBox_Quantity_new.Text, out int enteredQuantity) && enteredQuantity > 0)
                {
                    int availableQuantity = GetProductQuantity(selectedProductID);

                    if (enteredQuantity <= availableQuantity)
                    {
                        float price = Convert.ToSingle(selectedRow.Cells["price"].Value);
                        string productName = selectedRow.Cells["product_name"].Value.ToString();

                        double totalPrice;
                        if (HasActiveDiscountVoucher(customerId))
                        {
                            totalPrice = (price * enteredQuantity) - ((price * enteredQuantity) * 0.10);
                        }
                        else
                        {
                            totalPrice = price * enteredQuantity;
                        }
                        string formattedTotalPrice = totalPrice.ToString("0.00");

                        // Check if the product is already in the cart
                        foreach (DataGridViewRow cartRow in DataGridViewCart.Rows)
                        {
                            int cartProductID = Convert.ToInt32(cartRow.Cells["product_id_cart"].Value);
                            if (cartProductID == selectedProductID)
                            {
                                // Update the quantity in the existing cart row
                                int currentQuantity = Convert.ToInt32(cartRow.Cells["quantity_cart"].Value);
                                cartRow.Cells["quantity_cart"].Value = currentQuantity + enteredQuantity;

                                // Update the product quantity in the database (deducting the additional quantity)
                                UpdateProductQuantity(selectedProductID, enteredQuantity, true);

                                MessageBox.Show("Product quantity updated in the cart successfully!", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TextBox_Quantity_new.Text = null;
                                return;
                            }
                        }

                        // Add the product to the cart (DataGridViewCart)
                        DataGridViewCart.Rows.Add(selectedProductID, productName, enteredQuantity, formattedTotalPrice);

                        // Update the product quantity in the database (deducting the entered quantity)
                        UpdateProductQuantity(selectedProductID, enteredQuantity, true);

                        MessageBox.Show("Product added to cart successfully!", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBox_Quantity_new.Text = null;
                        GetProductQuantity(selectedProductID);
                    }
                    else
                    {
                        MessageBox.Show("The entered quantity is greater than the available quantity for the selected product.", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TextBox_Quantity_new.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid quantity! Please enter a valid positive integer.", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox_Quantity_new.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Please select a product from the list before adding to the cart.", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBox_Quantity_new.Text = null;
            }
        }
        private void UpdateProductQuantity(int productId, int quantity, bool isAddingToCart = true, bool isFinishingOrder = false)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the operation is adding to the cart or finishing the order
                    string updateQuantityQuery = isAddingToCart
                        ? "UPDATE PRODUCT SET quantity = quantity - @quantity WHERE product_id = @productId;"
                        : (isFinishingOrder
                            ? "UPDATE PRODUCT SET quantity = quantity WHERE product_id = @productId;" // No change in quantity during order placement
                            : "UPDATE PRODUCT SET quantity = quantity + @quantity WHERE product_id = @productId;"); // Add the quantity back during cart removal

                    SqlCommand cmd = new SqlCommand(updateQuantityQuery, connection);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@productId", productId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., show a message to the user)
                MessageBox.Show("Error updating product quantity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonDeleteFromCart_Click(object sender, EventArgs e)
        {
            if (DataGridViewCart.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridViewCart.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["product_id_cart"].Value);
                int quantityToRemove = Convert.ToInt32(selectedRow.Cells["quantity_cart"].Value);

                // Update product quantity in the database (adding the quantity back)
                UpdateProductQuantity(productId, quantityToRemove, false);

                // Remove the row from the DataGridViewCart
                DataGridViewCart.Rows.Remove(selectedRow);

                // Update the product quantity in the DataGridView_products
                foreach (DataGridViewRow productRow in DataGridView_products.Rows)
                {
                    if (Convert.ToInt32(productRow.Cells["product_id"].Value) == productId)
                    {
                        int updatedQuantity = GetProductQuantity(productId);
                        productRow.Cells["quantity"].Value = updatedQuantity;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product from the cart before deleting.", "Delete from Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int GetProductQuantity(int productId)
        {
            // Assume you have a method to fetch the quantity from the database
            return GetProductQuantityFromDatabase(productId);
        }
        private int GetProductQuantityFromDatabase(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Fetch the quantity from the PRODUCTS table based on the productId
                    string selectQuantityQuery = "SELECT quantity FROM PRODUCT WHERE product_id = @productId;";

                    using (SqlCommand cmd = new SqlCommand(selectQuantityQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@productId", productId);

                        // Execute the query and get the quantity
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log or show a message to the user)
                MessageBox.Show("Error fetching product quantity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return a default value or handle the case where quantity retrieval fails
            return 0;
        }



        #endregion

        #region panel view history

        #region method to get orders that customer's do

        private void ViewOrders()
        {
            // Create a SqlConnection object to connect to your database
            SqlConnection cn = new SqlConnection(@"Data Source=USER;Initial Catalog=SuperMarket;Integrated Security=True");
            try
            {
                cn.Open();

                // Create the SQL query
                string query = @"SELECT p.product_name AS [Product], oi.quantity AS [Quantity], oi.price AS [Total Price], o.order_date AS [Order Date], o.required_date AS [Required Date], o.shipped_date AS [Shipped Date], o.order_status AS [Order Status],o.order_id AS [Order ID]
                         FROM ORDERS o
                         INNER JOIN CUSTOMER c ON o.customer_id = c.customer_id
                         INNER JOIN ORDER_ITEMS oi ON oi.order_id = o.order_id
                         INNER JOIN PRODUCT p ON p.product_id = oi.product_id
                         WHERE c.email = @Email
                         ORDER BY o.order_id";

                // Use SqlCommand with parameters to avoid SQL injection
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Email", customerEmail);

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                // Bind the data to the history_grid
                dataGridView_history.DataSource = dt;

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        #region count orders and discount voucher
        private int GetOrderCountInCurrentMonth(int customerId)
        {
            int orderCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM ORDERS WHERE customer_id = @customerId AND MONTH(order_date) = MONTH(GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    orderCount = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return orderCount;
        }

        #endregion

        #region check has a voucher
        private bool HasActiveDiscountVoucher(int customerId)
        {
            bool hasActiveVoucher = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM DISCOUNT_VOUCHER WHERE customer_id = @customerId AND expiry_date_of_discount >= GETDATE()";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    int voucherCount = (int)cmd.ExecuteScalar();
                    hasActiveVoucher = voucherCount > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return hasActiveVoucher;
        }
        #endregion

    }
}



