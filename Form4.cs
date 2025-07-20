using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        string connection = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        DataSet ds;
        private string selectedField;
        private string selectedGuest_ID;
        private Button btnBack;
        private Button btnSearch;
        private ComboBox cmbSearchBy;
        private Label label8;
        private TextBox txtBookingRef;
        private Label label9;
        private TextBox txtDuration;
        private Label label7;
        private TextBox txtNumKids;
        private TextBox txtNumAdults;
        private TextBox txtCheckOut;
        private Button button1;
        private TextBox txtCheckIn;
        private TextBox txtGuestId;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox txtSearch;
        private Label label1;
        private DataGridView dataGridView1;
        private ErrorProvider errorProvider = new ErrorProvider();


        public Form4()
        {
            InitializeComponent();
            PopulateComboBoxes();
            LoadRolesData();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            this.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void PopulateDataGrid()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            string populate = "SELECT * FROM BOOKINGS";
            SqlCommand command = new SqlCommand(populate, conn);
            adap = new SqlDataAdapter();
            ds = new DataSet();
            command = new SqlCommand(populate, conn);
            adap.SelectCommand = command;
            adap.Fill(ds, "BOOKINGS");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "BOOKINGS";

            conn.Close();
        }


        private void PopulateComboBoxes()
        {
            cmbSearchBy.Items.Clear();
            cmbSearchBy.Items.AddRange(new string[] { "Check_In", "Check_Out", "NumAdults", "NumChildren", "Duration" });
        }




        private void LoadRolesData()
        {
            string query = "SELECT * FROM BOOKINGS";

            using (var conn = new SqlConnection(connection))
            using (var adapter = new SqlDataAdapter(query, conn))
            {
                conn.Open();
                var dataset = new DataTable();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
            LoadRolesData();
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            txtBookingRef.Clear();
            txtGuestId.Clear();
            txtCheckIn.Clear();
            txtCheckOut.Clear();
            txtNumAdults.Clear();
            txtNumKids.Clear();
            txtDuration.Clear();
        }

        private void RemoveRoleFromDatabase(int guestID)
        {
            string[] queries = {
                "DELETE FROM BOOKING_ON_ROOM WHERE Booking_ref IN (SELECT Booking_ref FROM BOOKINGS WHERE Guest_ID = @Guest_ID)",
                "DELETE FROM BOOKINGS WHERE Guest_ID = @Guest_ID",
                "DELETE FROM GUEST WHERE Guest_ID = @Guest_ID"
            };

            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {


                        foreach (var query in queries)
                        {
                            using (var command = new SqlCommand(query, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@Guest_ID", guestID);
                                if (conn.State != ConnectionState.Open)
                                {
                                    conn.Open();
                                }
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred while removing the guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadRolesData(); // Refresh the data grid view
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewDelete_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                //selectedGuest_ID = selectedRow.Cells["Guest_ID"].Value?.ToString();

                // Populate textboxes with data from the selected row
                txtBookingRef.Text = selectedRow.Cells["Booking_ref"].Value?.ToString();
                txtGuestId.Text = selectedRow.Cells["Guest_ID"].Value?.ToString();
                txtCheckIn.Text = selectedRow.Cells["Check_In"].Value?.ToString();
                txtCheckOut.Text = selectedRow.Cells["Check_Out"].Value?.ToString();
                txtNumAdults.Text = selectedRow.Cells["NumAdults"].Value?.ToString();
                txtNumKids.Text = selectedRow.Cells["NumChildren"].Value?.ToString();
                txtDuration.Text = selectedRow.Cells["Duration"].Value?.ToString();

                // Set textboxes to ReadOnly
                txtBookingRef.ReadOnly = true;
                txtGuestId.ReadOnly = true;
                txtCheckIn.ReadOnly = true;
                txtCheckOut.ReadOnly = true;
                txtNumAdults.ReadOnly = true;
                txtNumKids.ReadOnly = true;
                txtDuration.ReadOnly = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
        }

        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBookingRef = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumKids = new System.Windows.Forms.TextBox();
            this.txtNumAdults = new System.Windows.Forms.TextBox();
            this.txtCheckOut = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCheckIn = new System.Windows.Forms.TextBox();
            this.txtGuestId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(740, 468);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(97, 53);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(266, 599);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Location = new System.Drawing.Point(192, 483);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(262, 24);
            this.cmbSearchBy.TabIndex = 15;
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 534);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Enter text/value:";
            // 
            // txtBookingRef
            // 
            this.txtBookingRef.Location = new System.Drawing.Point(162, 22);
            this.txtBookingRef.Name = "txtBookingRef";
            this.txtBookingRef.Size = new System.Drawing.Size(150, 22);
            this.txtBookingRef.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Booking Ref";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(162, 373);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(150, 22);
            this.txtDuration.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Duration:";
            // 
            // txtNumKids
            // 
            this.txtNumKids.Location = new System.Drawing.Point(162, 321);
            this.txtNumKids.Name = "txtNumKids";
            this.txtNumKids.Size = new System.Drawing.Size(150, 22);
            this.txtNumKids.TabIndex = 9;
            // 
            // txtNumAdults
            // 
            this.txtNumAdults.Location = new System.Drawing.Point(162, 242);
            this.txtNumAdults.Name = "txtNumAdults";
            this.txtNumAdults.Size = new System.Drawing.Size(150, 22);
            this.txtNumAdults.TabIndex = 8;
            // 
            // txtCheckOut
            // 
            this.txtCheckOut.Location = new System.Drawing.Point(162, 191);
            this.txtCheckOut.Name = "txtCheckOut";
            this.txtCheckOut.Size = new System.Drawing.Size(150, 22);
            this.txtCheckOut.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(564, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 53);
            this.button1.TabIndex = 12;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtCheckIn
            // 
            this.txtCheckIn.Location = new System.Drawing.Point(162, 134);
            this.txtCheckIn.Name = "txtCheckIn";
            this.txtCheckIn.Size = new System.Drawing.Size(150, 22);
            this.txtCheckIn.TabIndex = 6;
            // 
            // txtGuestId
            // 
            this.txtGuestId.Location = new System.Drawing.Point(162, 87);
            this.txtGuestId.Name = "txtGuestId";
            this.txtGuestId.Size = new System.Drawing.Size(150, 22);
            this.txtGuestId.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Number of Kids:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Number of Adults:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Check out:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Check in:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Guest_ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBookingRef);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDuration);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNumKids);
            this.groupBox1.Controls.Add(this.txtNumAdults);
            this.groupBox1.Controls.Add(this.txtCheckOut);
            this.groupBox1.Controls.Add(this.txtCheckIn);
            this.groupBox1.Controls.Add(this.txtGuestId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(564, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 428);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(192, 534);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(262, 22);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search By:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(509, 230);
            this.dataGridView1.TabIndex = 9;
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(1162, 675);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Populate the textboxes based on the selected row
                txtBookingRef.Text = dataGridView1.SelectedRows[0].Cells["Booking_ref"].Value.ToString();
                txtGuestId.Text = dataGridView1.SelectedRows[0].Cells["Guest_ID"].Value.ToString();
                txtCheckIn.Text = dataGridView1.SelectedRows[0].Cells["Check_In"].Value.ToString();
                txtCheckOut.Text = dataGridView1.SelectedRows[0].Cells["Check_Out"].Value.ToString();
                txtNumAdults.Text = dataGridView1.SelectedRows[0].Cells["NumAdults"].Value.ToString();
                txtNumKids.Text = dataGridView1.SelectedRows[0].Cells["NumChildren"].Value.ToString();
                txtDuration.Text = dataGridView1.SelectedRows[0].Cells["Duration"].Value.ToString();

                txtBookingRef.ReadOnly = true;
                txtGuestId.ReadOnly = true;
                txtCheckIn.ReadOnly = true;
                txtCheckOut.ReadOnly = true;
                txtNumAdults.ReadOnly = true;
                txtNumKids.ReadOnly = true;
                txtDuration.ReadOnly = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string guestID = selectedRow.Cells["Guest_ID"].Value?.ToString();

                if (int.TryParse(guestID, out int guestIDValue))
                {
                    RemoveRoleFromDatabase(guestIDValue);
                }
                else
                {
                    MessageBox.Show("Invalid Guest ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No row selected for deletion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            bookingForm back = new bookingForm();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchBy = cmbSearchBy.SelectedItem?.ToString();
            string searchValue = txtSearch.Text;

            if (!string.IsNullOrEmpty(searchBy) && !string.IsNullOrEmpty(searchValue))
            {
                string query = $"SELECT * FROM BOOKINGS WHERE {searchBy} LIKE @SearchValue";
                using (var conn = new SqlConnection(connection))
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                    adap = new SqlDataAdapter(command);
                    ds = new DataSet();
                    adap.Fill(ds, "BOOKINGS");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "BOOKINGS";
                }
            }
            else
            {
                MessageBox.Show("Please select a search criteria and enter a value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load_1(object sender, EventArgs e)
        {

        }
    }
}
