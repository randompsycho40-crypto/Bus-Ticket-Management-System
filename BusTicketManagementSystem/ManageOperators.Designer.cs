
namespace BusTicketManagementSystem
{
    partial class ManageOperators
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnShowOperator = new System.Windows.Forms.Button();
            this.btnDeleteOperator = new System.Windows.Forms.Button();
            this.btnEditOperator = new System.Windows.Forms.Button();
            this.btnAddOperator = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchOperator = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.dgvOperator = new System.Windows.Forms.DataGridView();
            this.colOperatorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistrationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelOperatorDetails = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblOperatorName = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperator)).BeginInit();
            this.panelOperatorDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.lblPageTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1078, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1078, 120);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Oprators";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(1078, 120);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Manage Oprators";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnShowOperator);
            this.panelActions.Controls.Add(this.btnDeleteOperator);
            this.panelActions.Controls.Add(this.btnEditOperator);
            this.panelActions.Controls.Add(this.btnAddOperator);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActions.Location = new System.Drawing.Point(0, 120);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1078, 65);
            this.panelActions.TabIndex = 1;
            this.panelActions.Paint += new System.Windows.Forms.PaintEventHandler(this.panelActions_Paint);
            // 
            // btnShowOperator
            // 
            this.btnShowOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowOperator.Location = new System.Drawing.Point(858, 6);
            this.btnShowOperator.Name = "btnShowOperator";
            this.btnShowOperator.Size = new System.Drawing.Size(208, 41);
            this.btnShowOperator.TabIndex = 3;
            this.btnShowOperator.Text = "Show Operator";
            this.btnShowOperator.UseVisualStyleBackColor = true;
            this.btnShowOperator.Click += new System.EventHandler(this.btnShowOperator_Click);
            // 
            // btnDeleteOperator
            // 
            this.btnDeleteOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOperator.Location = new System.Drawing.Point(563, 6);
            this.btnDeleteOperator.Name = "btnDeleteOperator";
            this.btnDeleteOperator.Size = new System.Drawing.Size(208, 41);
            this.btnDeleteOperator.TabIndex = 2;
            this.btnDeleteOperator.Text = "Delete Operator";
            this.btnDeleteOperator.UseVisualStyleBackColor = true;
            this.btnDeleteOperator.Click += new System.EventHandler(this.btnDeleteOperator_Click);
            // 
            // btnEditOperator
            // 
            this.btnEditOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOperator.Location = new System.Drawing.Point(280, 6);
            this.btnEditOperator.Name = "btnEditOperator";
            this.btnEditOperator.Size = new System.Drawing.Size(208, 41);
            this.btnEditOperator.TabIndex = 1;
            this.btnEditOperator.Text = "Edit Operator";
            this.btnEditOperator.UseVisualStyleBackColor = true;
            this.btnEditOperator.Click += new System.EventHandler(this.btnEditOperator_Click);
            // 
            // btnAddOperator
            // 
            this.btnAddOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOperator.Location = new System.Drawing.Point(12, 6);
            this.btnAddOperator.Name = "btnAddOperator";
            this.btnAddOperator.Size = new System.Drawing.Size(208, 41);
            this.btnAddOperator.TabIndex = 0;
            this.btnAddOperator.Text = "Add Operator";
            this.btnAddOperator.UseVisualStyleBackColor = true;
            this.btnAddOperator.Click += new System.EventHandler(this.btnAddOperator_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearchOperator);
            this.panelSearch.Controls.Add(this.labelSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 185);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1078, 55);
            this.panelSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(858, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(208, 42);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchOperator
            // 
            this.txtSearchOperator.Location = new System.Drawing.Point(298, 18);
            this.txtSearchOperator.Name = "txtSearchOperator";
            this.txtSearchOperator.Size = new System.Drawing.Size(513, 26);
            this.txtSearchOperator.TabIndex = 1;
            this.txtSearchOperator.TextChanged += new System.EventHandler(this.txtSearchOperator_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.BackColor = System.Drawing.Color.White;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.Location = new System.Drawing.Point(12, 12);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(248, 32);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Text = "Search Operator:";
            this.labelSearch.Click += new System.EventHandler(this.labelSearch_Click);
            // 
            // dgvOperator
            // 
            this.dgvOperator.AllowUserToAddRows = false;
            this.dgvOperator.AllowUserToDeleteRows = false;
            this.dgvOperator.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperator.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperator.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOperatorID,
            this.colOperatorName,
            this.colCompanyName,
            this.colPhone,
            this.colEmail,
            this.colStatus,
            this.colRegistrationDate});
            this.dgvOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperator.Location = new System.Drawing.Point(0, 240);
            this.dgvOperator.MultiSelect = false;
            this.dgvOperator.Name = "dgvOperator";
            this.dgvOperator.ReadOnly = true;
            this.dgvOperator.RowHeadersWidth = 62;
            this.dgvOperator.RowTemplate.Height = 28;
            this.dgvOperator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperator.Size = new System.Drawing.Size(1078, 354);
            this.dgvOperator.TabIndex = 3;
            this.dgvOperator.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperator_CellContentClick);
            // 
            // colOperatorID
            // 
            this.colOperatorID.HeaderText = "Operator ID";
            this.colOperatorID.MinimumWidth = 8;
            this.colOperatorID.Name = "colOperatorID";
            this.colOperatorID.ReadOnly = true;
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
            // colPhone
            // 
            this.colPhone.HeaderText = "Phone";
            this.colPhone.MinimumWidth = 8;
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 8;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colRegistrationDate
            // 
            this.colRegistrationDate.HeaderText = "Registration Date";
            this.colRegistrationDate.MinimumWidth = 8;
            this.colRegistrationDate.Name = "colRegistrationDate";
            this.colRegistrationDate.ReadOnly = true;
            // 
            // panelOperatorDetails
            // 
            this.panelOperatorDetails.BackColor = System.Drawing.Color.White;
            this.panelOperatorDetails.Controls.Add(this.btnClear);
            this.panelOperatorDetails.Controls.Add(this.lblStatus);
            this.panelOperatorDetails.Controls.Add(this.cmbStatus);
            this.panelOperatorDetails.Controls.Add(this.txtEmail);
            this.panelOperatorDetails.Controls.Add(this.lblEmail);
            this.panelOperatorDetails.Controls.Add(this.txtPhone);
            this.panelOperatorDetails.Controls.Add(this.lblPhone);
            this.panelOperatorDetails.Controls.Add(this.txtCompanyName);
            this.panelOperatorDetails.Controls.Add(this.txtOperatorName);
            this.panelOperatorDetails.Controls.Add(this.lblCompanyName);
            this.panelOperatorDetails.Controls.Add(this.lblOperatorName);
            this.panelOperatorDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOperatorDetails.Location = new System.Drawing.Point(0, 404);
            this.panelOperatorDetails.Name = "panelOperatorDetails";
            this.panelOperatorDetails.Size = new System.Drawing.Size(1078, 190);
            this.panelOperatorDetails.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(925, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(141, 51);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(13, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 26);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Pending",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(119, 122);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 28);
            this.cmbStatus.TabIndex = 8;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(587, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(315, 26);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(490, 78);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 26);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(119, 78);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(315, 26);
            this.txtPhone.TabIndex = 5;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(13, 78);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(87, 26);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone:";
            this.lblPhone.Click += new System.EventHandler(this.lblPhone_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(760, 13);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(315, 26);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.Location = new System.Drawing.Point(208, 13);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Size = new System.Drawing.Size(315, 26);
            this.txtOperatorName.TabIndex = 2;
            this.txtOperatorName.TextChanged += new System.EventHandler(this.txtOperatorName_TextChanged);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(558, 13);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(197, 26);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "Company Name: ";
            this.lblCompanyName.Click += new System.EventHandler(this.lblCompanyName_Click);
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.AutoSize = true;
            this.lblOperatorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorName.Location = new System.Drawing.Point(13, 15);
            this.lblOperatorName.Name = "lblOperatorName";
            this.lblOperatorName.Size = new System.Drawing.Size(189, 26);
            this.lblOperatorName.TabIndex = 0;
            this.lblOperatorName.Text = "Operator Name: ";
            this.lblOperatorName.Click += new System.EventHandler(this.lblOperatorName_Click);
            // 
            // ManageOperators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelOperatorDetails);
            this.Controls.Add(this.dgvOperator);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageOperators";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Operators";
            this.panelHeader.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperator)).EndInit();
            this.panelOperatorDetails.ResumeLayout(false);
            this.panelOperatorDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnDeleteOperator;
        private System.Windows.Forms.Button btnEditOperator;
        private System.Windows.Forms.Button btnAddOperator;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox txtSearchOperator;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowOperator;
        private System.Windows.Forms.DataGridView dgvOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationDate;
        private System.Windows.Forms.Panel panelOperatorDetails;
        private System.Windows.Forms.TextBox txtOperatorName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblOperatorName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnClear;
    }
}