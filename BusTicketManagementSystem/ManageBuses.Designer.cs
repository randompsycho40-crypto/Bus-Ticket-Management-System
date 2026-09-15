
namespace BusTicketManagementSystem
{
    partial class ManageBuses
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
            this.btnShowBuses = new System.Windows.Forms.Button();
            this.btnDeleteBus = new System.Windows.Forms.Button();
            this.btnEditBus = new System.Windows.Forms.Button();
            this.btnAddBus = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBus = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvBuses = new System.Windows.Forms.DataGridView();
            this.colBusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBusDetails = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtFare = new System.Windows.Forms.TextBox();
            this.lblFare = new System.Windows.Forms.Label();
            this.txtTotalSeats = new System.Windows.Forms.TextBox();
            this.lblTotalSeats = new System.Windows.Forms.Label();
            this.txtBusType = new System.Windows.Forms.TextBox();
            this.lblBusType = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.txtBusNumber = new System.Windows.Forms.TextBox();
            this.lblBusNumber = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).BeginInit();
            this.panelBusDetails.SuspendLayout();
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
            this.lblPageTitle.Text = "Manage Buses";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Click += new System.EventHandler(this.lblPageTitle_Click);
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnShowBuses);
            this.panelActions.Controls.Add(this.btnDeleteBus);
            this.panelActions.Controls.Add(this.btnEditBus);
            this.panelActions.Controls.Add(this.btnAddBus);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActions.Location = new System.Drawing.Point(0, 75);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1078, 65);
            this.panelActions.TabIndex = 1;
            // 
            // btnShowBuses
            // 
            this.btnShowBuses.Location = new System.Drawing.Point(925, 6);
            this.btnShowBuses.Name = "btnShowBuses";
            this.btnShowBuses.Size = new System.Drawing.Size(120, 37);
            this.btnShowBuses.TabIndex = 3;
            this.btnShowBuses.Text = "Show Buses";
            this.btnShowBuses.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBus
            // 
            this.btnDeleteBus.Location = new System.Drawing.Point(627, 6);
            this.btnDeleteBus.Name = "btnDeleteBus";
            this.btnDeleteBus.Size = new System.Drawing.Size(120, 37);
            this.btnDeleteBus.TabIndex = 2;
            this.btnDeleteBus.Text = "Delete Bus";
            this.btnDeleteBus.UseVisualStyleBackColor = true;
            // 
            // btnEditBus
            // 
            this.btnEditBus.Location = new System.Drawing.Point(319, 6);
            this.btnEditBus.Name = "btnEditBus";
            this.btnEditBus.Size = new System.Drawing.Size(120, 37);
            this.btnEditBus.TabIndex = 1;
            this.btnEditBus.Text = "Edit Bus";
            this.btnEditBus.UseVisualStyleBackColor = true;
            // 
            // btnAddBus
            // 
            this.btnAddBus.Location = new System.Drawing.Point(25, 6);
            this.btnAddBus.Name = "btnAddBus";
            this.btnAddBus.Size = new System.Drawing.Size(120, 37);
            this.btnAddBus.TabIndex = 0;
            this.btnAddBus.Text = "Add Bus";
            this.btnAddBus.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearchBus);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 140);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1078, 55);
            this.panelSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(627, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 42);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchBus
            // 
            this.txtSearchBus.Location = new System.Drawing.Point(113, 7);
            this.txtSearchBus.Name = "txtSearchBus";
            this.txtSearchBus.Size = new System.Drawing.Size(326, 26);
            this.txtSearchBus.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(21, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(86, 28);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search: ";
            // 
            // dgvBuses
            // 
            this.dgvBuses.AllowUserToAddRows = false;
            this.dgvBuses.AllowUserToDeleteRows = false;
            this.dgvBuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBusID,
            this.colBusNumber,
            this.colOperatorName,
            this.colRoute,
            this.colBusType,
            this.colTotalSeats,
            this.colFare,
            this.colStatus});
            this.dgvBuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuses.Location = new System.Drawing.Point(0, 195);
            this.dgvBuses.MultiSelect = false;
            this.dgvBuses.Name = "dgvBuses";
            this.dgvBuses.ReadOnly = true;
            this.dgvBuses.RowHeadersWidth = 62;
            this.dgvBuses.RowTemplate.Height = 28;
            this.dgvBuses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuses.Size = new System.Drawing.Size(1078, 399);
            this.dgvBuses.TabIndex = 3;
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
            this.colOperatorName.HeaderText = "Operator Name";
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
            // colBusType
            // 
            this.colBusType.HeaderText = "Bus Type";
            this.colBusType.MinimumWidth = 8;
            this.colBusType.Name = "colBusType";
            this.colBusType.ReadOnly = true;
            // 
            // colTotalSeats
            // 
            this.colTotalSeats.HeaderText = "Total Seats";
            this.colTotalSeats.MinimumWidth = 8;
            this.colTotalSeats.Name = "colTotalSeats";
            this.colTotalSeats.ReadOnly = true;
            // 
            // colFare
            // 
            this.colFare.HeaderText = "Fare";
            this.colFare.MinimumWidth = 8;
            this.colFare.Name = "colFare";
            this.colFare.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // panelBusDetails
            // 
            this.panelBusDetails.Controls.Add(this.btnClear);
            this.panelBusDetails.Controls.Add(this.cmbStatus);
            this.panelBusDetails.Controls.Add(this.lblStatus);
            this.panelBusDetails.Controls.Add(this.txtFare);
            this.panelBusDetails.Controls.Add(this.lblFare);
            this.panelBusDetails.Controls.Add(this.txtTotalSeats);
            this.panelBusDetails.Controls.Add(this.lblTotalSeats);
            this.panelBusDetails.Controls.Add(this.txtBusType);
            this.panelBusDetails.Controls.Add(this.lblBusType);
            this.panelBusDetails.Controls.Add(this.txtRoute);
            this.panelBusDetails.Controls.Add(this.lblRoute);
            this.panelBusDetails.Controls.Add(this.txtOperatorName);
            this.panelBusDetails.Controls.Add(this.lblOperatorName);
            this.panelBusDetails.Controls.Add(this.txtBusNumber);
            this.panelBusDetails.Controls.Add(this.lblBusNumber);
            this.panelBusDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBusDetails.Location = new System.Drawing.Point(0, 404);
            this.panelBusDetails.Name = "panelBusDetails";
            this.panelBusDetails.Size = new System.Drawing.Size(1078, 190);
            this.panelBusDetails.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(924, 131);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 43);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(119, 154);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(159, 28);
            this.cmbStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(22, 151);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(91, 32);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status:";
            // 
            // txtFare
            // 
            this.txtFare.Location = new System.Drawing.Point(534, 122);
            this.txtFare.Name = "txtFare";
            this.txtFare.Size = new System.Drawing.Size(281, 26);
            this.txtFare.TabIndex = 11;
            // 
            // lblFare
            // 
            this.lblFare.AutoSize = true;
            this.lblFare.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFare.Location = new System.Drawing.Point(459, 115);
            this.lblFare.Name = "lblFare";
            this.lblFare.Size = new System.Drawing.Size(69, 32);
            this.lblFare.TabIndex = 10;
            this.lblFare.Text = "Fare:";
            // 
            // txtTotalSeats
            // 
            this.txtTotalSeats.Location = new System.Drawing.Point(169, 122);
            this.txtTotalSeats.Name = "txtTotalSeats";
            this.txtTotalSeats.Size = new System.Drawing.Size(281, 26);
            this.txtTotalSeats.TabIndex = 9;
            // 
            // lblTotalSeats
            // 
            this.lblTotalSeats.AutoSize = true;
            this.lblTotalSeats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSeats.Location = new System.Drawing.Point(19, 115);
            this.lblTotalSeats.Name = "lblTotalSeats";
            this.lblTotalSeats.Size = new System.Drawing.Size(144, 32);
            this.lblTotalSeats.TabIndex = 8;
            this.lblTotalSeats.Text = "Total Seats:";
            // 
            // txtBusType
            // 
            this.txtBusType.Location = new System.Drawing.Point(534, 88);
            this.txtBusType.Name = "txtBusType";
            this.txtBusType.Size = new System.Drawing.Size(281, 26);
            this.txtBusType.TabIndex = 7;
            this.txtBusType.TextChanged += new System.EventHandler(this.txtBusType_TextChanged);
            // 
            // lblBusType
            // 
            this.lblBusType.AutoSize = true;
            this.lblBusType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusType.Location = new System.Drawing.Point(404, 81);
            this.lblBusType.Name = "lblBusType";
            this.lblBusType.Size = new System.Drawing.Size(124, 32);
            this.lblBusType.TabIndex = 6;
            this.lblBusType.Text = "Bus Type:";
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(117, 81);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(281, 26);
            this.txtRoute.TabIndex = 5;
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(22, 74);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(89, 32);
            this.lblRoute.TabIndex = 4;
            this.lblRoute.Text = "Route:";
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.Location = new System.Drawing.Point(715, 41);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Size = new System.Drawing.Size(281, 26);
            this.txtOperatorName.TabIndex = 3;
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.AutoSize = true;
            this.lblOperatorName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorName.Location = new System.Drawing.Point(503, 34);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(206, 32);
            this.lblOperatorName.TabIndex = 2;
            this.lblOperatorName.Text = "Operator Name: ";
            // 
            // txtBusNumber
            // 
            this.txtBusNumber.Location = new System.Drawing.Point(216, 34);
            this.txtBusNumber.Name = "txtBusNumber";
            this.txtBusNumber.Size = new System.Drawing.Size(281, 26);
            this.txtBusNumber.TabIndex = 1;
            // 
            // lblBusNumber
            // 
            this.lblBusNumber.AutoSize = true;
            this.lblBusNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNumber.Location = new System.Drawing.Point(22, 28);
            this.lblBusNumber.Name = "lblBusNumber";
            this.lblBusNumber.Size = new System.Drawing.Size(165, 32);
            this.lblBusNumber.TabIndex = 0;
            this.lblBusNumber.Text = "Bus Number:";
            // 
            // ManageBuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelBusDetails);
            this.Controls.Add(this.dgvBuses);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageBuses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Buses";
            this.panelHeader.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).EndInit();
            this.panelBusDetails.ResumeLayout(false);
            this.panelBusDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnEditBus;
        private System.Windows.Forms.Button btnAddBus;
        private System.Windows.Forms.Button btnDeleteBus;
        private System.Windows.Forms.Button btnShowBuses;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchBus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBuses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel panelBusDetails;
        private System.Windows.Forms.Label lblBusNumber;
        private System.Windows.Forms.TextBox txtBusNumber;
        private System.Windows.Forms.Label lblOperatorName;
        private System.Windows.Forms.TextBox txtOperatorName;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblBusType;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.TextBox txtBusType;
        private System.Windows.Forms.Label lblTotalSeats;
        private System.Windows.Forms.TextBox txtFare;
        private System.Windows.Forms.Label lblFare;
        private System.Windows.Forms.TextBox txtTotalSeats;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnClear;
    }
}