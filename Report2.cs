using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project3
{
    public partial class Report2 : Form
    {
        // Connection string to the database
        private string sConnection = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";

        public Report2()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        // Event handler for the Generate Report button
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        // Method to execute SQL query with parameters
        private DataTable ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sConnection))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Check if a RoomType is selected, if not, pass DBNull
                        if (string.IsNullOrWhiteSpace(comboBox1.Text))
                        {
                            command.Parameters.AddWithValue("@RoomType", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@RoomType", comboBox1.Text);
                        }

                        // Add StartDate and EndDate parameters
                        command.Parameters.AddWithValue("@StartDate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value.ToString("yyyy-MM-dd"));

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Event handler for the Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Define the SQL query to generate the income report
            string query = "SELECT " +
                           "CONVERT(varchar, MIN(B.Check_In), 101) AS StartDate, " +
                           "CONVERT(varchar, MAX(B.Check_Out), 101) AS EndDate, " +
                           "COUNT(B.Booking_ref) AS TotalNumberOfBookings " +
                           "FROM BOOKINGS B " +
                           "JOIN BOOKING_ON_ROOM BR ON B.Booking_ref = BR.Booking_ref " +
                           "JOIN ROOM R ON BR.Room_ID = R.Room_ID " +
                           "WHERE (R.RoomName = @RoomType OR @RoomType IS NULL) " +
                           "AND (@StartDate IS NULL OR B.Check_In >= @StartDate) " +
                           "AND (@EndDate IS NULL OR B.Check_Out <= @EndDate);";

            // Execute the query with parameters
            DataTable incomeReport = ExecuteQuery(query);

            // Clear the listbox
            lstIncome.Items.Clear();

            // Add column headers
            lstIncome.Items.Add("StartDate\t\t\tEndDate\t\t\tTotalNumberOfBookings");

            // Check if DataTable is not null and has rows
            if (incomeReport != null && incomeReport.Rows.Count > 0)
            {
                // Add data to the listbox
                foreach (DataRow row in incomeReport.Rows)
                {
                    lstIncome.Items.Add($"{row["StartDate"]}\t\t{row["EndDate"]}\t\t{row["TotalNumberOfBookings"]}");
                }
            }
            else
            {
                // Inform the user if no data is returned
                MessageBox.Show("No data returned from the query.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBACK_Click_1(object sender, EventArgs e)
        {
           /* Reports back = new Reports();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();*/
            this.Close();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
