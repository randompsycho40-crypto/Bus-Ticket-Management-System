
namespace BusTicketManagementSystem
{
    partial class MyBuses
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
            this.dgvMyBuses = new System.Windows.Forms.DataGridView();
            this.colBusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cmbBusType = new System.Windows.Forms.ComboBox();
            this.lblBusType = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.txtBusNumber = new System.Windows.Forms.TextBox();
            this.lblBusNumber = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBuses)).BeginInit();
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
            this.lblPageTitle.Text = "My Buses";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnShowBuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBuses.Location = new System.Drawing.Point(757, 6);
            this.btnShowBuses.Name = "btnShowBuses";
            this.btnShowBuses.Size = new System.Drawing.Size(179, 37);
            this.btnShowBuses.TabIndex = 4;
            this.btnShowBuses.Text = "Show Buses";
            this.btnShowBuses.UseVisualStyleBackColor = true;
            this.btnShowBuses.Click += new System.EventHandler(this.btnShowBuses_Click);
            // 
            // btnDeleteBus
            // 
            this.btnDeleteBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBus.Location = new System.Drawing.Point(510, 6);
            this.btnDeleteBus.Name = "btnDeleteBus";
            this.btnDeleteBus.Size = new System.Drawing.Size(127, 37);
            this.btnDeleteBus.TabIndex = 3;
            this.btnDeleteBus.Text = "Delete Bus";
            this.btnDeleteBus.UseVisualStyleBackColor = true;
            this.btnDeleteBus.Click += new System.EventHandler(this.btnDeleteBus_Click);
            // 
            // btnEditBus
            // 
            this.btnEditBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditBus.Location = new System.Drawing.Point(257, 6);
            this.btnEditBus.Name = "btnEditBus";
            this.btnEditBus.Size = new System.Drawing.Size(127, 37);
            this.btnEditBus.TabIndex = 2;
            this.btnEditBus.Text = "Edit Bus";
            this.btnEditBus.UseVisualStyleBackColor = true;
            this.btnEditBus.Click += new System.EventHandler(this.btnEditBus_Click);
            // 
            // btnAddBus
            // 
            this.btnAddBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBus.Location = new System.Drawing.Point(27, 6);
            this.btnAddBus.Name = "btnAddBus";
            this.btnAddBus.Size = new System.Drawing.Size(127, 37);
            this.btnAddBus.TabIndex = 0;
            this.btnAddBus.Text = "Add Bus";
            this.btnAddBus.UseVisualStyleBackColor = true;
            this.btnAddBus.Click += new System.EventHandler(this.btnAddBus_Click);
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
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(418, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 43);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchBus
            // 
            this.txtSearchBus.Location = new System.Drawing.Point(138, 17);
            this.txtSearchBus.Name = "txtSearchBus";
            this.txtSearchBus.Size = new System.Drawing.Size(246, 26);
            this.txtSearchBus.TabIndex = 4;
            this.txtSearchBus.TextChanged += new System.EventHandler(this.txtSearchBus_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(38, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(94, 30);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search: ";
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // dgvMyBuses
            // 
            this.dgvMyBuses.AllowUserToAddRows = false;
            this.dgvMyBuses.AllowUserToDeleteRows = false;
            this.dgvMyBuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyBuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyBuses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBusID,
            this.colBusNumber,
            this.colRoute,
            this.colBusType,
            this.colTotalSeats,
            this.colFare,
            this.colStatus});
            this.dgvMyBuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyBuses.Location = new System.Drawing.Point(0, 195);
            this.dgvMyBuses.MultiSelect = false;
            this.dgvMyBuses.Name = "dgvMyBuses";
            this.dgvMyBuses.ReadOnly = true;
            this.dgvMyBuses.RowHeadersWidth = 62;
            this.dgvMyBuses.RowTemplate.Height = 28;
            this.dgvMyBuses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyBuses.Size = new System.Drawing.Size(1078, 399);
            this.dgvMyBuses.TabIndex = 3;
            this.dgvMyBuses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyBuses_CellContentClick);
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
            this.panelBusDetails.Controls.Add(this.cmbBusType);
            this.panelBusDetails.Controls.Add(this.lblBusType);
            this.panelBusDetails.Controls.Add(this.txtRoute);
            this.panelBusDetails.Controls.Add(this.lblRoute);
            this.panelBusDetails.Controls.Add(this.txtBusNumber);
            this.panelBusDetails.Controls.Add(this.lblBusNumber);
            this.panelBusDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBusDetails.Location = new System.Drawing.Point(0, 404);
            this.panelBusDetails.Name = "panelBusDetails";
            this.panelBusDetails.Size = new System.Drawing.Size(1078, 190);
            this.panelBusDetails.TabIndex = 4;
            this.panelBusDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBusDetails_Paint);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(812, 114);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 48);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(772, 80);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 28);
            this.cmbStatus.TabIndex = 11;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(667, 77);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 25);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status: ";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // txtFare
            // 
            this.txtFare.Location = new System.Drawing.Point(442, 80);
            this.txtFare.Name = "txtFare";
            this.txtFare.Size = new System.Drawing.Size(180, 26);
            this.txtFare.TabIndex = 9;
            this.txtFare.TextChanged += new System.EventHandler(this.txtFare_TextChanged);
            // 
            // lblFare
            // 
            this.lblFare.AutoSize = true;
            this.lblFare.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFare.Location = new System.Drawing.Point(363, 79);
            this.lblFare.Name = "lblFare";
            this.lblFare.Size = new System.Drawing.Size(57, 25);
            this.lblFare.TabIndex = 8;
            this.lblFare.Text = "Fare: ";
            this.lblFare.Click += new System.EventHandler(this.lblFare_Click);
            // 
            // txtTotalSeats
            // 
            this.txtTotalSeats.Location = new System.Drawing.Point(139, 78);
            this.txtTotalSeats.Name = "txtTotalSeats";
            this.txtTotalSeats.Size = new System.Drawing.Size(180, 26);
            this.txtTotalSeats.TabIndex = 7;
            this.txtTotalSeats.TextChanged += new System.EventHandler(this.txtTotalSeats_TextChanged);
            // 
            // lblTotalSeats
            // 
            this.lblTotalSeats.AutoSize = true;
            this.lblTotalSeats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSeats.Location = new System.Drawing.Point(4, 79);
            this.lblTotalSeats.Name = "lblTotalSeats";
            this.lblTotalSeats.Size = new System.Drawing.Size(114, 25);
            this.lblTotalSeats.TabIndex = 6;
            this.lblTotalSeats.Text = "Total Seats: ";
            this.lblTotalSeats.Click += new System.EventHandler(this.lblTotalSeats_Click);
            // 
            // cmbBusType
            // 
            this.cmbBusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusType.FormattingEnabled = true;
            this.cmbBusType.Items.AddRange(new object[] {
            "AC",
            "",
            "Non-AC",
            "",
            "Sleeper",
            "",
            "Business Class"});
            this.cmbBusType.Location = new System.Drawing.Point(772, 20);
            this.cmbBusType.Name = "cmbBusType";
            this.cmbBusType.Size = new System.Drawing.Size(180, 28);
            this.cmbBusType.TabIndex = 5;
            this.cmbBusType.SelectedIndexChanged += new System.EventHandler(this.cmbBusType_SelectedIndexChanged);
            // 
            // lblBusType
            // 
            this.lblBusType.AutoSize = true;
            this.lblBusType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusType.Location = new System.Drawing.Point(667, 19);
            this.lblBusType.Name = "lblBusType";
            this.lblBusType.Size = new System.Drawing.Size(99, 25);
            this.lblBusType.TabIndex = 4;
            this.lblBusType.Text = "Bus Type: ";
            this.lblBusType.Click += new System.EventHandler(this.lblBusType_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(442, 18);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(180, 26);
            this.txtRoute.TabIndex = 3;
            this.txtRoute.TextChanged += new System.EventHandler(this.txtRoute_TextChanged);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(363, 17);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(73, 25);
            this.lblRoute.TabIndex = 2;
            this.lblRoute.Text = "Route: ";
            this.lblRoute.Click += new System.EventHandler(this.lblRoute_Click);
            // 
            // txtBusNumber
            // 
            this.txtBusNumber.Location = new System.Drawing.Point(139, 16);
            this.txtBusNumber.Name = "txtBusNumber";
            this.txtBusNumber.Size = new System.Drawing.Size(180, 26);
            this.txtBusNumber.TabIndex = 1;
            this.txtBusNumber.TextChanged += new System.EventHandler(this.txtBusNumber_TextChanged);
            // 
            // lblBusNumber
            // 
            this.lblBusNumber.AutoSize = true;
            this.lblBusNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNumber.Location = new System.Drawing.Point(3, 15);
            this.lblBusNumber.Name = "lblBusNumber";
            this.lblBusNumber.Size = new System.Drawing.Size(128, 25);
            this.lblBusNumber.TabIndex = 0;
            this.lblBusNumber.Text = "Bus Number: ";
            this.lblBusNumber.Click += new System.EventHandler(this.lblBusNumber_Click);
            // 
            // MyBuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelBusDetails);
            this.Controls.Add(this.dgvMyBuses);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MyBuses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Buses";
            this.Load += new System.EventHandler(this.MyBuses_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBuses)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvMyBuses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel panelBusDetails;
        private System.Windows.Forms.Label lblBusNumber;
        private System.Windows.Forms.TextBox txtBusNumber;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblBusType;
        private System.Windows.Forms.ComboBox cmbBusType;
        private System.Windows.Forms.Label lblTotalSeats;
        private System.Windows.Forms.TextBox txtTotalSeats;
        private System.Windows.Forms.Label lblFare;
        private System.Windows.Forms.TextBox txtFare;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnClear;
    }
}