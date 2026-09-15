using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class CustomerDashboard : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private readonly int customerID;
        private readonly string customerName;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public CustomerDashboard(int customerID, string customerName)
        {
            InitializeComponent();

            this.customerID = customerID;
            this.customerName = customerName;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + customerName;

            LoadDashboardData();
            LoadRecentBookings();
        }

        // =========================================================
        // LOAD DASHBOARD DATA
        // =========================================================

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    con.Open();

                    // =================================================
                    // TOTAL BOOKINGS
                    // =================================================

                    string totalBookingsQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Bookings
                        WHERE CustomerID = @CustomerID
                          AND BookingStatus <> 'Cancelled';";

                    using (SqlCommand cmd =
                           new SqlCommand(totalBookingsQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        int totalBookings =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        lblTotalBookingsValue.Text =
                            totalBookings.ToString();
                    }

                    // =================================================
                    // UPCOMING TRIPS
                    // =================================================

                    string upcomingTripsQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Bookings b
                        INNER JOIN dbo.Schedules s
                            ON b.ScheduleID = s.ScheduleID
                        WHERE b.CustomerID = @CustomerID
                          AND b.BookingStatus <> 'Cancelled'
                          AND s.TravelDate >= CAST(GETDATE() AS DATE);";

                    using (SqlCommand cmd =
                           new SqlCommand(upcomingTripsQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        int upcomingTrips =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        lblUpcomingTripsValue.Text =
                            upcomingTrips.ToString();
                    }

                    // =================================================
                    // COMPLETED TRIPS
                    // =================================================

                    string completedTripsQuery = @"
                        SELECT COUNT(*)
                        FROM dbo.Bookings b
                        INNER JOIN dbo.Schedules s
                            ON b.ScheduleID = s.ScheduleID
                        WHERE b.CustomerID = @CustomerID
                          AND b.BookingStatus <> 'Cancelled'
                          AND s.TravelDate < CAST(GETDATE() AS DATE);";

                    using (SqlCommand cmd =
                           new SqlCommand(completedTripsQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        int completedTrips =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        lblCompletedTripsValue.Text =
                            completedTrips.ToString();
                    }

                    // =================================================
                    // TOTAL SPENT
                    // =================================================

                    string totalSpentQuery = @"
                        SELECT ISNULL(SUM(TotalAmount), 0)
                        FROM dbo.Bookings
                        WHERE CustomerID = @CustomerID
                          AND BookingStatus <> 'Cancelled'
                          AND PaymentStatus = 'Paid';";

                    using (SqlCommand cmd =
                           new SqlCommand(totalSpentQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        decimal totalSpent =
                            Convert.ToDecimal(cmd.ExecuteScalar());

                        lblTotalSpentValue.Text =
                            "৳ " + totalSpent.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load dashboard data.\n\n" +
                    ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD RECENT BOOKINGS
        // =========================================================

        private void LoadRecentBookings()
        {
            try
            {
                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT TOP 10
                            b.BookingID,
                            r.FromLocation + ' - ' +
                            r.ToLocation AS Route,
                            s.TravelDate,
                            b.TotalSeats,
                            b.TotalAmount,
                            b.BookingStatus

                        FROM dbo.Bookings b

                        INNER JOIN dbo.Schedules s
                            ON b.ScheduleID = s.ScheduleID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE b.CustomerID = @CustomerID

                        ORDER BY b.BookingDate DESC;";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        using (SqlDataAdapter adapter =
                               new SqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();

                            adapter.Fill(dt);

                            dgvRecentBookings.AutoGenerateColumns =
                                false;

                            colBookingID.DataPropertyName =
                                "BookingID";

                            colRoute.DataPropertyName =
                                "Route";

                            colTravelDate.DataPropertyName =
                                "TravelDate";

                            colSeats.DataPropertyName =
                                "TotalSeats";

                            colAmount.DataPropertyName =
                                "TotalAmount";

                            colBookingStatus.DataPropertyName =
                                "BookingStatus";

                            dgvRecentBookings.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load recent bookings.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DASHBOARD BUTTON
        // =========================================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            LoadRecentBookings();
        }

        // =========================================================
        // SEARCH BUSES
        // =========================================================

        private void btnSearchBuses_Click(object sender, EventArgs e)
        {
            SearchBuses searchBuses =
                new SearchBuses(
                    customerID,
                    customerName);

            searchBuses.ShowDialog();
        }

        // =========================================================
        // BOOK TICKET
        // =========================================================

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Please search for a bus first. You can select your seats and continue with the booking from there.",
                "Book Ticket",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // MY BOOKINGS
        // =========================================================

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "My Bookings module will be connected next.",
                "My Bookings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // PAYMENTS
        // =========================================================

        private void btnPayments_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Payments module will be connected after the booking module.",
                "Payments",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // LOG OUT
        // =========================================================

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to log out?",
                    "Log Out",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CustomerLogin login =
                    new CustomerLogin();

                login.Show();

                this.Close();
            }
        }

        // =========================================================
        // OTHER DESIGNER EVENTS
        // =========================================================

        private void panelContent_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void cardUpcomingTrips_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void cardCompletedTrips_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblTotalBookingsValue_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblUpcomingTripsTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblUpcomingTripsValue_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblCompletedTripsTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblCompletedTripsValue_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalBookingsTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void cardTotalBookings_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void cardTotalSpent_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblTotalSpentTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalSpentValue_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblRecentBookingsTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void dgvRecentBookings_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}