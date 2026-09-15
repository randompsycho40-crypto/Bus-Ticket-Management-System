using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class ManageBuses : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private int selectedBusID = 0;

        public ManageBuses()
        {
            InitializeComponent();

            // Existing Designer columns will be used
            dgvBuses.AutoGenerateColumns = false;

            // Make sure button events are connected
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

            dgvBuses.CellClick -= dgvBuses_CellClick;
            dgvBuses.CellClick += dgvBuses_CellClick;

            cmbStatus.SelectedIndex = 0;

            LoadBuses();
        }

        // =========================================================
        // LOAD ALL BUSES
        // =========================================================

        private void LoadBuses()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            b.BusID,
                            b.BusNumber,
                            ISNULL(
                                NULLIF(u.FullName, ''),
                                o.CompanyName
                            ) AS OperatorName,

                            ISNULL(
                                r.FromLocation + ' - ' + r.ToLocation,
                                'No Route Assigned'
                            ) AS Route,

                            b.BusType,
                            b.TotalSeats,

                            ISNULL(
                                (
                                    SELECT TOP 1 s.Fare
                                    FROM dbo.Schedules s
                                    WHERE s.BusID = b.BusID
                                    ORDER BY s.TravelDate DESC, s.ScheduleID DESC
                                ),
                                0
                            ) AS Fare,

                            b.Status

                        FROM dbo.Buses b

                        INNER JOIN dbo.Operators o
                            ON b.OperatorID = o.OperatorID

                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID

                        OUTER APPLY
                        (
                            SELECT TOP 1
                                s.RouteID
                            FROM dbo.Schedules s
                            WHERE s.BusID = b.BusID
                            ORDER BY s.TravelDate DESC, s.ScheduleID DESC
                        ) latestSchedule

                        LEFT JOIN dbo.Routes r
                            ON latestSchedule.RouteID = r.RouteID

                        ORDER BY b.BusID DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvBuses.DataSource = null;
                        dgvBuses.DataSource = table;
                    }
                }

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading buses:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // FORMAT EXISTING GRID COLUMNS
        // =========================================================

        private void FormatGrid()
        {
            if (dgvBuses.Columns.Count < 8)
                return;

            colBusID.DataPropertyName = "BusID";
            colBusNumber.DataPropertyName = "BusNumber";
            colOperatorName.DataPropertyName = "OperatorName";
            colRoute.DataPropertyName = "Route";
            colBusType.DataPropertyName = "BusType";
            colTotalSeats.DataPropertyName = "TotalSeats";
            colFare.DataPropertyName = "Fare";
            colStatus.DataPropertyName = "Status";

            colBusID.HeaderText = "Bus ID";
            colBusNumber.HeaderText = "Bus Number";
            colOperatorName.HeaderText = "Operator Name";
            colRoute.HeaderText = "Route";
            colBusType.HeaderText = "Bus Type";
            colTotalSeats.HeaderText = "Total Seats";
            colFare.HeaderText = "Fare";
            colStatus.HeaderText = "Status";
        }

        // =========================================================
        // ADD BUS
        // =========================================================

        private void btnAddBus_Click(object sender, EventArgs e)
        {
            if (!ValidateBusInput())
                return;

            int operatorID = GetOperatorID(txtOperatorName.Text.Trim());

            if (operatorID == 0)
            {
                MessageBox.Show(
                    "Operator not found.\n\nPlease enter the Operator Name exactly as it exists in the Operators table.",
                    "Invalid Operator",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(txtTotalSeats.Text.Trim(), out int totalSeats))
            {
                MessageBox.Show(
                    "Total Seats must be a valid number.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Check duplicate bus number
                    string duplicateQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Buses
                        WHERE BusNumber = @BusNumber";

                    using (SqlCommand duplicateCmd =
                           new SqlCommand(duplicateQuery, con))
                    {
                        duplicateCmd.Parameters.AddWithValue(
                            "@BusNumber",
                            txtBusNumber.Text.Trim());

                        int count = Convert.ToInt32(duplicateCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "This Bus Number already exists.",
                                "Duplicate Bus",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    // Insert Bus
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
                        );

                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int newBusID;

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
                            txtBusType.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@TotalSeats",
                            totalSeats);

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.Text.Trim());

                        newBusID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Create basic seats for the new bus
                    CreateSeats(con, newBusID, totalSeats);

                    MessageBox.Show(
                        "Bus added successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                LoadBuses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding bus:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // GET OPERATOR ID
        // =========================================================

        private int GetOperatorID(string operatorName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT TOP 1 o.OperatorID
                        FROM dbo.Operators o
                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID
                        WHERE
                            o.CompanyName = @Name
                            OR u.FullName = @Name";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", operatorName);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            return Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                return 0;
            }

            return 0;
        }

        // =========================================================
        // CREATE SEATS
        // =========================================================

        private void CreateSeats(
            SqlConnection con,
            int busID,
            int totalSeats)
        {
            int columns = 4;
            int rows = (int)Math.Ceiling(totalSeats / 4.0);

            int seatCounter = 0;

            for (int row = 1; row <= rows; row++)
            {
                for (int column = 1; column <= columns; column++)
                {
                    if (seatCounter >= totalSeats)
                        break;

                    seatCounter++;

                    string columnLetter =
                        ((char)('A' + column - 1)).ToString();

                    string seatNumber =
                        row.ToString() + columnLetter;

                    string query = @"
                        INSERT INTO dbo.Seats
                        (
                            BusID,
                            SeatNumber,
                            SeatType,
                            RowNumber,
                            ColumnNumber,
                            Deck,
                            Status
                        )
                        VALUES
                        (
                            @BusID,
                            @SeatNumber,
                            'Regular',
                            @RowNumber,
                            @ColumnNumber,
                            'Lower',
                            'Active'
                        )";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BusID", busID);
                        cmd.Parameters.AddWithValue("@SeatNumber", seatNumber);
                        cmd.Parameters.AddWithValue("@RowNumber", row);
                        cmd.Parameters.AddWithValue("@ColumnNumber", column);

                        cmd.ExecuteNonQuery();
                    }
                }
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
                    "Select Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateBusInput())
                return;

            int operatorID = GetOperatorID(txtOperatorName.Text.Trim());

            if (operatorID == 0)
            {
                MessageBox.Show(
                    "Operator not found.",
                    "Invalid Operator",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(txtTotalSeats.Text.Trim(), out int totalSeats))
            {
                MessageBox.Show(
                    "Total Seats must be a valid number.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        UPDATE dbo.Buses
                        SET
                            OperatorID = @OperatorID,
                            BusNumber = @BusNumber,
                            BusType = @BusType,
                            TotalSeats = @TotalSeats,
                            Status = @Status
                        WHERE BusID = @BusID";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        cmd.Parameters.AddWithValue(
                            "@BusNumber",
                            txtBusNumber.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@BusType",
                            txtBusType.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@TotalSeats",
                            totalSeats);

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@BusID",
                            selectedBusID);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Bus updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadBuses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating bus:\n" + ex.Message,
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
                    "Please select a bus first.",
                    "Select Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this bus?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // First delete seats belonging to this bus
                    string deleteSeatsQuery = @"
                        DELETE FROM dbo.Seats
                        WHERE BusID = @BusID";

                    using (SqlCommand seatCmd =
                           new SqlCommand(deleteSeatsQuery, con))
                    {
                        seatCmd.Parameters.AddWithValue(
                            "@BusID",
                            selectedBusID);

                        seatCmd.ExecuteNonQuery();
                    }

                    // Delete bus
                    string deleteBusQuery = @"
                        DELETE FROM dbo.Buses
                        WHERE BusID = @BusID";

                    using (SqlCommand busCmd =
                           new SqlCommand(deleteBusQuery, con))
                    {
                        busCmd.Parameters.AddWithValue(
                            "@BusID",
                            selectedBusID);

                        busCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Bus deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadBuses();
                ClearFields();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "This bus cannot be deleted because it is already connected to schedules, bookings, or other records.\n\nYou should set its Status to Inactive instead.",
                        "Bus In Use",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Database error:\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting bus:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SHOW BUSES
        // =========================================================

        private void btnShowBuses_Click(object sender, EventArgs e)
        {
            LoadBuses();
            ClearFields();
        }

        // =========================================================
        // SEARCH
        // =========================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchBus.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadBuses();
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            b.BusID,
                            b.BusNumber,
                            ISNULL(
                                NULLIF(u.FullName, ''),
                                o.CompanyName
                            ) AS OperatorName,

                            ISNULL(
                                r.FromLocation + ' - ' + r.ToLocation,
                                'No Route Assigned'
                            ) AS Route,

                            b.BusType,
                            b.TotalSeats,

                            ISNULL(
                                (
                                    SELECT TOP 1 s.Fare
                                    FROM dbo.Schedules s
                                    WHERE s.BusID = b.BusID
                                    ORDER BY s.TravelDate DESC, s.ScheduleID DESC
                                ),
                                0
                            ) AS Fare,

                            b.Status

                        FROM dbo.Buses b

                        INNER JOIN dbo.Operators o
                            ON b.OperatorID = o.OperatorID

                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID

                        OUTER APPLY
                        (
                            SELECT TOP 1
                                s.RouteID
                            FROM dbo.Schedules s
                            WHERE s.BusID = b.BusID
                            ORDER BY s.TravelDate DESC, s.ScheduleID DESC
                        ) latestSchedule

                        LEFT JOIN dbo.Routes r
                            ON latestSchedule.RouteID = r.RouteID

                        WHERE
                            b.BusNumber LIKE @Search
                            OR b.BusType LIKE @Search
                            OR b.Status LIKE @Search
                            OR o.CompanyName LIKE @Search
                            OR u.FullName LIKE @Search
                            OR r.FromLocation LIKE @Search
                            OR r.ToLocation LIKE @Search

                        ORDER BY b.BusID DESC";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%");

                        using (SqlDataAdapter adapter =
                               new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            dgvBuses.DataSource = null;
                            dgvBuses.DataSource = table;
                        }
                    }
                }

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error searching buses:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // GRID ROW CLICK
        // =========================================================

        private void dgvBuses_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvBuses.Rows[e.RowIndex];

            if (row.Cells["colBusID"].Value == null)
                return;

            selectedBusID =
                Convert.ToInt32(row.Cells["colBusID"].Value);

            txtBusNumber.Text =
                Convert.ToString(row.Cells["colBusNumber"].Value);

            txtOperatorName.Text =
                Convert.ToString(row.Cells["colOperatorName"].Value);

            txtRoute.Text =
                Convert.ToString(row.Cells["colRoute"].Value);

            txtBusType.Text =
                Convert.ToString(row.Cells["colBusType"].Value);

            txtTotalSeats.Text =
                Convert.ToString(row.Cells["colTotalSeats"].Value);

            txtFare.Text =
                Convert.ToString(row.Cells["colFare"].Value);

            cmbStatus.Text =
                Convert.ToString(row.Cells["colStatus"].Value);
        }

        // =========================================================
        // CLEAR
        // =========================================================

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedBusID = 0;

            txtBusNumber.Clear();
            txtOperatorName.Clear();
            txtRoute.Clear();
            txtBusType.Clear();
            txtTotalSeats.Clear();
            txtFare.Clear();
            txtSearchBus.Clear();

            cmbStatus.SelectedIndex = 0;

            dgvBuses.ClearSelection();
        }

        // =========================================================
        // VALIDATION
        // =========================================================

        private bool ValidateBusInput()
        {
            if (string.IsNullOrWhiteSpace(txtBusNumber.Text))
            {
                MessageBox.Show(
                    "Please enter Bus Number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBusNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOperatorName.Text))
            {
                MessageBox.Show(
                    "Please enter Operator Name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtOperatorName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBusType.Text))
            {
                MessageBox.Show(
                    "Please enter Bus Type.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBusType.Focus();
                return false;
            }

            string busType =
                txtBusType.Text.Trim();

            if (busType != "AC" &&
                busType != "Non-AC" &&
                busType != "Sleeper")
            {
                MessageBox.Show(
                    "Bus Type must be one of:\n\nAC\nNon-AC\nSleeper",
                    "Invalid Bus Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBusType.Focus();
                return false;
            }

            if (!int.TryParse(
                    txtTotalSeats.Text.Trim(),
                    out int totalSeats) ||
                totalSeats <= 0)
            {
                MessageBox.Show(
                    "Total Seats must be a positive number.",
                    "Invalid Total Seats",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTotalSeats.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show(
                    "Please select Status.",
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

        private void txtBusType_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblPageTitle_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}
