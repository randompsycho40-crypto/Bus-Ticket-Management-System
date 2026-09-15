using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class BookTicket : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private int customerID;
        private string customerName;

        private int scheduleID;
        private int busID;
        private decimal fare;

        private int totalSeats;
        private decimal totalAmount;

        private string selectedSeatNames = "";

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public BookTicket()
        {
            InitializeComponent();
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void BookTicket_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPendingBooking();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load booking information.\n\n" +
                    ex.Message,
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        // =========================================================
        // LOAD DATA FROM SEAT SELECTION
        // =========================================================

        private void LoadPendingBooking()
        {
            customerID =
                PendingBookingData.CustomerID;

            customerName =
                PendingBookingData.CustomerName;

            scheduleID =
                PendingBookingData.ScheduleID;

            busID =
                PendingBookingData.BusID;

            fare =
                PendingBookingData.Fare;

            totalSeats =
                PendingBookingData.TotalSeats;

            totalAmount =
                PendingBookingData.TotalAmount;

            // -----------------------------------------------------
            // Selected seats
            // -----------------------------------------------------

            if (PendingBookingData.SeatNumbers != null &&
                PendingBookingData.SeatNumbers.Count > 0)
            {
                selectedSeatNames =
                    string.Join(
                        ", ",
                        PendingBookingData.SeatNumbers);
            }
            else
            {
                selectedSeatNames = "None";
            }

            // -----------------------------------------------------
            // Configure controls
            // -----------------------------------------------------

            txtBusNumber.ReadOnly = true;
            txtRoute.ReadOnly = true;
            txtAvailableSeats.ReadOnly = true;
            txtDepartureTime.ReadOnly = true;
            txtTotalAmount.ReadOnly = true;

            dtpTravelTime.Enabled = false;
            nudSeats.Enabled = false;

            // -----------------------------------------------------
            // Load schedule information
            // -----------------------------------------------------

            LoadScheduleInformation();

            // -----------------------------------------------------
            // Display selected seat count
            // -----------------------------------------------------

            nudSeats.Minimum = 1;
            nudSeats.Maximum =
                Math.Max(1, totalSeats);

            nudSeats.Value =
                Math.Max(1, totalSeats);

            // -----------------------------------------------------
            // Show selected seats
            // -----------------------------------------------------

            txtAvailableSeats.Text =
                selectedSeatNames;

            // -----------------------------------------------------
            // Total amount
            // -----------------------------------------------------

            txtTotalAmount.Text =
                "৳" +
                totalAmount.ToString("N2");

            // -----------------------------------------------------
            // Enable Confirm button
            // -----------------------------------------------------

            btnConfirmBooking.Enabled =
                totalSeats > 0;
        }

        // =========================================================
        // LOAD SCHEDULE INFORMATION
        // =========================================================

        private void LoadScheduleInformation()
        {
            if (scheduleID <= 0)
            {
                MessageBox.Show(
                    "Schedule information is missing.",
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        s.TravelDate,
                        s.DepartureTime,
                        s.Fare,
                        b.BusNumber,
                        r.FromLocation,
                        r.ToLocation
                    FROM dbo.Schedules s

                    INNER JOIN dbo.Buses b
                        ON s.BusID = b.BusID

                    INNER JOIN dbo.Routes r
                        ON s.RouteID = r.RouteID

                    WHERE s.ScheduleID = @ScheduleID
                      AND s.BusID = @BusID;";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@ScheduleID",
                        scheduleID);

                    cmd.Parameters.AddWithValue(
                        "@BusID",
                        busID);

                    con.Open();

                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "Selected schedule could not be found.",
                                "Booking Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }

                        // Bus Number
                        txtBusNumber.Text =
                            reader["BusNumber"].ToString();

                        // Route
                        txtRoute.Text =
                            reader["FromLocation"].ToString()
                            + " - "
                            + reader["ToLocation"].ToString();

                        // Travel Date
                        DateTime travelDate =
                            Convert.ToDateTime(
                                reader["TravelDate"]);

                        dtpTravelTime.Value =
                            travelDate;

                        // Departure Time
                        TimeSpan departureTime =
                            (TimeSpan)reader["DepartureTime"];

                        txtDepartureTime.Text =
                            departureTime.ToString(
                                @"hh\:mm");

                        // Fare
                        fare =
                            Convert.ToDecimal(
                                reader["Fare"]);

                        // Recalculate total
                        totalAmount =
                            fare * totalSeats;

                        txtTotalAmount.Text =
                            "৳" +
                            totalAmount.ToString("N2");
                    }
                }
            }
        }

        // =========================================================
        // CONFIRM BOOKING → GO TO PAYMENT
        // =========================================================

        private void btnConfirmBooking_Click(
            object sender,
            EventArgs e)
        {
            if (customerID <= 0)
            {
                MessageBox.Show(
                    "Customer information is missing.",
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (scheduleID <= 0)
            {
                MessageBox.Show(
                    "Schedule information is missing.",
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (PendingBookingData.SeatIDs == null ||
                PendingBookingData.SeatIDs.Count == 0)
            {
                MessageBox.Show(
                    "No seats have been selected.",
                    "Booking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // -----------------------------------------------------
            // Final booking summary
            // -----------------------------------------------------

            DialogResult result =
                MessageBox.Show(
                    "Booking Summary\n\n" +
                    "Bus: " +
                    txtBusNumber.Text +
                    "\nRoute: " +
                    txtRoute.Text +
                    "\nTravel Date: " +
                    dtpTravelTime.Value.ToString(
                        "dd MMM yyyy") +
                    "\nDeparture: " +
                    txtDepartureTime.Text +
                    "\nSeats: " +
                    selectedSeatNames +
                    "\nTotal Seats: " +
                    totalSeats +
                    "\nTotal Amount: ৳" +
                    totalAmount.ToString("N2") +
                    "\n\nContinue to payment?",
                    "Confirm Booking",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            // -----------------------------------------------------
            // Make sure PendingBookingData contains latest values
            // -----------------------------------------------------

            PendingBookingData.CustomerID =
                customerID;

            PendingBookingData.CustomerName =
                customerName;

            PendingBookingData.ScheduleID =
                scheduleID;

            PendingBookingData.BusID =
                busID;

            PendingBookingData.Fare =
                fare;

            PendingBookingData.TotalSeats =
                totalSeats;

            PendingBookingData.TotalAmount =
                totalAmount;

            // -----------------------------------------------------
            // OPEN PAYMENT FORM
            // -----------------------------------------------------

            using (CutomerPayments paymentForm =
                new CutomerPayments(customerID))
            {
                paymentForm.ShowDialog();
            }

            // -----------------------------------------------------
            // After successful payment
            // -----------------------------------------------------

            if (PendingBookingData.ScheduleID == 0)
            {
                MessageBox.Show(
                    "Booking completed successfully.",
                    "Booking Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
        }

        // =========================================================
        // CANCEL
        // =========================================================

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        // =========================================================
        // OLD NUMERIC CONTROL EVENT
        // =========================================================

        private void nudSeats_ValueChanged(
            object sender,
            EventArgs e)
        {
            // Seat count comes directly from SeatSelection.
        }

        // =========================================================
        // DESIGNER EVENT HANDLERS
        // =========================================================

        private void lblPageTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void panelBookingDetails_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblBusNumber_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblRoute_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTravelDate_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblAvailableSeats_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblDepartureTime_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblSeats_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalAmount_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtBusNumber_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtRoute_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void dtpTravelTime_ValueChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtAvailableSeats_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtDepartureTime_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtTotalAmount_TextChanged(
            object sender,
            EventArgs e)
        {
        }
    }
}