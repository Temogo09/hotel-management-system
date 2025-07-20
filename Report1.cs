using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project3
{
    public partial class Report1 : Form
    {
        // Connection string to the database
        private string connectionString = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";

        public Report1()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        // Event handler for generating reports
        private void btnGenerateReports_Click(object sender, EventArgs e)
        {

            btnReport1_Click(sender, e);
        }

        // Event handler for the button to generate report
        private void btnReport1_Click(object sender, EventArgs e)
        {
            // Define a simplified SQL query for top 10 peak weeks
            string query = "SELECT DATEPART(YEAR, B.Check_In) AS Year, " +
                           "DATEPART(WEEK, B.Check_In) AS Week, " +
                           "COUNT(B.Booking_ref) AS NumberOfBookings " +
                           "FROM BOOKINGS B " +
                           "JOIN BOOKING_ON_ROOM BR ON B.Booking_ref = BR.Booking_ref " +
                           "JOIN ROOM R ON BR.Room_ID = R.Room_ID " +
                           "WHERE (@RoomType IS NULL OR R.RoomName = @RoomType) " +
                           "AND (@StartDate IS NULL OR B.Check_In >= @StartDate) " +
                           "AND (@EndDate IS NULL OR B.Check_Out <= @EndDate) " +
                           "GROUP BY DATEPART(YEAR, B.Check_In), DATEPART(WEEK, B.Check_In) " +
                           "ORDER BY NumberOfBookings DESC " +
                           "OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;";

            // Execute the query with parameters
            DataTable top10PeakWeeks = ExecuteQuery(query);

            // Clear the listbox
            LBReports.Items.Clear();

            // Add column headers
            LBReports.Items.Add("Year\tWeek\tNumberOfBookings");

            // Check if DataTable is not null and has rows
            if (top10PeakWeeks != null && top10PeakWeeks.Rows.Count > 0)
            {
                // Add data to the listbox
                foreach (DataRow row in top10PeakWeeks.Rows)
                {
                    LBReports.Items.Add($"{row["Year"]}\t{row["Week"]}\t{row["NumberOfBookings"]}");
                }
            }
            else
            {
                // Inform the user if no data is returned
                MessageBox.Show("No data returned from the query.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to execute SQL query with parameters
        private DataTable ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@RoomType", string.IsNullOrWhiteSpace(cBoxRoomType.Text) ? (object)DBNull.Value : cBoxRoomType.Text);
                        command.Parameters.AddWithValue("@StartDate", dateTimePicker1.Value != null ? (object)dateTimePicker1.Value.ToString("yyyy-MM-dd") : DBNull.Value);
                        command.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value != null ? (object)dateTimePicker2.Value.ToString("yyyy-MM-dd") : DBNull.Value);

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

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
         
            /*Reports back = new Reports();
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
