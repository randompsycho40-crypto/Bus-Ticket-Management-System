
namespace BusTicketManagementSystem
{
    partial class Routes
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
            this.btnShowRoutes = new System.Windows.Forms.Button();
            this.btnDeleteRoute = new System.Windows.Forms.Button();
            this.btnEditRoute = new System.Windows.Forms.Button();
            this.btnAddRoute = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchRoute = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvRoutes = new System.Windows.Forms.DataGridView();
            this.colRouteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRouteDetails = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblRouteStatus = new System.Windows.Forms.Label();
            this.txtFare = new System.Windows.Forms.TextBox();
            this.lblFare = new System.Windows.Forms.Label();
            this.txtEstimatedTime = new System.Windows.Forms.TextBox();
            this.lblEstimatedTime = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();
            this.panelRouteDetails.SuspendLayout();
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
            this.lblPageTitle.Text = "Routes";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnShowRoutes);
            this.panelActions.Controls.Add(this.btnDeleteRoute);
            this.panelActions.Controls.Add(this.btnEditRoute);
            this.panelActions.Controls.Add(this.btnAddRoute);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActions.Location = new System.Drawing.Point(0, 75);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1078, 65);
            this.panelActions.TabIndex = 1;
            // 
            // btnShowRoutes
            // 
            this.btnShowRoutes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRoutes.Location = new System.Drawing.Point(663, 6);
            this.btnShowRoutes.Name = "btnShowRoutes";
            this.btnShowRoutes.Size = new System.Drawing.Size(160, 40);
            this.btnShowRoutes.TabIndex = 4;
            this.btnShowRoutes.Text = "Show Routes";
            this.btnShowRoutes.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRoute
            // 
            this.btnDeleteRoute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRoute.Location = new System.Drawing.Point(441, 6);
            this.btnDeleteRoute.Name = "btnDeleteRoute";
            this.btnDeleteRoute.Size = new System.Drawing.Size(160, 40);
            this.btnDeleteRoute.TabIndex = 3;
            this.btnDeleteRoute.Text = "Delete Route";
            this.btnDeleteRoute.UseVisualStyleBackColor = true;
            // 
            // btnEditRoute
            // 
            this.btnEditRoute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRoute.Location = new System.Drawing.Point(211, 6);
            this.btnEditRoute.Name = "btnEditRoute";
            this.btnEditRoute.Size = new System.Drawing.Size(160, 40);
            this.btnEditRoute.TabIndex = 2;
            this.btnEditRoute.Text = "Edit Route";
            this.btnEditRoute.UseVisualStyleBackColor = true;
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoute.Location = new System.Drawing.Point(8, 6);
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Size = new System.Drawing.Size(160, 40);
            this.btnAddRoute.TabIndex = 0;
            this.btnAddRoute.Text = "Add Route";
            this.btnAddRoute.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearchRoute);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 140);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1078, 55);
            this.panelSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(429, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 38);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchRoute
            // 
            this.txtSearchRoute.Location = new System.Drawing.Point(158, 14);
            this.txtSearchRoute.Name = "txtSearchRoute";
            this.txtSearchRoute.Size = new System.Drawing.Size(250, 26);
            this.txtSearchRoute.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(12, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(130, 25);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Route:";
            // 
            // dgvRoutes
            // 
            this.dgvRoutes.AllowUserToAddRows = false;
            this.dgvRoutes.AllowUserToDeleteRows = false;
            this.dgvRoutes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoutes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRouteID,
            this.colFrom,
            this.colTo,
            this.colDistance,
            this.colEstimatedTime,
            this.colFare,
            this.colStatus});
            this.dgvRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoutes.Location = new System.Drawing.Point(0, 195);
            this.dgvRoutes.MultiSelect = false;
            this.dgvRoutes.Name = "dgvRoutes";
            this.dgvRoutes.ReadOnly = true;
            this.dgvRoutes.RowHeadersWidth = 62;
            this.dgvRoutes.RowTemplate.Height = 28;
            this.dgvRoutes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoutes.Size = new System.Drawing.Size(1078, 399);
            this.dgvRoutes.TabIndex = 3;
            // 
            // colRouteID
            // 
            this.colRouteID.HeaderText = "Route ID";
            this.colRouteID.MinimumWidth = 8;
            this.colRouteID.Name = "colRouteID";
            this.colRouteID.ReadOnly = true;
            // 
            // colFrom
            // 
            this.colFrom.HeaderText = "From";
            this.colFrom.MinimumWidth = 8;
            this.colFrom.Name = "colFrom";
            this.colFrom.ReadOnly = true;
            // 
            // colTo
            // 
            this.colTo.HeaderText = "To";
            this.colTo.MinimumWidth = 8;
            this.colTo.Name = "colTo";
            this.colTo.ReadOnly = true;
            // 
            // colDistance
            // 
            this.colDistance.HeaderText = "Distance";
            this.colDistance.MinimumWidth = 8;
            this.colDistance.Name = "colDistance";
            this.colDistance.ReadOnly = true;
            // 
            // colEstimatedTime
            // 
            this.colEstimatedTime.HeaderText = "Estimated Time";
            this.colEstimatedTime.MinimumWidth = 8;
            this.colEstimatedTime.Name = "colEstimatedTime";
            this.colEstimatedTime.ReadOnly = true;
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
            // panelRouteDetails
            // 
            this.panelRouteDetails.Controls.Add(this.btnClear);
            this.panelRouteDetails.Controls.Add(this.cmbStatus);
            this.panelRouteDetails.Controls.Add(this.lblRouteStatus);
            this.panelRouteDetails.Controls.Add(this.txtFare);
            this.panelRouteDetails.Controls.Add(this.lblFare);
            this.panelRouteDetails.Controls.Add(this.txtEstimatedTime);
            this.panelRouteDetails.Controls.Add(this.lblEstimatedTime);
            this.panelRouteDetails.Controls.Add(this.txtDistance);
            this.panelRouteDetails.Controls.Add(this.lblDistance);
            this.panelRouteDetails.Controls.Add(this.txtTo);
            this.panelRouteDetails.Controls.Add(this.lblTo);
            this.panelRouteDetails.Controls.Add(this.txtFrom);
            this.panelRouteDetails.Controls.Add(this.lblFrom);
            this.panelRouteDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRouteDetails.Location = new System.Drawing.Point(0, 404);
            this.panelRouteDetails.Name = "panelRouteDetails";
            this.panelRouteDetails.Size = new System.Drawing.Size(1078, 190);
            this.panelRouteDetails.TabIndex = 4;
            this.panelRouteDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRouteDetails_Paint);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(720, 138);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(160, 40);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(739, 78);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 28);
            this.cmbStatus.TabIndex = 11;
            // 
            // lblRouteStatus
            // 
            this.lblRouteStatus.AutoSize = true;
            this.lblRouteStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRouteStatus.Location = new System.Drawing.Point(658, 81);
            this.lblRouteStatus.Name = "lblRouteStatus";
            this.lblRouteStatus.Size = new System.Drawing.Size(75, 25);
            this.lblRouteStatus.TabIndex = 10;
            this.lblRouteStatus.Text = "Status: ";
            // 
            // txtFare
            // 
            this.txtFare.Location = new System.Drawing.Point(455, 82);
            this.txtFare.Name = "txtFare";
            this.txtFare.Size = new System.Drawing.Size(180, 26);
            this.txtFare.TabIndex = 9;
            // 
            // lblFare
            // 
            this.lblFare.AutoSize = true;
            this.lblFare.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFare.Location = new System.Drawing.Point(392, 83);
            this.lblFare.Name = "lblFare";
            this.lblFare.Size = new System.Drawing.Size(57, 25);
            this.lblFare.TabIndex = 8;
            this.lblFare.Text = "Fare: ";
            // 
            // txtEstimatedTime
            // 
            this.txtEstimatedTime.Location = new System.Drawing.Point(172, 84);
            this.txtEstimatedTime.Name = "txtEstimatedTime";
            this.txtEstimatedTime.Size = new System.Drawing.Size(180, 26);
            this.txtEstimatedTime.TabIndex = 7;
            // 
            // lblEstimatedTime
            // 
            this.lblEstimatedTime.AutoSize = true;
            this.lblEstimatedTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedTime.Location = new System.Drawing.Point(13, 85);
            this.lblEstimatedTime.Name = "lblEstimatedTime";
            this.lblEstimatedTime.Size = new System.Drawing.Size(153, 25);
            this.lblEstimatedTime.TabIndex = 6;
            this.lblEstimatedTime.Text = "Estimated Time: ";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(638, 22);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(180, 26);
            this.txtDistance.TabIndex = 5;
            this.txtDistance.TextChanged += new System.EventHandler(this.txtDistance_TextChanged);
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(537, 25);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(95, 25);
            this.lblDistance.TabIndex = 4;
            this.lblDistance.Text = "Distance: ";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(330, 22);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(180, 26);
            this.txtTo.TabIndex = 3;
            this.txtTo.TextChanged += new System.EventHandler(this.txtTo_TextChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(282, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(42, 25);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To: ";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(73, 23);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(180, 26);
            this.txtFrom.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(13, 24);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(65, 25);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From: ";
            // 
            // Routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelRouteDetails);
            this.Controls.Add(this.dgvRoutes);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Routes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Routes";
            this.Load += new System.EventHandler(this.Routes_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
            this.panelRouteDetails.ResumeLayout(false);
            this.panelRouteDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnEditRoute;
        private System.Windows.Forms.Button btnAddRoute;
        private System.Windows.Forms.Button btnDeleteRoute;
        private System.Windows.Forms.Button btnShowRoutes;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchRoute;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvRoutes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel panelRouteDetails;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblEstimatedTime;
        private System.Windows.Forms.Label lblFare;
        private System.Windows.Forms.TextBox txtEstimatedTime;
        private System.Windows.Forms.TextBox txtFare;
        private System.Windows.Forms.Label lblRouteStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnClear;
    }
}