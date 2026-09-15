using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace BusTicketManagementSystem
{
    public partial class ManageReports : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        public ManageReports()
        {
            InitializeComponent();

            dgvReports.AutoGenerateColumns = false;

            colReportID.HeaderText = "Report ID";

            comboBox1.SelectedIndex = 0;

            // Generate report ONLY when button is clicked
            btnGenerateReport.Click += btnGenerateReport_Click;

            // Load default report when form opens
            GenerateSelectedReport();
        }

        // =========================================================
        // GENERATE REPORT BUTTON
        // =========================================================
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateSelectedReport();
        }

        // =========================================================
        // SELECTED REPORT
        // =========================================================
        private void GenerateSelectedReport()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a report type.",
                    "Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string reportType = comboBox1.SelectedItem.ToString();

            try
            {
                switch (reportType)
                {
                    case "Sales Report":
                        LoadSalesReport();
                        break;

                    case "Commission Report":
                        LoadCommissionReport();
                        break;

                    case "Payment Report":
                        LoadPaymentReport();
                        break;

                    case "Operator Report":
                        LoadOperatorReport();
                        break;

                    case "Bus Report":
                        LoadBusReport();
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
                    "Failed to generate report.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SALES REPORT
        // =========================================================
        private void LoadSalesReport()
        {
            string query = @"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY o.OperatorID) AS ReportID,
                    'Sales Report' AS ReportType,
                    u.FullName AS OperatorName,
                    o.CompanyName,

                    ISNULL(SUM(bk.TotalAmount), 0) AS TotalSales,

                    0 AS Commission,

                    0 AS TotalPayments,

                    GETDATE() AS ReportDate

                FROM dbo.Operators o

                INNER JOIN dbo.Users u
                    ON o.UserID = u.UserID

                LEFT JOIN dbo.Buses bus
                    ON o.OperatorID = bus.OperatorID

                LEFT JOIN dbo.Schedules s
                    ON bus.BusID = s.BusID

                LEFT JOIN dbo.Bookings bk
                    ON s.ScheduleID = bk.ScheduleID
                    AND bk.BookingStatus IN ('Confirmed', 'Completed')

                GROUP BY
                    o.OperatorID,
                    u.FullName,
                    o.CompanyName

                ORDER BY o.OperatorID;";

            LoadReport(query);
        }

        // =========================================================
        // COMMISSION REPORT
        // =========================================================
        private void LoadCommissionReport()
        {
            string query = @"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY o.OperatorID) AS ReportID,
                    'Commission Report' AS ReportType,
                    u.FullName AS OperatorName,
                    o.CompanyName,

                    ISNULL(
                        (
                            SELECT SUM(bk.TotalAmount)
                            FROM dbo.Buses bus
                            INNER JOIN dbo.Schedules s
                                ON bus.BusID = s.BusID
                            INNER JOIN dbo.Bookings bk
                                ON s.ScheduleID = bk.ScheduleID
                            WHERE bus.OperatorID = o.OperatorID
                              AND bk.BookingStatus IN ('Confirmed', 'Completed')
                        ),
                        0
                    ) AS TotalSales,

                    ISNULL(
                        (
                            SELECT SUM(bk.TotalAmount)
                            FROM dbo.Buses bus
                            INNER JOIN dbo.Schedules s
                                ON bus.BusID = s.BusID
                            INNER JOIN dbo.Bookings bk
                                ON s.ScheduleID = bk.ScheduleID
                            WHERE bus.OperatorID = o.OperatorID
                              AND bk.BookingStatus IN ('Confirmed', 'Completed')
                        ),
                        0
                    ) * o.CommissionRate / 100.0 AS Commission,

                    ISNULL(
                        (
                            SELECT SUM(op.Amount)
                            FROM dbo.OperatorPayments op
                            WHERE op.OperatorID = o.OperatorID
                              AND op.PaymentStatus = 'Paid'
                        ),
                        0
                    ) AS TotalPayments,

                    GETDATE() AS ReportDate

                FROM dbo.Operators o

                INNER JOIN dbo.Users u
                    ON o.UserID = u.UserID

                ORDER BY o.OperatorID;";

            LoadReport(query);
        }

        // =========================================================
        // PAYMENT REPORT
        // =========================================================
        private void LoadPaymentReport()
        {
            string query = @"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY op.OperatorPaymentID) AS ReportID,

                    'Payment Report' AS ReportType,

                    u.FullName AS OperatorName,

                    o.CompanyName,

                    0 AS TotalSales,

                    0 AS Commission,

                    op.Amount AS TotalPayments,

                    ISNULL(op.PaymentDate, op.CreatedAt) AS ReportDate

                FROM dbo.OperatorPayments op

                INNER JOIN dbo.Operators o
                    ON op.OperatorID = o.OperatorID

                INNER JOIN dbo.Users u
                    ON o.UserID = u.UserID

                ORDER BY op.OperatorPaymentID;";

            LoadReport(query);
        }

        // =========================================================
        // OPERATOR REPORT
        // =========================================================
        private void LoadOperatorReport()
        {
            string query = @"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY o.OperatorID) AS ReportID,

                    'Operator Report' AS ReportType,

                    u.FullName AS OperatorName,

                    o.CompanyName,

                    ISNULL(
                        (
                            SELECT SUM(bk.TotalAmount)
                            FROM dbo.Buses bus
                            INNER JOIN dbo.Schedules s
                                ON bus.BusID = s.BusID
                            INNER JOIN dbo.Bookings bk
                                ON s.ScheduleID = bk.ScheduleID
                            WHERE bus.OperatorID = o.OperatorID
                              AND bk.BookingStatus IN ('Confirmed', 'Completed')
                        ),
                        0
                    ) AS TotalSales,

                    o.CommissionRate AS Commission,

                    ISNULL(
                        (
                            SELECT SUM(op.Amount)
                            FROM dbo.OperatorPayments op
                            WHERE op.OperatorID = o.OperatorID
                              AND op.PaymentStatus = 'Paid'
                        ),
                        0
                    ) AS TotalPayments,

                    o.CreatedAt AS ReportDate

                FROM dbo.Operators o

                INNER JOIN dbo.Users u
                    ON o.UserID = u.UserID

                ORDER BY o.OperatorID;";

            LoadReport(query);
        }

        // =========================================================
        // BUS REPORT
        // =========================================================
        private void LoadBusReport()
        {
            string query = @"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY bus.BusID) AS ReportID,

                    'Bus Report' AS ReportType,

                    u.FullName AS OperatorName,

                    o.CompanyName,

                    ISNULL(
                        (
                            SELECT SUM(bk.TotalAmount)
                            FROM dbo.Schedules s
                            INNER JOIN dbo.Bookings bk
                                ON s.ScheduleID = bk.ScheduleID
                            WHERE s.BusID = bus.BusID
                              AND bk.BookingStatus IN ('Confirmed', 'Completed')
                        ),
                        0
                    ) AS TotalSales,

                    ISNULL(
                        (
                            SELECT SUM(bk.TotalAmount)
                            FROM dbo.Schedules s
                            INNER JOIN dbo.Bookings bk
                                ON s.ScheduleID = bk.ScheduleID
                            WHERE s.BusID = bus.BusID
                              AND bk.BookingStatus IN ('Confirmed', 'Completed')
                        ),
                        0
                    ) * o.CommissionRate / 100.0 AS Commission,

                    0 AS TotalPayments,

                    bus.CreatedAt AS ReportDate

                FROM dbo.Buses bus

                INNER JOIN dbo.Operators o
                    ON bus.OperatorID = o.OperatorID

                INNER JOIN dbo.Users u
                    ON o.UserID = u.UserID

                ORDER BY bus.BusID;";

            LoadReport(query);
        }

        // =========================================================
        // COMMON REPORT LOADER
        // =========================================================
        private void LoadReport(string query)
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter =
                       new SqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvReports.DataSource = null;
                    dgvReports.DataSource = table;
                }
            }

            FormatGrid();
            CalculateSummary();
        }

        // =========================================================
        // GRID FORMATTING
        // =========================================================
        private void FormatGrid()
        {
            if (dgvReports.Columns.Count < 8)
                return;

            dgvReports.Columns["colReportID"].DataPropertyName =
                "ReportID";

            dgvReports.Columns["colReportType"].DataPropertyName =
                "ReportType";

            dgvReports.Columns["colOperatorName"].DataPropertyName =
                "OperatorName";

            dgvReports.Columns["colCompanyName"].DataPropertyName =
                "CompanyName";

            dgvReports.Columns["colTotalSales"].DataPropertyName =
                "TotalSales";

            dgvReports.Columns["colCommission"].DataPropertyName =
                "Commission";

            dgvReports.Columns["colTotalPayments"].DataPropertyName =
                "TotalPayments";

            dgvReports.Columns["colReportDate"].DataPropertyName =
                "ReportDate";

            dgvReports.Columns["colTotalSales"]
                .DefaultCellStyle.Format = "N2";

            dgvReports.Columns["colCommission"]
                .DefaultCellStyle.Format = "N2";

            dgvReports.Columns["colTotalPayments"]
                .DefaultCellStyle.Format = "N2";

            dgvReports.Columns["colReportDate"]
                .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm";
        }

        // =========================================================
        // SUMMARY
        // =========================================================
        private void CalculateSummary()
        {
            decimal totalSales = 0;
            decimal totalCommissions = 0;
            decimal totalPayments = 0;

            foreach (DataGridViewRow row in dgvReports.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["colTotalSales"].Value != null)
                {
                    decimal value;

                    if (decimal.TryParse(
                        row.Cells["colTotalSales"].Value.ToString(),
                        out value))
                    {
                        totalSales += value;
                    }
                }

                if (row.Cells["colCommission"].Value != null)
                {
                    decimal value;

                    if (decimal.TryParse(
                        row.Cells["colCommission"].Value.ToString(),
                        out value))
                    {
                        totalCommissions += value;
                    }
                }

                if (row.Cells["colTotalPayments"].Value != null)
                {
                    decimal value;

                    if (decimal.TryParse(
                        row.Cells["colTotalPayments"].Value.ToString(),
                        out value))
                    {
                        totalPayments += value;
                    }
                }
            }

            lblTotalSalesValue.Text =
                totalSales.ToString("N2");

            lblTotalCommissionsValue.Text =
                totalCommissions.ToString("N2");

            lblTotalPaymentsValue.Text =
                totalPayments.ToString("N2");
        }

        // =========================================================
        // EXISTING LABEL CLICK EVENT
        // =========================================================
        private void lblPageTitle_Click(object sender, EventArgs e)
        {
            // Nothing required here.
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
