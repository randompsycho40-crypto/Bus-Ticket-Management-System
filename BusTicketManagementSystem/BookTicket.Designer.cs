
namespace BusTicketManagementSystem
{
    partial class BookTicket
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
            this.panelBookingDetails = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirmBooking = new System.Windows.Forms.Button();
            this.nudSeats = new System.Windows.Forms.NumericUpDown();
            this.dtpTravelTime = new System.Windows.Forms.DateTimePicker();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtAvailableSeats = new System.Windows.Forms.TextBox();
            this.txtDepartureTime = new System.Windows.Forms.TextBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.txtBusNumber = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblDepartureTime = new System.Windows.Forms.Label();
            this.lblAvailableSeats = new System.Windows.Forms.Label();
            this.lblTravelDate = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblBusNumber = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelBookingDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeats)).BeginInit();
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
            this.lblPageTitle.Text = "Book Ticket";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Click += new System.EventHandler(this.lblPageTitle_Click);
            // 
            // panelBookingDetails
            // 
            this.panelBookingDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBookingDetails.Controls.Add(this.btnCancel);
            this.panelBookingDetails.Controls.Add(this.btnConfirmBooking);
            this.panelBookingDetails.Controls.Add(this.nudSeats);
            this.panelBookingDetails.Controls.Add(this.dtpTravelTime);
            this.panelBookingDetails.Controls.Add(this.txtTotalAmount);
            this.panelBookingDetails.Controls.Add(this.txtAvailableSeats);
            this.panelBookingDetails.Controls.Add(this.txtDepartureTime);
            this.panelBookingDetails.Controls.Add(this.txtRoute);
            this.panelBookingDetails.Controls.Add(this.txtBusNumber);
            this.panelBookingDetails.Controls.Add(this.lblTotalAmount);
            this.panelBookingDetails.Controls.Add(this.lblSeats);
            this.panelBookingDetails.Controls.Add(this.lblDepartureTime);
            this.panelBookingDetails.Controls.Add(this.lblAvailableSeats);
            this.panelBookingDetails.Controls.Add(this.lblTravelDate);
            this.panelBookingDetails.Controls.Add(this.lblRoute);
            this.panelBookingDetails.Controls.Add(this.lblBusNumber);
            this.panelBookingDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBookingDetails.Location = new System.Drawing.Point(0, 75);
            this.panelBookingDetails.Name = "panelBookingDetails";
            this.panelBookingDetails.Size = new System.Drawing.Size(1078, 250);
            this.panelBookingDetails.TabIndex = 1;
            this.panelBookingDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBookingDetails_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(536, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 49);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmBooking
            // 
            this.btnConfirmBooking.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmBooking.Location = new System.Drawing.Point(262, 196);
            this.btnConfirmBooking.Name = "btnConfirmBooking";
            this.btnConfirmBooking.Size = new System.Drawing.Size(153, 49);
            this.btnConfirmBooking.TabIndex = 14;
            this.btnConfirmBooking.Text = "Confirm Booking";
            this.btnConfirmBooking.UseVisualStyleBackColor = true;
            this.btnConfirmBooking.Click += new System.EventHandler(this.btnConfirmBooking_Click);
            // 
            // nudSeats
            // 
            this.nudSeats.Location = new System.Drawing.Point(713, 115);
            this.nudSeats.Name = "nudSeats";
            this.nudSeats.Size = new System.Drawing.Size(120, 26);
            this.nudSeats.TabIndex = 13;
            this.nudSeats.ValueChanged += new System.EventHandler(this.nudSeats_ValueChanged);
            // 
            // dtpTravelTime
            // 
            this.dtpTravelTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTravelTime.Location = new System.Drawing.Point(178, 68);
            this.dtpTravelTime.Name = "dtpTravelTime";
            this.dtpTravelTime.Size = new System.Drawing.Size(200, 26);
            this.dtpTravelTime.TabIndex = 12;
            this.dtpTravelTime.ValueChanged += new System.EventHandler(this.dtpTravelTime_ValueChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(178, 153);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(237, 26);
            this.txtTotalAmount.TabIndex = 11;
            this.txtTotalAmount.TextChanged += new System.EventHandler(this.txtTotalAmount_TextChanged);
            // 
            // txtAvailableSeats
            // 
            this.txtAvailableSeats.Location = new System.Drawing.Point(178, 114);
            this.txtAvailableSeats.Name = "txtAvailableSeats";
            this.txtAvailableSeats.Size = new System.Drawing.Size(237, 26);
            this.txtAvailableSeats.TabIndex = 10;
            this.txtAvailableSeats.TextChanged += new System.EventHandler(this.txtAvailableSeats_TextChanged);
            // 
            // txtDepartureTime
            // 
            this.txtDepartureTime.Location = new System.Drawing.Point(704, 62);
            this.txtDepartureTime.Name = "txtDepartureTime";
            this.txtDepartureTime.Size = new System.Drawing.Size(237, 26);
            this.txtDepartureTime.TabIndex = 9;
            this.txtDepartureTime.TextChanged += new System.EventHandler(this.txtDepartureTime_TextChanged);
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(623, 15);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(237, 26);
            this.txtRoute.TabIndex = 8;
            this.txtRoute.TextChanged += new System.EventHandler(this.txtRoute_TextChanged);
            // 
            // txtBusNumber
            // 
            this.txtBusNumber.Location = new System.Drawing.Point(178, 15);
            this.txtBusNumber.Name = "txtBusNumber";
            this.txtBusNumber.Size = new System.Drawing.Size(237, 26);
            this.txtBusNumber.TabIndex = 7;
            this.txtBusNumber.TextChanged += new System.EventHandler(this.txtBusNumber_TextChanged);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(11, 149);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(146, 28);
            this.lblTotalAmount.TabIndex = 6;
            this.lblTotalAmount.Text = "Total Amount:";
            this.lblTotalAmount.Click += new System.EventHandler(this.lblTotalAmount_Click);
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeats.Location = new System.Drawing.Point(531, 110);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(176, 28);
            this.lblSeats.TabIndex = 5;
            this.lblSeats.Text = "Number of Seats:";
            this.lblSeats.Click += new System.EventHandler(this.lblSeats_Click);
            // 
            // lblDepartureTime
            // 
            this.lblDepartureTime.AutoSize = true;
            this.lblDepartureTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureTime.Location = new System.Drawing.Point(531, 62);
            this.lblDepartureTime.Name = "lblDepartureTime";
            this.lblDepartureTime.Size = new System.Drawing.Size(167, 28);
            this.lblDepartureTime.TabIndex = 4;
            this.lblDepartureTime.Text = "Departure Time:";
            this.lblDepartureTime.Click += new System.EventHandler(this.lblDepartureTime_Click);
            // 
            // lblAvailableSeats
            // 
            this.lblAvailableSeats.AutoSize = true;
            this.lblAvailableSeats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableSeats.Location = new System.Drawing.Point(11, 110);
            this.lblAvailableSeats.Name = "lblAvailableSeats";
            this.lblAvailableSeats.Size = new System.Drawing.Size(161, 28);
            this.lblAvailableSeats.TabIndex = 3;
            this.lblAvailableSeats.Text = "Available Seats:";
            this.lblAvailableSeats.Click += new System.EventHandler(this.lblAvailableSeats_Click);
            // 
            // lblTravelDate
            // 
            this.lblTravelDate.AutoSize = true;
            this.lblTravelDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTravelDate.Location = new System.Drawing.Point(11, 66);
            this.lblTravelDate.Name = "lblTravelDate";
            this.lblTravelDate.Size = new System.Drawing.Size(125, 28);
            this.lblTravelDate.TabIndex = 2;
            this.lblTravelDate.Text = "Travel Date:";
            this.lblTravelDate.Click += new System.EventHandler(this.lblTravelDate_Click);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(531, 13);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(73, 28);
            this.lblRoute.TabIndex = 1;
            this.lblRoute.Text = "Route:";
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // lblBusNumber
            // 
            this.lblBusNumber.AutoSize = true;
            this.lblBusNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNumber.Location = new System.Drawing.Point(11, 11);
            this.lblBusNumber.Name = "lblBusNumber";
            this.lblBusNumber.Size = new System.Drawing.Size(135, 28);
            this.lblBusNumber.TabIndex = 0;
            this.lblBusNumber.Text = "Bus Number:";
            this.lblBusNumber.Click += new System.EventHandler(this.lblBusNumber_Click);
            // 
            // BookTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelBookingDetails);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BookTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Ticket";
            this.Load += new System.EventHandler(this.BookTicket_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelBookingDetails.ResumeLayout(false);
            this.panelBookingDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelBookingDetails;
        private System.Windows.Forms.Label lblBusNumber;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblTravelDate;
        private System.Windows.Forms.Label lblAvailableSeats;
        private System.Windows.Forms.Label lblDepartureTime;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtBusNumber;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtAvailableSeats;
        private System.Windows.Forms.TextBox txtDepartureTime;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.DateTimePicker dtpTravelTime;
        private System.Windows.Forms.NumericUpDown nudSeats;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirmBooking;
    }
}