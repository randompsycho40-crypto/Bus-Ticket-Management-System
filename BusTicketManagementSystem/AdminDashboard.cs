using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class AdminDashboard : Form
    {
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

        private readonly int operatorID;

        public AdminDashboard(int operatorID)
        {
            InitializeComponent();

            this.operatorID = operatorID;

            // Apply normal/default Windows Forms appearance
            ApplyDefaultWinFormsStyle();

            // Make sure button events are connected
            btnDashboard.Click -= btnDashboard_Click;
            btnDashboard.Click += btnDashboard_Click;

            btnBuses.Click -= btnBuses_Click;
            btnBuses.Click += btnBuses_Click;

            btnRoutes.Click -= btnRoutes_Click;
            btnRoutes.Click += btnRoutes_Click;

            btnSchedules.Click -= btnSchedules_Click;
            btnSchedules.Click += btnSchedules_Click;

            btnBookings.Click -= btnBookings_Click;
            btnBookings.Click += btnBookings_Click;

            btnPaymentsReports.Click -= btnPaymentsReports_Click;
            btnPaymentsReports.Click += btnPaymentsReports_Click;

            btnLogout.Click -= btnLogout_Click;
            btnLogout.Click += btnLogout_Click;
        }

        // =========================================================
        // DEFAULT WINDOWS FORMS STYLE
        // =========================================================

        private void ApplyDefaultWinFormsStyle()
        {
            this.ClientSize = new Size(1200, 700);
            this.MinimumSize = new Size(1200, 700);
            this.MaximumSize = new Size(1200, 700);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.BackColor = SystemColors.Control;

            SetDefaultControlStyle(this);

            SetDefaultGridStyle(dgvTodaySchedule);
            SetDefaultGridStyle(dgvBookingOverview);

            if (dgvTodaySchedule.Columns.Count >= 4)
            {
                dgvTodaySchedule.Columns[0].DataPropertyName = "BusNumber";
                dgvTodaySchedule.Columns[1].DataPropertyName = "Route";
                dgvTodaySchedule.Columns[2].DataPropertyName = "TravelTime";
                dgvTodaySchedule.Columns[3].DataPropertyName = "Status";
            }

            if (dgvBookingOverview.Columns.Count >= 5)
            {
                dgvBookingOverview.Columns[0].DataPropertyName = "BookingID";
                dgvBookingOverview.Columns[1].DataPropertyName = "Route";
                dgvBookingOverview.Columns[2].DataPropertyName = "BookingDate";
                dgvBookingOverview.Columns[3].DataPropertyName = "TotalSeats";
                dgvBookingOverview.Columns[4].DataPropertyName = "BookingStatus";
            }
        }

        // =========================================================
        // DEFAULT CONTROL STYLE
        // =========================================================

        private void SetDefaultControlStyle(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Panel panel)
                {
                    panel.BackColor = SystemColors.Control;
                }

                if (control is Label label)
                {
                    label.BackColor = SystemColors.Control;
                    label.ForeColor = SystemColors.ControlText;
                }

                if (control is Button button)
                {
                    button.BackColor = SystemColors.Control;
                    button.ForeColor = SystemColors.ControlText;
                    button.FlatStyle = FlatStyle.Standard;
                }

                if (control is CheckBox checkBox)
                {
                    checkBox.BackColor = SystemColors.Control;
                    checkBox.ForeColor = SystemColors.ControlText;
                }

                if (control is TextBox textBox)
                {
                    textBox.BackColor = SystemColors.Window;
                    textBox.ForeColor = SystemColors.ControlText;
                }

                if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = SystemColors.Window;
                    comboBox.ForeColor = SystemColors.ControlText;
                }

                if (control.HasChildren)
                {
                    SetDefaultControlStyle(control);
                }
            }
        }

        // =========================================================
        // DEFAULT DATAGRIDVIEW STYLE
        // =========================================================

        private void SetDefaultGridStyle(DataGridView grid)
        {
            if (grid == null)
                return;

            grid.BackgroundColor = SystemColors.Window;
            grid.GridColor = SystemColors.ControlDark;

            grid.DefaultCellStyle.BackColor =
                SystemColors.Window;

            grid.DefaultCellStyle.ForeColor =
                SystemColors.ControlText;

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                SystemColors.Control;

            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                SystemColors.ControlText;

            grid.RowHeadersDefaultCellStyle.BackColor =
                SystemColors.Control;

            grid.RowHeadersDefaultCellStyle.ForeColor =
                SystemColors.ControlText;

            grid.EnableHeadersVisualStyles = true;

            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;

            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            grid.MultiSelect = false;

            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadOperatorDashboard();
        }

        private void AdminDashboard_Load_1(object sender, EventArgs e)
        {
            LoadOperatorDashboard();
        }

        // =========================================================
        // LOAD OPERATOR DASHBOARD
        // =========================================================

        private void LoadOperatorDashboard()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // =================================================
                    // OPERATOR INFORMATION
                    // =================================================

                    string operatorQuery = @"
                        SELECT
                            u.FullName,
                            o.CompanyName
                        FROM dbo.Operators o
                        INNER JOIN dbo.Users u
                            ON o.UserID = u.UserID
                        WHERE o.OperatorID = @OperatorID";

                    using (SqlCommand cmd =
                        new SqlCommand(operatorQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName =
                                    reader["FullName"].ToString();

                                string companyName =
                                    reader["CompanyName"].ToString();

                                label1.Text =
                                    "Welcome, " +
                                    fullName +
                                    " | " +
                                    companyName;
                            }
                        }
                    }

                    // =================================================
                    // DASHBOARD CARDS
                    // =================================================

                    string cardQuery = @"
                        SELECT

                            (
                                SELECT COUNT(*)
                                FROM dbo.Buses
                                WHERE OperatorID = @OperatorID
                            ) AS MyBuses,

                            (
                                SELECT COUNT(*)
                                FROM dbo.Buses
                                WHERE OperatorID = @OperatorID
                                AND Status = 'Active'
                            ) AS ActiveBuses,

                            (
                                SELECT COUNT(DISTINCT s.RouteID)
                                FROM dbo.Schedules s
                                INNER JOIN dbo.Buses b
                                    ON s.BusID = b.BusID
                                WHERE b.OperatorID = @OperatorID
                            ) AS TotalRoutes,

                            (
                                SELECT COUNT(*)
                                FROM dbo.Schedules s
                                INNER JOIN dbo.Buses b
                                    ON s.BusID = b.BusID
                                WHERE b.OperatorID = @OperatorID
                            ) AS TotalSchedules,

                            (
                                SELECT COUNT(*)
                                FROM dbo.Bookings bk
                                INNER JOIN dbo.Schedules s
                                    ON bk.ScheduleID = s.ScheduleID
                                INNER JOIN dbo.Buses b
                                    ON s.BusID = b.BusID
                                WHERE b.OperatorID = @OperatorID
                            ) AS TotalBookings,

                            (
                                SELECT ISNULL(SUM(bk.TotalAmount), 0)
                                FROM dbo.Bookings bk
                                INNER JOIN dbo.Schedules s
                                    ON bk.ScheduleID = s.ScheduleID
                                INNER JOIN dbo.Buses b
                                    ON s.BusID = b.BusID
                                WHERE b.OperatorID = @OperatorID
                                AND bk.BookingStatus IN
                                    ('Confirmed', 'Completed')
                            ) AS TotalSales";

                    using (SqlCommand cmd =
                        new SqlCommand(cardQuery, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OperatorID",
                            operatorID);

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblMyBusesValue.Text =
                                    reader["MyBuses"].ToString();

                                lblActiveBusesValue.Text =
                                    reader["ActiveBuses"].ToString();

                                lblTotalRoutesValue.Text =
                                    reader["TotalRoutes"].ToString();

                                lblTodaysSchedulesValue.Text =
                                    reader["TotalSchedules"].ToString();

                                lblTotalBookingsValue.Text =
                                    reader["TotalBookings"].ToString();

                                decimal totalSales =
                                    Convert.ToDecimal(
                                        reader["TotalSales"]);

                                lblTotalSalesValue.Text =
                                    "৳ " +
                                    totalSales.ToString("N2");
                            }
                        }
                    }

                    // =================================================
                    // TODAY'S SCHEDULE
                    // =================================================

                    string todayScheduleQuery = @"
                        SELECT
                            b.BusNumber,

                            r.FromLocation +
                            ' - ' +
                            r.ToLocation AS Route,

                            CONVERT(
                                VARCHAR(5),
                                s.DepartureTime,
                                108
                            )
                            +
                            ' - ' +
                            CONVERT(
                                VARCHAR(5),
                                s.ArrivalTime,
                                108
                            ) AS TravelTime,

                            s.Status

                        FROM dbo.Schedules s

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE b.OperatorID = @OperatorID

                        AND CAST(s.TravelDate AS DATE) =
                            CAST(GETDATE() AS DATE)

                        ORDER BY s.DepartureTime";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            todayScheduleQuery,
                            con))
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

                            dgvTodaySchedule.DataSource =
                                table;
                        }
                    }

                    // =================================================
                    // BOOKING OVERVIEW
                    // =================================================

                    string bookingQuery = @"
                        SELECT TOP 10

                            bk.BookingID,

                            r.FromLocation +
                            ' - ' +
                            r.ToLocation AS Route,

                            bk.BookingDate,

                            bk.TotalSeats,

                            bk.BookingStatus

                        FROM dbo.Bookings bk

                        INNER JOIN dbo.Schedules s
                            ON bk.ScheduleID = s.ScheduleID

                        INNER JOIN dbo.Buses b
                            ON s.BusID = b.BusID

                        INNER JOIN dbo.Routes r
                            ON s.RouteID = r.RouteID

                        WHERE b.OperatorID = @OperatorID

                        ORDER BY bk.BookingDate DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            bookingQuery,
                            con))
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

                            dgvBookingOverview.DataSource =
                                table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load Operator Dashboard.\n\n" +
                    ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DASHBOARD BUTTON
        // =========================================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadOperatorDashboard();
        }

        // =========================================================
        // MY BUSES
        // =========================================================

        private void btnBuses_Click(object sender, EventArgs e)
        {
            MyBuses form = new MyBuses(operatorID);
            form.ShowDialog();
        }

        // =========================================================
        // ROUTES
        // =========================================================

        private void btnRoutes_Click(object sender, EventArgs e)
        {
            Routes form = new Routes(operatorID);
            form.ShowDialog();
        }

        // =========================================================
        // SCHEDULES
        // =========================================================

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            Schedules form = new Schedules(operatorID);
            form.ShowDialog();
        }

        // =========================================================
        // BOOKINGS
        // =========================================================

        private void btnBookings_Click(object sender, EventArgs e)
        {
            Bookings form = new Bookings(operatorID);
            form.ShowDialog();
        }

        // =========================================================
        // PAYMENTS & REPORTS
        // =========================================================

        private void btnPaymentsReports_Click(object sender, EventArgs e)
        {
            PaymentsReports form =
                new PaymentsReports(operatorID);

            form.ShowDialog();
        }

        // =========================================================
        // LOGOUT
        // =========================================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            this.Close();
        }

        // =========================================================
        // EXISTING DESIGNER EVENTS
        // =========================================================

        private void lblTodayScheduleTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblTotalBookingsValue_Click(
            object sender,
            EventArgs e)
        {
        }

        private void panelContent_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
}