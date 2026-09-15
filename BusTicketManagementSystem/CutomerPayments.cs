using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class CutomerPayments : Form
    {
        private readonly int customerID;
        private bool isPaymentMode = false;

        private const string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        public CutomerPayments(int customerID)
        {
            InitializeComponent();

            this.customerID = customerID;

            // Prevent duplicate event subscriptions
            btnShowPayments.Click -= btnShowPayments_Click;
            btnViewDetails.Click -= btnViewDetails_Click;
            btnClear.Click -= btnClear_Click;
            btnSearch.Click -= btnSearch_Click;

            btnShowPayments.Click += btnShowPayments_Click;
            btnViewDetails.Click += btnViewDetails_Click;
            btnClear.Click += btnClear_Click;
            btnSearch.Click += btnSearch_Click;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void CutomerPayments_Load(object sender, EventArgs e)
        {
            isPaymentMode =
                PendingBookingData.ScheduleID > 0 &&
                PendingBookingData.CustomerID == customerID &&
                PendingBookingData.SeatIDs != null &&
                PendingBookingData.SeatIDs.Count > 0;

            if (isPaymentMode)
            {
                lblPageTitle.Text = "Complete Payment";

                btnViewDetails.Text = "Pay & Confirm";
                btnViewDetails.Enabled = true;

                txtSearchPayment.Enabled = false;
                btnSearch.Enabled = false;

                LoadPendingPayment();
            }
            else
            {
                lblPageTitle.Text = "Payments";

                btnViewDetails.Text = "View Details";

                txtSearchPayment.Enabled = true;
                btnSearch.Enabled = true;

                LoadPayments();
            }
        }

        // =========================================================
        // LOAD NORMAL PAYMENT HISTORY
        // =========================================================

        private void LoadPayments()
        {
            try
            {
                dgvCustomerPayments.Rows.Clear();

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT
                            p.PaymentID,
                            p.BookingID,
                            p.Amount,
                            p.PaymentMethod,
                            p.PaymentDate,
                            p.PaymentStatus
                        FROM dbo.Payments p
                        INNER JOIN dbo.Bookings b
                            ON p.BookingID = b.BookingID
                        WHERE b.CustomerID = @CustomerID
                        ORDER BY
                            ISNULL(p.PaymentDate, p.CreatedAt) DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string paymentID =
                                    reader["PaymentID"].ToString();

                                string bookingID =
                                    reader["BookingID"].ToString();

                                decimal amount =
                                    Convert.ToDecimal(
                                        reader["Amount"]);

                                string paymentMethod =
                                    reader["PaymentMethod"].ToString();

                                string paymentDate;

                                if (reader["PaymentDate"] == DBNull.Value)
                                {
                                    paymentDate = "-";
                                }
                                else
                                {
                                    paymentDate =
                                        Convert.ToDateTime(
                                            reader["PaymentDate"])
                                        .ToString(
                                            "dd MMM yyyy hh:mm tt");
                                }

                                string paymentStatus =
                                    reader["PaymentStatus"].ToString();

                                dgvCustomerPayments.Rows.Add(
                                    paymentID,
                                    bookingID,
                                    amount.ToString("C2"),
                                    paymentMethod,
                                    paymentDate,
                                    paymentStatus
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load payments.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD PENDING PAYMENT
        // =========================================================

        private void LoadPendingPayment()
        {
            try
            {
                dgvCustomerPayments.Rows.Clear();

                decimal amount =
                    PendingBookingData.TotalAmount;

                dgvCustomerPayments.Rows.Add(
                    "Pending",
                    "New Booking",
                    amount.ToString("C2"),
                    "Online",
                    DateTime.Now.ToString(
                        "dd MMM yyyy hh:mm tt"),
                    "Pending"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load payment information.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SHOW PAYMENTS
        // =========================================================

        private void btnShowPayments_Click(
            object sender,
            EventArgs e)
        {
            if (isPaymentMode)
            {
                LoadPendingPayment();
            }
            else
            {
                LoadPayments();
            }
        }

        // =========================================================
        // VIEW DETAILS / PAY
        // =========================================================

        private void btnViewDetails_Click(
            object sender,
            EventArgs e)
        {
            if (isPaymentMode)
            {
                ProcessPayment();
            }
            else
            {
                ViewPaymentDetails();
            }
        }

        // =========================================================
        // PROCESS PAYMENT
        // =========================================================

        private void ProcessPayment()
        {
            // ---------------------------------------------------------
            // BASIC VALIDATION
            // ---------------------------------------------------------

            if (PendingBookingData.CustomerID <= 0)
            {
                MessageBox.Show(
                    "Customer information is missing.",
                    "Payment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (PendingBookingData.ScheduleID <= 0)
            {
                MessageBox.Show(
                    "Schedule information is missing.",
                    "Payment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (PendingBookingData.BusID <= 0)
            {
                MessageBox.Show(
                    "Bus information is missing.",
                    "Payment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (PendingBookingData.SeatIDs == null ||
                PendingBookingData.SeatIDs.Count == 0)
            {
                MessageBox.Show(
                    "No seats have been selected.",
                    "Payment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (PendingBookingData.TotalSeats <= 0)
            {
                MessageBox.Show(
                    "Invalid number of seats.",
                    "Payment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (PendingBookingData.TotalAmount <= 0)
            {
                MessageBox.Show(
                    "Invalid booking amount.",
                    "Payment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // ---------------------------------------------------------
            // SELECTED SEAT NAMES
            // ---------------------------------------------------------

            string seatNames =
                PendingBookingData.SeatNumbers != null &&
                PendingBookingData.SeatNumbers.Count > 0
                    ? string.Join(
                        ", ",
                        PendingBookingData.SeatNumbers)
                    : "Selected Seats";

            // ---------------------------------------------------------
            // CONFIRM PAYMENT
            // ---------------------------------------------------------

            DialogResult confirm =
                MessageBox.Show(
                    "Confirm payment?\n\n" +
                    "Seats: " + seatNames + "\n" +
                    "Total Seats: " +
                    PendingBookingData.TotalSeats + "\n" +
                    "Total Amount: " +
                    PendingBookingData.TotalAmount.ToString("C2") +
                    "\n\n" +
                    "Payment Method: Online",
                    "Confirm Payment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            // ---------------------------------------------------------
            // DATABASE TRANSACTION
            // ---------------------------------------------------------

            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlTransaction transaction =
                    con.BeginTransaction())
                {
                    try
                    {
                        // =================================================
                        // 1. CHECK CUSTOMER
                        // =================================================

                        string customerQuery = @"
                            SELECT COUNT(*)
                            FROM dbo.Customers
                            WHERE CustomerID = @CustomerID";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                customerQuery,
                                con,
                                transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@CustomerID",
                                PendingBookingData.CustomerID);

                            int customerExists =
                                Convert.ToInt32(
                                    cmd.ExecuteScalar());

                            if (customerExists == 0)
                            {
                                throw new Exception(
                                    "Customer account was not found.");
                            }
                        }

                        // =================================================
                        // 2. CHECK SCHEDULE
                        // =================================================

                        string scheduleQuery = @"
                            SELECT
                                ScheduleID,
                                BusID,
                                TravelDate,
                                DepartureTime,
                                Fare,
                                Status
                            FROM dbo.Schedules
                            WHERE ScheduleID = @ScheduleID
                              AND BusID = @BusID
                              AND TravelDate >= CAST(GETDATE() AS DATE)
                              AND ISNULL(Status, '') NOT IN
                                  ('Cancelled', 'Completed')";

                        using (SqlCommand cmd =
                            new SqlCommand(
                                scheduleQuery,
                                con,
                                transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@ScheduleID",
                                PendingBookingData.ScheduleID);

                            cmd.Parameters.AddWithValue(
                                "@BusID",
                                PendingBookingData.BusID);

                            using (SqlDataReader reader =
                                cmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new Exception(
                                        "Selected schedule is no longer available.");
                                }
                            }
                        }

                        // =================================================
                        // 3. CHECK ALL SELECTED SEATS
                        // =================================================

                        foreach (int seatID
                            in PendingBookingData.SeatIDs)
                        {
                            // -------------------------------------------------
                            // 3A. CHECK SEAT EXISTS FOR SELECTED BUS
                            //     AND SEAT STATUS IS ACTIVE
                            // -------------------------------------------------

                            string seatQuery = @"
                                SELECT COUNT(*)
                                FROM dbo.Seats
                                WHERE SeatID = @SeatID
                                  AND BusID = @BusID
                                  AND Status = 'Active'";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    seatQuery,
                                    con,
                                    transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@SeatID",
                                    seatID);

                                cmd.Parameters.AddWithValue(
                                    "@BusID",
                                    PendingBookingData.BusID);

                                int seatExists =
                                    Convert.ToInt32(
                                        cmd.ExecuteScalar());

                                if (seatExists == 0)
                                {
                                    throw new Exception(
                                        "One of the selected seats is invalid or inactive.");
                                }
                            }

                            // -------------------------------------------------
                            // 3B. CHECK WHETHER SEAT IS ALREADY BOOKED
                            //     FOR THIS PARTICULAR SCHEDULE
                            // -------------------------------------------------

                            string bookedSeatQuery = @"
                                SELECT COUNT(*)
                                FROM dbo.BookingSeats bs
                                INNER JOIN dbo.Bookings b
                                    ON bs.BookingID = b.BookingID
                                WHERE bs.SeatID = @SeatID
                                  AND b.ScheduleID = @ScheduleID
                                  AND ISNULL(b.BookingStatus, '') <> 'Cancelled'";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    bookedSeatQuery,
                                    con,
                                    transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@SeatID",
                                    seatID);

                                cmd.Parameters.AddWithValue(
                                    "@ScheduleID",
                                    PendingBookingData.ScheduleID);

                                int alreadyBooked =
                                    Convert.ToInt32(
                                        cmd.ExecuteScalar());

                                if (alreadyBooked > 0)
                                {
                                    throw new Exception(
                                        "Seat ID " +
                                        seatID +
                                        " has already been booked for this schedule.");
                                }
                            }
                        }

                        // =================================================
                        // 4. CREATE BOOKING
                        // =================================================

                        string bookingQuery = @"
                            INSERT INTO dbo.Bookings
                            (
                                CustomerID,
                                ScheduleID,
                                BookingDate,
                                TotalSeats,
                                TotalAmount,
                                BookingStatus,
                                PaymentStatus
                            )
                            VALUES
                            (
                                @CustomerID,
                                @ScheduleID,
                                GETDATE(),
                                @TotalSeats,
                                @TotalAmount,
                                'Confirmed',
                                'Paid'
                            );

                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int bookingID;

                        using (SqlCommand cmd =
                            new SqlCommand(
                                bookingQuery,
                                con,
                                transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@CustomerID",
                                PendingBookingData.CustomerID);

                            cmd.Parameters.AddWithValue(
                                "@ScheduleID",
                                PendingBookingData.ScheduleID);

                            cmd.Parameters.AddWithValue(
                                "@TotalSeats",
                                PendingBookingData.TotalSeats);

                            cmd.Parameters.AddWithValue(
                                "@TotalAmount",
                                PendingBookingData.TotalAmount);

                            bookingID =
                                Convert.ToInt32(
                                    cmd.ExecuteScalar());
                        }

                        // =================================================
                        // 5. INSERT BOOKING SEATS
                        // =================================================

                        string bookingSeatQuery = @"
                            INSERT INTO dbo.BookingSeats
                            (
                                BookingID,
                                SeatID
                            )
                            VALUES
                            (
                                @BookingID,
                                @SeatID
                            )";

                        foreach (int seatID
                            in PendingBookingData.SeatIDs)
                        {
                            using (SqlCommand cmd =
                                new SqlCommand(
                                    bookingSeatQuery,
                                    con,
                                    transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@BookingID",
                                    bookingID);

                                cmd.Parameters.AddWithValue(
                                    "@SeatID",
                                    seatID);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // =================================================
                        // 6. CREATE PAYMENT RECORD
                        // =================================================

                        string paymentQuery = @"
                            INSERT INTO dbo.Payments
                            (
                                BookingID,
                                Amount,
                                PaymentMethod,
                                PaymentStatus,
                                TransactionID,
                                PaymentDate
                            )
                            VALUES
                            (
                                @BookingID,
                                @Amount,
                                @PaymentMethod,
                                'Paid',
                                @TransactionID,
                                GETDATE()
                            );

                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int paymentID;

                        string transactionID =
                            "TXN-" +
                            DateTime.Now.ToString(
                                "yyyyMMddHHmmssfff");

                        using (SqlCommand cmd =
                            new SqlCommand(
                                paymentQuery,
                                con,
                                transaction))
                        {
                            cmd.Parameters.AddWithValue(
                                "@BookingID",
                                bookingID);

                            cmd.Parameters.AddWithValue(
                                "@Amount",
                                PendingBookingData.TotalAmount);

                            cmd.Parameters.AddWithValue(
                                "@PaymentMethod",
                                "Online");

                            cmd.Parameters.AddWithValue(
                                "@TransactionID",
                                transactionID);

                            paymentID =
                                Convert.ToInt32(
                                    cmd.ExecuteScalar());
                        }

                        // =================================================
                        // 7. COMMIT EVERYTHING
                        // =================================================

                        transaction.Commit();

                        // =================================================
                        // 8. SAVE DISPLAY VALUES
                        //    BEFORE CLEARING PENDING DATA
                        // =================================================

                        string paidAmount =
                            PendingBookingData.TotalAmount
                            .ToString("C2");

                        int selectedTotalSeats =
                            PendingBookingData.TotalSeats;

                        // =================================================
                        // 9. CLEAR PENDING BOOKING DATA
                        // =================================================

                        PendingBookingData.CustomerID = 0;
                        PendingBookingData.CustomerName = null;

                        PendingBookingData.ScheduleID = 0;
                        PendingBookingData.BusID = 0;

                        PendingBookingData.Fare = 0;

                        if (PendingBookingData.SeatIDs != null)
                        {
                            PendingBookingData.SeatIDs.Clear();
                        }

                        if (PendingBookingData.SeatNumbers != null)
                        {
                            PendingBookingData.SeatNumbers.Clear();
                        }

                        PendingBookingData.TotalSeats = 0;
                        PendingBookingData.TotalAmount = 0;

                        // =================================================
                        // 10. SUCCESS MESSAGE
                        // =================================================

                        MessageBox.Show(
                            "Payment Successful!\n\n" +
                            "Payment ID: " + paymentID + "\n" +
                            "Booking ID: " + bookingID + "\n" +
                            "Seats: " + seatNames + "\n" +
                            "Total Seats: " + selectedTotalSeats + "\n" +
                            "Amount: " + paidAmount + "\n" +
                            "Payment Method: Online\n" +
                            "Payment Status: Paid\n\n" +
                            "Booking Status: Confirmed",
                            "Payment Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult =
                            DialogResult.OK;

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // -------------------------------------------------
                        // ROLLBACK EVERYTHING IF ANY STEP FAILS
                        // -------------------------------------------------

                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                        }

                        MessageBox.Show(
                            "Payment failed.\n\n" +
                            ex.Message,
                            "Payment Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================
        // VIEW PAYMENT DETAILS
        // =========================================================

        private void ViewPaymentDetails()
        {
            if (dgvCustomerPayments.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a payment first.",
                    "Payment Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DataGridViewRow row =
                dgvCustomerPayments.SelectedRows[0];

            string paymentID =
                Convert.ToString(
                    row.Cells["colPaymentID"].Value);

            string bookingID =
                Convert.ToString(
                    row.Cells["colBookingID"].Value);

            string amount =
                Convert.ToString(
                    row.Cells["colPaymentAmount"].Value);

            string method =
                Convert.ToString(
                    row.Cells["colPaymentMethod"].Value);

            string date =
                Convert.ToString(
                    row.Cells["colPaymentDate"].Value);

            string status =
                Convert.ToString(
                    row.Cells["colPaymentStatus"].Value);

            MessageBox.Show(
                "Payment Details\n\n" +
                "Payment ID: " + paymentID + "\n" +
                "Booking ID: " + bookingID + "\n" +
                "Amount: " + amount + "\n" +
                "Payment Method: " + method + "\n" +
                "Payment Date: " + date + "\n" +
                "Payment Status: " + status,
                "Payment Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            if (isPaymentMode)
                return;

            string search =
                txtSearchPayment.Text.Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                LoadPayments();
                return;
            }

            try
            {
                dgvCustomerPayments.Rows.Clear();

                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT
                            p.PaymentID,
                            p.BookingID,
                            p.Amount,
                            p.PaymentMethod,
                            p.PaymentDate,
                            p.PaymentStatus
                        FROM dbo.Payments p
                        INNER JOIN dbo.Bookings b
                            ON p.BookingID = b.BookingID
                        WHERE b.CustomerID = @CustomerID
                          AND
                          (
                              CAST(p.PaymentID AS NVARCHAR(50))
                                  LIKE @Search
                              OR
                              CAST(p.BookingID AS NVARCHAR(50))
                                  LIKE @Search
                              OR
                              ISNULL(p.PaymentStatus, '')
                                  LIKE @Search
                          )
                        ORDER BY
                            ISNULL(p.PaymentDate, p.CreatedAt) DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CustomerID",
                            customerID);

                        cmd.Parameters.AddWithValue(
                            "@Search",
                            "%" + search + "%");

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string paymentDate;

                                if (reader["PaymentDate"] ==
                                    DBNull.Value)
                                {
                                    paymentDate = "-";
                                }
                                else
                                {
                                    paymentDate =
                                        Convert.ToDateTime(
                                            reader["PaymentDate"])
                                        .ToString(
                                            "dd MMM yyyy hh:mm tt");
                                }

                                dgvCustomerPayments.Rows.Add(
                                    reader["PaymentID"].ToString(),
                                    reader["BookingID"].ToString(),
                                    Convert.ToDecimal(
                                        reader["Amount"])
                                        .ToString("C2"),
                                    reader["PaymentMethod"].ToString(),
                                    paymentDate,
                                    reader["PaymentStatus"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Search failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CLEAR
        // =========================================================

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtSearchPayment.Clear();

            if (isPaymentMode)
            {
                LoadPendingPayment();
            }
            else
            {
                LoadPayments();
            }
        }
    }
}