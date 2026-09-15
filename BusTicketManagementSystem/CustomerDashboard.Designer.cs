
namespace BusTicketManagementSystem
{
    partial class CustomerDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnMyBookings = new System.Windows.Forms.Button();
            this.btnBookTicket = new System.Windows.Forms.Button();
            this.btnSearchBuses = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelRecentBookings = new System.Windows.Forms.Panel();
            this.dgvRecentBookings = new System.Windows.Forms.DataGridView();
            this.colBookingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTravelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRecentBookingsTitle = new System.Windows.Forms.Label();
            this.cardTotalSpent = new System.Windows.Forms.Panel();
            this.lblTotalSpentValue = new System.Windows.Forms.Label();
            this.lblTotalSpentTitle = new System.Windows.Forms.Label();
            this.cardCompletedTrips = new System.Windows.Forms.Panel();
            this.lblCompletedTripsValue = new System.Windows.Forms.Label();
            this.lblCompletedTripsTitle = new System.Windows.Forms.Label();
            this.cardTotalBookings = new System.Windows.Forms.Panel();
            this.lblTotalBookingsValue = new System.Windows.Forms.Label();
            this.lblTotalBookingsTitle = new System.Windows.Forms.Label();
            this.cardUpcomingTrips = new System.Windows.Forms.Panel();
            this.lblUpcomingTripsValue = new System.Windows.Forms.Label();
            this.lblUpcomingTripsTitle = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelRecentBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentBookings)).BeginInit();
            this.cardTotalSpent.SuspendLayout();
            this.cardCompletedTrips.SuspendLayout();
            this.cardTotalBookings.SuspendLayout();
            this.cardUpcomingTrips.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.lblWelcome);
            this.panelSidebar.Controls.Add(this.btnLogOut);
            this.panelSidebar.Controls.Add(this.btnPayments);
            this.panelSidebar.Controls.Add(this.btnMyBookings);
            this.panelSidebar.Controls.Add(this.btnBookTicket);
            this.panelSidebar.Controls.Add(this.btnSearchBuses);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.lblCustomer);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(214, 644);
            this.panelSidebar.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(8, 90);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(195, 28);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "welcome, customer";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogOut
            // 
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(3, 574);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(200, 40);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayments.Location = new System.Drawing.Point(0, 505);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(200, 40);
            this.btnPayments.TabIndex = 6;
            this.btnPayments.Text = "Payments";
            this.btnPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnMyBookings
            // 
            this.btnMyBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyBookings.Location = new System.Drawing.Point(0, 425);
            this.btnMyBookings.Name = "btnMyBookings";
            this.btnMyBookings.Size = new System.Drawing.Size(200, 40);
            this.btnMyBookings.TabIndex = 5;
            this.btnMyBookings.Text = "My Bookings";
            this.btnMyBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyBookings.UseVisualStyleBackColor = true;
            this.btnMyBookings.Click += new System.EventHandler(this.btnMyBookings_Click);
            // 
            // btnBookTicket
            // 
            this.btnBookTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookTicket.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookTicket.Location = new System.Drawing.Point(0, 339);
            this.btnBookTicket.Name = "btnBookTicket";
            this.btnBookTicket.Size = new System.Drawing.Size(200, 40);
            this.btnBookTicket.TabIndex = 4;
            this.btnBookTicket.Text = "Book Ticket";
            this.btnBookTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookTicket.UseVisualStyleBackColor = true;
            this.btnBookTicket.Click += new System.EventHandler(this.btnBookTicket_Click);
            // 
            // btnSearchBuses
            // 
            this.btnSearchBuses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBuses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBuses.Location = new System.Drawing.Point(0, 252);
            this.btnSearchBuses.Name = "btnSearchBuses";
            this.btnSearchBuses.Size = new System.Drawing.Size(200, 40);
            this.btnSearchBuses.TabIndex = 3;
            this.btnSearchBuses.Text = "Search Buses";
            this.btnSearchBuses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchBuses.UseVisualStyleBackColor = true;
            this.btnSearchBuses.Click += new System.EventHandler(this.btnSearchBuses_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Location = new System.Drawing.Point(0, 174);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(200, 40);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(34, 52);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(143, 38);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(64, 24);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(72, 28);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "BusGo";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelRecentBookings);
            this.panelContent.Controls.Add(this.cardTotalSpent);
            this.panelContent.Controls.Add(this.cardCompletedTrips);
            this.panelContent.Controls.Add(this.cardTotalBookings);
            this.panelContent.Controls.Add(this.cardUpcomingTrips);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(214, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(964, 644);
            this.panelContent.TabIndex = 1;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // panelRecentBookings
            // 
            this.panelRecentBookings.BackColor = System.Drawing.Color.White;
            this.panelRecentBookings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRecentBookings.Controls.Add(this.dgvRecentBookings);
            this.panelRecentBookings.Controls.Add(this.lblRecentBookingsTitle);
            this.panelRecentBookings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRecentBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelRecentBookings.Location = new System.Drawing.Point(20, 404);
            this.panelRecentBookings.Name = "panelRecentBookings";
            this.panelRecentBookings.Size = new System.Drawing.Size(924, 220);
            this.panelRecentBookings.TabIndex = 4;
            // 
            // dgvRecentBookings
            // 
            this.dgvRecentBookings.AllowUserToAddRows = false;
            this.dgvRecentBookings.AllowUserToDeleteRows = false;
            this.dgvRecentBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookingID,
            this.colRoute,
            this.colTravelDate,
            this.colSeats,
            this.colAmount,
            this.colBookingStatus});
            this.dgvRecentBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentBookings.Location = new System.Drawing.Point(0, 36);
            this.dgvRecentBookings.MultiSelect = false;
            this.dgvRecentBookings.Name = "dgvRecentBookings";
            this.dgvRecentBookings.ReadOnly = true;
            this.dgvRecentBookings.RowHeadersWidth = 62;
            this.dgvRecentBookings.RowTemplate.Height = 28;
            this.dgvRecentBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentBookings.Size = new System.Drawing.Size(922, 182);
            this.dgvRecentBookings.TabIndex = 6;
            this.dgvRecentBookings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecentBookings_CellContentClick);
            // 
            // colBookingID
            // 
            this.colBookingID.HeaderText = "Booking ID";
            this.colBookingID.MinimumWidth = 8;
            this.colBookingID.Name = "colBookingID";
            this.colBookingID.ReadOnly = true;
            // 
            // colRoute
            // 
            this.colRoute.HeaderText = "Route";
            this.colRoute.MinimumWidth = 8;
            this.colRoute.Name = "colRoute";
            this.colRoute.ReadOnly = true;
            // 
            // colTravelDate
            // 
            this.colTravelDate.HeaderText = "Travel Date";
            this.colTravelDate.MinimumWidth = 8;
            this.colTravelDate.Name = "colTravelDate";
            this.colTravelDate.ReadOnly = true;
            // 
            // colSeats
            // 
            this.colSeats.HeaderText = "Seats";
            this.colSeats.MinimumWidth = 8;
            this.colSeats.Name = "colSeats";
            this.colSeats.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.MinimumWidth = 8;
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colBookingStatus
            // 
            this.colBookingStatus.HeaderText = "Booking Status";
            this.colBookingStatus.MinimumWidth = 8;
            this.colBookingStatus.Name = "colBookingStatus";
            this.colBookingStatus.ReadOnly = true;
            // 
            // lblRecentBookingsTitle
            // 
            this.lblRecentBookingsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentBookingsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentBookingsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblRecentBookingsTitle.Name = "lblRecentBookingsTitle";
            this.lblRecentBookingsTitle.Size = new System.Drawing.Size(922, 36);
            this.lblRecentBookingsTitle.TabIndex = 5;
            this.lblRecentBookingsTitle.Text = "Recent Bookings";
            this.lblRecentBookingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRecentBookingsTitle.Click += new System.EventHandler(this.lblRecentBookingsTitle_Click);
            // 
            // cardTotalSpent
            // 
            this.cardTotalSpent.BackColor = System.Drawing.Color.White;
            this.cardTotalSpent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotalSpent.Controls.Add(this.lblTotalSpentValue);
            this.cardTotalSpent.Controls.Add(this.lblTotalSpentTitle);
            this.cardTotalSpent.Location = new System.Drawing.Point(696, 182);
            this.cardTotalSpent.Name = "cardTotalSpent";
            this.cardTotalSpent.Size = new System.Drawing.Size(250, 110);
            this.cardTotalSpent.TabIndex = 3;
            this.cardTotalSpent.Paint += new System.Windows.Forms.PaintEventHandler(this.cardTotalSpent_Paint);
            // 
            // lblTotalSpentValue
            // 
            this.lblTotalSpentValue.AutoSize = true;
            this.lblTotalSpentValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSpentValue.Location = new System.Drawing.Point(108, 51);
            this.lblTotalSpentValue.Name = "lblTotalSpentValue";
            this.lblTotalSpentValue.Size = new System.Drawing.Size(38, 45);
            this.lblTotalSpentValue.TabIndex = 2;
            this.lblTotalSpentValue.Text = "0";
            this.lblTotalSpentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalSpentValue.Click += new System.EventHandler(this.lblTotalSpentValue_Click);
            // 
            // lblTotalSpentTitle
            // 
            this.lblTotalSpentTitle.AutoSize = true;
            this.lblTotalSpentTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSpentTitle.Location = new System.Drawing.Point(63, 8);
            this.lblTotalSpentTitle.Name = "lblTotalSpentTitle";
            this.lblTotalSpentTitle.Size = new System.Drawing.Size(119, 28);
            this.lblTotalSpentTitle.TabIndex = 1;
            this.lblTotalSpentTitle.Text = "Total Spent";
            this.lblTotalSpentTitle.Click += new System.EventHandler(this.lblTotalSpentTitle_Click);
            // 
            // cardCompletedTrips
            // 
            this.cardCompletedTrips.BackColor = System.Drawing.Color.White;
            this.cardCompletedTrips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardCompletedTrips.Controls.Add(this.lblCompletedTripsValue);
            this.cardCompletedTrips.Controls.Add(this.lblCompletedTripsTitle);
            this.cardCompletedTrips.Location = new System.Drawing.Point(23, 182);
            this.cardCompletedTrips.Name = "cardCompletedTrips";
            this.cardCompletedTrips.Size = new System.Drawing.Size(250, 110);
            this.cardCompletedTrips.TabIndex = 2;
            this.cardCompletedTrips.Paint += new System.Windows.Forms.PaintEventHandler(this.cardCompletedTrips_Paint);
            // 
            // lblCompletedTripsValue
            // 
            this.lblCompletedTripsValue.AutoSize = true;
            this.lblCompletedTripsValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedTripsValue.Location = new System.Drawing.Point(94, 55);
            this.lblCompletedTripsValue.Name = "lblCompletedTripsValue";
            this.lblCompletedTripsValue.Size = new System.Drawing.Size(38, 45);
            this.lblCompletedTripsValue.TabIndex = 2;
            this.lblCompletedTripsValue.Text = "0";
            this.lblCompletedTripsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCompletedTripsValue.Click += new System.EventHandler(this.lblCompletedTripsValue_Click);
            // 
            // lblCompletedTripsTitle
            // 
            this.lblCompletedTripsTitle.AutoSize = true;
            this.lblCompletedTripsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedTripsTitle.Location = new System.Drawing.Point(35, 0);
            this.lblCompletedTripsTitle.Name = "lblCompletedTripsTitle";
            this.lblCompletedTripsTitle.Size = new System.Drawing.Size(165, 28);
            this.lblCompletedTripsTitle.TabIndex = 1;
            this.lblCompletedTripsTitle.Text = "Completed Trips";
            this.lblCompletedTripsTitle.Click += new System.EventHandler(this.lblCompletedTripsTitle_Click);
            // 
            // cardTotalBookings
            // 
            this.cardTotalBookings.BackColor = System.Drawing.Color.White;
            this.cardTotalBookings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotalBookings.Controls.Add(this.lblTotalBookingsValue);
            this.cardTotalBookings.Controls.Add(this.lblTotalBookingsTitle);
            this.cardTotalBookings.Location = new System.Drawing.Point(696, 52);
            this.cardTotalBookings.Name = "cardTotalBookings";
            this.cardTotalBookings.Size = new System.Drawing.Size(250, 110);
            this.cardTotalBookings.TabIndex = 1;
            this.cardTotalBookings.Paint += new System.Windows.Forms.PaintEventHandler(this.cardTotalBookings_Paint);
            // 
            // lblTotalBookingsValue
            // 
            this.lblTotalBookingsValue.AutoSize = true;
            this.lblTotalBookingsValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBookingsValue.Location = new System.Drawing.Point(108, 49);
            this.lblTotalBookingsValue.Name = "lblTotalBookingsValue";
            this.lblTotalBookingsValue.Size = new System.Drawing.Size(38, 45);
            this.lblTotalBookingsValue.TabIndex = 5;
            this.lblTotalBookingsValue.Text = "0";
            this.lblTotalBookingsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalBookingsValue.Click += new System.EventHandler(this.lblTotalBookingsValue_Click);
            // 
            // lblTotalBookingsTitle
            // 
            this.lblTotalBookingsTitle.AutoSize = true;
            this.lblTotalBookingsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBookingsTitle.Location = new System.Drawing.Point(51, 9);
            this.lblTotalBookingsTitle.Name = "lblTotalBookingsTitle";
            this.lblTotalBookingsTitle.Size = new System.Drawing.Size(152, 28);
            this.lblTotalBookingsTitle.TabIndex = 4;
            this.lblTotalBookingsTitle.Text = "Total Bookings";
            this.lblTotalBookingsTitle.Click += new System.EventHandler(this.lblTotalBookingsTitle_Click);
            // 
            // cardUpcomingTrips
            // 
            this.cardUpcomingTrips.BackColor = System.Drawing.Color.White;
            this.cardUpcomingTrips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardUpcomingTrips.Controls.Add(this.lblUpcomingTripsValue);
            this.cardUpcomingTrips.Controls.Add(this.lblUpcomingTripsTitle);
            this.cardUpcomingTrips.Location = new System.Drawing.Point(23, 52);
            this.cardUpcomingTrips.Name = "cardUpcomingTrips";
            this.cardUpcomingTrips.Size = new System.Drawing.Size(250, 110);
            this.cardUpcomingTrips.TabIndex = 0;
            this.cardUpcomingTrips.Paint += new System.Windows.Forms.PaintEventHandler(this.cardUpcomingTrips_Paint);
            // 
            // lblUpcomingTripsValue
            // 
            this.lblUpcomingTripsValue.AutoSize = true;
            this.lblUpcomingTripsValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingTripsValue.Location = new System.Drawing.Point(94, 49);
            this.lblUpcomingTripsValue.Name = "lblUpcomingTripsValue";
            this.lblUpcomingTripsValue.Size = new System.Drawing.Size(38, 45);
            this.lblUpcomingTripsValue.TabIndex = 1;
            this.lblUpcomingTripsValue.Text = "0";
            this.lblUpcomingTripsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUpcomingTripsValue.Click += new System.EventHandler(this.lblUpcomingTripsValue_Click);
            // 
            // lblUpcomingTripsTitle
            // 
            this.lblUpcomingTripsTitle.AutoSize = true;
            this.lblUpcomingTripsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingTripsTitle.Location = new System.Drawing.Point(35, 9);
            this.lblUpcomingTripsTitle.Name = "lblUpcomingTripsTitle";
            this.lblUpcomingTripsTitle.Size = new System.Drawing.Size(159, 28);
            this.lblUpcomingTripsTitle.TabIndex = 0;
            this.lblUpcomingTripsTitle.Text = "Upcoming Trips";
            this.lblUpcomingTripsTitle.Click += new System.EventHandler(this.lblUpcomingTripsTitle_Click);
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Dashboard";
            this.Load += new System.EventHandler(this.CustomerDashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelRecentBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentBookings)).EndInit();
            this.cardTotalSpent.ResumeLayout(false);
            this.cardTotalSpent.PerformLayout();
            this.cardCompletedTrips.ResumeLayout(false);
            this.cardCompletedTrips.PerformLayout();
            this.cardTotalBookings.ResumeLayout(false);
            this.cardTotalBookings.PerformLayout();
            this.cardUpcomingTrips.ResumeLayout(false);
            this.cardUpcomingTrips.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnBookTicket;
        private System.Windows.Forms.Button btnSearchBuses;
        private System.Windows.Forms.Button btnMyBookings;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel cardUpcomingTrips;
        private System.Windows.Forms.Panel cardTotalSpent;
        private System.Windows.Forms.Panel cardCompletedTrips;
        private System.Windows.Forms.Panel cardTotalBookings;
        private System.Windows.Forms.Label lblUpcomingTripsTitle;
        private System.Windows.Forms.Label lblTotalSpentTitle;
        private System.Windows.Forms.Label lblCompletedTripsTitle;
        private System.Windows.Forms.Label lblTotalBookingsTitle;
        private System.Windows.Forms.Label lblUpcomingTripsValue;
        private System.Windows.Forms.Label lblTotalSpentValue;
        private System.Windows.Forms.Label lblCompletedTripsValue;
        private System.Windows.Forms.Label lblTotalBookingsValue;
        private System.Windows.Forms.Panel panelRecentBookings;
        private System.Windows.Forms.Label lblRecentBookingsTitle;
        private System.Windows.Forms.DataGridView dgvRecentBookings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTravelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingStatus;
    }
}