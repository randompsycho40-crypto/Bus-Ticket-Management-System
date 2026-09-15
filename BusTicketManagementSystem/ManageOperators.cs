using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class ManageOperators : Form
    {
        // ==========================================
        // DATABASE CONNECTION
        // ==========================================
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        // Selected operator ID
        private int selectedOperatorID = 0;

        public ManageOperators()
        {
            InitializeComponent();

            // ==========================================
            // FORM SETTINGS
            // ==========================================
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // ==========================================
            // DATAGRIDVIEW SETTINGS
            // ==========================================
            dgvOperator.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvOperator.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvOperator.MultiSelect = false;
            dgvOperator.ReadOnly = true;
            dgvOperator.AllowUserToAddRows = false;

            // IMPORTANT:
            // We already created the columns in Designer.
            // Therefore, do NOT let DataGridView create new columns.
            dgvOperator.AutoGenerateColumns = false;

            dgvOperator.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvOperator.RowTemplate.Height = 35;

            // Connect existing Designer columns
            ConfigureExistingGridColumns();

            // Load database data
            LoadOperators();
        }

        // ==========================================
        // CONFIGURE EXISTING DESIGNER COLUMNS
        // ==========================================
        private void ConfigureExistingGridColumns()
        {
            // We are NOT creating new columns.
            // We are only connecting the existing 7 columns
            // from the Designer to database fields.

            if (dgvOperator.Columns.Count >= 7)
            {
                // Column 0
                dgvOperator.Columns[0].HeaderText = "Operator ID";
                dgvOperator.Columns[0].DataPropertyName = "OperatorID";
                dgvOperator.Columns[0].FillWeight = 70;

                // Column 1
                dgvOperator.Columns[1].HeaderText = "Operator Name";
                dgvOperator.Columns[1].DataPropertyName = "OperatorName";
                dgvOperator.Columns[1].FillWeight = 150;

                // Column 2
                dgvOperator.Columns[2].HeaderText = "Company Name";
                dgvOperator.Columns[2].DataPropertyName = "CompanyName";
                dgvOperator.Columns[2].FillWeight = 150;

                // Column 3
                dgvOperator.Columns[3].HeaderText = "Phone";
                dgvOperator.Columns[3].DataPropertyName = "Phone";
                dgvOperator.Columns[3].FillWeight = 110;

                // Column 4
                dgvOperator.Columns[4].HeaderText = "Email";
                dgvOperator.Columns[4].DataPropertyName = "Email";
                dgvOperator.Columns[4].FillWeight = 170;

                // Column 5
                dgvOperator.Columns[5].HeaderText = "Status";
                dgvOperator.Columns[5].DataPropertyName = "Status";
                dgvOperator.Columns[5].FillWeight = 90;

                // Column 6
                dgvOperator.Columns[6].HeaderText = "Registration Date";
                dgvOperator.Columns[6].DataPropertyName = "RegistrationDate";
                dgvOperator.Columns[6].FillWeight = 120;

                // Date format
                dgvOperator.Columns[6].DefaultCellStyle.Format =
                    "dd-MMM-yyyy";
            }

            // If Designer has any accidental extra columns,
            // hide them instead of allowing duplicates.
            for (int i = 7; i < dgvOperator.Columns.Count; i++)
            {
                dgvOperator.Columns[i].Visible = false;
            }
        }

        // ==========================================
        // LOAD ALL OPERATORS
        // ==========================================
        private void LoadOperators()
        {
            string query = @"
                SELECT
                    o.OperatorID,
                    u.FullName AS OperatorName,
                    o.CompanyName,
                    o.Phone,
                    o.Email,
                    o.Status,
                    o.CreatedAt AS RegistrationDate
                FROM dbo.Operators o
                INNER JOIN dbo.Users u
                    ON o.UserID = u.UserID
                ORDER BY o.OperatorID;
            ";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvOperator.DataSource = table;
                    }
                }

                ConfigureExistingGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load operators.\n\nError: " +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // GRID ROW CLICK
        // ==========================================
        private void dgvOperator_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvOperator.Rows[e.RowIndex];

            if (row.Cells["OperatorID"].Value == null)
                return;

            selectedOperatorID =
                Convert.ToInt32(
                    row.Cells["OperatorID"].Value
                );

            txtOperatorName.Text =
                row.Cells["OperatorName"].Value?.ToString() ?? "";

            txtCompanyName.Text =
                row.Cells["CompanyName"].Value?.ToString() ?? "";

            txtPhone.Text =
                row.Cells["Phone"].Value?.ToString() ?? "";

            txtEmail.Text =
                row.Cells["Email"].Value?.ToString() ?? "";

            cmbStatus.Text =
                row.Cells["Status"].Value?.ToString() ?? "Active";
        }

        // ==========================================
        // SHOW ALL OPERATORS
        // ==========================================
        private void btnShowOperator_Click(
            object sender,
            EventArgs e)
        {
            LoadOperators();
            ClearFields();
        }

        // ==========================================
        // SEARCH OPERATORS
        // ==========================================
        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            string searchText =
                txtSearchOperator.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadOperators();
                return;
            }

            string query = @"
                SELECT
                    o.OperatorID,
                    u.FullName AS OperatorName,
                    o.CompanyName,
                    o.Phone,
                    o.Email,
                    o.Status,
                    o.CreatedAt AS RegistrationDate
                FROM dbo.Operators o
                INNER JOIN dbo.Users u
                    ON o.UserID = u.UserID
                WHERE
                    u.FullName LIKE @Search
                    OR o.CompanyName LIKE @Search
                    OR o.Phone LIKE @Search
                    OR o.Email LIKE @Search
                    OR o.Status LIKE @Search
                ORDER BY o.OperatorID;
            ";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%"
                        );

                        DataTable table =
                            new DataTable();

                        adapter.Fill(table);

                        dgvOperator.DataSource = table;
                    }
                }

                ConfigureExistingGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search operators.\n\nError: " +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // ADD OPERATOR
        // ==========================================
        private void btnAddOperator_Click(
            object sender,
            EventArgs e)
        {
            string operatorName =
                txtOperatorName.Text.Trim();

            string companyName =
                txtCompanyName.Text.Trim();

            string phone =
                txtPhone.Text.Trim();

            string email =
                txtEmail.Text.Trim();

            string status =
                cmbStatus.Text.Trim();

            if (string.IsNullOrWhiteSpace(operatorName))
            {
                MessageBox.Show(
                    "Please enter operator name.",
                    "Required Field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtOperatorName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show(
                    "Please enter company name.",
                    "Required Field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCompanyName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show(
                    "Please enter phone number.",
                    "Required Field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Please enter email address.",
                    "Required Field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                status = "Active";
            }

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction =
                        connection.BeginTransaction();

                    try
                    {
                        // ------------------------------------------
                        // CREATE USER ACCOUNT
                        // ------------------------------------------
                        string userQuery = @"
                            INSERT INTO dbo.Users
                            (
                                FullName,
                                Username,
                                Password,
                                Role,
                                Status
                            )
                            VALUES
                            (
                                @FullName,
                                @Username,
                                @Password,
                                'Operator',
                                @Status
                            );

                            SELECT SCOPE_IDENTITY();
                        ";

                        int userID;

                        using (SqlCommand userCommand =
                            new SqlCommand(
                                userQuery,
                                connection,
                                transaction))
                        {
                            userCommand.Parameters.AddWithValue(
                                "@FullName",
                                operatorName
                            );

                            userCommand.Parameters.AddWithValue(
                                "@Username",
                                GenerateUsername(
                                    operatorName,
                                    connection,
                                    transaction
                                )
                            );

                            userCommand.Parameters.AddWithValue(
                                "@Password",
                                "1234"
                            );

                            userCommand.Parameters.AddWithValue(
                                "@Status",
                                status
                            );

                            userID =
                                Convert.ToInt32(
                                    userCommand.ExecuteScalar()
                                );
                        }

                        // ------------------------------------------
                        // CREATE OPERATOR RECORD
                        // ------------------------------------------
                        string operatorQuery = @"
                            INSERT INTO dbo.Operators
                            (
                                UserID,
                                CompanyName,
                                CompanyAddress,
                                LicenseNumber,
                                CommissionRate,
                                Status,
                                Phone,
                                Email
                            )
                            VALUES
                            (
                                @UserID,
                                @CompanyName,
                                NULL,
                                NULL,
                                10.00,
                                @Status,
                                @Phone,
                                @Email
                            );
                        ";

                        using (SqlCommand operatorCommand =
                            new SqlCommand(
                                operatorQuery,
                                connection,
                                transaction))
                        {
                            operatorCommand.Parameters.AddWithValue(
                                "@UserID",
                                userID
                            );

                            operatorCommand.Parameters.AddWithValue(
                                "@CompanyName",
                                companyName
                            );

                            operatorCommand.Parameters.AddWithValue(
                                "@Status",
                                status
                            );

                            operatorCommand.Parameters.AddWithValue(
                                "@Phone",
                                phone
                            );

                            operatorCommand.Parameters.AddWithValue(
                                "@Email",
                                email
                            );

                            operatorCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                MessageBox.Show(
                    "Operator added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadOperators();
                ClearFields();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 ||
                    ex.Number == 2627)
                {
                    MessageBox.Show(
                        "A duplicate value already exists.\n\n" +
                        "Please check the username or other unique information.",
                        "Duplicate Data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Unable to add operator.\n\nError: " +
                        ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add operator.\n\nError: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // GENERATE USERNAME
        // ==========================================
        private string GenerateUsername(
            string name,
            SqlConnection connection,
            SqlTransaction transaction)
        {
            string username =
                name.ToLower()
                    .Replace(" ", "");

            if (string.IsNullOrWhiteSpace(username))
            {
                username = "operator";
            }

            string baseUsername = username;
            int counter = 1;

            while (true)
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM dbo.Users
                    WHERE Username = @Username;
                ";

                using (SqlCommand command =
                    new SqlCommand(
                        query,
                        connection,
                        transaction))
                {
                    command.Parameters.AddWithValue(
                        "@Username",
                        username
                    );

                    int count =
                        Convert.ToInt32(
                            command.ExecuteScalar()
                        );

                    if (count == 0)
                        break;
                }

                username =
                    baseUsername + counter;

                counter++;
            }

            return username;
        }

        // ==========================================
        // EDIT OPERATOR
        // ==========================================
        private void btnEditOperator_Click(
            object sender,
            EventArgs e)
        {
            if (selectedOperatorID == 0)
            {
                MessageBox.Show(
                    "Please select an operator from the table first.",
                    "Select Operator",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string operatorName =
                txtOperatorName.Text.Trim();

            string companyName =
                txtCompanyName.Text.Trim();

            string phone =
                txtPhone.Text.Trim();

            string email =
                txtEmail.Text.Trim();

            string status =
                cmbStatus.Text.Trim();

            if (string.IsNullOrWhiteSpace(operatorName))
            {
                MessageBox.Show(
                    "Operator name cannot be empty.",
                    "Invalid Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtOperatorName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show(
                    "Company name cannot be empty.",
                    "Invalid Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCompanyName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show(
                    "Phone cannot be empty.",
                    "Invalid Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Email cannot be empty.",
                    "Invalid Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                status = "Active";
            }

            string query = @"
                UPDATE u
                SET
                    u.FullName = @FullName,
                    u.Status = @UserStatus
                FROM dbo.Users u
                INNER JOIN dbo.Operators o
                    ON u.UserID = o.UserID
                WHERE o.OperatorID = @OperatorID;

                UPDATE dbo.Operators
                SET
                    CompanyName = @CompanyName,
                    Phone = @Phone,
                    Email = @Email,
                    Status = @Status
                WHERE OperatorID = @OperatorID;
            ";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@FullName",
                            operatorName
                        );

                        command.Parameters.AddWithValue(
                            "@UserStatus",
                            status
                        );

                        command.Parameters.AddWithValue(
                            "@CompanyName",
                            companyName
                        );

                        command.Parameters.AddWithValue(
                            "@Phone",
                            phone
                        );

                        command.Parameters.AddWithValue(
                            "@Email",
                            email
                        );

                        command.Parameters.AddWithValue(
                            "@Status",
                            status
                        );

                        command.Parameters.AddWithValue(
                            "@OperatorID",
                            selectedOperatorID
                        );

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Operator updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadOperators();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update operator.\n\nError: " +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // DELETE OPERATOR
        // ==========================================
        private void btnDeleteOperator_Click(
            object sender,
            EventArgs e)
        {
            if (selectedOperatorID == 0)
            {
                MessageBox.Show(
                    "Please select an operator from the table first.",
                    "Select Operator",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this operator?\n\n" +
                    "This action will also delete the related user account.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    string getUserQuery = @"
                        SELECT UserID
                        FROM dbo.Operators
                        WHERE OperatorID = @OperatorID;
                    ";

                    int userID = 0;

                    using (SqlCommand command =
                        new SqlCommand(
                            getUserQuery,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@OperatorID",
                            selectedOperatorID
                        );

                        object value =
                            command.ExecuteScalar();

                        if (value != null)
                            userID =
                                Convert.ToInt32(value);
                    }

                    string deleteOperatorQuery = @"
                        DELETE FROM dbo.Operators
                        WHERE OperatorID = @OperatorID;
                    ";

                    using (SqlCommand command =
                        new SqlCommand(
                            deleteOperatorQuery,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@OperatorID",
                            selectedOperatorID
                        );

                        command.ExecuteNonQuery();
                    }

                    if (userID > 0)
                    {
                        string deleteUserQuery = @"
                            DELETE FROM dbo.Users
                            WHERE UserID = @UserID
                              AND Role = 'Operator';
                        ";

                        using (SqlCommand command =
                            new SqlCommand(
                                deleteUserQuery,
                                connection))
                        {
                            command.Parameters.AddWithValue(
                                "@UserID",
                                userID
                            );

                            command.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show(
                    "Operator deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                selectedOperatorID = 0;

                LoadOperators();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "This operator cannot be deleted because related records exist.\n\n" +
                    "You may change the operator status to Inactive instead.\n\n" +
                    "Error: " + ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete operator.\n\nError: " +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // CLEAR
        // ==========================================
        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedOperatorID = 0;

            txtOperatorName.Clear();
            txtCompanyName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
            else
                cmbStatus.Text = "Active";

            txtOperatorName.Focus();
        }

        // ==========================================
        // UNUSED EVENTS
        // ==========================================
        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtOperatorName_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void panelActions_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void labelSearch_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtSearchOperator_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblOperatorName_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblCompanyName_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtCompanyName_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblPhone_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtPhone_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblEmail_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtEmail_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblStatus_Click(
            object sender,
            EventArgs e)
        {
        }

        private void cmbStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }
    }
}
