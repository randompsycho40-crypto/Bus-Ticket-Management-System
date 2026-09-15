
namespace BusTicketManagementSystem
{
    partial class MyBookings
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
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.panelAction = new System.Windows.Forms.Panel();
            this.btnShowBookings = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearchBooking = new System.Windows.Forms.Label();
            this.txtSearchBooking = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvMyBookings = new System.Windows.Forms.DataGridView();
            this.colBookingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTravelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblPageTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1078, 75);
            this.panelHeader.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(1078, 75);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "My Bookings";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnClear);
            this.panelAction.Controls.Add(this.btnCancelBooking);
            this.panelAction.Controls.Add(this.btnViewDetails);
            this.panelAction.Controls.Add(this.btnShowBookings);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAction.Location = new System.Drawing.Point(0, 75);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(1078, 65);
            this.panelAction.TabIndex = 1;
            // 
            // btnShowBookings
            // 
            this.btnShowBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBookings.Location = new System.Drawing.Point(12, 16);
            this.btnShowBookings.Name = "btnShowBookings";
            this.btnShowBookings.Size = new System.Drawing.Size(198, 35);
            this.btnShowBookings.TabIndex = 0;
            this.btnShowBookings.Text = "Show Bookings";
            this.btnShowBookings.UseVisualStyleBackColor = true;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.Location = new System.Drawing.Point(293, 16);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(198, 35);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBooking.Location = new System.Drawing.Point(574, 16);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(198, 35);
            this.btnCancelBooking.TabIndex = 2;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(845, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(198, 35);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearchBooking);
            this.panelSearch.Controls.Add(this.lblSearchBooking);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 140);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1078, 55);
            this.panelSearch.TabIndex = 2;
            // 
            // lblSearchBooking
            // 
            this.lblSearchBooking.AutoSize = true;
            this.lblSearchBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBooking.Location = new System.Drawing.Point(12, 13);
            this.lblSearchBooking.Name = "lblSearchBooking";
            this.lblSearchBooking.Size = new System.Drawing.Size(164, 28);
            this.lblSearchBooking.TabIndex = 0;
            this.lblSearchBooking.Text = "Search Booking:";
            // 
            // txtSearchBooking
            // 
            this.txtSearchBooking.Location = new System.Drawing.Point(182, 15);
            this.txtSearchBooking.Name = "txtSearchBooking";
            this.txtSearchBooking.Size = new System.Drawing.Size(325, 26);
            this.txtSearchBooking.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(529, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(167, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvMyBookings
            // 
            this.dgvMyBookings.AllowUserToAddRows = false;
            this.dgvMyBookings.AllowUserToDeleteRows = false;
            this.dgvMyBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookingID,
            this.colBusNumber,
            this.colRoute,
            this.colTravelDate,
            this.colDepartureTime,
            this.colSeats,
            this.colAmount,
            this.colBookingStatus});
            this.dgvMyBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyBookings.Location = new System.Drawing.Point(0, 195);
            this.dgvMyBookings.MultiSelect = false;
            this.dgvMyBookings.Name = "dgvMyBookings";
            this.dgvMyBookings.RowHeadersWidth = 62;
            this.dgvMyBookings.RowTemplate.Height = 28;
            this.dgvMyBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyBookings.Size = new System.Drawing.Size(1078, 399);
            this.dgvMyBookings.TabIndex = 3;
            // 
            // colBookingID
            // 
            this.colBookingID.HeaderText = "Booking ID";
            this.colBookingID.MinimumWidth = 8;
            this.colBookingID.Name = "colBookingID";
            // 
            // colBusNumber
            // 
            this.colBusNumber.HeaderText = "Bus Number";
            this.colBusNumber.MinimumWidth = 8;
            this.colBusNumber.Name = "colBusNumber";
            // 
            // colRoute
            // 
            this.colRoute.HeaderText = "Route";
            this.colRoute.MinimumWidth = 8;
            this.colRoute.Name = "colRoute";
            // 
            // colTravelDate
            // 
            this.colTravelDate.HeaderText = "Travel Date";
            this.colTravelDate.MinimumWidth = 8;
            this.colTravelDate.Name = "colTravelDate";
            // 
            // colDepartureTime
            // 
            this.colDepartureTime.HeaderText = "Departure Time";
            this.colDepartureTime.MinimumWidth = 8;
            this.colDepartureTime.Name = "colDepartureTime";
            // 
            // colSeats
            // 
            this.colSeats.HeaderText = "Seats";
            this.colSeats.MinimumWidth = 8;
            this.colSeats.Name = "colSeats";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.MinimumWidth = 8;
            this.colAmount.Name = "colAmount";
            // 
            // colBookingStatus
            // 
            this.colBookingStatus.HeaderText = "Status";
            this.colBookingStatus.MinimumWidth = 8;
            this.colBookingStatus.Name = "colBookingStatus";
            // 
            // MyBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.dgvMyBookings);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MyBookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Bookings";
            this.panelHeader.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button btnShowBookings;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearchBooking;
        private System.Windows.Forms.TextBox txtSearchBooking;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvMyBookings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTravelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookingStatus;
    }
}