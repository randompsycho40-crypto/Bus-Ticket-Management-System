using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class SearchBuses : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private readonly int customerID;
        private readonly string customerName;

        // =========================================================
        // CONSTRUCTORS
        // =========================================================

        public SearchBuses()
        {
            InitializeComponent();

            customerID = 0;
            customerName = "";
        }

        public SearchBuses(int customerID, string customerName)
        {
            InitializeComponent();

            this.customerID = customerID;
            this.customerName = customerName;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void SearchBuses_Load(object sender, EventArgs e)
        {
            txtFrom.Clear();
            txtTo.Clear();

            dptTravelDate.MinDate = DateTime.Today;
            dptTravelDate.Value = DateTime.Today;

            dgvBusResults.AutoGenerateColumns = false;
            dgvBusResults.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBusResults.MultiSelect = false;
            dgvBusResults.ReadOnly = true;

            colBusID.DataPropertyName = "BusID";
            colBusNumber.DataPropertyName = "BusNumber";
            colOperatorName.DataPropertyName = "OperatorName";
            colRoute.DataPropertyName = "Route";
            colDepartureTime.DataPropertyName = "DepartureTime";
            colArrivalTime.DataPropertyName = "ArrivalTime";
            colBusType.DataPropertyName = "BusType";
            colFare.DataPropertyName = "Fare";
            colAvailableSeats.DataPropertyName = "AvailableSeats";

            txtFrom.Focus();
        }

        // =========================================================
        // SEARCH BUTTON
        // =========================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string from = txtFrom.Text.Trim();
            string to = txtTo.Text.Trim();
            DateTime travelDate = dptTravelDate.Value.Date;

            if (string.IsNullOrWhiteSpace(from))
            {
                MessageBox.Show(
                    "Please enter the departure location.",
                    "Search Buses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFrom.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show(
                    "Please enter the destination.",
                    "Search Buses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTo.Focus();
                return;
            }

            if (travelDate < DateTime.Today)
            {
                MessageBox.Show(
                    "Please select today or a future date.",
                    "Search Buses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            SearchAvailableBuses(from, to, travelDate);
        }

        // =========================================================
        // SEARCH AVAILABLE BUSES
        // =========================================================

        private void SearchAvailableBuses(
            string from,
            string to,
            DateTime travelDate)
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT
                            s.ScheduleID,
                            b.BusID,
                            b.BusNumber,
                            ISNULL(
                                u.FullName,
                                'Unknown Operator'
                            ) AS OperatorName,

                            r.FromLocation + ' - ' +
                            r.ToLocation AS Route,

                            s.DepartureTime,
                            s.ArrivalTime,
                            b.BusType,
                            s.Fare,

                            (
                                SELECT COUNT(*)
                                FROM dbo.Seats st

                                WHERE st.BusID = b.BusID
                                  AND st.Status = 'Active'

                                  AND NOT EXISTS
                                  (
                                      SELECT 1
                                      FROM dbo.BookingSeats bs

                                      INNER JOIN dbo.Bookings bk
                                          ON bs.BookingID =
                                             bk.BookingID

                                      WHERE bs.SeatID = st.SeatID

                                        AND bk.ScheduleID =
                                            s.ScheduleID

                                        AND bk.BookingStatus <>
                                            'Cancelled'
                                  )
                            ) AS AvailableSeats

                        FROM dbo.Schedules s

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        LEFT JOIN dbo.Users u
                            ON b.OperatorID = u.UserID

                        WHERE r.FromLocation LIKE @From
                          AND r.ToLocation LIKE @To
                          AND s.TravelDate = @TravelDate

                        ORDER BY s.DepartureTime;";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@From",
                            "%" + from + "%");

                        cmd.Parameters.AddWithValue(
                            "@To",
                            "%" + to + "%");

                        cmd.Parameters.AddWithValue(
                            "@TravelDate",
                            travelDate);

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();

                            adapter.Fill(dt);

                            dgvBusResults.DataSource = null;
                            dgvBusResults.DataSource = dt;

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show(
                                    "No buses found for this route and date.",
                                    "Search Buses",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }
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
        // SELECT BUS
        // =========================================================

        private void dgvBusResults_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            OpenSelectedBus(e.RowIndex);
        }

        // =========================================================
        // OPEN SELECTED BUS
        // =========================================================

        private void OpenSelectedBus(int rowIndex)
        {
            if (rowIndex < 0)
                return;

            if (dgvBusResults.Rows.Count == 0)
                return;

            DataGridViewRow row =
                dgvBusResults.Rows[rowIndex];

            DataRowView data =
                row.DataBoundItem as DataRowView;

            if (data == null)
                return;

            try
            {
                int scheduleID =
                    Convert.ToInt32(
                        data["ScheduleID"]);

                int busID =
                    Convert.ToInt32(
                        data["BusID"]);

                decimal fare =
                    Convert.ToDecimal(
                        data["Fare"]);

                int availableSeats =
                    Convert.ToInt32(
                        data["AvailableSeats"]);

                if (customerID <= 0)
                {
                    MessageBox.Show(
                        "Customer information was not found. Please login again.",
                        "Customer Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (availableSeats <= 0)
                {
                    MessageBox.Show(
                        "No seats are available for this bus.",
                        "Seat Availability",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // =================================================
                // SEARCH BUS
                //       ↓
                // SEAT SELECTION
                // =================================================

                SeatSelection seatSelection =
                    new SeatSelection(
                        customerID,
                        customerName,
                        scheduleID,
                        busID,
                        fare);

                seatSelection.ShowDialog();

                // Refresh available seats after returning
                // from SeatSelection.
                RefreshCurrentSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open seat selection.\n\n" +
                    ex.Message,
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // REFRESH CURRENT SEARCH
        // =========================================================

        private void RefreshCurrentSearch()
        {
            string from =
                txtFrom.Text.Trim();

            string to =
                txtTo.Text.Trim();

            DateTime travelDate =
                dptTravelDate.Value.Date;

            if (!string.IsNullOrWhiteSpace(from) &&
                !string.IsNullOrWhiteSpace(to))
            {
                SearchAvailableBuses(
                    from,
                    to,
                    travelDate);
            }
        }

        // =========================================================
        // OTHER DESIGNER EVENTS
        // =========================================================

        private void lblPageTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblFrom_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtFrom_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblTo_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtTo_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblTravelDate_Click(
            object sender,
            EventArgs e)
        {
        }

        private void dptTravelDate_ValueChanged(
            object sender,
            EventArgs e)
        {
        }
    }
}