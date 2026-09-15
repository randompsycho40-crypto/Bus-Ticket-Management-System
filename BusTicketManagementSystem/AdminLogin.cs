using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class AdminLogin : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        public AdminLogin()
        {
            InitializeComponent();

            // Connect button events
            btnLogin.Click -= btnLogin_Click;
            btnLogin.Click += btnLogin_Click;

            btnCancel.Click -= btnCancel_Click;
            btnCancel.Click += btnCancel_Click;

            chkShowPassword.CheckedChanged -= chkShowPassword_CheckedChanged;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            btnRequestAccount.Click -= btnRequestAccount_Click;
            btnRequestAccount.Click += btnRequestAccount_Click;

            // Initial state
            txtUsername.Clear();
            txtPassword.Clear();

            txtPassword.UseSystemPasswordChar = true;

            chkShowPassword.Checked = false;

            txtUsername.Focus();
        }

        // =========================================
        // LOGIN
        // =========================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

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
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            u.UserID,
                            u.FullName,
                            o.OperatorID,
                            o.CompanyName
                        FROM dbo.Users u
                        INNER JOIN dbo.Operators o
                            ON u.UserID = o.UserID
                        WHERE u.Username = @Username
                          AND u.Password = @Password
                          AND u.Role = 'Operator'
                          AND u.Status = 'Active'
                          AND o.Status = 'Active'";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Username",
                            username);

                        cmd.Parameters.AddWithValue(
                            "@Password",
                            password);

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int operatorID =
                                    Convert.ToInt32(
                                        reader["OperatorID"]);

                                string operatorName =
                                    reader["FullName"].ToString();

                                string companyName =
                                    reader["CompanyName"].ToString();

                                MessageBox.Show(
                                    "Login successful!\n\n" +
                                    "Welcome, " + operatorName + "\n" +
                                    "Company: " + companyName,
                                    "Login Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                // Open dashboard with logged-in OperatorID
                                AdminDashboard dashboard =
                                    new AdminDashboard(operatorID);

                                this.Hide();

                                dashboard.FormClosed +=
                                    (s, args) => this.Close();

                                dashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Invalid username or password.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

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
                    "An error occurred while logging in.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // SHOW / HIDE PASSWORD
        // =========================================
        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        // =========================================
        // CANCEL
        // =========================================
        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            this.Close();
        }

        // =========================================
        // REQUEST OPERATOR ACCOUNT
        // =========================================
        private void btnRequestAccount_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Operator account requests are handled by the Super Admin.\n\n" +
                "Please contact the system administrator.",
                "Request Operator Account",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================
        // TITLE CLICK
        // =========================================
        private void lblTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}