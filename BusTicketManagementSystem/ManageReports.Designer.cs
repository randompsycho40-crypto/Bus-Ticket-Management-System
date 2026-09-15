
namespace BusTicketManagementSystem
{
    partial class ManageReports
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
            this.panelFilters = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.colReportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPayments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblTotalPaymentsValue = new System.Windows.Forms.Label();
            this.lblPayments = new System.Windows.Forms.Label();
            this.lblTotalCommissionsValue = new System.Windows.Forms.Label();
            this.lblTotalCommissions = new System.Windows.Forms.Label();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.panelSummary.SuspendLayout();
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
            this.lblPageTitle.Text = "Manage Reports";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Click += new System.EventHandler(this.lblPageTitle_Click);
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.btnGenerateReport);
            this.panelFilters.Controls.Add(this.comboBox1);
            this.panelFilters.Controls.Add(this.lblReportType);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 75);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1078, 65);
            this.panelFilters.TabIndex = 1;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(342, 16);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(221, 40);
            this.btnGenerateReport.TabIndex = 4;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sales Report",
            "Commission Report",
            "Payment Report",
            "Operator Report",
            "Bus Report"});
            this.comboBox1.Location = new System.Drawing.Point(173, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 3;
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(22, 16);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(133, 28);
            this.lblReportType.TabIndex = 2;
            this.lblReportType.Text = "Report Type:";
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReportID,
            this.colReportType,
            this.colOperatorName,
            this.colCompanyName,
            this.colTotalSales,
            this.colCommission,
            this.colTotalPayments,
            this.colReportDate});
            this.dgvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReports.Location = new System.Drawing.Point(0, 140);
            this.dgvReports.MultiSelect = false;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersWidth = 62;
            this.dgvReports.RowTemplate.Height = 28;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(1078, 454);
            this.dgvReports.TabIndex = 2;
            this.dgvReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellContentClick);
            // 
            // colReportID
            // 
            this.colReportID.HeaderText = "Repoert ID";
            this.colReportID.MinimumWidth = 8;
            this.colReportID.Name = "colReportID";
            this.colReportID.ReadOnly = true;
            // 
            // colReportType
            // 
            this.colReportType.HeaderText = "Report Type";
            this.colReportType.MinimumWidth = 8;
            this.colReportType.Name = "colReportType";
            this.colReportType.ReadOnly = true;
            // 
            // colOperatorName
            // 
            this.colOperatorName.HeaderText = "Operator Name";
            this.colOperatorName.MinimumWidth = 8;
            this.colOperatorName.Name = "colOperatorName";
            this.colOperatorName.ReadOnly = true;
            // 
            // colCompanyName
            // 
            this.colCompanyName.HeaderText = "Company Name";
            this.colCompanyName.MinimumWidth = 8;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.ReadOnly = true;
            // 
            // colTotalSales
            // 
            this.colTotalSales.HeaderText = "Total Sales";
            this.colTotalSales.MinimumWidth = 8;
            this.colTotalSales.Name = "colTotalSales";
            this.colTotalSales.ReadOnly = true;
            // 
            // colCommission
            // 
            this.colCommission.HeaderText = "Commission";
            this.colCommission.MinimumWidth = 8;
            this.colCommission.Name = "colCommission";
            this.colCommission.ReadOnly = true;
            // 
            // colTotalPayments
            // 
            this.colTotalPayments.HeaderText = "Total Payments";
            this.colTotalPayments.MinimumWidth = 8;
            this.colTotalPayments.Name = "colTotalPayments";
            this.colTotalPayments.ReadOnly = true;
            // 
            // colReportDate
            // 
            this.colReportDate.HeaderText = "Report Date";
            this.colReportDate.MinimumWidth = 8;
            this.colReportDate.Name = "colReportDate";
            this.colReportDate.ReadOnly = true;
            // 
            // panelSummary
            // 
            this.panelSummary.Controls.Add(this.lblTotalPaymentsValue);
            this.panelSummary.Controls.Add(this.lblPayments);
            this.panelSummary.Controls.Add(this.lblTotalCommissionsValue);
            this.panelSummary.Controls.Add(this.lblTotalCommissions);
            this.panelSummary.Controls.Add(this.lblTotalSalesValue);
            this.panelSummary.Controls.Add(this.lblTotalSales);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSummary.Location = new System.Drawing.Point(0, 474);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1078, 120);
            this.panelSummary.TabIndex = 3;
            // 
            // lblTotalPaymentsValue
            // 
            this.lblTotalPaymentsValue.AutoSize = true;
            this.lblTotalPaymentsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaymentsValue.Location = new System.Drawing.Point(245, 80);
            this.lblTotalPaymentsValue.Name = "lblTotalPaymentsValue";
            this.lblTotalPaymentsValue.Size = new System.Drawing.Size(49, 22);
            this.lblTotalPaymentsValue.TabIndex = 5;
            this.lblTotalPaymentsValue.Text = "0.00";
            // 
            // lblPayments
            // 
            this.lblPayments.AutoSize = true;
            this.lblPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayments.Location = new System.Drawing.Point(12, 80);
            this.lblPayments.Name = "lblPayments";
            this.lblPayments.Size = new System.Drawing.Size(161, 22);
            this.lblPayments.TabIndex = 4;
            this.lblPayments.Text = "Total Payments: ";
            // 
            // lblTotalCommissionsValue
            // 
            this.lblTotalCommissionsValue.AutoSize = true;
            this.lblTotalCommissionsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCommissionsValue.Location = new System.Drawing.Point(245, 44);
            this.lblTotalCommissionsValue.Name = "lblTotalCommissionsValue";
            this.lblTotalCommissionsValue.Size = new System.Drawing.Size(49, 22);
            this.lblTotalCommissionsValue.TabIndex = 3;
            this.lblTotalCommissionsValue.Text = "0.00";
            // 
            // lblTotalCommissions
            // 
            this.lblTotalCommissions.AutoSize = true;
            this.lblTotalCommissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCommissions.Location = new System.Drawing.Point(12, 44);
            this.lblTotalCommissions.Name = "lblTotalCommissions";
            this.lblTotalCommissions.Size = new System.Drawing.Size(191, 22);
            this.lblTotalCommissions.TabIndex = 2;
            this.lblTotalCommissions.Text = "Total Commissions: ";
            // 
            // lblTotalSalesValue
            // 
            this.lblTotalSalesValue.AutoSize = true;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalesValue.Location = new System.Drawing.Point(245, 12);
            this.lblTotalSalesValue.Name = "lblTotalSalesValue";
            this.lblTotalSalesValue.Size = new System.Drawing.Size(49, 22);
            this.lblTotalSalesValue.TabIndex = 1;
            this.lblTotalSalesValue.Text = "0.00";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.Location = new System.Drawing.Point(12, 12);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(124, 22);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = "Total Sales: ";
            // 
            // ManageReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Reports";
            this.panelHeader.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportDate;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalCommissionsValue;
        private System.Windows.Forms.Label lblTotalCommissions;
        private System.Windows.Forms.Label lblPayments;
        private System.Windows.Forms.Label lblTotalPaymentsValue;
    }
}