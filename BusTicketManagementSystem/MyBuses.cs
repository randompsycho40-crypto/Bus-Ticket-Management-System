using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class MyBuses : Form
    {
        private readonly string connectionString =
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";


    private readonly int operatorID;
        private int selectedBusID = 0;

        public MyBuses(int operatorID)
        {
            InitializeComponent();

            this.operatorID = operatorID;

            // =====================================================
            // REMOVE DUPLICATE EVENT CONNECTIONS
            // =====================================================

            btnAddBus.Click -= btnAddBus_Click;
            btnAddBus.Click += btnAddBus_Click;

            btnEditBus.Click -= btnEditBus_Click;
            btnEditBus.Click += btnEditBus_Click;

            btnDeleteBus.Click -= btnDeleteBus_Click;
            btnDeleteBus.Click += btnDeleteBus_Click;

            btnShowBuses.Click -= btnShowBuses_Click;
            btnShowBuses.Click += btnShowBuses_Click;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            btnClear.Click -= btnClear_Click;
            btnClear.Click += btnClear_Click;

            dgvMyBuses.CellClick -= dgvMyBuses_CellClick;
            dgvMyBuses.CellClick += dgvMyBuses_CellClick;

            txtSearchBus.KeyDown -= txtSearchBus_KeyDown;
            txtSearchBus.KeyDown += txtSearchBus_KeyDown;

            // =====================================================
            // BUS TYPE
            // =====================================================

            cmbBusType.Items.Clear();

            cmbBusType.Items.Add("AC");
            cmbBusType.Items.Add("Non-AC");
            cmbBusType.Items.Add("Sleeper");

            cmbBusType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            // =====================================================
            // GRID
            // =====================================================

            dgvMyBuses.AutoGenerateColumns = false;

            colBusID.DataPropertyName = "BusID";
            colBusNumber.DataPropertyName = "BusNumber";
            colRoute.DataPropertyName = "Route";
            colBusType.DataPropertyName = "BusType";
            colTotalSeats.DataPropertyName = "TotalSeats";
            colFare.DataPropertyName = "Fare";
            colStatus.DataPropertyName = "Status";

            // Fare and Route are derived from Schedule
            txtRoute.ReadOnly = true;
            txtFare.ReadOnly = true;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void MyBuses_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadMyBuses();
        }

        // =========================================================
        // LOAD ALL BUSES OF CURRENT OPERATOR
        // =========================================================

        private void LoadMyBuses()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT
                        b.BusID,
                        b.BusNumber,

                        ISNULL(
                            r.FromLocation + ' - ' + r.ToLocation,
                            'Not Scheduled'
                        ) AS Route,

                        b.BusType,
                        b.TotalSeats,

                        ISNULL(
                            s.Fare,
                            0
                        ) AS Fare,

                        b.Status

                    FROM dbo.Buses b

                    OUTER APPLY
                    (
                        SELECT TOP 1
                            s.RouteID,
                            s.Fare
                        FROM dbo.Schedules s
                        WHERE s.BusID = b.BusID
                        ORDER BY
                            s.TravelDate DESC,
                            s.ScheduleID DESC
                    ) s

                    LEFT JOIN dbo.Routes r
                        ON s.RouteID = r.RouteID

                    WHERE b.OperatorID = @OperatorID

                    ORDER BY b.BusID DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            dgvMyBuses.DataSource = table;
                        }
                    }
                }

                dgvMyBuses.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load buses.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ADD BUS
        // =========================================================

        private void btnAddBus_Click(object sender, EventArgs e)
        {
            if (!ValidateBusInput())
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // -------------------------------------------------
                    // CHECK DUPLICATE BUS NUMBER
                    // -------------------------------------------------

                    string checkQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.Buses
                    WHERE BusNumber = @BusNumber";

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@BusNumber",
                            txtBusNumber.Text.Trim());

                        int exists =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (exists > 0)
                        {
                            MessageBox.Show(
                                "This bus number already exists.",
                                "Duplicate Bus",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtBusNumber.Focus();
                            return;
                        }
                    }

                    // -------------------------------------------------
                    // INSERT BUS
                    // -------------------------------------------------

                    string insertQuery = @"
                    INSERT INTO dbo.Buses
                    (
                        OperatorID,
                        BusNumber,
                        BusType,
                        TotalSeats,
                        Status
                    )
                    VALUES
                    (
                        @OperatorID,
                        @BusNumber,
                        @BusType,
                        @TotalSeats,
                        @Status
                    )";

                    using (SqlCommand cmd =
                        new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        cmd.Parameters.AddWithValue(
                            "@BusNumber",
                            txtBusNumber.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@BusType",
                            cmbBusType.SelectedItem.ToString());

                        cmd.Parameters.AddWithValue(
                            "@TotalSeats",
                            Convert.ToInt32(
                                txtTotalSeats.Text.Trim()));

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Bus added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMyBuses();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to add bus.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // EDIT BUS
        // =========================================================

        private void btnEditBus_Click(object sender, EventArgs e)
        {
            if (selectedBusID == 0)
            {
                MessageBox.Show(
                    "Please select a bus from the table first.",
                    "Edit Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateBusInput())
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // -------------------------------------------------
                    // CHECK DUPLICATE BUS NUMBER
                    // -------------------------------------------------

                    string checkQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.Buses
                    WHERE BusNumber = @BusNumber
                    AND BusID <> @BusID";

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@BusNumber",
                            txtBusNumber.Text.Trim());

                        checkCmd.Parameters.AddWithValue(
                            "@BusID",
                            selectedBusID);

                        int exists =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (exists > 0)
                        {
                            MessageBox.Show(
                                "Another bus already uses this bus number.",
                                "Duplicate Bus",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtBusNumber.Focus();
                            return;
                        }
                    }

                    // -------------------------------------------------
                    // UPDATE BUS
                    // -------------------------------------------------

                    string updateQuery = @"
                    UPDATE dbo.Buses
                    SET
                        BusNumber = @BusNumber,
                        BusType = @BusType,
                        TotalSeats = @TotalSeats,
                        Status = @Status

                    WHERE BusID = @BusID
                    AND OperatorID = @OperatorID";

                    using (SqlCommand cmd =
                        new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@BusNumber",
                            txtBusNumber.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@BusType",
                            cmbBusType.SelectedItem.ToString());

                        cmd.Parameters.AddWithValue(
                            "@TotalSeats",
                            Convert.ToInt32(
                                txtTotalSeats.Text.Trim()));

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.SelectedItem.ToString());

                        cmd.Parameters.AddWithValue(
                            "@BusID",
                            selectedBusID);

                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        int rows =
                            cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show(
                                "Bus could not be updated.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Bus updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMyBuses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update bus.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DELETE BUS
        // =========================================================

        private void btnDeleteBus_Click(object sender, EventArgs e)
        {
            if (selectedBusID == 0)
            {
                MessageBox.Show(
                    "Please select a bus from the table first.",
                    "Delete Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this bus?\n\n" +
                    "Bus Number: " +
                    txtBusNumber.Text,
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // -------------------------------------------------
                    // CHECK SCHEDULE DEPENDENCY
                    // -------------------------------------------------

                    string checkScheduleQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.Schedules
                    WHERE BusID = @BusID";

                    using (SqlCommand checkCmd =
                        new SqlCommand(
                            checkScheduleQuery,
                            con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@BusID",
                            selectedBusID);

                        int scheduleCount =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (scheduleCount > 0)
                        {
                            MessageBox.Show(
                                "This bus cannot be deleted because it is already used in a schedule.\n\n" +
                                "Please remove or update the related schedules first.",
                                "Delete Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    // -------------------------------------------------
                    // DELETE BUS
                    // -------------------------------------------------

                    string deleteQuery = @"
                    DELETE FROM dbo.Buses
                    WHERE BusID = @BusID
                    AND OperatorID = @OperatorID";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            deleteQuery,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@BusID",
                            selectedBusID);

                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        int rows =
                            cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show(
                                "Bus could not be deleted.",
                                "Delete Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Bus deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMyBuses();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "This bus cannot be deleted because it is being used by another part of the system.\n\n" +
                    ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete bus.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SHOW ALL BUSES
        // =========================================================

        private void btnShowBuses_Click(object sender, EventArgs e)
        {
            txtSearchBus.Clear();

            LoadMyBuses();
            ClearFields();
        }

        // =========================================================
        // SEARCH
        // =========================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBuses();
        }

        private void txtSearchBus_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchBuses();
            }
        }

        private void SearchBuses()
        {
            string searchText =
                txtSearchBus.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadMyBuses();
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT
                        b.BusID,
                        b.BusNumber,

                        ISNULL(
                            r.FromLocation + ' - ' + r.ToLocation,
                            'Not Scheduled'
                        ) AS Route,

                        b.BusType,
                        b.TotalSeats,

                        ISNULL(
                            s.Fare,
                            0
                        ) AS Fare,

                        b.Status

                    FROM dbo.Buses b

                    OUTER APPLY
                    (
                        SELECT TOP 1
                            s.RouteID,
                            s.Fare
                        FROM dbo.Schedules s
                        WHERE s.BusID = b.BusID
                        ORDER BY
                            s.TravelDate DESC,
                            s.ScheduleID DESC
                    ) s

                    LEFT JOIN dbo.Routes r
                        ON s.RouteID = r.RouteID

                    WHERE b.OperatorID = @OperatorID

                    AND
                    (
                        b.BusNumber LIKE @Search
                        OR b.BusType LIKE @Search
                        OR b.Status LIKE @Search
                        OR r.FromLocation LIKE @Search
                        OR r.ToLocation LIKE @Search
                    )

                    ORDER BY b.BusID DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        cmd.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%");

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            dgvMyBuses.DataSource =
                                table;
                        }
                    }
                }

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search buses.\n\n" +
                    ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SELECT BUS FROM GRID
        // =========================================================

        private void dgvMyBuses_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvMyBuses.Rows[e.RowIndex];

                object busIDValue =
                    row.Cells["colBusID"].Value;

                if (busIDValue == null ||
                    busIDValue == DBNull.Value)
                {
                    return;
                }

                selectedBusID =
                    Convert.ToInt32(busIDValue);

                txtBusNumber.Text =
                    row.Cells["colBusNumber"]
                       .Value?.ToString() ?? "";

                string busType =
                    row.Cells["colBusType"]
                        .Value?.ToString();

                if (!string.IsNullOrWhiteSpace(busType))
                {
                    cmbBusType.SelectedItem = busType;
                }
                else
                {
                    cmbBusType.SelectedIndex = -1;
                }

                txtTotalSeats.Text =
                    row.Cells["colTotalSeats"]
                       .Value?.ToString() ?? "";

                txtFare.Text =
                    row.Cells["colFare"]
                       .Value?.ToString() ?? "";

                string status =
                    row.Cells["colStatus"]
                        .Value?.ToString();

                if (!string.IsNullOrWhiteSpace(status))
                {
                    cmbStatus.SelectedItem = status;
                }
                else
                {
                    cmbStatus.SelectedIndex = -1;
                }

                txtRoute.Text =
                    row.Cells["colRoute"]
                       .Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load selected bus details.\n\n" +
                    ex.Message,
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // OLD DESIGNER EVENT COMPATIBILITY
        // =========================================================

        private void dgvMyBuses_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Designer may still be connected to CellContentClick.
            // Redirect it to the working CellClick handler.
            dgvMyBuses_CellClick(sender, e);
        }

        // =========================================================
        // CLEAR
        // =========================================================

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedBusID = 0;

            txtBusNumber.Clear();
            txtRoute.Clear();
            txtTotalSeats.Clear();
            txtFare.Clear();

            cmbBusType.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            dgvMyBuses.ClearSelection();
        }

        // =========================================================
        // VALIDATION
        // =========================================================

        private bool ValidateBusInput()
        {
            // -----------------------------------------------------
            // BUS NUMBER
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                txtBusNumber.Text))
            {
                MessageBox.Show(
                    "Please enter the bus number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBusNumber.Focus();
                return false;
            }

            // -----------------------------------------------------
            // BUS TYPE
            // -----------------------------------------------------

            if (cmbBusType.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a bus type.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbBusType.Focus();
                return false;
            }

            // -----------------------------------------------------
            // TOTAL SEATS
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                txtTotalSeats.Text))
            {
                MessageBox.Show(
                    "Please enter the total number of seats.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTotalSeats.Focus();
                return false;
            }

            int totalSeats;

            if (!int.TryParse(
                txtTotalSeats.Text.Trim(),
                out totalSeats))
            {
                MessageBox.Show(
                    "Total seats must be a valid number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTotalSeats.Focus();
                return false;
            }

            if (totalSeats <= 0)
            {
                MessageBox.Show(
                    "Total seats must be greater than 0.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTotalSeats.Focus();
                return false;
            }

            // -----------------------------------------------------
            // STATUS
            // -----------------------------------------------------

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select the bus status.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        // =========================================================
        // EXISTING DESIGNER EVENTS
        // =========================================================

        private void txtSearchBus_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblSearch_Click(
            object sender,
            EventArgs e)
        {
        }

        private void panelBusDetails_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void cmbStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblStatus_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtFare_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblFare_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtTotalSeats_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalSeats_Click(
            object sender,
            EventArgs e)
        {
        }

        private void cmbBusType_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblBusType_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtRoute_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblRoute_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtBusNumber_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblBusNumber_Click(
            object sender,
            EventArgs e)
        {
        }
    }


}
