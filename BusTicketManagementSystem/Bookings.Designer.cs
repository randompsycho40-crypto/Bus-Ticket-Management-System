
namespace BusTicketManagementSystem
{
    partial class Bookings
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelPageTitle = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnShowBookings = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSearchBooking = new System.Windows.Forms.Label();
            this.txtSearchBooking = new System.Windows.Forms.TextBox();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.colBookingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTravelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRouteDetails = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.dptTravelTime = new System.Windows.Forms.DateTimePicker();
            this.btnClearr = new System.Windows.Forms.Button();
            this.cmbBookingStatus = new System.Windows.Forms.ComboBox();
            this.lblBookingStatus = new System.Windows.Forms.Label();
            this.txtSeats = new System.Windows.Forms.TextBox();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblTravelTime = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblBusNumber = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.panelRouteDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelPageTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1078, 75);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.AutoSize = true;
            this.labelPageTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageTitle.Location = new System.Drawing.Point(0, 0);
            this.labelPageTitle.Name = "labelPageTitle";
            this.labelPageTitle.Size = new System.Drawing.Size(161, 45);
            this.labelPageTitle.TabIndex = 0;
            this.labelPageTitle.Text = "Bookings";
            this.labelPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnClear);
            this.panelActions.Controls.Add(this.btnViewDetails);
            this.panelActions.Controls.Add(this.btnShowBookings);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActions.Location = new System.Drawing.Point(0, 75);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1078, 65);
            this.panelActions.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(603, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(218, 56);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.Location = new System.Drawing.Point(291, 0);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(220, 65);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnShowBookings
            // 
            this.btnShowBookings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBookings.Location = new System.Drawing.Point(12, 3);
            this.btnShowBookings.Name = "btnShowBookings";
            this.btnShowBookings.Size = new System.Drawing.Size(205, 59);
            this.btnShowBookings.TabIndex = 0;
            this.btnShowBookings.Text = "Show Bookings";
            this.btnShowBookings.UseVisualStyleBackColor = true;
            this.btnShowBookings.Click += new System.EventHandler(this.btnShowBookings_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.lblSearchBooking);
            this.panelSearch.Controls.Add(this.txtSearchBooking);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 140);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1078, 55);
            this.panelSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(514, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 43);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblSearchBooking
            // 
            this.lblSearchBooking.AutoSize = true;
            this.lblSearchBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBooking.Location = new System.Drawing.Point(85, 25);
            this.lblSearchBooking.Name = "lblSearchBooking";
            this.lblSearchBooking.Size = new System.Drawing.Size(150, 25);
            this.lblSearchBooking.TabIndex = 3;
            this.lblSearchBooking.Text = "Search Booking:";
            this.lblSearchBooking.Click += new System.EventHandler(this.lblSearchBooking_Click);
            // 
            // txtSearchBooking
            // 
            this.txtSearchBooking.Location = new System.Drawing.Point(241, 24);
            this.txtSearchBooking.Name = "txtSearchBooking";
            this.txtSearchBooking.Size = new System.Drawing.Size(250, 26);
            this.txtSearchBooking.TabIndex = 2;
            this.txtSearchBooking.TextChanged += new System.EventHandler(this.txtSearchBooking_TextChanged);
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookingID,
            this.colCustomerName,
            this.colBusNumber,
            this.colRoute,
            this.colTravelDate,
            this.colSeats,
            this.colAmount,
            this.colBookingStatus});
            this.dgvBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookings.Location = new System.Drawing.Point(0, 195);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersWidth = 62;
            this.dgvBookings.RowTemplate.Height = 28;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(1078, 399);
            this.dgvBookings.TabIndex = 4;
            this.dgvBookings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookings_CellContentClick);
            // 
            // colBookingID
            // 
            this.colBookingID.HeaderText = "Booking ID";
            this.colBookingID.MinimumWidth = 8;
            this.colBookingID.Name = "colBookingID";
            this.colBookingID.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.HeaderText = "Customer Name";
            this.colCustomerName.MinimumWidth = 8;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colBusNumber
            // 
            this.colBusNumber.HeaderText = "Bus Number";
            this.colBusNumber.MinimumWidth = 8;
            this.colBusNumber.Name = "colBusNumber";
            this.colBusNumber.ReadOnly = true;
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
            // panelRouteDetails
            // 
            this.panelRouteDetails.Controls.Add(this.txtAmount);
            this.panelRouteDetails.Controls.Add(this.lblAmount);
            this.panelRouteDetails.Controls.Add(this.dptTravelTime);
            this.panelRouteDetails.Controls.Add(this.btnClearr);
            this.panelRouteDetails.Controls.Add(this.cmbBookingStatus);
            this.panelRouteDetails.Controls.Add(this.lblBookingStatus);
            this.panelRouteDetails.Controls.Add(this.txtSeats);
            this.panelRouteDetails.Controls.Add(this.lblSeats);
            this.panelRouteDetails.Controls.Add(this.lblTravelTime);
            this.panelRouteDetails.Controls.Add(this.txtRoute);
            this.panelRouteDetails.Controls.Add(this.lblRoute);
            this.panelRouteDetails.Controls.Add(this.txtTo);
            this.panelRouteDetails.Controls.Add(this.lblBusNumber);
            this.panelRouteDetails.Controls.Add(this.txtCustomerName);
            this.panelRouteDetails.Controls.Add(this.lblCustomerName);
            this.panelRouteDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRouteDetails.Location = new System.Drawing.Point(0, 404);
            this.panelRouteDetails.Name = "panelRouteDetails";
            this.panelRouteDetails.Size = new System.Drawing.Size(1078, 190);
            this.panelRouteDetails.TabIndex = 5;
            this.panelRouteDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRouteDetails_Paint);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(717, 82);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 26);
            this.txtAmount.TabIndex = 15;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(620, 83);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(91, 25);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "Amount: ";
            this.lblAmount.Click += new System.EventHandler(this.lblAmount_Click);
            // 
            // dptTravelTime
            // 
            this.dptTravelTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptTravelTime.Location = new System.Drawing.Point(140, 83);
            this.dptTravelTime.Name = "dptTravelTime";
            this.dptTravelTime.Size = new System.Drawing.Size(200, 26);
            this.dptTravelTime.TabIndex = 13;
            this.dptTravelTime.ValueChanged += new System.EventHandler(this.dptTravelTime_ValueChanged);
            // 
            // btnClearr
            // 
            this.btnClearr.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearr.Location = new System.Drawing.Point(915, 134);
            this.btnClearr.Name = "btnClearr";
            this.btnClearr.Size = new System.Drawing.Size(160, 40);
            this.btnClearr.TabIndex = 12;
            this.btnClearr.Text = "Clear";
            this.btnClearr.UseVisualStyleBackColor = true;
            this.btnClearr.Click += new System.EventHandler(this.btnClearr_Click);
            // 
            // cmbBookingStatus
            // 
            this.cmbBookingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookingStatus.FormattingEnabled = true;
            this.cmbBookingStatus.Items.AddRange(new object[] {
            "Confirmed",
            "Pending",
            "Cancelled"});
            this.cmbBookingStatus.Location = new System.Drawing.Point(177, 144);
            this.cmbBookingStatus.Name = "cmbBookingStatus";
            this.cmbBookingStatus.Size = new System.Drawing.Size(121, 28);
            this.cmbBookingStatus.TabIndex = 11;
            this.cmbBookingStatus.SelectedIndexChanged += new System.EventHandler(this.cmbBookingStatus_SelectedIndexChanged);
            // 
            // lblBookingStatus
            // 
            this.lblBookingStatus.AutoSize = true;
            this.lblBookingStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingStatus.Location = new System.Drawing.Point(20, 147);
            this.lblBookingStatus.Name = "lblBookingStatus";
            this.lblBookingStatus.Size = new System.Drawing.Size(151, 25);
            this.lblBookingStatus.TabIndex = 10;
            this.lblBookingStatus.Text = "Booking Status: ";
            this.lblBookingStatus.Click += new System.EventHandler(this.lblBookingStatus_Click);
            // 
            // txtSeats
            // 
            this.txtSeats.Location = new System.Drawing.Point(415, 86);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Size = new System.Drawing.Size(180, 26);
            this.txtSeats.TabIndex = 9;
            this.txtSeats.TextChanged += new System.EventHandler(this.txtSeats_TextChanged);
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeats.Location = new System.Drawing.Point(357, 85);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(67, 25);
            this.lblSeats.TabIndex = 8;
            this.lblSeats.Text = "Seats: ";
            this.lblSeats.Click += new System.EventHandler(this.lblSeats_Click);
            // 
            // lblTravelTime
            // 
            this.lblTravelTime.AutoSize = true;
            this.lblTravelTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTravelTime.Location = new System.Drawing.Point(13, 85);
            this.lblTravelTime.Name = "lblTravelTime";
            this.lblTravelTime.Size = new System.Drawing.Size(121, 25);
            this.lblTravelTime.TabIndex = 6;
            this.lblTravelTime.Text = "Travel Time: ";
            this.lblTravelTime.Click += new System.EventHandler(this.lblTravelTime_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(818, 21);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(180, 26);
            this.txtRoute.TabIndex = 5;
            this.txtRoute.TextChanged += new System.EventHandler(this.txtRoute_TextChanged);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(748, 21);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(73, 25);
            this.lblRoute.TabIndex = 4;
            this.lblRoute.Text = "Route: ";
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(526, 21);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(180, 26);
            this.txtTo.TabIndex = 3;
            this.txtTo.TextChanged += new System.EventHandler(this.txtTo_TextChanged);
            // 
            // lblBusNumber
            // 
            this.lblBusNumber.AutoSize = true;
            this.lblBusNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNumber.Location = new System.Drawing.Point(392, 21);
            this.lblBusNumber.Name = "lblBusNumber";
            this.lblBusNumber.Size = new System.Drawing.Size(128, 25);
            this.lblBusNumber.TabIndex = 2;
            this.lblBusNumber.Text = "Bus Number: ";
            this.lblBusNumber.Click += new System.EventHandler(this.lblBusNumber_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(172, 22);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(180, 26);
            this.txtCustomerName.TabIndex = 1;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(13, 24);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(158, 25);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name: ";
            this.lblCustomerName.Click += new System.EventHandler(this.lblCustomerName_Click);
            // 
            // Bookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelRouteDetails);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookings";
            this.Load += new System.EventHandler(this.Bookings_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.panelRouteDetails.ResumeLayout(false);
            this.panelRouteDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelPageTitle;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnShowBookings;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearchBooking;
        private System.Windows.Forms.Label lblSearchBooking;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTravelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingStatus;
        private System.Windows.Forms.Panel panelRouteDetails;
        private System.Windows.Forms.Button btnClearr;
        private System.Windows.Forms.ComboBox cmbBookingStatus;
        private System.Windows.Forms.Label lblBookingStatus;
        private System.Windows.Forms.TextBox txtSeats;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblTravelTime;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblBusNumber;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.DateTimePicker dptTravelTime;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
    }
}