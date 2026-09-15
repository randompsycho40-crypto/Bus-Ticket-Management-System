using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class SuperAdmin : Form
    {
        // ==========================================
        // DATABASE CONNECTION
        // ==========================================
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        public SuperAdmin()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void SuperAdmin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

            textBox1.Clear();
            textBox2.Clear();

            chkShowPassword.Checked = false;

            textBox1.Focus();
        }

        // ==========================================
        // LOGIN / CONTINUE BUTTON
        // ==========================================
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            // Check empty username
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Please enter your username.",
                    "Login Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            // Check empty password
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your password.",
                    "Login Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox2.Focus();
                return;
            }

            // ==========================================
            // CHECK LOGIN FROM DATABASE
            // ==========================================
            string query = @"
                SELECT UserID, FullName
                FROM dbo.Users
                WHERE Username = @Username
                  AND Password = @Password
                  AND Role = 'SuperAdmin'
                  AND Status = 'Active';
            ";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName = reader["FullName"].ToString();

                                MessageBox.Show(
                                    "Login successful!\n\nWelcome, " + fullName + ".",
                                    "Login Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                // ==========================================
                                // OPEN SUPER ADMIN DASHBOARD
                                // ==========================================
                                SuperAdminDashBoard dashboard =
                                    new SuperAdminDashBoard();

                                this.Hide();

                                dashboard.ShowDialog();

                                this.Show();

                                // Clear login fields after dashboard closes
                                textBox1.Clear();
                                textBox2.Clear();

                                chkShowPassword.Checked = false;
                                textBox2.PasswordChar = '*';

                                textBox1.Focus();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Invalid username or password.",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );

                                textBox2.Clear();
                                textBox2.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the database.\n\nError: "
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // CANCEL BUTTON
        // ==========================================
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel and close?",
                "Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ==========================================
        // CHANGE LOGIN INFORMATION
        // ==========================================
        private void button3_Click(object sender, EventArgs e)
        {
            // Get current username
            string currentUsername = Prompt.ShowDialog(
                "Enter your current username:",
                "Verify Current Username"
            );

            if (currentUsername == null)
                return;

            currentUsername = currentUsername.Trim();

            // Get current password
            string currentPassword = Prompt.ShowDialog(
                "Enter your current password:",
                "Verify Current Password"
            );

            if (currentPassword == null)
                return;

            // Verify current credentials from database
            string verifyQuery = @"
                SELECT UserID
                FROM dbo.Users
                WHERE Username = @Username
                  AND Password = @Password
                  AND Role = 'SuperAdmin'
                  AND Status = 'Active';
            ";

            int userID = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(verifyQuery, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Username",
                            currentUsername
                        );

                        command.Parameters.AddWithValue(
                            "@Password",
                            currentPassword
                        );

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            userID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the database.\n\nError: "
                    + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (userID == 0)
            {
                MessageBox.Show(
                    "Current username or password is incorrect.",
                    "Verification Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // ==========================================
            // NEW USERNAME
            // ==========================================
            string newUsername = Prompt.ShowDialog(
                "Enter your new username:",
                "Change Username"
            );

            if (newUsername == null)
                return;

            newUsername = newUsername.Trim();

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                MessageBox.Show(
                    "Username cannot be empty.",
                    "Invalid Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // ==========================================
            // NEW PASSWORD
            // ==========================================
            string newPassword = Prompt.ShowDialog(
                "Enter your new password:",
                "Change Password"
            );

            if (newPassword == null)
                return;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show(
                    "Password cannot be empty.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // ==========================================
            // UPDATE DATABASE
            // ==========================================
            string updateQuery = @"
                UPDATE dbo.Users
                SET Username = @NewUsername,
                    Password = @NewPassword
                WHERE UserID = @UserID;
            ";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@NewUsername",
                            newUsername
                        );

                        command.Parameters.AddWithValue(
                            "@NewPassword",
                            newPassword
                        );

                        command.Parameters.AddWithValue(
                            "@UserID",
                            userID
                        );

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Username and password have been changed successfully.",
                    "Login Information Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show(
                        "This username already exists. Please choose another username.",
                        "Username Already Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Unable to update login information.\n\nError: "
                        + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update login information.\n\nError: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // SHOW / HIDE PASSWORD
        // ==========================================
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }


    // =========================================================
    // SIMPLE INPUT BOX
    // =========================================================
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 170,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Width = 340,
                Text = text
            };

            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 340
            };

            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 200,
                Top = 90,
                Width = 75,
                DialogResult = DialogResult.OK
            };

            Button cancel = new Button()
            {
                Text = "Cancel",
                Left = 285,
                Top = 90,
                Width = 75,
                DialogResult = DialogResult.Cancel
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return textBox.Text;
            }

            return null;
        }
    }
}