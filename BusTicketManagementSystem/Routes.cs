using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketManagementSystem
{
    public partial class Routes : Form
    {
        private readonly string connectionString =
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusTicketManagementSystem;Integrated Security=True";

    private readonly int operatorID;
        private int selectedRouteID = 0;

        public Routes(int operatorID)
        {
            InitializeComponent();

            this.operatorID = operatorID;

            // =====================================================
            // REMOVE DUPLICATE EVENT CONNECTIONS
            // =====================================================

            btnAddRoute.Click -= btnAddRoute_Click;
            btnAddRoute.Click += btnAddRoute_Click;

            btnEditRoute.Click -= btnEditRoute_Click;
            btnEditRoute.Click += btnEditRoute_Click;

            btnDeleteRoute.Click -= btnDeleteRoute_Click;
            btnDeleteRoute.Click += btnDeleteRoute_Click;

            btnShowRoutes.Click -= btnShowRoutes_Click;
            btnShowRoutes.Click += btnShowRoutes_Click;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            btnClear.Click -= btnClear_Click;
            btnClear.Click += btnClear_Click;

            dgvRoutes.CellClick -= dgvRoutes_CellClick;
            dgvRoutes.CellClick += dgvRoutes_CellClick;

            txtSearchRoute.KeyDown -= txtSearchRoute_KeyDown;
            txtSearchRoute.KeyDown += txtSearchRoute_KeyDown;

            // =====================================================
            // STATUS
            // =====================================================

            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            cmbStatus.SelectedIndex = -1;

            // =====================================================
            // GRID
            // =====================================================

            dgvRoutes.AutoGenerateColumns = false;

            colRouteID.DataPropertyName = "RouteID";
            colFrom.DataPropertyName = "FromLocation";
            colTo.DataPropertyName = "ToLocation";
            colDistance.DataPropertyName = "DistanceKM";
            colEstimatedTime.DataPropertyName = "EstimatedTime";
            colFare.DataPropertyName = "RouteFare";
            colStatus.DataPropertyName = "Status";
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void Routes_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadRoutes();
        }

        // =========================================================
        // LOAD ALL ROUTES
        // =========================================================

        private void LoadRoutes()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT
                        RouteID,
                        FromLocation,
                        ToLocation,
                        DistanceKM,
                        EstimatedTime,
                        RouteFare,
                        Status
                    FROM dbo.Routes
                    ORDER BY RouteID DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            dgvRoutes.DataSource = table;
                        }
                    }
                }

                dgvRoutes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load routes.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ADD ROUTE
        // =========================================================

        private void btnAddRoute_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateRouteInput())
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // -------------------------------------------------
                    // CHECK DUPLICATE ROUTE
                    // -------------------------------------------------

                    string duplicateQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.Routes
                    WHERE
                        LOWER(LTRIM(RTRIM(FromLocation))) =
                        LOWER(LTRIM(RTRIM(@FromLocation)))
                    AND
                        LOWER(LTRIM(RTRIM(ToLocation))) =
                        LOWER(LTRIM(RTRIM(@ToLocation)))";

                    using (SqlCommand checkCmd =
                        new SqlCommand(
                            duplicateQuery,
                            con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@FromLocation",
                            txtFrom.Text.Trim());

                        checkCmd.Parameters.AddWithValue(
                            "@ToLocation",
                            txtTo.Text.Trim());

                        int exists =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (exists > 0)
                        {
                            MessageBox.Show(
                                "This route already exists.",
                                "Duplicate Route",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    // -------------------------------------------------
                    // INSERT ROUTE
                    // -------------------------------------------------

                    string insertQuery = @"
                    INSERT INTO dbo.Routes
                    (
                        FromLocation,
                        ToLocation,
                        DistanceKM,
                        EstimatedTime,
                        RouteFare,
                        Status
                    )
                    VALUES
                    (
                        @FromLocation,
                        @ToLocation,
                        @DistanceKM,
                        @EstimatedTime,
                        @RouteFare,
                        @Status
                    )";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            insertQuery,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@FromLocation",
                            txtFrom.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@ToLocation",
                            txtTo.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@DistanceKM",
                            Convert.ToDecimal(
                                txtDistance.Text.Trim()));

                        cmd.Parameters.AddWithValue(
                            "@EstimatedTime",
                            txtEstimatedTime.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@RouteFare",
                            Convert.ToDecimal(
                                txtFare.Text.Trim()));

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Route added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadRoutes();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to add route.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // EDIT ROUTE
        // =========================================================

        private void btnEditRoute_Click(
            object sender,
            EventArgs e)
        {
            if (selectedRouteID == 0)
            {
                MessageBox.Show(
                    "Please select a route from the table first.",
                    "Edit Route",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateRouteInput())
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // -------------------------------------------------
                    // CHECK DUPLICATE ROUTE
                    // -------------------------------------------------

                    string duplicateQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.Routes
                    WHERE
                        LOWER(LTRIM(RTRIM(FromLocation))) =
                        LOWER(LTRIM(RTRIM(@FromLocation)))
                    AND
                        LOWER(LTRIM(RTRIM(ToLocation))) =
                        LOWER(LTRIM(RTRIM(@ToLocation)))
                    AND RouteID <> @RouteID";

                    using (SqlCommand checkCmd =
                        new SqlCommand(
                            duplicateQuery,
                            con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@FromLocation",
                            txtFrom.Text.Trim());

                        checkCmd.Parameters.AddWithValue(
                            "@ToLocation",
                            txtTo.Text.Trim());

                        checkCmd.Parameters.AddWithValue(
                            "@RouteID",
                            selectedRouteID);

                        int exists =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (exists > 0)
                        {
                            MessageBox.Show(
                                "Another route with the same From and To locations already exists.",
                                "Duplicate Route",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    // -------------------------------------------------
                    // UPDATE ROUTE
                    // -------------------------------------------------

                    string updateQuery = @"
                    UPDATE dbo.Routes
                    SET
                        FromLocation = @FromLocation,
                        ToLocation = @ToLocation,
                        DistanceKM = @DistanceKM,
                        EstimatedTime = @EstimatedTime,
                        RouteFare = @RouteFare,
                        Status = @Status
                    WHERE RouteID = @RouteID";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            updateQuery,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@FromLocation",
                            txtFrom.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@ToLocation",
                            txtTo.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@DistanceKM",
                            Convert.ToDecimal(
                                txtDistance.Text.Trim()));

                        cmd.Parameters.AddWithValue(
                            "@EstimatedTime",
                            txtEstimatedTime.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@RouteFare",
                            Convert.ToDecimal(
                                txtFare.Text.Trim()));

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.SelectedItem.ToString());

                        cmd.Parameters.AddWithValue(
                            "@RouteID",
                            selectedRouteID);

                        int rows =
                            cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show(
                                "Route could not be updated.",
                                "Update Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Route updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadRoutes();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to update route.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // DELETE ROUTE
        // =========================================================

        private void btnDeleteRoute_Click(
            object sender,
            EventArgs e)
        {
            if (selectedRouteID == 0)
            {
                MessageBox.Show(
                    "Please select a route from the table first.",
                    "Delete Route",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this route?\n\n" +
                    txtFrom.Text +
                    " → " +
                    txtTo.Text,
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    con.Open();

                    // -------------------------------------------------
                    // CHECK SCHEDULE DEPENDENCY
                    // -------------------------------------------------

                    string checkQuery = @"
                    SELECT COUNT(*)
                    FROM dbo.Schedules
                    WHERE RouteID = @RouteID";

                    using (SqlCommand checkCmd =
                        new SqlCommand(
                            checkQuery,
                            con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@RouteID",
                            selectedRouteID);

                        int scheduleCount =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar());

                        if (scheduleCount > 0)
                        {
                            MessageBox.Show(
                                "This route cannot be deleted because it is already used by one or more schedules.\n\n" +
                                "Please remove or update those schedules first.",
                                "Delete Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    // -------------------------------------------------
                    // DELETE ROUTE
                    // -------------------------------------------------

                    string deleteQuery = @"
                    DELETE FROM dbo.Routes
                    WHERE RouteID = @RouteID";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            deleteQuery,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@RouteID",
                            selectedRouteID);

                        int rows =
                            cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show(
                                "Route could not be deleted.",
                                "Delete Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Route deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadRoutes();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "This route cannot be deleted because it is being used by another part of the system.\n\n" +
                    ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to delete route.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SHOW ALL ROUTES
        // =========================================================

        private void btnShowRoutes_Click(
            object sender,
            EventArgs e)
        {
            txtSearchRoute.Clear();

            LoadRoutes();
            ClearFields();
        }

        // =========================================================
        // SEARCH
        // =========================================================

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            SearchRoutes();
        }

        private void txtSearchRoute_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchRoutes();
            }
        }

        private void SearchRoutes()
        {
            string searchText =
                txtSearchRoute.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadRoutes();
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT
                        RouteID,
                        FromLocation,
                        ToLocation,
                        DistanceKM,
                        EstimatedTime,
                        RouteFare,
                        Status
                    FROM dbo.Routes
                    WHERE
                        FromLocation LIKE @Search
                        OR ToLocation LIKE @Search
                        OR EstimatedTime LIKE @Search
                        OR Status LIKE @Search
                    ORDER BY RouteID DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(
                            query,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Search",
                            "%" + searchText + "%");

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            dgvRoutes.DataSource =
                                table;
                        }
                    }
                }

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search routes.\n\n" +
                    ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SELECT ROUTE FROM GRID
        // =========================================================

        private void dgvRoutes_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvRoutes.Rows[e.RowIndex];

                object routeIDValue =
                    row.Cells["colRouteID"].Value;

                if (routeIDValue == null ||
                    routeIDValue == DBNull.Value)
                {
                    return;
                }

                selectedRouteID =
                    Convert.ToInt32(routeIDValue);

                txtFrom.Text =
                    row.Cells["colFrom"]
                       .Value?.ToString() ?? "";

                txtTo.Text =
                    row.Cells["colTo"]
                       .Value?.ToString() ?? "";

                txtDistance.Text =
                    row.Cells["colDistance"]
                       .Value?.ToString() ?? "";

                txtEstimatedTime.Text =
                    row.Cells["colEstimatedTime"]
                       .Value?.ToString() ?? "";

                txtFare.Text =
                    row.Cells["colFare"]
                       .Value?.ToString() ?? "";

                string status =
                    row.Cells["colStatus"]
                       .Value?.ToString();

                if (!string.IsNullOrWhiteSpace(status))
                {
                    cmbStatus.SelectedItem = status;
                }
                else
                {
                    cmbStatus.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load selected route details.\n\n" +
                    ex.Message,
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // OLD DESIGNER EVENT COMPATIBILITY
        // =========================================================

        private void dgvRoutes_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Designer may still be connected to CellContentClick.
            // Redirect it to the working CellClick handler.
            dgvRoutes_CellClick(sender, e);
        }

        // =========================================================
        // CLEAR
        // =========================================================

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedRouteID = 0;

            txtFrom.Clear();
            txtTo.Clear();
            txtDistance.Clear();
            txtEstimatedTime.Clear();
            txtFare.Clear();

            cmbStatus.SelectedIndex = -1;

            dgvRoutes.ClearSelection();
        }

        // =========================================================
        // VALIDATION
        // =========================================================

        private bool ValidateRouteInput()
        {
            // -----------------------------------------------------
            // FROM
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                txtFrom.Text))
            {
                MessageBox.Show(
                    "Please enter the starting location.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFrom.Focus();
                return false;
            }

            // -----------------------------------------------------
            // TO
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                txtTo.Text))
            {
                MessageBox.Show(
                    "Please enter the destination.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTo.Focus();
                return false;
            }

            // -----------------------------------------------------
            // SAME LOCATION CHECK
            // -----------------------------------------------------

            if (string.Equals(
                txtFrom.Text.Trim(),
                txtTo.Text.Trim(),
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Starting location and destination cannot be the same.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTo.Focus();
                return false;
            }

            // -----------------------------------------------------
            // DISTANCE
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                txtDistance.Text))
            {
                MessageBox.Show(
                    "Please enter the distance.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDistance.Focus();
                return false;
            }

            decimal distance;

            if (!decimal.TryParse(
                txtDistance.Text.Trim(),
                out distance))
            {
                MessageBox.Show(
                    "Distance must be a valid number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDistance.Focus();
                return false;
            }

            if (distance <= 0)
            {
                MessageBox.Show(
                    "Distance must be greater than 0.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDistance.Focus();
                return false;
            }

            // -----------------------------------------------------
            // ESTIMATED TIME
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                txtEstimatedTime.Text))
            {
                MessageBox.Show(
                    "Please enter the estimated travel time.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEstimatedTime.Focus();
                return false;
            }

            // -----------------------------------------------------
            // FARE
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                txtFare.Text))
            {
                MessageBox.Show(
                    "Please enter the route fare.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFare.Focus();
                return false;
            }

            decimal fare;

            if (!decimal.TryParse(
                txtFare.Text.Trim(),
                out fare))
            {
                MessageBox.Show(
                    "Fare must be a valid number.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFare.Focus();
                return false;
            }

            if (fare <= 0)
            {
                MessageBox.Show(
                    "Fare must be greater than 0.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFare.Focus();
                return false;
            }

            // -----------------------------------------------------
            // STATUS
            // -----------------------------------------------------

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select the route status.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        // =========================================================
        // EXISTING DESIGNER EVENTS
        // =========================================================

        private void panelRouteDetails_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void txtDistance_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtTo_TextChanged(
            object sender,
            EventArgs e)
        {
        }
    }
}
