
namespace BusTicketManagementSystem
{
    partial class SearchBuses
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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dptTravelDate = new System.Windows.Forms.DateTimePicker();
            this.lblTravelDate = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dgvBusResults = new System.Windows.Forms.DataGridView();
            this.colBusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailableSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusResults)).BeginInit();
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
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(1078, 75);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Search Buses";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Click += new System.EventHandler(this.lblPageTitle_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.dptTravelDate);
            this.panelSearch.Controls.Add(this.lblTravelDate);
            this.panelSearch.Controls.Add(this.txtTo);
            this.panelSearch.Controls.Add(this.lblTo);
            this.panelSearch.Controls.Add(this.txtFrom);
            this.panelSearch.Controls.Add(this.lblFrom);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 75);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1078, 100);
            this.panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(919, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 39);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dptTravelDate
            // 
            this.dptTravelDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptTravelDate.Location = new System.Drawing.Point(667, 44);
            this.dptTravelDate.Name = "dptTravelDate";
            this.dptTravelDate.Size = new System.Drawing.Size(200, 26);
            this.dptTravelDate.TabIndex = 5;
            this.dptTravelDate.ValueChanged += new System.EventHandler(this.dptTravelDate_ValueChanged);
            // 
            // lblTravelDate
            // 
            this.lblTravelDate.AutoSize = true;
            this.lblTravelDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTravelDate.Location = new System.Drawing.Point(525, 41);
            this.lblTravelDate.Name = "lblTravelDate";
            this.lblTravelDate.Size = new System.Drawing.Size(136, 30);
            this.lblTravelDate.TabIndex = 4;
            this.lblTravelDate.Text = "Travel Date:";
            this.lblTravelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTravelDate.Click += new System.EventHandler(this.lblTravelDate_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(342, 41);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(177, 26);
            this.txtTo.TabIndex = 3;
            this.txtTo.TextChanged += new System.EventHandler(this.txtTo_TextChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(293, 40);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(43, 30);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTo.Click += new System.EventHandler(this.lblTo_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(107, 40);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(165, 26);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(12, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(72, 30);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFrom.Click += new System.EventHandler(this.lblFrom_Click);
            // 
            // dgvBusResults
            // 
            this.dgvBusResults.AllowUserToAddRows = false;
            this.dgvBusResults.AllowUserToDeleteRows = false;
            this.dgvBusResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBusResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBusID,
            this.colBusNumber,
            this.colOperatorName,
            this.colRoute,
            this.colDepartureTime,
            this.colArrivalTime,
            this.colBusType,
            this.colFare,
            this.colAvailableSeats});
            this.dgvBusResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBusResults.Location = new System.Drawing.Point(0, 175);
            this.dgvBusResults.MultiSelect = false;
            this.dgvBusResults.Name = "dgvBusResults";
            this.dgvBusResults.ReadOnly = true;
            this.dgvBusResults.RowHeadersWidth = 62;
            this.dgvBusResults.RowTemplate.Height = 28;
            this.dgvBusResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusResults.Size = new System.Drawing.Size(1078, 419);
            this.dgvBusResults.TabIndex = 2;
            this.dgvBusResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusResults_CellContentClick);
            // 
            // colBusID
            // 
            this.colBusID.HeaderText = "Bus ID";
            this.colBusID.MinimumWidth = 8;
            this.colBusID.Name = "colBusID";
            this.colBusID.ReadOnly = true;
            // 
            // colBusNumber
            // 
            this.colBusNumber.HeaderText = "Bus Number";
            this.colBusNumber.MinimumWidth = 8;
            this.colBusNumber.Name = "colBusNumber";
            this.colBusNumber.ReadOnly = true;
            // 
            // colOperatorName
            // 
            this.colOperatorName.HeaderText = "Operator";
            this.colOperatorName.MinimumWidth = 8;
            this.colOperatorName.Name = "colOperatorName";
            this.colOperatorName.ReadOnly = true;
            // 
            // colRoute
            // 
            this.colRoute.HeaderText = "Route";
            this.colRoute.MinimumWidth = 8;
            this.colRoute.Name = "colRoute";
            this.colRoute.ReadOnly = true;
            // 
            // colDepartureTime
            // 
            this.colDepartureTime.HeaderText = "Departure Time";
            this.colDepartureTime.MinimumWidth = 8;
            this.colDepartureTime.Name = "colDepartureTime";
            this.colDepartureTime.ReadOnly = true;
            // 
            // colArrivalTime
            // 
            this.colArrivalTime.HeaderText = "Arrival Time";
            this.colArrivalTime.MinimumWidth = 8;
            this.colArrivalTime.Name = "colArrivalTime";
            this.colArrivalTime.ReadOnly = true;
            // 
            // colBusType
            // 
            this.colBusType.HeaderText = "Bus Type";
            this.colBusType.MinimumWidth = 8;
            this.colBusType.Name = "colBusType";
            this.colBusType.ReadOnly = true;
            // 
            // colFare
            // 
            this.colFare.HeaderText = "Fare";
            this.colFare.MinimumWidth = 8;
            this.colFare.Name = "colFare";
            this.colFare.ReadOnly = true;
            // 
            // colAvailableSeats
            // 
            this.colAvailableSeats.HeaderText = "Available Seats";
            this.colAvailableSeats.MinimumWidth = 8;
            this.colAvailableSeats.Name = "colAvailableSeats";
            this.colAvailableSeats.ReadOnly = true;
            // 
            // SearchBuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.dgvBusResults);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchBuses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Buses";
            this.Load += new System.EventHandler(this.SearchBuses_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dptTravelDate;
        private System.Windows.Forms.Label lblTravelDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBusResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailableSeats;
    }
}