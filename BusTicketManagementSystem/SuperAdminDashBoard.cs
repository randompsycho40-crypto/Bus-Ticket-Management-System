using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class SuperAdminDashBoard : Form
    {
        // ==========================================
        // DATABASE CONNECTION
        // ==========================================
        private readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public SuperAdminDashBoard()
        {
            InitializeComponent();
        }


        // ==========================================
        // FORM LOAD
        // ==========================================
        private void SuperAdminDashBoard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }


        // ==========================================
        // LOAD DASHBOARD DATA FROM DATABASE
        // ==========================================
        private void LoadDashboardData()
        {
            string query = @"
                SELECT

                    -- 1. Total Operators
                    (SELECT COUNT(*)
                     FROM dbo.Operators) AS TotalOperators,

                    -- 2. Active Operators
                    (SELECT COUNT(*)
                     FROM dbo.Operators
                     WHERE Status = 'Active') AS ActiveOperators,

                    -- 3. Pending Operators
                    -- Operators who have NOT paid commission
                    (SELECT COUNT(DISTINCT OperatorID)
                     FROM dbo.OperatorPayments
                     WHERE PaymentStatus = 'Pending') AS PendingOperators,

                    -- 4. Total Buses
                    (SELECT COUNT(*)
                     FROM dbo.Buses) AS TotalBuses,

                    -- 5. Tickets Sold
                    (SELECT ISNULL(SUM(TotalSeats), 0)
                     FROM dbo.Bookings
                     WHERE BookingStatus = 'Confirmed') AS TicketsSold,

                    -- 6. Total Sales
                    (SELECT ISNULL(SUM(TotalAmount), 0)
                     FROM dbo.Bookings
                     WHERE BookingStatus = 'Confirmed') AS TotalSales;
            ";

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ==========================================
                                // CARD 1 - TOTAL OPERATORS
                                // ==========================================
                                lblTotalOperatorsValue.Text =
                                    reader["TotalOperators"].ToString();


                                // ==========================================
                                // CARD 2 - ACTIVE OPERATORS
                                // ==========================================
                                lblActiveOperatorsValue.Text =
                                    reader["ActiveOperators"].ToString();


                                // ==========================================
                                // CARD 3 - PENDING OPERATORS
                                // ==========================================
                                lblPendingOperatorsValue.Text =
                                    reader["PendingOperators"].ToString();


                                // ==========================================
                                // CARD 4 - TOTAL BUSES
                                // ==========================================
                                lblTotalBusesValue.Text =
                                    reader["TotalBuses"].ToString();


                                // ==========================================
                                // CARD 5 - TICKETS SOLD
                                // ==========================================
                                lblTicketsSoldValue.Text =
                                    reader["TicketsSold"].ToString();


                                // ==========================================
                                // CARD 6 - TOTAL SALES
                                // ==========================================
                                decimal totalSales =
                                    Convert.ToDecimal(
                                        reader["TotalSales"]
                                    );

                                lblTotalSalesValue.Text =
                                    "৳ " + totalSales.ToString("N2");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load dashboard data.\n\n" +
                    "Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ==========================================
        // SIDEBAR PANEL
        // ==========================================
        private void panelSidebar_Paint(
            object sender,
            PaintEventArgs e)
        {
            // No code required
        }


        // ==========================================
        // HEADER PANEL
        // ==========================================
        private void panelHeader_Paint(
            object sender,
            PaintEventArgs e)
        {
            // No code required
        }


        // ==========================================
        // DASHBOARD BUTTON
        // ==========================================
        private void btnDashboard_Click(
            object sender,
            EventArgs e)
        {
            LoadDashboardData();
        }


        // ==========================================
        // MANAGE OPERATORS
        // ==========================================
        private void btnOperators_Click(
            object sender,
            EventArgs e)
        {
            ManageOperators operatorsForm =
                new ManageOperators();

            operatorsForm.ShowDialog();

            // Refresh dashboard after closing Operators
            LoadDashboardData();
        }


        // ==========================================
        // MANAGE BUSES
        // ==========================================
        private void btnBuses_Click(
            object sender,
            EventArgs e)
        {
            ManageBuses busesForm =
                new ManageBuses();

            busesForm.ShowDialog();

            // Refresh dashboard after closing Manage Buses
            LoadDashboardData();
        }


        // ==========================================
        // PAYMENTS
        // ==========================================
        private void btnPayments_Click(
            object sender,
            EventArgs e)
        {
            ManagePayments paymentsForm =
                new ManagePayments();

            paymentsForm.ShowDialog();

            LoadDashboardData();
        }


        // ==========================================
        // REPORTS
        // ==========================================
        private void btnReports_Click(
            object sender,
            EventArgs e)
        {
            ManageReports reportsForm =
                new ManageReports();

            reportsForm.ShowDialog();

            // Refresh dashboard after closing Reports
            LoadDashboardData();
        }


        // ==========================================
        // SETTINGS
        // ==========================================
        private void btnSettings_Click(
            object sender,
            EventArgs e)
        {
            ManageSettings settingsForm =
                new ManageSettings();

            settingsForm.ShowDialog();
        }


        // ==========================================
        // LOGOUT
        // ==========================================
        private void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


        // ==========================================
        // TOTAL BUSES VALUE
        // ==========================================
        private void lblTotalBusesValue_Click(
            object sender,
            EventArgs e)
        {
            // No action required
        }


        // ==========================================
        // DASHBOARD BUTTON EVENT FROM DESIGNER
        // ==========================================
        private void btnDashboard_Click_1(
            object sender,
            EventArgs e)
        {
            LoadDashboardData();
        }


        // ==========================================
        // REPORTS BUTTON EVENT FROM DESIGNER
        // ==========================================
        private void btnReports_Click_1(
            object sender,
            EventArgs e)
        {
            ManageReports reportsForm =
                new ManageReports();

            reportsForm.ShowDialog();

            // Refresh dashboard after closing Reports
            LoadDashboardData();
        }


        // ==========================================
        // BUSES BUTTON EVENT FROM DESIGNER
        // ==========================================
        private void btnBuses_Click_1(
            object sender,
            EventArgs e)
        {
            ManageBuses busesForm =
                new ManageBuses();

            busesForm.ShowDialog();

            // Refresh dashboard after closing Manage Buses
            LoadDashboardData();
        }


        // ==========================================
        // SETTINGS BUTTON EVENT FROM DESIGNER
        // ==========================================
        private void btnSettings_Click_1(
            object sender,
            EventArgs e)
        {
            ManageSettings settingsForm =
                new ManageSettings();

            settingsForm.ShowDialog();
        }


        // ==========================================
        // LOGOUT BUTTON EVENT FROM DESIGNER
        // ==========================================
        private void btnLogout_Click_1(
            object sender,
            EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}