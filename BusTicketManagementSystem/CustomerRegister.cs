using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class CustomerRegister : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        public CustomerRegister()
        {
            InitializeComponent();

            // Connect button events
            btnRegister.Click += btnRegister_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void CustomerRegister_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            chkShowPassword.Checked = false;

            ClearFields();

            txtFullName.Focus();
        }

        // =========================================================
        // USERNAME LABEL
        // =========================================================

        private void lblUsername_Click(object sender, EventArgs e)
        {
        }

        // =========================================================
        // SHOW PASSWORD
        // =========================================================

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        // =========================================================
        // REGISTER
        // =========================================================

        private void btnRegister_Click(
            object sender,
            EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // -----------------------------------------------------
            // VALIDATION
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show(
                    "Please enter your full name.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Please enter a username.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show(
                    "Please enter your phone number.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Please enter your email address.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter a password.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Password and Confirm Password do not match.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            // -----------------------------------------------------
            // DATABASE
            // -----------------------------------------------------

            try
            {
                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    con.Open();

                    // -------------------------------------------------
                    // CHECK DUPLICATE USERNAME
                    // -------------------------------------------------

                    string checkUsernameQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Users
                        WHERE Username = @Username;";

                    using (SqlCommand checkUsernameCmd =
                           new SqlCommand(checkUsernameQuery, con))
                    {
                        checkUsernameCmd.Parameters.AddWithValue(
                            "@Username",
                            username);

                        int usernameExists =
                            Convert.ToInt32(
                                checkUsernameCmd.ExecuteScalar());

                        if (usernameExists > 0)
                        {
                            MessageBox.Show(
                                "This username is already taken. Please choose another username.",
                                "Registration",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtUsername.Focus();
                            return;
                        }
                    }

                    // -------------------------------------------------
                    // CHECK DUPLICATE EMAIL
                    // -------------------------------------------------

                    string checkEmailQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Users
                        WHERE Email = @Email;";

                    using (SqlCommand checkEmailCmd =
                           new SqlCommand(checkEmailQuery, con))
                    {
                        checkEmailCmd.Parameters.AddWithValue(
                            "@Email",
                            email);

                        int emailExists =
                            Convert.ToInt32(
                                checkEmailCmd.ExecuteScalar());

                        if (emailExists > 0)
                        {
                            MessageBox.Show(
                                "This email is already registered.",
                                "Registration",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtEmail.Focus();
                            return;
                        }
                    }

                    // -------------------------------------------------
                    // TRANSACTION
                    // -------------------------------------------------

                    using (SqlTransaction transaction =
                           con.BeginTransaction())
                    {
                        try
                        {
                            // -----------------------------------------
                            // INSERT INTO USERS
                            // -----------------------------------------

                            string userQuery = @"
                                INSERT INTO dbo.Users
                                (
                                    Username,
                                    Password,
                                    FullName,
                                    Email,
                                    Phone,
                                    Role,
                                    Status,
                                    CreatedAt
                                )
                                VALUES
                                (
                                    @Username,
                                    @Password,
                                    @FullName,
                                    @Email,
                                    @Phone,
                                    'Customer',
                                    'Active',
                                    GETDATE()
                                );

                                SELECT SCOPE_IDENTITY();";

                            int userID;

                            using (SqlCommand userCmd =
                                   new SqlCommand(
                                       userQuery,
                                       con,
                                       transaction))
                            {
                                userCmd.Parameters.AddWithValue(
                                    "@Username",
                                    username);

                                userCmd.Parameters.AddWithValue(
                                    "@Password",
                                    password);

                                userCmd.Parameters.AddWithValue(
                                    "@FullName",
                                    fullName);

                                userCmd.Parameters.AddWithValue(
                                    "@Email",
                                    email);

                                userCmd.Parameters.AddWithValue(
                                    "@Phone",
                                    phone);

                                userID =
                                    Convert.ToInt32(
                                        userCmd.ExecuteScalar());
                            }

                            // -----------------------------------------
                            // INSERT INTO CUSTOMERS
                            // -----------------------------------------

                            string customerQuery = @"
                                INSERT INTO dbo.Customers
                                (
                                    UserID,
                                    Address,
                                    CreatedAt
                                )
                                VALUES
                                (
                                    @UserID,
                                    NULL,
                                    GETDATE()
                                );";

                            using (SqlCommand customerCmd =
                                   new SqlCommand(
                                       customerQuery,
                                       con,
                                       transaction))
                            {
                                customerCmd.Parameters.AddWithValue(
                                    "@UserID",
                                    userID);

                                customerCmd.ExecuteNonQuery();
                            }

                            // -----------------------------------------
                            // COMMIT
                            // -----------------------------------------

                            transaction.Commit();

                            MessageBox.Show(
                                "Customer account created successfully!\n\nYou can now login using your username and password.",
                                "Registration Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearFields();

                            this.Close();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Registration failed.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CLEAR
        // =========================================================

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();

            txtFullName.Focus();
        }

        // =========================================================
        // CLEAR ALL FIELDS
        // =========================================================

        private void ClearFields()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            chkShowPassword.Checked = false;

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        // =========================================================
        // BACK
        // =========================================================

        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}