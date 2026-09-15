
namespace BusTicketManagementSystem
{
    partial class Schedules
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
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnShowSchedules = new System.Windows.Forms.Button();
            this.btnEditSchedule = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchSchedule = new System.Windows.Forms.TextBox();
            this.lblSeachSchedule = new System.Windows.Forms.Label();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.colScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelScheduleDetails = new System.Windows.Forms.Panel();
            this.dptDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.lbpdtDate = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmdStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.lblArrivalTime = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.cmbRoute = new System.Windows.Forms.ComboBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.cmbBusNumber = new System.Windows.Forms.ComboBox();
            this.lblBusNumber = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.panelScheduleDetails.SuspendLayout();
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
            this.lblPageTitle.Text = "Schedules";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnDeleteSchedule);
            this.panelActions.Controls.Add(this.btnShowSchedules);
            this.panelActions.Controls.Add(this.btnEditSchedule);
            this.panelActions.Controls.Add(this.btnAddSchedule);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActions.Location = new System.Drawing.Point(0, 75);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1078, 65);
            this.panelActions.TabIndex = 1;
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.BackColor = System.Drawing.Color.White;
            this.btnDeleteSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSchedule.Location = new System.Drawing.Point(550, 16);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(215, 46);
            this.btnDeleteSchedule.TabIndex = 4;
            this.btnDeleteSchedule.Text = "Delete Schedule";
            this.btnDeleteSchedule.UseVisualStyleBackColor = false;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnShowSchedules
            // 
            this.btnShowSchedules.BackColor = System.Drawing.Color.White;
            this.btnShowSchedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowSchedules.Location = new System.Drawing.Point(860, 16);
            this.btnShowSchedules.Name = "btnShowSchedules";
            this.btnShowSchedules.Size = new System.Drawing.Size(215, 46);
            this.btnShowSchedules.TabIndex = 3;
            this.btnShowSchedules.Text = "Show Schedules";
            this.btnShowSchedules.UseVisualStyleBackColor = false;
            this.btnShowSchedules.Click += new System.EventHandler(this.btnShowSchedules_Click);
            // 
            // btnEditSchedule
            // 
            this.btnEditSchedule.BackColor = System.Drawing.Color.White;
            this.btnEditSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSchedule.Location = new System.Drawing.Point(271, 16);
            this.btnEditSchedule.Name = "btnEditSchedule";
            this.btnEditSchedule.Size = new System.Drawing.Size(215, 46);
            this.btnEditSchedule.TabIndex = 2;
            this.btnEditSchedule.Text = "Edit Schedule";
            this.btnEditSchedule.UseVisualStyleBackColor = false;
            this.btnEditSchedule.Click += new System.EventHandler(this.btnEditSchedule_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.BackColor = System.Drawing.Color.White;
            this.btnAddSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSchedule.Location = new System.Drawing.Point(8, 16);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(215, 46);
            this.btnAddSchedule.TabIndex = 0;
            this.btnAddSchedule.Text = "Add Schedule";
            this.btnAddSchedule.UseVisualStyleBackColor = false;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearchSchedule);
            this.panelSearch.Controls.Add(this.lblSeachSchedule);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 140);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1078, 55);
            this.panelSearch.TabIndex = 2;
            this.panelSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSearch_Paint);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(452, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 43);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchSchedule
            // 
            this.txtSearchSchedule.Location = new System.Drawing.Point(196, 12);
            this.txtSearchSchedule.Name = "txtSearchSchedule";
            this.txtSearchSchedule.Size = new System.Drawing.Size(250, 26);
            this.txtSearchSchedule.TabIndex = 1;
            this.txtSearchSchedule.TextChanged += new System.EventHandler(this.txtSearchSchedule_TextChanged);
            // 
            // lblSeachSchedule
            // 
            this.lblSeachSchedule.AutoSize = true;
            this.lblSeachSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeachSchedule.Location = new System.Drawing.Point(22, 13);
            this.lblSeachSchedule.Name = "lblSeachSchedule";
            this.lblSeachSchedule.Size = new System.Drawing.Size(168, 22);
            this.lblSeachSchedule.TabIndex = 0;
            this.lblSeachSchedule.Text = "Search Schedule:";
            this.lblSeachSchedule.Click += new System.EventHandler(this.lblSeachSchedule_Click);
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScheduleID,
            this.colDepartureDate,
            this.colDepartureTime,
            this.colArrivalTime,
            this.colStatus,
            this.colBusNumber,
            this.colRoute});
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.Location = new System.Drawing.Point(0, 195);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersWidth = 62;
            this.dgvSchedule.RowTemplate.Height = 28;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1078, 549);
            this.dgvSchedule.TabIndex = 3;
            this.dgvSchedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellContentClick);
            // 
            // colScheduleID
            // 
            this.colScheduleID.HeaderText = "Schedule ID";
            this.colScheduleID.MinimumWidth = 8;
            this.colScheduleID.Name = "colScheduleID";
            this.colScheduleID.ReadOnly = true;
            // 
            // colDepartureDate
            // 
            this.colDepartureDate.HeaderText = "Departure Date";
            this.colDepartureDate.MinimumWidth = 8;
            this.colDepartureDate.Name = "colDepartureDate";
            this.colDepartureDate.ReadOnly = true;
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
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
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
            // panelScheduleDetails
            // 
            this.panelScheduleDetails.Controls.Add(this.dptDepartureDate);
            this.panelScheduleDetails.Controls.Add(this.lbpdtDate);
            this.panelScheduleDetails.Controls.Add(this.btnClear);
            this.panelScheduleDetails.Controls.Add(this.cmdStatus);
            this.panelScheduleDetails.Controls.Add(this.lblStatus);
            this.panelScheduleDetails.Controls.Add(this.dtpArrivalTime);
            this.panelScheduleDetails.Controls.Add(this.lblArrivalTime);
            this.panelScheduleDetails.Controls.Add(this.dateTimePicker1);
            this.panelScheduleDetails.Controls.Add(this.lblDepartureDate);
            this.panelScheduleDetails.Controls.Add(this.cmbRoute);
            this.panelScheduleDetails.Controls.Add(this.lblRoute);
            this.panelScheduleDetails.Controls.Add(this.cmbBusNumber);
            this.panelScheduleDetails.Controls.Add(this.lblBusNumber);
            this.panelScheduleDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelScheduleDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelScheduleDetails.Location = new System.Drawing.Point(0, 554);
            this.panelScheduleDetails.Name = "panelScheduleDetails";
            this.panelScheduleDetails.Size = new System.Drawing.Size(1078, 190);
            this.panelScheduleDetails.TabIndex = 4;
            // 
            // dptDepartureDate
            // 
            this.dptDepartureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptDepartureDate.Location = new System.Drawing.Point(791, 73);
            this.dptDepartureDate.Name = "dptDepartureDate";
            this.dptDepartureDate.Size = new System.Drawing.Size(200, 31);
            this.dptDepartureDate.TabIndex = 12;
            this.dptDepartureDate.ValueChanged += new System.EventHandler(this.dptDepartureDate_ValueChanged);
            // 
            // lbpdtDate
            // 
            this.lbpdtDate.AutoSize = true;
            this.lbpdtDate.Location = new System.Drawing.Point(624, 79);
            this.lbpdtDate.Name = "lbpdtDate";
            this.lbpdtDate.Size = new System.Drawing.Size(149, 25);
            this.lbpdtDate.TabIndex = 11;
            this.lbpdtDate.Text = "Departure Date:";
            this.lbpdtDate.Click += new System.EventHandler(this.lbpdtDate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(957, 133);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 45);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmdStatus
            // 
            this.cmdStatus.AllowDrop = true;
            this.cmdStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdStatus.FormattingEnabled = true;
            this.cmdStatus.Location = new System.Drawing.Point(479, 79);
            this.cmdStatus.Name = "cmdStatus";
            this.cmdStatus.Size = new System.Drawing.Size(121, 33);
            this.cmdStatus.TabIndex = 9;
            this.cmdStatus.SelectedIndexChanged += new System.EventHandler(this.cmdStatus_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(396, 86);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 25);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // dtpArrivalTime
            // 
            this.dtpArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpArrivalTime.Location = new System.Drawing.Point(163, 81);
            this.dtpArrivalTime.Name = "dtpArrivalTime";
            this.dtpArrivalTime.Size = new System.Drawing.Size(200, 31);
            this.dtpArrivalTime.TabIndex = 7;
            this.dtpArrivalTime.ValueChanged += new System.EventHandler(this.dtpArrivalTime_ValueChanged);
            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.AutoSize = true;
            this.lblArrivalTime.Location = new System.Drawing.Point(22, 81);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(121, 25);
            this.lblArrivalTime.TabIndex = 6;
            this.lblArrivalTime.Text = "Arrival Time:";
            this.lblArrivalTime.Click += new System.EventHandler(this.lblArrivalTime_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(731, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 31);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.AutoSize = true;
            this.lblDepartureDate.Location = new System.Drawing.Point(574, 34);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(151, 25);
            this.lblDepartureDate.TabIndex = 4;
            this.lblDepartureDate.Text = "Departure Time:";
            this.lblDepartureDate.Click += new System.EventHandler(this.lblDepartureDate_Click);
            // 
            // cmbRoute
            // 
            this.cmbRoute.AllowDrop = true;
            this.cmbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoute.FormattingEnabled = true;
            this.cmbRoute.Location = new System.Drawing.Point(401, 26);
            this.cmbRoute.Name = "cmbRoute";
            this.cmbRoute.Size = new System.Drawing.Size(121, 33);
            this.cmbRoute.TabIndex = 3;
            this.cmbRoute.SelectedIndexChanged += new System.EventHandler(this.cmbRoute_SelectedIndexChanged);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Location = new System.Drawing.Point(314, 29);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(68, 25);
            this.lblRoute.TabIndex = 2;
            this.lblRoute.Text = "Route:";
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // cmbBusNumber
            // 
            this.cmbBusNumber.AllowDrop = true;
            this.cmbBusNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusNumber.FormattingEnabled = true;
            this.cmbBusNumber.Location = new System.Drawing.Point(151, 26);
            this.cmbBusNumber.Name = "cmbBusNumber";
            this.cmbBusNumber.Size = new System.Drawing.Size(121, 33);
            this.cmbBusNumber.TabIndex = 1;
            this.cmbBusNumber.SelectedIndexChanged += new System.EventHandler(this.cmbBusNumber_SelectedIndexChanged);
            // 
            // lblBusNumber
            // 
            this.lblBusNumber.AutoSize = true;
            this.lblBusNumber.Location = new System.Drawing.Point(22, 29);
            this.lblBusNumber.Name = "lblBusNumber";
            this.lblBusNumber.Size = new System.Drawing.Size(123, 25);
            this.lblBusNumber.TabIndex = 0;
            this.lblBusNumber.Text = "Bus Number:";
            this.lblBusNumber.Click += new System.EventHandler(this.lblBusNumber_Click);
            // 
            // Schedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 744);
            this.Controls.Add(this.panelScheduleDetails);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Schedules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedules";
            this.Load += new System.EventHandler(this.Schedules_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.panelScheduleDetails.ResumeLayout(false);
            this.panelScheduleDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnEditSchedule;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnShowSchedules;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSeachSchedule;
        private System.Windows.Forms.TextBox txtSearchSchedule;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.Panel panelScheduleDetails;
        private System.Windows.Forms.Label lblBusNumber;
        private System.Windows.Forms.ComboBox cmbBusNumber;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ComboBox cmbRoute;
        private System.Windows.Forms.Label lblDepartureDate;
        private System.Windows.Forms.Label lblArrivalTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DateTimePicker dtpArrivalTime;
        private System.Windows.Forms.ComboBox cmdStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbpdtDate;
        private System.Windows.Forms.DateTimePicker dptDepartureDate;
    }
}