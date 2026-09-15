using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class ManageSettings : Form
    {
        // ==========================================
        // DATABASE CONNECTION
        // ==========================================
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public ManageSettings()
        {
            InitializeComponent();

            // ==========================================
            // CONNECT BUTTON EVENTS
            // ==========================================

            btnChangeLogin.Click -= btnChangeLogin_Click;
            btnChangeLogin.Click += btnChangeLogin_Click;

            btnSaveSettings.Click -= btnSaveSettings_Click;
            btnSaveSettings.Click += btnSaveSettings_Click;

            btnResetSettings.Click -= btnResetSettings_Click;
            btnResetSettings.Click += btnResetSettings_Click;


            // ==========================================
            // DEFAULT SYSTEM STATUS
            // ==========================================

            if (cmbSystemStatus.Items.Count > 0)
            {
                cmbSystemStatus.SelectedIndex = 0;
            }


            // ==========================================
            // LOAD SUPER ADMIN SETTINGS
            // ==========================================

            LoadSuperAdminSettings();
        }


        // ==========================================
        // LOAD SUPER ADMIN LOGIN INFORMATION
        // ==========================================
        private void LoadSuperAdminSettings()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT TOP 1
                            Username,
                            Password
                        FROM dbo.Users
                        WHERE Role = 'SuperAdmin'
                        ORDER BY UserID";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsername.Text =
                                    reader["Username"].ToString();

                                txtPassword.Text =
                                    reader["Password"].ToString();
                            }
                        }
                    }
                }


                // ==========================================
                // DEFAULT APPLICATION INFORMATION
                // ==========================================

                txtAppName.Text = "BusGo";

                if (cmbSystemStatus.Items.Count > 0)
                {
                    cmbSystemStatus.SelectedItem = "Active";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load settings.\n\n" +
                    ex.Message,
                    "Settings Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ==========================================
        // CHANGE LOGIN INFORMATION
        // ==========================================
        private void btnChangeLogin_Click(
            object sender,
            EventArgs e)
        {
            string username =
                txtUsername.Text.Trim();

            string password =
                txtPassword.Text.Trim();


            // ==========================================
            // USERNAME VALIDATION
            // ==========================================

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Please enter a username.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsername.Focus();
                return;
            }


            // ==========================================
            // PASSWORD VALIDATION
            // ==========================================

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter a password.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }


            // ==========================================
            // CONFIRM CHANGE
            // ==========================================

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to change the Super Admin login information?",
                    "Confirm Change",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }


            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();


                    // ==========================================
                    // CHECK USERNAME ALREADY EXISTS
                    // ==========================================

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Users
                        WHERE Username = @Username
                        AND Role <> 'SuperAdmin'";


                    using (SqlCommand checkCmd =
                        new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@Username",
                            username
                        );


                        int existingUser =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar()
                            );


                        if (existingUser > 0)
                        {
                            MessageBox.Show(
                                "This username is already used by another user.",
                                "Username Already Exists",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            txtUsername.Focus();
                            return;
                        }
                    }


                    // ==========================================
                    // UPDATE SUPER ADMIN LOGIN
                    // ==========================================

                    string updateQuery = @"
                        UPDATE dbo.Users
                        SET
                            Username = @Username,
                            Password = @Password
                        WHERE Role = 'SuperAdmin'";


                    using (SqlCommand updateCmd =
                        new SqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue(
                            "@Username",
                            username
                        );

                        updateCmd.Parameters.AddWithValue(
                            "@Password",
                            password
                        );


                        int rows =
                            updateCmd.ExecuteNonQuery();


                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Super Admin login information updated successfully.\n\n" +
                                "Use the new username and password from your next login.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                "Super Admin account was not found.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error changing login information.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ==========================================
        // SAVE SYSTEM SETTINGS
        // ==========================================
        private void btnSaveSettings_Click(
            object sender,
            EventArgs e)
        {
            // ==========================================
            // APPLICATION NAME VALIDATION
            // ==========================================

            if (string.IsNullOrWhiteSpace(txtAppName.Text))
            {
                MessageBox.Show(
                    "Application Name cannot be empty.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtAppName.Focus();
                return;
            }


            // ==========================================
            // SYSTEM STATUS VALIDATION
            // ==========================================

            if (string.IsNullOrWhiteSpace(cmbSystemStatus.Text))
            {
                MessageBox.Show(
                    "Please select System Status.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbSystemStatus.Focus();
                return;
            }


            // ==========================================
            // SAVE CONFIRMATION
            // ==========================================

            MessageBox.Show(
                "System settings saved successfully.\n\n" +
                "Application Name: " +
                txtAppName.Text.Trim() +
                "\nSystem Status: " +
                cmbSystemStatus.Text.Trim(),
                "Settings Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        // ==========================================
        // RESET SYSTEM SETTINGS
        // ==========================================
        private void btnResetSettings_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to reset the system settings?",
                    "Reset Settings",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (result != DialogResult.Yes)
            {
                return;
            }


            // ==========================================
            // RESTORE DEFAULT VALUES
            // ==========================================

            txtAppName.Text = "BusGo";


            if (cmbSystemStatus.Items.Count > 0)
            {
                cmbSystemStatus.SelectedItem = "Active";
            }


            MessageBox.Show(
                "System settings have been reset to default values.",
                "Reset Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        // ==========================================
        // PAGE TITLE CLICK
        // ==========================================
        private void labelPageTitle_Click(
            object sender,
            EventArgs e)
        {
            // No action required
        }


        // ==========================================
        // SYSTEM INFORMATION LABEL CLICK
        // ==========================================
        private void label1_Click(
            object sender,
            EventArgs e)
        {
            // No action required
        }
    }
}