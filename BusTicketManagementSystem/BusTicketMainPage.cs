using System;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class BusTicketMainPage : Form
    {
        public BusTicketMainPage()
        {
            InitializeComponent();

            // Handle the X button separately
            this.FormClosing += BusTicketMainPage_FormClosing;
        }

        private void BusTicketMainPage_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select your role first.",
                    "Role Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string selectedRole =
                comboBox1.SelectedItem.ToString();

            // =====================================================
            // SUPER ADMIN
            // =====================================================

            if (selectedRole.Contains("SuperAdmin"))
            {
                this.Hide();

                SuperAdmin superAdminForm =
                    new SuperAdmin();

                superAdminForm.ShowDialog();

                this.Show();
            }

            // =====================================================
            // BUS OPERATOR / ADMIN
            // =====================================================

            else if (selectedRole.Contains("Bus Operator"))
            {
                this.Hide();

                AdminLogin adminLogin =
                    new AdminLogin();

                adminLogin.ShowDialog();

                this.Show();
            }

            // =====================================================
            // CUSTOMER
            // =====================================================

            else if (selectedRole.Contains("Customer"))
            {
                this.Hide();

                CustomerLogin customerLogin =
                    new CustomerLogin();

                customerLogin.ShowDialog();

                this.Show();
            }

            // =====================================================
            // INVALID ROLE
            // =====================================================

            else
            {
                MessageBox.Show(
                    "Invalid role selected.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            ExitApplication();
        }

        // =========================================================
        // MAIN FORM X BUTTON
        // =========================================================

        private void BusTicketMainPage_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        // =========================================================
        // EXIT BUTTON
        // =========================================================

        private void ExitApplication()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}