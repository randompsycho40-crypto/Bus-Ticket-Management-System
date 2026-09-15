using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class Schedules : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private readonly int operatorID;

        private int selectedScheduleID = 0;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public Schedules(int operatorID)
        {
            InitializeComponent();

            this.operatorID = operatorID;

            // =====================================================
            // BUTTON EVENTS
            // =====================================================

            btnAddSchedule.Click -= btnAddSchedule_Click;
            btnAddSchedule.Click += btnAddSchedule_Click;

            btnEditSchedule.Click -= btnEditSchedule_Click;
            btnEditSchedule.Click += btnEditSchedule_Click;

            btnDeleteSchedule.Click -= btnDeleteSchedule_Click;
            btnDeleteSchedule.Click += btnDeleteSchedule_Click;

            btnShowSchedules.Click -= btnShowSchedules_Click;
            btnShowSchedules.Click += btnShowSchedules_Click;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            btnClear.Click -= btnClear_Click;
            btnClear.Click += btnClear_Click;

            // =====================================================
            // GRID ROW CLICK
            // =====================================================

            dgvSchedule.CellClick -= dgvSchedule_CellClick;
            dgvSchedule.CellClick += dgvSchedule_CellClick;

            // =====================================================
            // SEARCH ENTER
            // =====================================================

            txtSearchSchedule.KeyDown -= txtSearchSchedule_KeyDown;
            txtSearchSchedule.KeyDown += txtSearchSchedule_KeyDown;

            // =====================================================
            // STATUS COMBOBOX
            // =====================================================

            cmdStatus.Items.Clear();

            cmdStatus.Items.Add("Scheduled");
            cmdStatus.Items.Add("Completed");
            cmdStatus.Items.Add("Cancelled");

            cmdStatus.SelectedIndex = -1;

            // =====================================================
            // DATE / TIME PICKERS
            // =====================================================

            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;

            dtpArrivalTime.Format = DateTimePickerFormat.Time;
            dtpArrivalTime.ShowUpDown = true;

            dptDepartureDate.Format = DateTimePickerFormat.Short;

            // =====================================================
            // GRID SETTINGS
            // =====================================================

            dgvSchedule.AutoGenerateColumns = false;

            colScheduleID.DataPropertyName = "ScheduleID";
            colDepartureDate.DataPropertyName = "TravelDate";
            colDepartureTime.DataPropertyName = "DepartureTime";
            colArrivalTime.DataPropertyName = "ArrivalTime";
            colStatus.DataPropertyName = "Status";
            colBusNumber.DataPropertyName = "BusNumber";
            colRoute.DataPropertyName = "Route";

            // =====================================================
            // INITIAL LOAD
            // =====================================================

            LoadBusNumbers();
            LoadRoutes();
            LoadSchedules();

            ClearFields();
        }

        // =========================================================
        // LOAD BUS NUMBERS
        // =========================================================
        private void LoadBusNumbers()
        {
            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            BusID,
                            BusNumber
                        FROM dbo.Buses
                        WHERE OperatorID = @OperatorID
                        ORDER BY BusNumber;";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        using (SqlDataAdapter adapter =
                               new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            cmbBusNumber.DataSource = null;
                            cmbBusNumber.DataSource = table;

                            cmbBusNumber.DisplayMember = "BusNumber";
                            cmbBusNumber.ValueMember = "BusID";

                            cmbBusNumber.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load buses.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD ROUTES
        // =========================================================
        private void LoadRoutes()
        {
            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            RouteID,
                            FromLocation + ' → ' + ToLocation AS Route
                        FROM dbo.Routes
                        ORDER BY FromLocation, ToLocation;";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        cmbRoute.DataSource = null;
                        cmbRoute.DataSource = table;

                        cmbRoute.DisplayMember = "Route";
                        cmbRoute.ValueMember = "RouteID";

                        cmbRoute.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load routes.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD ALL SCHEDULES
        // =========================================================
        private void LoadSchedules()
        {
            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            s.ScheduleID,
                            s.TravelDate,

                            CONVERT(
                                VARCHAR(5),
                                s.DepartureTime,
                                108
                            ) AS DepartureTime,

                            CONVERT(
                                VARCHAR(5),
                                s.ArrivalTime,
                                108
                            ) AS ArrivalTime,

                            s.Status,

                            b.BusNumber,

                            r.FromLocation + ' → ' + r.ToLocation AS Route

                        FROM dbo.Schedules s

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE b.OperatorID = @OperatorID

                        ORDER BY
                            s.TravelDate DESC,
                            s.DepartureTime ASC;";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvSchedule.DataSource = null;
                        dgvSchedule.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load schedules.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ADD SCHEDULE
        // =========================================================
        private void btnAddSchedule_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                int busID =
                    Convert.ToInt32(cmbBusNumber.SelectedValue);

                int routeID =
                    Convert.ToInt32(cmbRoute.SelectedValue);

                DateTime travelDate =
                    dptDepartureDate.Value.Date;

                TimeSpan departureTime =
                    dateTimePicker1.Value.TimeOfDay;

                TimeSpan arrivalTime =
                    dtpArrivalTime.Value.TimeOfDay;

                string status =
                    cmdStatus.SelectedItem.ToString();

                if (arrivalTime <= departureTime)
                {
                    MessageBox.Show(
                        "Arrival Time must be later than Departure Time.",
                        "Invalid Time",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (ScheduleConflictExists(
                    busID,
                    travelDate,
                    departureTime,
                    arrivalTime,
                    0))
                {
                    MessageBox.Show(
                        "This bus already has a conflicting schedule on the selected date.",
                        "Schedule Conflict",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO dbo.Schedules
                        (
                            BusID,
                            RouteID,
                            TravelDate,
                            DepartureTime,
                            ArrivalTime,
                            Fare,
                            Status,
                            CreatedAt
                        )
                        SELECT
                            @BusID,
                            @RouteID,
                            @TravelDate,
                            @DepartureTime,
                            @ArrivalTime,
                            r.Fare,
                            @Status,
                            GETDATE()
                        FROM dbo.Routes r
                        WHERE r.RouteID = @RouteID;";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@BusID",
                            busID);

                        command.Parameters.AddWithValue(
                            "@RouteID",
                            routeID);

                        command.Parameters.AddWithValue(
                            "@TravelDate",
                            travelDate);

                        command.Parameters.AddWithValue(
                            "@DepartureTime",
                            departureTime);

                        command.Parameters.AddWithValue(
                            "@ArrivalTime",
                            arrivalTime);

                        command.Parameters.AddWithValue(
                            "@Status",
                            status);

                        connection.Open();

                        int rowsAffected =
                            command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Schedule added successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadSchedules();
                            ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to add schedule.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // EDIT SCHEDULE
        // =========================================================
        private void btnEditSchedule_Click(
            object sender,
            EventArgs e)
        {
            if (selectedScheduleID == 0)
            {
                MessageBox.Show(
                    "Please select a schedule from the table first.",
                    "Edit Schedule",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateFields())
                return;

            try
            {
                int busID =
                    Convert.ToInt32(cmbBusNumber.SelectedValue);

                int routeID =
                    Convert.ToInt32(cmbRoute.SelectedValue);

                DateTime travelDate =
                    dptDepartureDate.Value.Date;

                TimeSpan departureTime =
                    dateTimePicker1.Value.TimeOfDay;

                TimeSpan arrivalTime =
                    dtpArrivalTime.Value.TimeOfDay;

                string status =
                    cmdStatus.SelectedItem.ToString();

                if (arrivalTime <= departureTime)
                {
                    MessageBox.Show(
                        "Arrival Time must be later than Departure Time.",
                        "Invalid Time",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (ScheduleConflictExists(
                    busID,
                    travelDate,
                    departureTime,
                    arrivalTime,
                    selectedScheduleID))
                {
                    MessageBox.Show(
                        "This bus already has a conflicting schedule on the selected date.",
                        "Schedule Conflict",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE dbo.Schedules
                        SET
                            BusID = @BusID,
                            RouteID = @RouteID,
                            TravelDate = @TravelDate,
                            DepartureTime = @DepartureTime,
                            ArrivalTime = @ArrivalTime,
                            Fare =
                            (
                                SELECT Fare
                                FROM dbo.Routes
                                WHERE RouteID = @RouteID
                            ),
                            Status = @Status
                        WHERE ScheduleID = @ScheduleID;";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@BusID",
                            busID);

                        command.Parameters.AddWithValue(
                            "@RouteID",
                            routeID);

                        command.Parameters.AddWithValue(
                            "@TravelDate",
                            travelDate);

                        command.Parameters.AddWithValue(
                            "@DepartureTime",
                            departureTime);

                        command.Parameters.AddWithValue(
                            "@ArrivalTime",
                            arrivalTime);

                        command.Parameters.AddWithValue(
                            "@Status",
                            status);

                        command.Parameters.AddWithValue(
                            "@ScheduleID",
                            selectedScheduleID);

                        connection.Open();

                        int rowsAffected =
                            command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Schedule updated successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadSchedules();
                            ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to update schedule.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DELETE SCHEDULE
        // =========================================================
        private void btnDeleteSchedule_Click(
            object sender,
            EventArgs e)
        {
            if (selectedScheduleID == 0)
            {
                MessageBox.Show(
                    "Please select a schedule from the table first.",
                    "Delete Schedule",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this schedule?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        DELETE FROM dbo.Schedules
                        WHERE ScheduleID = @ScheduleID;";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@ScheduleID",
                            selectedScheduleID);

                        connection.Open();

                        int rowsAffected =
                            command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Schedule deleted successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadSchedules();
                            ClearFields();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "This schedule cannot be deleted because it is already being used by another record.\n\n" +
                    ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to delete schedule.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SHOW ALL SCHEDULES
        // =========================================================
        private void btnShowSchedules_Click(
            object sender,
            EventArgs e)
        {
            txtSearchSchedule.Clear();

            LoadSchedules();

            ClearFields();
        }

        // =========================================================
        // SEARCH BUTTON
        // =========================================================
        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            SearchSchedules();
        }

        // =========================================================
        // SEARCH BY ENTER
        // =========================================================
        private void txtSearchSchedule_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                SearchSchedules();
            }
        }

        // =========================================================
        // SEARCH SCHEDULES
        // =========================================================
        private void SearchSchedules()
        {
            string searchText =
                txtSearchSchedule.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadSchedules();
                return;
            }

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            s.ScheduleID,
                            s.TravelDate,

                            CONVERT(
                                VARCHAR(5),
                                s.DepartureTime,
                                108
                            ) AS DepartureTime,

                            CONVERT(
                                VARCHAR(5),
                                s.ArrivalTime,
                                108
                            ) AS ArrivalTime,

                            s.Status,

                            b.BusNumber,

                            r.FromLocation + ' → ' + r.ToLocation AS Route

                        FROM dbo.Schedules s

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE b.OperatorID = @OperatorID

                        AND
                        (
                            b.BusNumber LIKE @Search
                            OR r.FromLocation LIKE @Search
                            OR r.ToLocation LIKE @Search
                            OR s.Status LIKE @Search
                            OR CONVERT(
                                VARCHAR(10),
                                s.TravelDate,
                                23
                            ) LIKE @Search
                        )

                        ORDER BY
                            s.TravelDate DESC,
                            s.DepartureTime ASC;";

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        adapter.SelectCommand.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%");

                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvSchedule.DataSource = null;
                        dgvSchedule.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to search schedules.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // GRID ROW CLICK
        // =========================================================
        private void dgvSchedule_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvSchedule.Rows[e.RowIndex];

                // =================================================
                // SCHEDULE ID
                // =================================================
                object scheduleIDValue =
                    row.Cells["colScheduleID"].Value;

                if (scheduleIDValue == null ||
                    scheduleIDValue == DBNull.Value)
                {
                    return;
                }

                selectedScheduleID =
                    Convert.ToInt32(scheduleIDValue);

                // =================================================
                // BUS NUMBER
                // =================================================
                string busNumber =
                    Convert.ToString(
                        row.Cells["colBusNumber"].Value);

                cmbBusNumber.SelectedIndex = -1;

                if (!string.IsNullOrWhiteSpace(busNumber))
                {
                    for (int i = 0;
                         i < cmbBusNumber.Items.Count;
                         i++)
                    {
                        DataRowView item =
                            cmbBusNumber.Items[i] as DataRowView;

                        if (item != null &&
                            Convert.ToString(
                                item["BusNumber"]) == busNumber)
                        {
                            cmbBusNumber.SelectedIndex = i;
                            break;
                        }
                    }
                }

                // =================================================
                // ROUTE
                // =================================================
                string route =
                    Convert.ToString(
                        row.Cells["colRoute"].Value);

                cmbRoute.SelectedIndex = -1;

                if (!string.IsNullOrWhiteSpace(route))
                {
                    for (int i = 0;
                         i < cmbRoute.Items.Count;
                         i++)
                    {
                        DataRowView item =
                            cmbRoute.Items[i] as DataRowView;

                        if (item != null &&
                            Convert.ToString(
                                item["Route"]) == route)
                        {
                            cmbRoute.SelectedIndex = i;
                            break;
                        }
                    }
                }

                // =================================================
                // DATE
                // =================================================
                object dateValue =
                    row.Cells["colDepartureDate"].Value;

                if (dateValue != null &&
                    dateValue != DBNull.Value)
                {
                    DateTime travelDate;

                    if (DateTime.TryParse(
                        dateValue.ToString(),
                        out travelDate))
                    {
                        dptDepartureDate.Value =
                            travelDate;
                    }
                }

                // =================================================
                // DEPARTURE TIME
                // =================================================
                object departureValue =
                    row.Cells["colDepartureTime"].Value;

                if (departureValue != null &&
                    departureValue != DBNull.Value)
                {
                    TimeSpan departureTime =
                        GetTimeSpan(departureValue);

                    dateTimePicker1.Value =
                        DateTime.Today.Add(departureTime);
                }

                // =================================================
                // ARRIVAL TIME
                // =================================================
                object arrivalValue =
                    row.Cells["colArrivalTime"].Value;

                if (arrivalValue != null &&
                    arrivalValue != DBNull.Value)
                {
                    TimeSpan arrivalTime =
                        GetTimeSpan(arrivalValue);

                    dtpArrivalTime.Value =
                        DateTime.Today.Add(arrivalTime);
                }

                // =================================================
                // STATUS
                // =================================================
                string status =
                    Convert.ToString(
                        row.Cells["colStatus"].Value);

                cmdStatus.SelectedIndex = -1;

                if (!string.IsNullOrWhiteSpace(status))
                {
                    int statusIndex =
                        cmdStatus.Items.IndexOf(status);

                    if (statusIndex >= 0)
                    {
                        cmdStatus.SelectedIndex =
                            statusIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load schedule details.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DESIGNER COMPATIBILITY EVENT
        // =========================================================
        // Schedules.Designer.cs is still connected to this method.
        // Keep this method so CS1061 does not occur.
        // =========================================================
        private void dgvSchedule_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Forward the old Designer event
            // to the new row-click handler.
            dgvSchedule_CellClick(sender, e);
        }

        // =========================================================
        // CONVERT VALUE TO TIMESPAN
        // =========================================================
        private TimeSpan GetTimeSpan(object value)
        {
            if (value == null ||
                value == DBNull.Value)
            {
                return TimeSpan.Zero;
            }

            if (value is TimeSpan)
                return (TimeSpan)value;

            if (value is DateTime)
                return ((DateTime)value).TimeOfDay;

            TimeSpan result;

            if (TimeSpan.TryParse(
                value.ToString(),
                out result))
            {
                return result;
            }

            return TimeSpan.Zero;
        }

        // =========================================================
        // CLEAR BUTTON
        // =========================================================
        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        // =========================================================
        // CLEAR FIELDS
        // =========================================================
        private void ClearFields()
        {
            selectedScheduleID = 0;

            cmbBusNumber.SelectedIndex = -1;
            cmbRoute.SelectedIndex = -1;
            cmdStatus.SelectedIndex = -1;

            dptDepartureDate.Value =
                DateTime.Today;

            dateTimePicker1.Value =
                DateTime.Today.AddHours(8);

            dtpArrivalTime.Value =
                DateTime.Today.AddHours(14);

            if (dgvSchedule != null)
            {
                dgvSchedule.ClearSelection();
            }
        }

        // =========================================================
        // VALIDATE FIELDS
        // =========================================================
        private bool ValidateFields()
        {
            if (cmbBusNumber.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a bus.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cmbRoute.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a route.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cmdStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a schedule status.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // =========================================================
        // CHECK SCHEDULE CONFLICT
        // =========================================================
        private bool ScheduleConflictExists(
            int busID,
            DateTime travelDate,
            TimeSpan departureTime,
            TimeSpan arrivalTime,
            int scheduleID)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM dbo.Schedules
                    WHERE BusID = @BusID
                      AND TravelDate = @TravelDate
                      AND ScheduleID <> @ScheduleID
                      AND
                      (
                          @DepartureTime < ArrivalTime
                          AND
                          @ArrivalTime > DepartureTime
                      );";

                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@BusID",
                        busID);

                    command.Parameters.AddWithValue(
                        "@TravelDate",
                        travelDate);

                    command.Parameters.AddWithValue(
                        "@DepartureTime",
                        departureTime);

                    command.Parameters.AddWithValue(
                        "@ArrivalTime",
                        arrivalTime);

                    command.Parameters.AddWithValue(
                        "@ScheduleID",
                        scheduleID);

                    connection.Open();

                    int count =
                        Convert.ToInt32(
                            command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        // =========================================================
        // EXISTING DESIGNER EVENTS
        // =========================================================

        // 1. Search TextChanged
        private void txtSearchSchedule_TextChanged(
            object sender,
            EventArgs e)
        {
            // Search handled by Search button / Enter.
        }

        // 2. Form Load
        private void Schedules_Load(
            object sender,
            EventArgs e)
        {
            // Initial loading handled in constructor.
        }

        // 3. Search Panel Paint
        private void panelSearch_Paint(
            object sender,
            PaintEventArgs e)
        {
            // No custom painting required.
        }

        // 4. Date Label Click
        private void lbpdtDate_Click(
            object sender,
            EventArgs e)
        {
            // No action required.
        }

        // 5. Status Label Click
        private void lblStatus_Click(
            object sender,
            EventArgs e)
        {
            // No action required.
        }

        // 6. Search Label Click
        private void lblSeachSchedule_Click(
            object sender,
            EventArgs e)
        {
            // No action required.
        }

        // 7. Route Label Click
        private void lblRoute_Click(
            object sender,
            EventArgs e)
        {
            // No action required.
        }

        // 8. Departure Date Label Click
        private void lblDepartureDate_Click(
            object sender,
            EventArgs e)
        {
            // No action required.
        }

        // 9. Bus Number Label Click
        private void lblBusNumber_Click(
            object sender,
            EventArgs e)
        {
            // No action required.
        }

        // 10. Arrival Time Label Click
        private void lblArrivalTime_Click(
            object sender,
            EventArgs e)
        {
            // No action required.
        }

        // 11. Arrival Time Changed
        private void dtpArrivalTime_ValueChanged(
            object sender,
            EventArgs e)
        {
            // No additional action required.
        }

        // 12. Departure Date Changed
        private void dptDepartureDate_ValueChanged(
            object sender,
            EventArgs e)
        {
            // No additional action required.
        }

        // 13. Departure Time Changed
        private void dateTimePicker1_ValueChanged(
            object sender,
            EventArgs e)
        {
            // No additional action required.
        }

        // 14. Route Selection Changed
        private void cmbRoute_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // No additional action required.
        }

        // 15. Status Selection Changed
        private void cmdStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // No additional action required.
        }

        // 16. Bus Number Selection Changed
        private void cmbBusNumber_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // No additional action required.
        }
    }
}