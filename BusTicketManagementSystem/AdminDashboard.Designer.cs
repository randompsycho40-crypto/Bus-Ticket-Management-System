namespace BusTicketManagementSystem
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();

            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnBuses = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.btnRoutes = new System.Windows.Forms.Button();
            this.btnBookings = new System.Windows.Forms.Button();
            this.btnPaymentsReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();

            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();

            this.panelContent = new System.Windows.Forms.Panel();

            this.cardMyBuses = new System.Windows.Forms.Panel();
            this.lblMyBusesTitle = new System.Windows.Forms.Label();
            this.lblMyBusesValue = new System.Windows.Forms.Label();

            this.cardActiveBuses = new System.Windows.Forms.Panel();
            this.lblActiveBusesTitle = new System.Windows.Forms.Label();
            this.lblActiveBusesValue = new System.Windows.Forms.Label();

            this.cardTotalRoutes = new System.Windows.Forms.Panel();
            this.lblTotalRoutesTitle = new System.Windows.Forms.Label();
            this.lblTotalRoutesValue = new System.Windows.Forms.Label();

            this.cardTotalSchedules = new System.Windows.Forms.Panel();
            this.lblTotalSchedulesTitle = new System.Windows.Forms.Label();
            this.lblTodaysSchedulesValue = new System.Windows.Forms.Label();

            this.cardTotalBookings = new System.Windows.Forms.Panel();
            this.lblTotalBookingsTitle = new System.Windows.Forms.Label();
            this.lblTotalBookingsValue = new System.Windows.Forms.Label();

            this.cardTotalSales = new System.Windows.Forms.Panel();
            this.lblTotalSalesTitle = new System.Windows.Forms.Label();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();

            this.panelTodaySchedule = new System.Windows.Forms.Panel();
            this.lblTodayScheduleTitle = new System.Windows.Forms.Label();
            this.dgvTodaySchedule = new System.Windows.Forms.DataGridView();

            this.colScheduleBus =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colScheduleRoute =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colScheduleTime =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colScheduleStatus =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.panelBookingOverview = new System.Windows.Forms.Panel();
            this.lblBookingOverviewTitle = new System.Windows.Forms.Label();
            this.dgvBookingOverview = new System.Windows.Forms.DataGridView();

            this.colBookingID =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colBookingRoute =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colBookingDate =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colBookingSeats =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colBookingStatus =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();

            this.cardMyBuses.SuspendLayout();
            this.cardActiveBuses.SuspendLayout();
            this.cardTotalRoutes.SuspendLayout();
            this.cardTotalSchedules.SuspendLayout();
            this.cardTotalBookings.SuspendLayout();
            this.cardTotalSales.SuspendLayout();

            this.panelTodaySchedule.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvTodaySchedule)).BeginInit();

            this.panelBookingOverview.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvBookingOverview)).BeginInit();

            this.SuspendLayout();

            // =========================================================
            // MAIN FORM
            // =========================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1250, 720);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.MinimizeBox = true;

            this.Name =
                "AdminDashboard";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Bus Operator Dashboard";

            this.Load +=
                new System.EventHandler(this.AdminDashboard_Load_1);

            // =========================================================
            // SIDEBAR
            // =========================================================

            this.panelSidebar.Dock =
                System.Windows.Forms.DockStyle.Left;

            this.panelSidebar.Location =
                new System.Drawing.Point(0, 0);

            this.panelSidebar.Name =
                "panelSidebar";

            this.panelSidebar.Size =
                new System.Drawing.Size(180, 720);

            // =========================================================
            // LOGO
            // =========================================================

            this.lblLogo.AutoSize = false;

            this.lblLogo.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.lblLogo.Location =
                new System.Drawing.Point(0, 20);

            this.lblLogo.Name =
                "lblLogo";

            this.lblLogo.Size =
                new System.Drawing.Size(180, 40);

            this.lblLogo.Text =
                "BusGo";

            this.lblLogo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // =========================================================
            // ROLE
            // =========================================================

            this.lblRole.AutoSize = false;

            this.lblRole.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    8.5F);

            this.lblRole.Location =
                new System.Drawing.Point(0, 62);

            this.lblRole.Name =
                "lblRole";

            this.lblRole.Size =
                new System.Drawing.Size(180, 35);

            this.lblRole.Text =
                "Admin / Bus Operator";

            this.lblRole.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // =========================================================
            // DASHBOARD BUTTON
            // =========================================================

            this.btnDashboard.Location =
                new System.Drawing.Point(12, 120);

            this.btnDashboard.Name =
                "btnDashboard";

            this.btnDashboard.Size =
                new System.Drawing.Size(156, 40);

            this.btnDashboard.Text =
                "Dashboard";

            this.btnDashboard.UseVisualStyleBackColor =
                true;

            // =========================================================
            // BUSES
            // =========================================================

            this.btnBuses.Location =
                new System.Drawing.Point(12, 168);

            this.btnBuses.Name =
                "btnBuses";

            this.btnBuses.Size =
                new System.Drawing.Size(156, 40);

            this.btnBuses.Text =
                "My Buses";

            this.btnBuses.UseVisualStyleBackColor =
                true;

            // =========================================================
            // SCHEDULES
            // =========================================================

            this.btnSchedules.Location =
                new System.Drawing.Point(12, 216);

            this.btnSchedules.Name =
                "btnSchedules";

            this.btnSchedules.Size =
                new System.Drawing.Size(156, 40);

            this.btnSchedules.Text =
                "Schedules";

            this.btnSchedules.UseVisualStyleBackColor =
                true;

            // =========================================================
            // ROUTES
            // =========================================================

            this.btnRoutes.Location =
                new System.Drawing.Point(12, 264);

            this.btnRoutes.Name =
                "btnRoutes";

            this.btnRoutes.Size =
                new System.Drawing.Size(156, 40);

            this.btnRoutes.Text =
                "Routes";

            this.btnRoutes.UseVisualStyleBackColor =
                true;

            // =========================================================
            // BOOKINGS
            // =========================================================

            this.btnBookings.Location =
                new System.Drawing.Point(12, 312);

            this.btnBookings.Name =
                "btnBookings";

            this.btnBookings.Size =
                new System.Drawing.Size(156, 40);

            this.btnBookings.Text =
                "Bookings";

            this.btnBookings.UseVisualStyleBackColor =
                true;

            // =========================================================
            // PAYMENTS & REPORTS
            // =========================================================

            this.btnPaymentsReports.Location =
                new System.Drawing.Point(12, 360);

            this.btnPaymentsReports.Name =
                "btnPaymentsReports";

            this.btnPaymentsReports.Size =
                new System.Drawing.Size(156, 45);

            this.btnPaymentsReports.Text =
                "Payments && Reports";

            this.btnPaymentsReports.UseVisualStyleBackColor =
                true;

            // =========================================================
            // LOGOUT
            // =========================================================

            this.btnLogout.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            this.btnLogout.Location =
                new System.Drawing.Point(12, 650);

            this.btnLogout.Name =
                "btnLogout";

            this.btnLogout.Size =
                new System.Drawing.Size(156, 40);

            this.btnLogout.Text =
                "Logout";

            this.btnLogout.UseVisualStyleBackColor =
                true;

            // =========================================================
            // HEADER
            // =========================================================

            this.panelHeader.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.panelHeader.Location =
                new System.Drawing.Point(180, 0);

            this.panelHeader.Name =
                "panelHeader";

            this.panelHeader.Size =
                new System.Drawing.Size(1070, 60);

            // =========================================================
            // HEADER TITLE
            // =========================================================

            this.lblDashboard.AutoSize = false;

            this.lblDashboard.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    15F,
                    System.Drawing.FontStyle.Bold);

            this.lblDashboard.Location =
                new System.Drawing.Point(15, 8);

            this.lblDashboard.Name =
                "lblDashboard";

            this.lblDashboard.Size =
                new System.Drawing.Size(300, 42);

            this.lblDashboard.Text =
                "Dashboard";

            this.lblDashboard.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // =========================================================
            // WELCOME LABEL
            // =========================================================

            this.label1.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;

            this.label1.AutoSize = false;

            this.label1.Location =
                new System.Drawing.Point(480, 8);

            this.label1.Name =
                "label1";

            this.label1.Size =
                new System.Drawing.Size(570, 42);

            this.label1.Text =
                "Welcome, Bus Operator";

            this.label1.TextAlign =
                System.Drawing.ContentAlignment.MiddleRight;

            // =========================================================
            // CONTENT
            // =========================================================

            this.panelContent.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.panelContent.Location =
                new System.Drawing.Point(180, 60);

            this.panelContent.Name =
                "panelContent";

            this.panelContent.Padding =
                new System.Windows.Forms.Padding(15);

            this.panelContent.Size =
                new System.Drawing.Size(1070, 660);

            // =========================================================
            // CARD 1
            // =========================================================

            this.cardMyBuses.Location =
                new System.Drawing.Point(15, 15);

            this.cardMyBuses.Name =
                "cardMyBuses";

            this.cardMyBuses.Size =
                new System.Drawing.Size(320, 85);

            this.lblMyBusesTitle.AutoSize = false;

            this.lblMyBusesTitle.Location =
                new System.Drawing.Point(15, 8);

            this.lblMyBusesTitle.Name =
                "lblMyBusesTitle";

            this.lblMyBusesTitle.Size =
                new System.Drawing.Size(290, 25);

            this.lblMyBusesTitle.Text =
                "My Buses";

            this.lblMyBusesValue.AutoSize = false;

            this.lblMyBusesValue.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblMyBusesValue.Location =
                new System.Drawing.Point(15, 35);

            this.lblMyBusesValue.Name =
                "lblMyBusesValue";

            this.lblMyBusesValue.Size =
                new System.Drawing.Size(290, 40);

            this.lblMyBusesValue.Text =
                "0";

            // =========================================================
            // CARD 2
            // =========================================================

            this.cardActiveBuses.Location =
                new System.Drawing.Point(350, 15);

            this.cardActiveBuses.Name =
                "cardActiveBuses";

            this.cardActiveBuses.Size =
                new System.Drawing.Size(320, 85);

            this.lblActiveBusesTitle.AutoSize = false;

            this.lblActiveBusesTitle.Location =
                new System.Drawing.Point(15, 8);

            this.lblActiveBusesTitle.Name =
                "lblActiveBusesTitle";

            this.lblActiveBusesTitle.Size =
                new System.Drawing.Size(290, 25);

            this.lblActiveBusesTitle.Text =
                "Active Buses";

            this.lblActiveBusesValue.AutoSize = false;

            this.lblActiveBusesValue.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblActiveBusesValue.Location =
                new System.Drawing.Point(15, 35);

            this.lblActiveBusesValue.Name =
                "lblActiveBusesValue";

            this.lblActiveBusesValue.Size =
                new System.Drawing.Size(290, 40);

            this.lblActiveBusesValue.Text =
                "0";

            // =========================================================
            // CARD 3
            // =========================================================

            this.cardTotalRoutes.Location =
                new System.Drawing.Point(685, 15);

            this.cardTotalRoutes.Name =
                "cardTotalRoutes";

            this.cardTotalRoutes.Size =
                new System.Drawing.Size(320, 85);

            this.lblTotalRoutesTitle.AutoSize = false;

            this.lblTotalRoutesTitle.Location =
                new System.Drawing.Point(15, 8);

            this.lblTotalRoutesTitle.Name =
                "lblTotalRoutesTitle";

            this.lblTotalRoutesTitle.Size =
                new System.Drawing.Size(290, 25);

            this.lblTotalRoutesTitle.Text =
                "Total Routes";

            this.lblTotalRoutesValue.AutoSize = false;

            this.lblTotalRoutesValue.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTotalRoutesValue.Location =
                new System.Drawing.Point(15, 35);

            this.lblTotalRoutesValue.Name =
                "lblTotalRoutesValue";

            this.lblTotalRoutesValue.Size =
                new System.Drawing.Size(290, 40);

            this.lblTotalRoutesValue.Text =
                "0";

            // =========================================================
            // CARD 4
            // =========================================================

            this.cardTotalSchedules.Location =
                new System.Drawing.Point(15, 115);

            this.cardTotalSchedules.Name =
                "cardTotalSchedules";

            this.cardTotalSchedules.Size =
                new System.Drawing.Size(320, 85);

            this.lblTotalSchedulesTitle.AutoSize = false;

            this.lblTotalSchedulesTitle.Location =
                new System.Drawing.Point(15, 8);

            this.lblTotalSchedulesTitle.Name =
                "lblTotalSchedulesTitle";

            this.lblTotalSchedulesTitle.Size =
                new System.Drawing.Size(290, 25);

            this.lblTotalSchedulesTitle.Text =
                "Total Schedules";

            this.lblTodaysSchedulesValue.AutoSize = false;

            this.lblTodaysSchedulesValue.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTodaysSchedulesValue.Location =
                new System.Drawing.Point(15, 35);

            this.lblTodaysSchedulesValue.Name =
                "lblTodaysSchedulesValue";

            this.lblTodaysSchedulesValue.Size =
                new System.Drawing.Size(290, 40);

            this.lblTodaysSchedulesValue.Text =
                "0";

            // =========================================================
            // CARD 5
            // =========================================================

            this.cardTotalBookings.Location =
                new System.Drawing.Point(350, 115);

            this.cardTotalBookings.Name =
                "cardTotalBookings";

            this.cardTotalBookings.Size =
                new System.Drawing.Size(320, 85);

            this.lblTotalBookingsTitle.AutoSize = false;

            this.lblTotalBookingsTitle.Location =
                new System.Drawing.Point(15, 8);

            this.lblTotalBookingsTitle.Name =
                "lblTotalBookingsTitle";

            this.lblTotalBookingsTitle.Size =
                new System.Drawing.Size(290, 25);

            this.lblTotalBookingsTitle.Text =
                "Total Bookings";

            this.lblTotalBookingsValue.AutoSize = false;

            this.lblTotalBookingsValue.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTotalBookingsValue.Location =
                new System.Drawing.Point(15, 35);

            this.lblTotalBookingsValue.Name =
                "lblTotalBookingsValue";

            this.lblTotalBookingsValue.Size =
                new System.Drawing.Size(290, 40);

            this.lblTotalBookingsValue.Text =
                "0";

            // =========================================================
            // CARD 6
            // =========================================================

            this.cardTotalSales.Location =
                new System.Drawing.Point(685, 115);

            this.cardTotalSales.Name =
                "cardTotalSales";

            this.cardTotalSales.Size =
                new System.Drawing.Size(320, 85);

            this.lblTotalSalesTitle.AutoSize = false;

            this.lblTotalSalesTitle.Location =
                new System.Drawing.Point(15, 8);

            this.lblTotalSalesTitle.Name =
                "lblTotalSalesTitle";

            this.lblTotalSalesTitle.Size =
                new System.Drawing.Size(290, 25);

            this.lblTotalSalesTitle.Text =
                "Total Sales";

            this.lblTotalSalesValue.AutoSize = false;

            this.lblTotalSalesValue.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.lblTotalSalesValue.Location =
                new System.Drawing.Point(15, 35);

            this.lblTotalSalesValue.Name =
                "lblTotalSalesValue";

            this.lblTotalSalesValue.Size =
                new System.Drawing.Size(290, 40);

            this.lblTotalSalesValue.Text =
                "৳ 0.00";

            // =========================================================
            // TODAY'S SCHEDULE PANEL
            // =========================================================

            this.panelTodaySchedule.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            this.panelTodaySchedule.Location =
                new System.Drawing.Point(15, 220);

            this.panelTodaySchedule.Name =
                "panelTodaySchedule";

            this.panelTodaySchedule.Size =
                new System.Drawing.Size(500, 410);

            // =========================================================
            // TODAY'S SCHEDULE TITLE
            // =========================================================

            this.lblTodayScheduleTitle.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.lblTodayScheduleTitle.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblTodayScheduleTitle.Location =
                new System.Drawing.Point(0, 0);

            this.lblTodayScheduleTitle.Name =
                "lblTodayScheduleTitle";

            this.lblTodayScheduleTitle.Size =
                new System.Drawing.Size(500, 38);

            this.lblTodayScheduleTitle.Text =
                "Today's Schedule";

            this.lblTodayScheduleTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // =========================================================
            // TODAY'S SCHEDULE GRID
            // =========================================================

            this.dgvTodaySchedule.AllowUserToAddRows =
                false;

            this.dgvTodaySchedule.AllowUserToDeleteRows =
                false;

            this.dgvTodaySchedule.AllowUserToResizeRows =
                false;

            this.dgvTodaySchedule.AutoGenerateColumns =
                false;

            this.dgvTodaySchedule.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvTodaySchedule.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.dgvTodaySchedule.ReadOnly =
                true;

            this.dgvTodaySchedule.RowHeadersVisible =
                false;

            this.dgvTodaySchedule.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvTodaySchedule.MultiSelect =
                false;

            this.dgvTodaySchedule.Name =
                "dgvTodaySchedule";

            this.dgvTodaySchedule.TabIndex =
                0;

            this.colScheduleBus.HeaderText =
                "Bus";

            this.colScheduleBus.Name =
                "colScheduleBus";

            this.colScheduleBus.ReadOnly =
                true;

            this.colScheduleRoute.HeaderText =
                "Route";

            this.colScheduleRoute.Name =
                "colScheduleRoute";

            this.colScheduleRoute.ReadOnly =
                true;

            this.colScheduleTime.HeaderText =
                "Time";

            this.colScheduleTime.Name =
                "colScheduleTime";

            this.colScheduleTime.ReadOnly =
                true;

            this.colScheduleStatus.HeaderText =
                "Status";

            this.colScheduleStatus.Name =
                "colScheduleStatus";

            this.colScheduleStatus.ReadOnly =
                true;

            this.dgvTodaySchedule.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colScheduleBus,
                    this.colScheduleRoute,
                    this.colScheduleTime,
                    this.colScheduleStatus
                });

            // =========================================================
            // BOOKING OVERVIEW PANEL
            // =========================================================

            this.panelBookingOverview.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.panelBookingOverview.Location =
                new System.Drawing.Point(530, 220);

            this.panelBookingOverview.Name =
                "panelBookingOverview";

            this.panelBookingOverview.Size =
                new System.Drawing.Size(475, 410);

            // =========================================================
            // BOOKING TITLE
            // =========================================================

            this.lblBookingOverviewTitle.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.lblBookingOverviewTitle.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblBookingOverviewTitle.Location =
                new System.Drawing.Point(0, 0);

            this.lblBookingOverviewTitle.Name =
                "lblBookingOverviewTitle";

            this.lblBookingOverviewTitle.Size =
                new System.Drawing.Size(475, 38);

            this.lblBookingOverviewTitle.Text =
                "Booking Overview";

            this.lblBookingOverviewTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // =========================================================
            // BOOKING GRID
            // =========================================================

            this.dgvBookingOverview.AllowUserToAddRows =
                false;

            this.dgvBookingOverview.AllowUserToDeleteRows =
                false;

            this.dgvBookingOverview.AllowUserToResizeRows =
                false;

            this.dgvBookingOverview.AutoGenerateColumns =
                false;

            this.dgvBookingOverview.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvBookingOverview.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.dgvBookingOverview.ReadOnly =
                true;

            this.dgvBookingOverview.RowHeadersVisible =
                false;

            this.dgvBookingOverview.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvBookingOverview.MultiSelect =
                false;

            this.dgvBookingOverview.Name =
                "dgvBookingOverview";

            this.dgvBookingOverview.TabIndex =
                0;

            this.colBookingID.HeaderText =
                "Booking ID";

            this.colBookingID.Name =
                "colBookingID";

            this.colBookingID.ReadOnly =
                true;

            this.colBookingRoute.HeaderText =
                "Route";

            this.colBookingRoute.Name =
                "colBookingRoute";

            this.colBookingRoute.ReadOnly =
                true;

            this.colBookingDate.HeaderText =
                "Booking Date";

            this.colBookingDate.Name =
                "colBookingDate";

            this.colBookingDate.ReadOnly =
                true;

            this.colBookingSeats.HeaderText =
                "Seats";

            this.colBookingSeats.Name =
                "colBookingSeats";

            this.colBookingSeats.ReadOnly =
                true;

            this.colBookingStatus.HeaderText =
                "Status";

            this.colBookingStatus.Name =
                "colBookingStatus";

            this.colBookingStatus.ReadOnly =
                true;

            this.dgvBookingOverview.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colBookingID,
                    this.colBookingRoute,
                    this.colBookingDate,
                    this.colBookingSeats,
                    this.colBookingStatus
                });

            // =========================================================
            // ADD CONTROLS TO CARDS
            // =========================================================

            this.cardMyBuses.Controls.Add(
                this.lblMyBusesValue);

            this.cardMyBuses.Controls.Add(
                this.lblMyBusesTitle);

            this.cardActiveBuses.Controls.Add(
                this.lblActiveBusesValue);

            this.cardActiveBuses.Controls.Add(
                this.lblActiveBusesTitle);

            this.cardTotalRoutes.Controls.Add(
                this.lblTotalRoutesValue);

            this.cardTotalRoutes.Controls.Add(
                this.lblTotalRoutesTitle);

            this.cardTotalSchedules.Controls.Add(
                this.lblTodaysSchedulesValue);

            this.cardTotalSchedules.Controls.Add(
                this.lblTotalSchedulesTitle);

            this.cardTotalBookings.Controls.Add(
                this.lblTotalBookingsValue);

            this.cardTotalBookings.Controls.Add(
                this.lblTotalBookingsTitle);

            this.cardTotalSales.Controls.Add(
                this.lblTotalSalesValue);

            this.cardTotalSales.Controls.Add(
                this.lblTotalSalesTitle);

            // =========================================================
            // ADD GRID CONTROLS
            // =========================================================

            this.panelTodaySchedule.Controls.Add(
                this.dgvTodaySchedule);

            this.panelTodaySchedule.Controls.Add(
                this.lblTodayScheduleTitle);

            this.panelBookingOverview.Controls.Add(
                this.dgvBookingOverview);

            this.panelBookingOverview.Controls.Add(
                this.lblBookingOverviewTitle);

            // =========================================================
            // SIDEBAR
            // =========================================================

            this.panelSidebar.Controls.Add(
                this.btnLogout);

            this.panelSidebar.Controls.Add(
                this.btnPaymentsReports);

            this.panelSidebar.Controls.Add(
                this.btnBookings);

            this.panelSidebar.Controls.Add(
                this.btnRoutes);

            this.panelSidebar.Controls.Add(
                this.btnSchedules);

            this.panelSidebar.Controls.Add(
                this.btnBuses);

            this.panelSidebar.Controls.Add(
                this.btnDashboard);

            this.panelSidebar.Controls.Add(
                this.lblRole);

            this.panelSidebar.Controls.Add(
                this.lblLogo);

            // =========================================================
            // HEADER
            // =========================================================

            this.panelHeader.Controls.Add(
                this.label1);

            this.panelHeader.Controls.Add(
                this.lblDashboard);

            // =========================================================
            // CONTENT
            // =========================================================

            this.panelContent.Controls.Add(
                this.panelBookingOverview);

            this.panelContent.Controls.Add(
                this.panelTodaySchedule);

            this.panelContent.Controls.Add(
                this.cardTotalSales);

            this.panelContent.Controls.Add(
                this.cardTotalBookings);

            this.panelContent.Controls.Add(
                this.cardTotalSchedules);

            this.panelContent.Controls.Add(
                this.cardTotalRoutes);

            this.panelContent.Controls.Add(
                this.cardActiveBuses);

            this.panelContent.Controls.Add(
                this.cardMyBuses);

            // =========================================================
            // MAIN FORM
            // =========================================================

            this.Controls.Add(
                this.panelContent);

            this.Controls.Add(
                this.panelHeader);

            this.Controls.Add(
                this.panelSidebar);

            // =========================================================
            // RESUME
            // =========================================================

            this.panelSidebar.ResumeLayout(false);

            this.panelHeader.ResumeLayout(false);

            this.panelContent.ResumeLayout(false);

            this.cardMyBuses.ResumeLayout(false);

            this.cardActiveBuses.ResumeLayout(false);

            this.cardTotalRoutes.ResumeLayout(false);

            this.cardTotalSchedules.ResumeLayout(false);

            this.cardTotalBookings.ResumeLayout(false);

            this.cardTotalSales.ResumeLayout(false);

            this.panelTodaySchedule.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvTodaySchedule)).EndInit();

            this.panelBookingOverview.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvBookingOverview)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblRole;

        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Button btnBuses;
        private System.Windows.Forms.Button btnPaymentsReports;
        private System.Windows.Forms.Button btnBookings;
        private System.Windows.Forms.Button btnRoutes;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Panel cardMyBuses;
        private System.Windows.Forms.Label lblMyBusesTitle;
        private System.Windows.Forms.Label lblMyBusesValue;

        private System.Windows.Forms.Panel cardActiveBuses;
        private System.Windows.Forms.Label lblActiveBusesTitle;
        private System.Windows.Forms.Label lblActiveBusesValue;

        private System.Windows.Forms.Panel cardTotalRoutes;
        private System.Windows.Forms.Label lblTotalRoutesTitle;
        private System.Windows.Forms.Label lblTotalRoutesValue;

        private System.Windows.Forms.Panel cardTotalSchedules;
        private System.Windows.Forms.Label lblTotalSchedulesTitle;
        private System.Windows.Forms.Label lblTodaysSchedulesValue;

        private System.Windows.Forms.Panel cardTotalBookings;
        private System.Windows.Forms.Label lblTotalBookingsTitle;
        private System.Windows.Forms.Label lblTotalBookingsValue;

        private System.Windows.Forms.Panel cardTotalSales;
        private System.Windows.Forms.Label lblTotalSalesTitle;
        private System.Windows.Forms.Label lblTotalSalesValue;

        private System.Windows.Forms.Panel panelTodaySchedule;
        private System.Windows.Forms.Label lblTodayScheduleTitle;
        private System.Windows.Forms.DataGridView dgvTodaySchedule;

        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleBus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleStatus;

        private System.Windows.Forms.Panel panelBookingOverview;
        private System.Windows.Forms.Label lblBookingOverviewTitle;
        private System.Windows.Forms.DataGridView dgvBookingOverview;

        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingStatus;
    }
}