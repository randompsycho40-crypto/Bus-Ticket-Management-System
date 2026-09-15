namespace BusTicketManagementSystem
{
    partial class SeatSelection
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.panelBusInfo = new System.Windows.Forms.Panel();
            this.lblBusNumberTitle = new System.Windows.Forms.Label();
            this.lblBusNumber = new System.Windows.Forms.Label();
            this.lblRouteTitle = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblTravelDateTitle = new System.Windows.Forms.Label();
            this.lblTravelDate = new System.Windows.Forms.Label();
            this.lblFareTitle = new System.Windows.Forms.Label();
            this.lblFare = new System.Windows.Forms.Label();
            this.panelSeatArea = new System.Windows.Forms.Panel();
            this.flpSeats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSeatLayout = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblSelectedTitle = new System.Windows.Forms.Label();
            this.lblSelectedSeats = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelBusInfo.SuspendLayout();
            this.panelSeatArea.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblPageTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(1000, 70);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Select Seats";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Click += new System.EventHandler(this.lblPageTitle_Click);
            // 
            // panelBusInfo
            // 
            this.panelBusInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBusInfo.Controls.Add(this.lblBusNumberTitle);
            this.panelBusInfo.Controls.Add(this.lblBusNumber);
            this.panelBusInfo.Controls.Add(this.lblRouteTitle);
            this.panelBusInfo.Controls.Add(this.lblRoute);
            this.panelBusInfo.Controls.Add(this.lblTravelDateTitle);
            this.panelBusInfo.Controls.Add(this.lblTravelDate);
            this.panelBusInfo.Controls.Add(this.lblFareTitle);
            this.panelBusInfo.Controls.Add(this.lblFare);
            this.panelBusInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBusInfo.Location = new System.Drawing.Point(0, 70);
            this.panelBusInfo.Name = "panelBusInfo";
            this.panelBusInfo.Size = new System.Drawing.Size(1000, 115);
            this.panelBusInfo.TabIndex = 1;
            // 
            // lblBusNumberTitle
            // 
            this.lblBusNumberTitle.AutoSize = true;
            this.lblBusNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBusNumberTitle.Location = new System.Drawing.Point(20, 15);
            this.lblBusNumberTitle.Name = "lblBusNumberTitle";
            this.lblBusNumberTitle.Size = new System.Drawing.Size(123, 25);
            this.lblBusNumberTitle.TabIndex = 0;
            this.lblBusNumberTitle.Text = "Bus Number:";
            // 
            // lblBusNumber
            // 
            this.lblBusNumber.AutoSize = true;
            this.lblBusNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBusNumber.Location = new System.Drawing.Point(130, 14);
            this.lblBusNumber.Name = "lblBusNumber";
            this.lblBusNumber.Size = new System.Drawing.Size(20, 28);
            this.lblBusNumber.TabIndex = 1;
            this.lblBusNumber.Text = "-";
            // 
            // lblRouteTitle
            // 
            this.lblRouteTitle.AutoSize = true;
            this.lblRouteTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRouteTitle.Location = new System.Drawing.Point(320, 15);
            this.lblRouteTitle.Name = "lblRouteTitle";
            this.lblRouteTitle.Size = new System.Drawing.Size(68, 25);
            this.lblRouteTitle.TabIndex = 2;
            this.lblRouteTitle.Text = "Route:";
            this.lblRouteTitle.Click += new System.EventHandler(this.lblRouteTitle_Click);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoute.Location = new System.Drawing.Point(380, 14);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(20, 28);
            this.lblRoute.TabIndex = 3;
            this.lblRoute.Text = "-";
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // lblTravelDateTitle
            // 
            this.lblTravelDateTitle.AutoSize = true;
            this.lblTravelDateTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTravelDateTitle.Location = new System.Drawing.Point(20, 65);
            this.lblTravelDateTitle.Name = "lblTravelDateTitle";
            this.lblTravelDateTitle.Size = new System.Drawing.Size(114, 25);
            this.lblTravelDateTitle.TabIndex = 4;
            this.lblTravelDateTitle.Text = "Travel Date:";
            this.lblTravelDateTitle.Click += new System.EventHandler(this.lblTravelDateTitle_Click);
            // 
            // lblTravelDate
            // 
            this.lblTravelDate.AutoSize = true;
            this.lblTravelDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTravelDate.Location = new System.Drawing.Point(130, 64);
            this.lblTravelDate.Name = "lblTravelDate";
            this.lblTravelDate.Size = new System.Drawing.Size(20, 28);
            this.lblTravelDate.TabIndex = 5;
            this.lblTravelDate.Text = "-";
            this.lblTravelDate.Click += new System.EventHandler(this.lblTravelDate_Click);
            // 
            // lblFareTitle
            // 
            this.lblFareTitle.AutoSize = true;
            this.lblFareTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFareTitle.Location = new System.Drawing.Point(320, 65);
            this.lblFareTitle.Name = "lblFareTitle";
            this.lblFareTitle.Size = new System.Drawing.Size(52, 25);
            this.lblFareTitle.TabIndex = 6;
            this.lblFareTitle.Text = "Fare:";
            this.lblFareTitle.Click += new System.EventHandler(this.lblFareTitle_Click);
            // 
            // lblFare
            // 
            this.lblFare.AutoSize = true;
            this.lblFare.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFare.Location = new System.Drawing.Point(380, 64);
            this.lblFare.Name = "lblFare";
            this.lblFare.Size = new System.Drawing.Size(65, 28);
            this.lblFare.TabIndex = 7;
            this.lblFare.Text = "৳0.00";
            this.lblFare.Click += new System.EventHandler(this.lblFare_Click);
            // 
            // panelSeatArea
            // 
            this.panelSeatArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeatArea.Controls.Add(this.flpSeats);
            this.panelSeatArea.Controls.Add(this.lblSeatLayout);
            this.panelSeatArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSeatArea.Location = new System.Drawing.Point(0, 185);
            this.panelSeatArea.Name = "panelSeatArea";
            this.panelSeatArea.Padding = new System.Windows.Forms.Padding(20);
            this.panelSeatArea.Size = new System.Drawing.Size(1000, 300);
            this.panelSeatArea.TabIndex = 2;
            // 
            // flpSeats
            // 
            this.flpSeats.AutoScroll = true;
            this.flpSeats.Location = new System.Drawing.Point(20, 55);
            this.flpSeats.Name = "flpSeats";
            this.flpSeats.Size = new System.Drawing.Size(940, 220);
            this.flpSeats.TabIndex = 1;
            this.flpSeats.Paint += new System.Windows.Forms.PaintEventHandler(this.flpSeats_Paint);
            // 
            // lblSeatLayout
            // 
            this.lblSeatLayout.AutoSize = true;
            this.lblSeatLayout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeatLayout.Location = new System.Drawing.Point(20, 15);
            this.lblSeatLayout.Name = "lblSeatLayout";
            this.lblSeatLayout.Size = new System.Drawing.Size(188, 30);
            this.lblSeatLayout.TabIndex = 0;
            this.lblSeatLayout.Text = "Select Your Seats";
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.lblSelectedTitle);
            this.panelBottom.Controls.Add(this.lblSelectedSeats);
            this.panelBottom.Controls.Add(this.lblTotalTitle);
            this.panelBottom.Controls.Add(this.lblTotalAmount);
            this.panelBottom.Controls.Add(this.btnConfirm);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 485);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 115);
            this.panelBottom.TabIndex = 3;
            // 
            // lblSelectedTitle
            // 
            this.lblSelectedTitle.AutoSize = true;
            this.lblSelectedTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedTitle.Location = new System.Drawing.Point(20, 18);
            this.lblSelectedTitle.Name = "lblSelectedTitle";
            this.lblSelectedTitle.Size = new System.Drawing.Size(139, 25);
            this.lblSelectedTitle.TabIndex = 0;
            this.lblSelectedTitle.Text = "Selected Seats:";
            this.lblSelectedTitle.Click += new System.EventHandler(this.lblSelectedTitle_Click);
            // 
            // lblSelectedSeats
            // 
            this.lblSelectedSeats.AutoSize = true;
            this.lblSelectedSeats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelectedSeats.Location = new System.Drawing.Point(164, 18);
            this.lblSelectedSeats.Name = "lblSelectedSeats";
            this.lblSelectedSeats.Size = new System.Drawing.Size(60, 28);
            this.lblSelectedSeats.TabIndex = 1;
            this.lblSelectedSeats.Text = "None";
            this.lblSelectedSeats.Click += new System.EventHandler(this.lblSelectedSeats_Click);
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.Location = new System.Drawing.Point(20, 60);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(133, 25);
            this.lblTotalTitle.TabIndex = 2;
            this.lblTotalTitle.Text = "Total Amount:";
            this.lblTotalTitle.Click += new System.EventHandler(this.lblTotalTitle_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(145, 58);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(79, 30);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "৳0.00";
            this.lblTotalAmount.Click += new System.EventHandler(this.lblTotalAmount_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(650, 25);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(145, 45);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Continue";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(815, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 45);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SeatSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelSeatArea);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBusInfo);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SeatSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seat Selection";
            this.Load += new System.EventHandler(this.SeatSelection_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelBusInfo.ResumeLayout(false);
            this.panelBusInfo.PerformLayout();
            this.panelSeatArea.ResumeLayout(false);
            this.panelSeatArea.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;

        private System.Windows.Forms.Panel panelBusInfo;
        private System.Windows.Forms.Label lblBusNumberTitle;
        private System.Windows.Forms.Label lblBusNumber;
        private System.Windows.Forms.Label lblRouteTitle;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblTravelDateTitle;
        private System.Windows.Forms.Label lblTravelDate;
        private System.Windows.Forms.Label lblFareTitle;
        private System.Windows.Forms.Label lblFare;

        private System.Windows.Forms.Panel panelSeatArea;
        private System.Windows.Forms.Label lblSeatLayout;
        private System.Windows.Forms.FlowLayoutPanel flpSeats;

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblSelectedTitle;
        private System.Windows.Forms.Label lblSelectedSeats;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}