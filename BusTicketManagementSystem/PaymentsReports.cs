using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class PaymentsReports : Form
    {
        private readonly int operatorID;

        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        public PaymentsReports(int operatorID)
        {
            InitializeComponent();

            this.operatorID = operatorID;

            dgvPaymentsReports.AutoGenerateColumns = false;

            // Keep the existing Designer columns
            colPaymentID.DataPropertyName = "PaymentID";
            colPaymentType.DataPropertyName = "PaymentType";
            colAmount.DataPropertyName = "Amount";
            colPaymentMethod.DataPropertyName = "PaymentMethod";
            colPaymentDate.DataPropertyName = "PaymentDate";
            colPaymentStatus.DataPropertyName = "PaymentStatus";

            // Clean report type list
            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("Sales Report");
            cmbReportType.Items.Add("Commission Report");
            cmbReportType.Items.Add("Payment Report");
            cmbReportType.Items.Add("Bus Report");

            cmbReportType.SelectedIndex = 0;

            // Wire buttons
            btnShowPayments.Click += btnShowPayments_Click;
            btnGenerateReport.Click += btnGenerateReport_Click;
            btnClear.Click += btnClear_Click;

            // Search when Enter is pressed
            txtSearchPayment.KeyDown += txtSearchPayment_KeyDown;
        }

        private void PaymentsReports_Load(object sender, EventArgs e)
        {
            LoadPayments();
        }

        // =========================================================
        // SHOW PAYMENTS
        // =========================================================

        private void LoadPayments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            p.PaymentID,
                            'Customer Payment' AS PaymentType,
                            p.Amount,
                            p.PaymentMethod,
                            p.PaymentDate,
                            p.PaymentStatus
                        FROM dbo.Payments p
                        INNER JOIN dbo.Bookings bk
                            ON p.BookingID = bk.BookingID
                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID
                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID
                        WHERE b.OperatorID = @OperatorID
                        ORDER BY p.PaymentID DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@OperatorID", operatorID);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvPaymentsReports.DataSource = dt;
                        }
                    }
                }

                LoadSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading payments:\n" + ex.Message,
                    "Payments Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SUMMARY
        // =========================================================

        private void LoadSummary()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Total Sales
                    string salesQuery = @"
                        SELECT ISNULL(SUM(bk.TotalAmount), 0)
                        FROM dbo.Bookings bk
                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID
                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID
                        WHERE b.OperatorID = @OperatorID
                          AND bk.BookingStatus IN ('Confirmed', 'Completed');";

                    using (SqlCommand cmd = new SqlCommand(salesQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@OperatorID", operatorID);

                        decimal totalSales = Convert.ToDecimal(cmd.ExecuteScalar());

                        lblTotalSalesValue.Text =
                            "৳ " + totalSales.ToString("N2");
                    }

                    // Total Commission
                    string commissionQuery = @"
                        SELECT
                            ISNULL(SUM(
                                bk.TotalAmount * (o.CommissionRate / 100.0)
                            ), 0)
                        FROM dbo.Bookings bk
                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID
                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID
                        INNER JOIN dbo.Operators o
                            ON b.OperatorID = o.OperatorID
                        WHERE b.OperatorID = @OperatorID
                          AND bk.BookingStatus IN ('Confirmed', 'Completed');";

                    using (SqlCommand cmd = new SqlCommand(commissionQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@OperatorID", operatorID);

                        decimal totalCommission =
                            Convert.ToDecimal(cmd.ExecuteScalar());

                        lblTotalCommissionsValue.Text =
                            "৳ " + totalCommission.ToString("N2");
                    }

                    // Total Customer Payments
                    string paymentsQuery = @"
                        SELECT ISNULL(SUM(p.Amount), 0)
                        FROM dbo.Payments p
                        INNER JOIN dbo.Bookings bk
                            ON p.BookingID = bk.BookingID
                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID
                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID
                        WHERE b.OperatorID = @OperatorID
                          AND p.PaymentStatus = 'Paid';";

                    using (SqlCommand cmd = new SqlCommand(paymentsQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@OperatorID", operatorID);

                        decimal totalPayments =
                            Convert.ToDecimal(cmd.ExecuteScalar());

                        lblTotalPaymentsValue.Text =
                            "৳ " + totalPayments.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading summary:\n" + ex.Message,
                    "Summary Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SEARCH PAYMENTS
        // =========================================================

        private void SearchPayments()
        {
            string searchText = txtSearchPayment.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadPayments();
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            p.PaymentID,
                            'Customer Payment' AS PaymentType,
                            p.Amount,
                            p.PaymentMethod,
                            p.PaymentDate,
                            p.PaymentStatus
                        FROM dbo.Payments p
                        INNER JOIN dbo.Bookings bk
                            ON p.BookingID = bk.BookingID
                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID
                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID
                        WHERE b.OperatorID = @OperatorID
                          AND
                          (
                              CAST(p.PaymentID AS VARCHAR) LIKE @Search
                              OR p.PaymentMethod LIKE @Search
                              OR p.PaymentStatus LIKE @Search
                              OR CAST(p.Amount AS VARCHAR) LIKE @Search
                              OR CONVERT(VARCHAR, p.PaymentDate, 23) LIKE @Search
                          )
                        ORDER BY p.PaymentID DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@OperatorID", operatorID);
                        cmd.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvPaymentsReports.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error searching payments:\n" + ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // GENERATE REPORT
        // =========================================================

        private void GenerateReport()
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a report type.",
                    "Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();

            try
            {
                switch (reportType)
                {
                    case "Sales Report":
                        GenerateSalesReport();
                        break;

                    case "Commission Report":
                        GenerateCommissionReport();
                        break;

                    case "Payment Report":
                        GeneratePaymentReport();
                        break;

                    case "Bus Report":
                        GenerateBusReport();
                        break;

                    default:
                        MessageBox.Show(
                            "Invalid report type.",
                            "Report",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error generating report:\n" + ex.Message,
                    "Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SALES REPORT
        // =========================================================

        private void GenerateSalesReport()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        p.PaymentID,
                        'Sales Report' AS PaymentType,
                        bk.TotalAmount AS Amount,
                        p.PaymentMethod,
                        p.PaymentDate,
                        bk.BookingStatus AS PaymentStatus
                    FROM dbo.Payments p
                    INNER JOIN dbo.Bookings bk
                        ON p.BookingID = bk.BookingID
                    INNER JOIN dbo.Schedules s
                        ON bk.ScheduleID = s.ScheduleID
                    INNER JOIN dbo.Buses b
                        ON s.BusID = b.BusID
                    WHERE b.OperatorID = @OperatorID
                    ORDER BY p.PaymentID DESC;";

                FillGrid(query);
            }
        }

        // =========================================================
        // COMMISSION REPORT
        // =========================================================

        private void GenerateCommissionReport()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        op.OperatorPaymentID AS PaymentID,
                        'Commission Report' AS PaymentType,
                        op.Amount,
                        ISNULL(op.PaymentMethod, 'N/A') AS PaymentMethod,
                        op.PaymentDate,
                        op.PaymentStatus
                    FROM dbo.OperatorPayments op
                    WHERE op.OperatorID = @OperatorID
                    ORDER BY op.OperatorPaymentID DESC;";

                FillGrid(query);
            }
        }

        // =========================================================
        // PAYMENT REPORT
        // =========================================================

        private void GeneratePaymentReport()
        {
            LoadPayments();
        }

        // =========================================================
        // BUS REPORT
        // =========================================================

        private void GenerateBusReport()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        b.BusID AS PaymentID,
                        'Bus Report' AS PaymentType,
                        ISNULL(
                            (
                                SELECT SUM(bk.TotalAmount)
                                FROM dbo.Bookings bk
                                INNER JOIN dbo.Schedules ss
                                    ON bk.ScheduleID = ss.ScheduleID
                                WHERE ss.BusID = b.BusID
                                  AND bk.BookingStatus IN
                                      ('Confirmed', 'Completed')
                            ), 0
                        ) AS Amount,
                        b.BusNumber AS PaymentMethod,
                        b.CreatedAt AS PaymentDate,
                        b.Status AS PaymentStatus
                    FROM dbo.Buses b
                    WHERE b.OperatorID = @OperatorID
                    ORDER BY b.BusID DESC;";

                FillGrid(query);
            }
        }

        // =========================================================
        // COMMON GRID FILL METHOD
        // =========================================================

        private void FillGrid(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@OperatorID", operatorID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvPaymentsReports.DataSource = dt;
                    }
                }
            }
        }

        // =========================================================
        // CLEAR
        // =========================================================

        private void ClearAll()
        {
            txtSearchPayment.Clear();

            if (cmbReportType.Items.Count > 0)
            {
                cmbReportType.SelectedIndex = 0;
            }

            dgvPaymentsReports.DataSource = null;

            lblTotalSalesValue.Text = "0.00";
            lblTotalCommissionsValue.Text = "0.00";
            lblTotalPaymentsValue.Text = "0.00";
        }

        // =========================================================
        // BUTTON EVENTS
        // =========================================================

        private void btnShowPayments_Click(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtSearchPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPayments();
                e.SuppressKeyPress = true;
            }
        }

        // =========================================================
        // EXISTING DESIGNER EVENTS
        // =========================================================

        private void lblPageTitle_Click(object sender, EventArgs e)
        {
            // No action needed
        }

        private void dgvPaymentsReports_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // No action needed
        }

        private void panelSummary_Paint(
            object sender,
            PaintEventArgs e)
        {
            // No action needed
        }
    }
}