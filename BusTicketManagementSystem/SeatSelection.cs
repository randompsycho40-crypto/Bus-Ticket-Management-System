using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class SeatSelection : Form
    {
        private readonly int customerID;
        private readonly string customerName;
        private readonly int scheduleID;
        private readonly int busID;
        private readonly decimal fare;

        private List<SeatInfo> selectedSeats =
            new List<SeatInfo>();

        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public SeatSelection(
            int customerID,
            string customerName,
            int scheduleID,
            int busID,
            decimal fare)
        {
            InitializeComponent();

            this.customerID = customerID;
            this.customerName = customerName;
            this.scheduleID = scheduleID;
            this.busID = busID;
            this.fare = fare;
        }


        // =========================================================
        // FORM LOAD
        // =========================================================

        private void SeatSelection_Load(object sender, EventArgs e)
        {
            try
            {
                lblSelectedSeats.Text = "None";
                lblTotalAmount.Text = "৳0.00";

                LoadBusInformation();
                LoadSeats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load seat selection.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // LOAD BUS INFORMATION
        // =========================================================

        private void LoadBusInformation()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        b.BusNumber,
                        r.FromLocation,
                        r.ToLocation,
                        s.TravelDate,
                        s.Fare
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
                        if (reader.Read())
                        {
                            lblBusNumber.Text =
                                reader["BusNumber"].ToString();

                            lblRoute.Text =
                                reader["FromLocation"].ToString()
                                + " - " +
                                reader["ToLocation"].ToString();

                            DateTime travelDate =
                                Convert.ToDateTime(
                                    reader["TravelDate"]);

                            lblTravelDate.Text =
                                travelDate.ToString(
                                    "dd MMM yyyy");

                            decimal scheduleFare =
                                Convert.ToDecimal(
                                    reader["Fare"]);

                            lblFare.Text =
                                "৳" +
                                scheduleFare.ToString("N2");
                        }
                    }
                }
            }
        }


        // =========================================================
        // LOAD SEATS
        // =========================================================

        private void LoadSeats()
        {
            flpSeats.Controls.Clear();
            selectedSeats.Clear();

            string query = @"
                SELECT
                    st.SeatID,
                    st.SeatNumber,
                    st.RowNumber,
                    st.ColumnNumber,

                    CASE
                        WHEN EXISTS
                        (
                            SELECT 1
                            FROM dbo.BookingSeats bs
                            INNER JOIN dbo.Bookings bk
                                ON bs.BookingID = bk.BookingID
                            WHERE bs.SeatID = st.SeatID
                              AND bk.ScheduleID = @ScheduleID
                              AND bk.BookingStatus <> 'Cancelled'
                        )
                        THEN 1
                        ELSE 0
                    END AS IsBooked

                FROM dbo.Seats st

                WHERE st.BusID = @BusID
                  AND st.Status = 'Active'

                ORDER BY
                    st.RowNumber,
                    st.ColumnNumber;";

            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
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
                        while (reader.Read())
                        {
                            int seatID =
                                Convert.ToInt32(
                                    reader["SeatID"]);

                            string seatNumber =
                                reader["SeatNumber"].ToString();

                            int rowNumber =
                                Convert.ToInt32(
                                    reader["RowNumber"]);

                            int columnNumber =
                                Convert.ToInt32(
                                    reader["ColumnNumber"]);

                            bool isBooked =
                                Convert.ToInt32(
                                    reader["IsBooked"]) == 1;

                            CreateSeatButton(
                                seatID,
                                seatNumber,
                                rowNumber,
                                columnNumber,
                                isBooked);
                        }
                    }
                }
            }
        }


        // =========================================================
        // CREATE SEAT BUTTON
        // =========================================================

        private void CreateSeatButton(
            int seatID,
            string seatNumber,
            int rowNumber,
            int columnNumber,
            bool isBooked)
        {
            Button seatButton = new Button();

            seatButton.Width = 70;
            seatButton.Height = 45;

            seatButton.Margin =
                new Padding(8);

            seatButton.Text =
                seatNumber;

            seatButton.Tag =
                new SeatInfo
                {
                    SeatID = seatID,
                    SeatNumber = seatNumber,
                    RowNumber = rowNumber,
                    ColumnNumber = columnNumber,
                    IsBooked = isBooked
                };

            if (isBooked)
            {
                seatButton.Enabled = false;

                seatButton.Text =
                    seatNumber + "\nBooked";
            }
            else
            {
                seatButton.Click +=
                    SeatButton_Click;
            }

            flpSeats.Controls.Add(
                seatButton);
        }


        // =========================================================
        // SEAT BUTTON CLICK
        // =========================================================

        private void SeatButton_Click(
            object sender,
            EventArgs e)
        {
            Button clickedButton =
                sender as Button;

            if (clickedButton == null)
                return;

            SeatInfo seat =
                clickedButton.Tag as SeatInfo;

            if (seat == null)
                return;

            bool alreadySelected =
                selectedSeats.Exists(
                    x => x.SeatID == seat.SeatID);

            if (alreadySelected)
            {
                selectedSeats.RemoveAll(
                    x => x.SeatID == seat.SeatID);

                clickedButton.Text =
                    seat.SeatNumber;
            }
            else
            {
                selectedSeats.Add(seat);

                clickedButton.Text =
                    seat.SeatNumber +
                    "\nSelected";
            }

            UpdateSelectionSummary();
        }


        // =========================================================
        // UPDATE SELECTION SUMMARY
        // =========================================================

        private void UpdateSelectionSummary()
        {
            if (selectedSeats.Count == 0)
            {
                lblSelectedSeats.Text =
                    "None";

                lblTotalAmount.Text =
                    "৳0.00";

                return;
            }

            List<string> seatNumbers =
                new List<string>();

            foreach (SeatInfo seat in selectedSeats)
            {
                seatNumbers.Add(
                    seat.SeatNumber);
            }

            seatNumbers.Sort();

            lblSelectedSeats.Text =
                string.Join(
                    ", ",
                    seatNumbers);

            decimal totalAmount =
                selectedSeats.Count * fare;

            lblTotalAmount.Text =
                "৳" +
                totalAmount.ToString("N2");
        }


        // =========================================================
        // CONTINUE
        // =========================================================

        private void btnConfirm_Click(
            object sender,
            EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show(
                    "Please select at least one seat.",
                    "No Seat Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Recheck seats before continuing
            if (!CheckSeatsStillAvailable())
                return;

            List<string> seatNumbers =
                new List<string>();

            List<int> seatIDs =
                new List<int>();

            foreach (SeatInfo seat in selectedSeats)
            {
                seatNumbers.Add(seat.SeatNumber);
                seatIDs.Add(seat.SeatID);
            }

            seatNumbers.Sort();

            decimal totalAmount =
                selectedSeats.Count * fare;

            // Store selected booking information
            // for the next BookTicket screen.
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

            PendingBookingData.SeatIDs =
                seatIDs;

            PendingBookingData.SeatNumbers =
                seatNumbers;

            PendingBookingData.TotalSeats =
                selectedSeats.Count;

            PendingBookingData.TotalAmount =
                totalAmount;


            // Open Booking Summary
            BookTicket bookTicket =
                new BookTicket();

            bookTicket.ShowDialog();

            // Refresh seats after returning
            LoadSeats();
            UpdateSelectionSummary();
        }


        // =========================================================
        // CHECK SEATS STILL AVAILABLE
        // =========================================================

        private bool CheckSeatsStillAvailable()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    foreach (SeatInfo seat in selectedSeats)
                    {
                        string query = @"
                            SELECT COUNT(*)
                            FROM dbo.BookingSeats bs
                            INNER JOIN dbo.Bookings bk
                                ON bs.BookingID = bk.BookingID
                            WHERE bs.SeatID = @SeatID
                              AND bk.ScheduleID = @ScheduleID
                              AND bk.BookingStatus <> 'Cancelled';";

                        using (SqlCommand cmd =
                            new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@SeatID",
                                seat.SeatID);

                            cmd.Parameters.AddWithValue(
                                "@ScheduleID",
                                scheduleID);

                            int booked =
                                Convert.ToInt32(
                                    cmd.ExecuteScalar());

                            if (booked > 0)
                            {
                                MessageBox.Show(
                                    "Seat " +
                                    seat.SeatNumber +
                                    " has already been booked.\n\n" +
                                    "Please select another seat.",
                                    "Seat Unavailable",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                LoadSeats();
                                UpdateSelectionSummary();

                                return false;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to check seat availability.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
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
        // DESIGNER EVENT HANDLERS
        // =========================================================

        private void lblTravelDateTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblRouteTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblRoute_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblFareTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblFare_Click(
            object sender,
            EventArgs e)
        {
        }

        private void flpSeats_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblSelectedTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblSelectedSeats_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalAmount_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTravelDate_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblPageTitle_Click(
            object sender,
            EventArgs e)
        {
        }


        // =========================================================
        // SEAT INFO CLASS
        // =========================================================

        private class SeatInfo
        {
            public int SeatID { get; set; }

            public string SeatNumber { get; set; }

            public int RowNumber { get; set; }

            public int ColumnNumber { get; set; }

            public bool IsBooked { get; set; }
        }
    }


    // =============================================================
    // TEMPORARY BOOKING DATA
    // Used to pass SeatSelection data to BookTicket.
    // =============================================================

    public static class PendingBookingData
    {
        public static int CustomerID { get; set; }

        public static string CustomerName { get; set; }

        public static int ScheduleID { get; set; }

        public static int BusID { get; set; }

        public static decimal Fare { get; set; }

        public static List<int> SeatIDs { get; set; }
            = new List<int>();

        public static List<string> SeatNumbers { get; set; }
            = new List<string>();

        public static int TotalSeats { get; set; }

        public static decimal TotalAmount { get; set; }
    }
}
