using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class Bookings : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private readonly int operatorID;
        private int selectedBookingID = 0;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public Bookings(int operatorID)
        {
            InitializeComponent();

            this.operatorID = operatorID;

            // =====================================================
            // BUTTON EVENTS
            // =====================================================

            btnShowBookings.Click -= btnShowBookings_Click;
            btnShowBookings.Click += btnShowBookings_Click;

            btnViewDetails.Click -= btnViewDetails_Click;
            btnViewDetails.Click += btnViewDetails_Click;

            btnClear.Click -= btnClear_Click;
            btnClear.Click += btnClear_Click;

            btnClearr.Click -= btnClearr_Click;
            btnClearr.Click += btnClearr_Click;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            // =====================================================
            // SEARCH ENTER
            // =====================================================

            txtSearchBooking.KeyDown -= txtSearchBooking_KeyDown;
            txtSearchBooking.KeyDown += txtSearchBooking_KeyDown;

            // =====================================================
            // GRID
            // =====================================================

            // Use CellClick for reliable row selection
            dgvBookings.CellClick -= dgvBookings_CellClick;
            dgvBookings.CellClick += dgvBookings_CellClick;

            // =====================================================
            // BOOKING STATUS
            // =====================================================

            cmbBookingStatus.Items.Clear();

            cmbBookingStatus.Items.Add("Confirmed");
            cmbBookingStatus.Items.Add("Pending");
            cmbBookingStatus.Items.Add("Cancelled");

            cmbBookingStatus.SelectedIndex = -1;

            // =====================================================
            // GRID COLUMNS
            // =====================================================

            dgvBookings.AutoGenerateColumns = false;

            colBookingID.DataPropertyName = "BookingID";
            colCustomerName.DataPropertyName = "CustomerName";
            colBusNumber.DataPropertyName = "BusNumber";
            colRoute.DataPropertyName = "Route";
            colTravelDate.DataPropertyName = "TravelDate";
            colSeats.DataPropertyName = "TotalSeats";
            colAmount.DataPropertyName = "TotalAmount";
            colBookingStatus.DataPropertyName = "BookingStatus";

            // =====================================================
            // DETAILS ARE DISPLAY ONLY
            // =====================================================

            txtCustomerName.ReadOnly = true;
            txtTo.ReadOnly = true;
            txtRoute.ReadOnly = true;
            txtSeats.ReadOnly = true;
            txtAmount.ReadOnly = true;

            dptTravelTime.Enabled = false;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================
        private void Bookings_Load(
            object sender,
            EventArgs e)
        {
            ClearFields();
            LoadBookings();
        }

        // =========================================================
        // LOAD OPERATOR BOOKINGS
        // =========================================================
        private void LoadBookings()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            bk.BookingID,

                            u.FullName AS CustomerName,

                            b.BusNumber,

                            r.FromLocation + ' → ' +
                            r.ToLocation AS Route,

                            s.TravelDate,

                            bk.TotalSeats,

                            bk.TotalAmount,

                            bk.BookingStatus

                        FROM dbo.Bookings bk

                        INNER JOIN dbo.Customers c
                            ON bk.CustomerID = c.CustomerID

                        INNER JOIN dbo.Users u
                            ON c.UserID = u.UserID

                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE b.OperatorID = @OperatorID

                        ORDER BY
                            bk.BookingDate DESC,
                            bk.BookingID DESC;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            dgvBookings.DataSource = null;
                            dgvBookings.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load bookings.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SEARCH BUTTON
        // =========================================================
        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            SearchBookings();
        }

        // =========================================================
        // SEARCH ENTER
        // =========================================================
        private void txtSearchBooking_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                SearchBookings();
            }
        }

        // =========================================================
        // SEARCH BOOKINGS
        // =========================================================
        private void SearchBookings()
        {
            string searchText =
                txtSearchBooking.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadBookings();
                ClearFields();
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            bk.BookingID,

                            u.FullName AS CustomerName,

                            b.BusNumber,

                            r.FromLocation + ' → ' +
                            r.ToLocation AS Route,

                            s.TravelDate,

                            bk.TotalSeats,

                            bk.TotalAmount,

                            bk.BookingStatus

                        FROM dbo.Bookings bk

                        INNER JOIN dbo.Customers c
                            ON bk.CustomerID = c.CustomerID

                        INNER JOIN dbo.Users u
                            ON c.UserID = u.UserID

                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE
                            b.OperatorID = @OperatorID

                            AND
                            (
                                u.FullName LIKE @Search

                                OR b.BusNumber LIKE @Search

                                OR r.FromLocation LIKE @Search

                                OR r.ToLocation LIKE @Search

                                OR bk.BookingStatus LIKE @Search

                                OR CONVERT(
                                    VARCHAR(20),
                                    s.TravelDate,
                                    23
                                ) LIKE @Search

                                OR CONVERT(
                                    VARCHAR(20),
                                    bk.BookingID
                                ) LIKE @Search
                            )

                        ORDER BY
                            bk.BookingDate DESC,
                            bk.BookingID DESC;";

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

                            dgvBookings.DataSource = null;
                            dgvBookings.DataSource = table;
                        }
                    }
                }

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search bookings.\n\n" +
                    ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SHOW ALL BOOKINGS
        // =========================================================
        private void btnShowBookings_Click(
            object sender,
            EventArgs e)
        {
            txtSearchBooking.Clear();

            LoadBookings();
            ClearFields();
        }

        // =========================================================
        // GRID CELL CLICK
        // =========================================================
        private void dgvBookings_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvBookings.Rows[e.RowIndex];

                object bookingIDValue =
                    row.Cells["colBookingID"].Value;

                if (bookingIDValue == null ||
                    bookingIDValue == DBNull.Value)
                {
                    return;
                }

                selectedBookingID =
                    Convert.ToInt32(bookingIDValue);

                LoadBookingDetails(
                    selectedBookingID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to select booking.\n\n" +
                    ex.Message,
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // OLD DESIGNER EVENT COMPATIBILITY
        // =========================================================
        // Your Designer may still contain
        // dgvBookings_CellContentClick.
        //
        // Keep this method so CS1061 does not happen.
        // =========================================================
        private void dgvBookings_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            dgvBookings_CellClick(sender, e);
        }

        // =========================================================
        // LOAD SELECTED BOOKING DETAILS
        // =========================================================
        private void LoadBookingDetails(
            int bookingID)
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            bk.BookingID,

                            u.FullName AS CustomerName,

                            b.BusNumber,

                            r.FromLocation + ' → ' +
                            r.ToLocation AS Route,

                            s.TravelDate,

                            s.DepartureTime,

                            s.ArrivalTime,

                            bk.TotalSeats,

                            bk.TotalAmount,

                            bk.BookingStatus

                        FROM dbo.Bookings bk

                        INNER JOIN dbo.Customers c
                            ON bk.CustomerID = c.CustomerID

                        INNER JOIN dbo.Users u
                            ON c.UserID = u.UserID

                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE
                            bk.BookingID = @BookingID

                            AND b.OperatorID = @OperatorID;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@BookingID",
                            bookingID);

                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        con.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // =================================
                                // CUSTOMER
                                // =================================

                                txtCustomerName.Text =
                                    reader["CustomerName"]
                                    .ToString();

                                // =================================
                                // BUS NUMBER
                                // =================================

                                txtTo.Text =
                                    reader["BusNumber"]
                                    .ToString();

                                // =================================
                                // ROUTE
                                // =================================

                                txtRoute.Text =
                                    reader["Route"]
                                    .ToString();

                                // =================================
                                // SEATS
                                // =================================

                                txtSeats.Text =
                                    reader["TotalSeats"]
                                    .ToString();

                                // =================================
                                // AMOUNT
                                // =================================

                                if (reader["TotalAmount"] !=
                                    DBNull.Value)
                                {
                                    txtAmount.Text =
                                        Convert.ToDecimal(
                                            reader["TotalAmount"])
                                        .ToString("0.00");
                                }
                                else
                                {
                                    txtAmount.Clear();
                                }

                                // =================================
                                // TRAVEL DATE
                                // =================================

                                if (reader["TravelDate"] !=
                                    DBNull.Value)
                                {
                                    dptTravelTime.Value =
                                        Convert.ToDateTime(
                                            reader["TravelDate"]);
                                }

                                // =================================
                                // BOOKING STATUS
                                // =================================

                                string status =
                                    reader["BookingStatus"]
                                    .ToString();

                                cmbBookingStatus.SelectedIndex =
                                    -1;

                                int statusIndex =
                                    cmbBookingStatus.Items.IndexOf(
                                        status);

                                if (statusIndex >= 0)
                                {
                                    cmbBookingStatus.SelectedIndex =
                                        statusIndex;
                                }
                            }
                            else
                            {
                                ClearFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load booking details.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // VIEW DETAILS BUTTON
        // =========================================================
        private void btnViewDetails_Click(
            object sender,
            EventArgs e)
        {
            int bookingID = 0;

            // First use selected row
            if (dgvBookings.SelectedRows.Count > 0)
            {
                object value =
                    dgvBookings.SelectedRows[0]
                    .Cells["colBookingID"].Value;

                if (value != null &&
                    value != DBNull.Value)
                {
                    bookingID =
                        Convert.ToInt32(value);
                }
            }
            // Otherwise use current cell
            else if (dgvBookings.CurrentCell != null)
            {
                int rowIndex =
                    dgvBookings.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    object value =
                        dgvBookings.Rows[rowIndex]
                        .Cells["colBookingID"].Value;

                    if (value != null &&
                        value != DBNull.Value)
                    {
                        bookingID =
                            Convert.ToInt32(value);
                    }
                }
            }

            // Last fallback
            if (bookingID == 0)
            {
                bookingID =
                    selectedBookingID;
            }

            if (bookingID == 0)
            {
                MessageBox.Show(
                    "Please select a booking from the table.",
                    "No Booking Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            selectedBookingID = bookingID;

            LoadBookingDetails(
                bookingID);
        }

        // =========================================================
        // BOOKING STATUS CHANGED
        // =========================================================
        private void cmbBookingStatus_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // Do not automatically update database here.
            // Status update remains controlled.
        }

        // =========================================================
        // UPDATE BOOKING STATUS
        // =========================================================
        private void UpdateBookingStatus()
        {
            if (selectedBookingID == 0)
                return;

            if (cmbBookingStatus.SelectedIndex == -1)
                return;

            try
            {
                string newStatus =
                    cmbBookingStatus.SelectedItem.ToString();

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE bk
                        SET
                            bk.BookingStatus = @BookingStatus

                        FROM dbo.Bookings bk

                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        WHERE
                            bk.BookingID = @BookingID

                            AND b.OperatorID = @OperatorID;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@BookingStatus",
                            newStatus);

                        cmd.Parameters.AddWithValue(
                            "@BookingID",
                            selectedBookingID);

                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update booking status.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
        // SECOND CLEAR BUTTON
        // =========================================================
        private void btnClearr_Click(
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
            selectedBookingID = 0;

            txtCustomerName.Clear();
            txtTo.Clear();
            txtRoute.Clear();
            txtSeats.Clear();
            txtAmount.Clear();

            dptTravelTime.Value =
                DateTime.Today;

            cmbBookingStatus.SelectedIndex = -1;

            if (dgvBookings != null)
            {
                dgvBookings.ClearSelection();
            }
        }

        // =========================================================
        // EXISTING DESIGNER EVENTS
        // =========================================================

        private void panelHeader_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblSearchBooking_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtSearchBooking_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void panelRouteDetails_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void txtAmount_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void dptTravelTime_ValueChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblBookingStatus_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtSeats_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblSeats_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTravelTime_Click(
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

        private void txtTo_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblBusNumber_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtCustomerName_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblCustomerName_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblAmount_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}