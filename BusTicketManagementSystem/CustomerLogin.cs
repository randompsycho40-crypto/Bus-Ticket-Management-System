using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class CustomerLogin : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        public CustomerLogin()
        {
            InitializeComponent();
        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            txtPassword.UseSystemPasswordChar = true;

            txtUsername.Focus();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Please enter your username.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your password.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT
                            u.UserID,
                            u.FullName,
                            u.Username,
                            c.CustomerID
                        FROM dbo.Users u
                        INNER JOIN dbo.Customers c
                            ON u.UserID = c.UserID
                        WHERE u.Username = @Username
                          AND u.Password = @Password
                          AND u.Role = 'Customer'
                          AND u.Status = 'Active';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int customerID = Convert.ToInt32(reader["CustomerID"]);
                                string fullName = reader["FullName"].ToString();

                                CustomerDashboard dashboard =
                                    new CustomerDashboard(customerID, fullName);

                                dashboard.Show();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Invalid username or password, or the customer account is inactive.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while logging in.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CustomerRegister registerForm = new CustomerRegister();

            registerForm.ShowDialog();
        }
    }
}