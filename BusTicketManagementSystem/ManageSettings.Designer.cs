
namespace BusTicketManagementSystem
{
    partial class ManageSettings
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
            this.labelPageTitle = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.cmbSystemStatus = new System.Windows.Forms.ComboBox();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblSystemSettings = new System.Windows.Forms.Label();
            this.btnChangeLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.labelLoginSettings = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelPageTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1078, 75);
            this.panelHeader.TabIndex = 0;
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageTitle.Location = new System.Drawing.Point(0, 0);
            this.labelPageTitle.Name = "labelPageTitle";
            this.labelPageTitle.Size = new System.Drawing.Size(1078, 75);
            this.labelPageTitle.TabIndex = 0;
            this.labelPageTitle.Text = "Settings";
            this.labelPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPageTitle.Click += new System.EventHandler(this.labelPageTitle_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnResetSettings);
            this.panelSettings.Controls.Add(this.btnSaveSettings);
            this.panelSettings.Controls.Add(this.cmbSystemStatus);
            this.panelSettings.Controls.Add(this.lblSystemStatus);
            this.panelSettings.Controls.Add(this.txtAppName);
            this.panelSettings.Controls.Add(this.lblApplicationName);
            this.panelSettings.Controls.Add(this.lblSystemSettings);
            this.panelSettings.Controls.Add(this.btnChangeLogin);
            this.panelSettings.Controls.Add(this.txtPassword);
            this.panelSettings.Controls.Add(this.txtUsername);
            this.panelSettings.Controls.Add(this.lblPassword);
            this.panelSettings.Controls.Add(this.lblUsername);
            this.panelSettings.Controls.Add(this.labelLoginSettings);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 75);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelSettings.Size = new System.Drawing.Size(1078, 519);
            this.panelSettings.TabIndex = 1;
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetSettings.Location = new System.Drawing.Point(288, 461);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(174, 46);
            this.btnResetSettings.TabIndex = 12;
            this.btnResetSettings.Text = "Reset Settings";
            this.btnResetSettings.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.Location = new System.Drawing.Point(19, 461);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(150, 46);
            this.btnSaveSettings.TabIndex = 11;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // cmbSystemStatus
            // 
            this.cmbSystemStatus.FormattingEnabled = true;
            this.cmbSystemStatus.Items.AddRange(new object[] {
            "Active",
            "Maintenance"});
            this.cmbSystemStatus.Location = new System.Drawing.Point(189, 425);
            this.cmbSystemStatus.Name = "cmbSystemStatus";
            this.cmbSystemStatus.Size = new System.Drawing.Size(121, 28);
            this.cmbSystemStatus.TabIndex = 10;
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatus.Location = new System.Drawing.Point(14, 424);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(141, 25);
            this.lblSystemStatus.TabIndex = 9;
            this.lblSystemStatus.Text = "System Status: ";
            this.lblSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(189, 384);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(273, 26);
            this.txtAppName.TabIndex = 8;
            this.txtAppName.Text = "BusGo";
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationName.Location = new System.Drawing.Point(13, 383);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(170, 25);
            this.lblApplicationName.TabIndex = 7;
            this.lblApplicationName.Text = "Application Name:";
            this.lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystemSettings
            // 
            this.lblSystemSettings.AutoSize = true;
            this.lblSystemSettings.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemSettings.Location = new System.Drawing.Point(12, 337);
            this.lblSystemSettings.Name = "lblSystemSettings";
            this.lblSystemSettings.Size = new System.Drawing.Size(256, 36);
            this.lblSystemSettings.TabIndex = 6;
            this.lblSystemSettings.Text = "System Information";
            this.lblSystemSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSystemSettings.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnChangeLogin
            // 
            this.btnChangeLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeLogin.Location = new System.Drawing.Point(18, 179);
            this.btnChangeLogin.Name = "btnChangeLogin";
            this.btnChangeLogin.Size = new System.Drawing.Size(341, 44);
            this.btnChangeLogin.TabIndex = 5;
            this.btnChangeLogin.Text = "Change Login Information";
            this.btnChangeLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(155, 147);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(273, 26);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(155, 89);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(273, 26);
            this.txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(14, 142);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(118, 30);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(14, 84);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(123, 30);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // labelLoginSettings
            // 
            this.labelLoginSettings.AutoSize = true;
            this.labelLoginSettings.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginSettings.Location = new System.Drawing.Point(12, 20);
            this.labelLoginSettings.Name = "labelLoginSettings";
            this.labelLoginSettings.Size = new System.Drawing.Size(189, 36);
            this.labelLoginSettings.TabIndex = 0;
            this.labelLoginSettings.Text = "Login Settings";
            this.labelLoginSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManageSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 594);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Settings";
            this.panelHeader.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelPageTitle;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelLoginSettings;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnChangeLogin;
        private System.Windows.Forms.Label lblSystemSettings;
        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.ComboBox cmbSystemStatus;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}