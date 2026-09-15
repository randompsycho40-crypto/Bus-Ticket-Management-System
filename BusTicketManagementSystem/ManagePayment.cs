using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class ManagePayments : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private int selectedPaymentID = 0;
        private string selectedPaymentType = "";

        public ManagePayments()
        {
            InitializeComponent();

            dgvPayments.AutoGenerateColumns = false;

            // Button events
            btnShowPayments.Click -= btnShowPayments_Click;
            btnShowPayments.Click += btnShowPayments_Click;

            btnViewDetails.Click -= btnViewDetails_Click;
            btnViewDetails.Click += btnViewDetails_Click;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            btnClear.Click -= btnClear_Click;
            btnClear.Click += btnClear_Click;

            btnClearr.Click -= btnClearr_Click;
            btnClearr.Click += btnClearr_Click;

            dgvPayments.CellClick -= dgvPayments_CellClick;
            dgvPayments.CellClick += dgvPayments_CellClick;

            // Default values
            if (cmbPaymentType.Items.Count > 0)
                cmbPaymentType.SelectedIndex = 0;

            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;

            if (cmbPaymentStatus.Items.Count > 0)
                cmbPaymentStatus.SelectedIndex = 0;

            dptPaymentDate.Value = DateTime.Now;
        }

        private void ManagePayments_Load(object sender, EventArgs e)
        {
            LoadPayments();
        }

        // =========================================================
        // LOAD ALL PAYMENTS
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
                            ISNULL(u.FullName, 'Unknown') AS OperatorName,
                            ISNULL(o.CompanyName, 'Unknown') AS CompanyName,
                            'Ticket Sale' AS PaymentType,
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
                        INNER JOIN dbo.Operators o
                            ON b.OperatorID = o.OperatorID
                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID

                        UNION ALL

                        SELECT
                            op.OperatorPaymentID AS PaymentID,
                            ISNULL(u.FullName, 'Unknown') AS OperatorName,
                            ISNULL(o.CompanyName, 'Unknown') AS CompanyName,
                            'Commission' AS PaymentType,
                            op.Amount,
                            ISNULL(op.PaymentMethod, 'N/A') AS PaymentMethod,
                            op.PaymentDate,
                            op.PaymentStatus
                        FROM dbo.OperatorPayments op
                        INNER JOIN dbo.Operators o
                            ON op.OperatorID = o.OperatorID
                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID

                        ORDER BY PaymentDate DESC;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvPayments.DataSource = null;
                        dgvPayments.DataSource = table;
                    }
                }

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading payments:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // FORMAT GRID
        // =========================================================

        private void FormatGrid()
        {
            if (dgvPayments.Columns.Count < 8)
                return;

            colPaymentID.DataPropertyName = "PaymentID";
            colOperatorName.DataPropertyName = "OperatorName";
            colCompanyName.DataPropertyName = "CompanyName";
            colPaymentType.DataPropertyName = "PaymentType";
            colAmount.DataPropertyName = "Amount";
            colPaymentMethod.DataPropertyName = "PaymentMethod";
            colPaymentDate.DataPropertyName = "PaymentDate";
            colPaymentStatus.DataPropertyName = "PaymentStatus";

            colPaymentID.HeaderText = "Payment ID";
            colOperatorName.HeaderText = "Operator Name";
            colCompanyName.HeaderText = "Company Name";
            colPaymentType.HeaderText = "Payment Type";
            colAmount.HeaderText = "Amount";
            colPaymentMethod.HeaderText = "Payment Method";
            colPaymentDate.HeaderText = "Payment Date";
            colPaymentStatus.HeaderText = "Payment Status";

            colAmount.DefaultCellStyle.Format = "৳ #,##0.00";
            colPaymentDate.DefaultCellStyle.Format = "dd-MM-yyyy HH:mm";
        }

        // =========================================================
        // SHOW PAYMENTS
        // =========================================================

        private void btnShowPayments_Click(object sender, EventArgs e)
        {
            LoadPayments();
            ClearFields();
        }

        // =========================================================
        // SEARCH
        // =========================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

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
                            ISNULL(u.FullName, 'Unknown') AS OperatorName,
                            ISNULL(o.CompanyName, 'Unknown') AS CompanyName,
                            'Ticket Sale' AS PaymentType,
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
                        INNER JOIN dbo.Operators o
                            ON b.OperatorID = o.OperatorID
                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID
                        WHERE
                            u.FullName LIKE @Search
                            OR o.CompanyName LIKE @Search
                            OR p.PaymentMethod LIKE @Search
                            OR p.PaymentStatus LIKE @Search
                            OR 'Ticket Sale' LIKE @Search

                        UNION ALL

                        SELECT
                            op.OperatorPaymentID AS PaymentID,
                            ISNULL(u.FullName, 'Unknown') AS OperatorName,
                            ISNULL(o.CompanyName, 'Unknown') AS CompanyName,
                            'Commission' AS PaymentType,
                            op.Amount,
                            ISNULL(op.PaymentMethod, 'N/A') AS PaymentMethod,
                            op.PaymentDate,
                            op.PaymentStatus
                        FROM dbo.OperatorPayments op
                        INNER JOIN dbo.Operators o
                            ON op.OperatorID = o.OperatorID
                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID
                        WHERE
                            u.FullName LIKE @Search
                            OR o.CompanyName LIKE @Search
                            OR op.PaymentMethod LIKE @Search
                            OR op.PaymentStatus LIKE @Search
                            OR 'Commission' LIKE @Search

                        ORDER BY PaymentDate DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            dgvPayments.DataSource = null;
                            dgvPayments.DataSource = table;
                        }
                    }
                }

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error searching payments:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SELECT PAYMENT
        // =========================================================

        private void dgvPayments_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPayments.Rows[e.RowIndex];

            if (row.Cells["colPaymentID"].Value == null)
                return;

            selectedPaymentID =
                Convert.ToInt32(row.Cells["colPaymentID"].Value);

            selectedPaymentType =
                Convert.ToString(row.Cells["colPaymentType"].Value);

            txtOperatorName.Text =
                Convert.ToString(row.Cells["colOperatorName"].Value);

            txtCompanyName.Text =
                Convert.ToString(row.Cells["colCompanyName"].Value);

            cmbPaymentType.Text =
                Convert.ToString(row.Cells["colPaymentType"].Value);

            txtAmount.Text =
                Convert.ToString(row.Cells["colAmount"].Value);

            cmbPaymentMethod.Text =
                Convert.ToString(row.Cells["colPaymentMethod"].Value);

            cmbPaymentStatus.Text =
                Convert.ToString(row.Cells["colPaymentStatus"].Value);

            if (row.Cells["colPaymentDate"].Value != null &&
                row.Cells["colPaymentDate"].Value != DBNull.Value)
            {
                DateTime paymentDate;

                if (DateTime.TryParse(
                    row.Cells["colPaymentDate"].Value.ToString(),
                    out paymentDate))
                {
                    dptPaymentDate.Value = paymentDate;
                }
            }
        }

        // =========================================================
        // VIEW DETAILS
        // =========================================================

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (selectedPaymentID == 0)
            {
                MessageBox.Show(
                    "Please select a payment from the table first.",
                    "Select Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string details =
                "Payment ID: " + selectedPaymentID + "\n\n" +
                "Operator Name: " + txtOperatorName.Text + "\n" +
                "Company Name: " + txtCompanyName.Text + "\n" +
                "Payment Type: " + cmbPaymentType.Text + "\n" +
                "Amount: ৳ " + txtAmount.Text + "\n" +
                "Payment Method: " + cmbPaymentMethod.Text + "\n" +
                "Payment Date: " + dptPaymentDate.Value.ToString("dd-MM-yyyy HH:mm") + "\n" +
                "Payment Status: " + cmbPaymentStatus.Text;

            MessageBox.Show(
                details,
                "Payment Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // CLEAR - TOP BUTTON
        // =========================================================

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // =========================================================
        // CLEAR - DETAILS BUTTON
        // =========================================================

        private void btnClearr_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // =========================================================
        // CLEAR FIELDS
        // =========================================================

        private void ClearFields()
        {
            selectedPaymentID = 0;
            selectedPaymentType = "";

            txtOperatorName.Clear();
            txtCompanyName.Clear();
            txtAmount.Clear();
            txtSearch.Clear();

            if (cmbPaymentType.Items.Count > 0)
                cmbPaymentType.SelectedIndex = 0;
            else
                cmbPaymentType.Text = "";

            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
            else
                cmbPaymentMethod.Text = "";

            if (cmbPaymentStatus.Items.Count > 0)
                cmbPaymentStatus.SelectedIndex = 0;
            else
                cmbPaymentStatus.Text = "";

            dptPaymentDate.Value = DateTime.Now;

            dgvPayments.ClearSelection();
        }

        // =========================================================
        // EMPTY DESIGNER EVENTS
        // =========================================================

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panelPaymentDetails_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}