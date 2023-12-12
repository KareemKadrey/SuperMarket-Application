using System;
using System.Drawing;
using System.Windows.Forms;

namespace supermarket
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
            SetupOverlay();
            this.KeyPreview = true; // Enable KeyPress event for the form
            this.KeyPress += SelectForm_KeyPress; // Handle KeyPress event
        }

        private void SelectForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (SelectBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a role before pressing Enter.", "Role Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true; // Mark the key event as handled to prevent further processing
                }
                else
                {
                    // Handle the case when Enter is pressed and a role is selected
                    Button_Ok_Click(sender, e);
                }
            }
        }

        private void SetupOverlay()
        {
            // Create and configure the overlay panel
            Panel overlayPanel = new Panel();
            overlayPanel.BackColor = Color.FromArgb(120, Color.Black); // Adjust the alpha value for the level of transparency
            overlayPanel.Dock = DockStyle.Fill;

            // Add the overlay panel to the form
            this.Controls.Add(overlayPanel);

            // Bring the overlay panel to the front so it covers other controls
            overlayPanel.SendToBack();
        }

        #region buttons and labels
        private void Button_Ok_Click(object sender, EventArgs e)
        {
            HandleRoleSelection();
        }

        private void HandleRoleSelection()
        {
            if (SelectBox.SelectedItem?.ToString() == "Admin")
            {
                Admin_Sign_in adminForm = new Admin_Sign_in();
                adminForm.Show();
                this.Hide();
            }
            else if (SelectBox.SelectedItem?.ToString() == "Customer")
            {
                Customer_Sign_in customerForm = new Customer_Sign_in();
                customerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a valid role.", "Role Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion
    }
}
