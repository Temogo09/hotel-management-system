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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
            dgvDelete.SelectionChanged += dgvUpdate_SelectionChanged;
            //LoadRolesData();
        }

        private string constring = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet dataset = new DataSet();
        private string selectedField;
        private string selectedGuest_ID;
        private ComboBox cbxSearchBy;
        private Button btnSearch;
        private TextBox tbxSearch;
        private TextBox tbxCellNo;
        private TextBox tbxEmail;
        private TextBox tbxLastName;
        private TextBox tbxFirstName;
        private TextBox tbxGuestID;
        private Label lblEnter;
        private Label lblSearch;
        private Label lblCellNo;
        private Label lblEmail;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblID;
        private Button btnBack;
        private Button btnDelete;
        private Label label1;
        private DataGridView dgvDelete;
        private ErrorProvider errorProvider = new ErrorProvider();

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
            PopulateComboBoxes();


        }
        private void PopulateComboBoxes()
        {

            cbxSearchBy.Items.Clear();

            cbxSearchBy.Items.AddRange(new string[] { "FName", "LName", "Email", "CellNumber" });

        }

        private void PopulateDataGrid()
        {
            using (var conn = new SqlConnection(constring))
            {
                conn.Open();
                var query = "SELECT * FROM GUEST";
                var command = new SqlCommand(query, conn);
                adapter.SelectCommand = command;
                dataset.Clear();
                adapter.Fill(dataset, "GUEST");
                dgvDelete.DataSource = dataset.Tables["GUEST"];
            }
        }
        private void RemoveRoleFromDatabase(int guestID)
        {
            string[] queries = {
                "DELETE FROM BOOKING_ON_ROOM WHERE Booking_ref IN (SELECT Booking_ref FROM BOOKINGS WHERE Guest_ID = @Guest_ID)",
                "DELETE FROM BOOKINGS WHERE Guest_ID = @Guest_ID",
                "DELETE FROM GUEST WHERE Guest_ID = @Guest_ID"
            };

            using (var conn = new SqlConnection(constring))
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

        private void LoadRolesData()
        {
            string query = "SELECT * FROM GUEST";

            using (var conn = new SqlConnection(constring))
            using (var adapter = new SqlDataAdapter(query, conn))
            {
                conn.Open();
                var dataset = new DataTable();
                adapter.Fill(dataset);
                dgvDelete.DataSource = dataset;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GuestForm guest = new GuestForm();
            guest.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        private void dgvUpdate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDelete.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDelete.SelectedRows[0];
                selectedGuest_ID = selectedRow.Cells["Guest_ID"].Value?.ToString();

                // Populate textboxes with data from the selected row
                tbxGuestID.Text = selectedRow.Cells["Guest_ID"].Value?.ToString();
                tbxFirstName.Text = selectedRow.Cells["FName"].Value?.ToString();
                tbxLastName.Text = selectedRow.Cells["LName"].Value?.ToString();
                tbxEmail.Text = selectedRow.Cells["Email"].Value?.ToString();
                tbxCellNo.Text = selectedRow.Cells["CellNumber"].Value?.ToString();

                // Set textboxes to ReadOnly
                tbxGuestID.ReadOnly = true;
                tbxFirstName.ReadOnly = true;
                tbxLastName.ReadOnly = true;
                tbxEmail.ReadOnly = true;
                tbxCellNo.ReadOnly = true;
            }
        }

        private void cbxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void InitializeComponent()
        {
            this.cbxSearchBy = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.tbxCellNo = new System.Windows.Forms.TextBox();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.tbxGuestID = new System.Windows.Forms.TextBox();
            this.lblEnter = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCellNo = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDelete = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxSearchBy
            // 
            this.cbxSearchBy.FormattingEnabled = true;
            this.cbxSearchBy.Location = new System.Drawing.Point(136, 392);
            this.cbxSearchBy.Name = "cbxSearchBy";
            this.cbxSearchBy.Size = new System.Drawing.Size(121, 24);
            this.cbxSearchBy.TabIndex = 39;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(309, 435);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(152, 437);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(100, 22);
            this.tbxSearch.TabIndex = 37;
            // 
            // tbxCellNo
            // 
            this.tbxCellNo.Location = new System.Drawing.Point(680, 244);
            this.tbxCellNo.Name = "tbxCellNo";
            this.tbxCellNo.Size = new System.Drawing.Size(100, 22);
            this.tbxCellNo.TabIndex = 36;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(680, 190);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(100, 22);
            this.tbxEmail.TabIndex = 35;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Location = new System.Drawing.Point(680, 130);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(100, 22);
            this.tbxLastName.TabIndex = 34;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Location = new System.Drawing.Point(680, 72);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(100, 22);
            this.tbxFirstName.TabIndex = 33;
            // 
            // tbxGuestID
            // 
            this.tbxGuestID.Location = new System.Drawing.Point(680, 25);
            this.tbxGuestID.Name = "tbxGuestID";
            this.tbxGuestID.Size = new System.Drawing.Size(100, 22);
            this.tbxGuestID.TabIndex = 32;
            // 
            // lblEnter
            // 
            this.lblEnter.AutoSize = true;
            this.lblEnter.Location = new System.Drawing.Point(36, 437);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(110, 17);
            this.lblEnter.TabIndex = 31;
            this.lblEnter.Text = "Enter text/value:";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(39, 392);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(77, 17);
            this.lblSearch.TabIndex = 30;
            this.lblSearch.Text = "Search By:";
            // 
            // lblCellNo
            // 
            this.lblCellNo.AutoSize = true;
            this.lblCellNo.Location = new System.Drawing.Point(577, 244);
            this.lblCellNo.Name = "lblCellNo";
            this.lblCellNo.Size = new System.Drawing.Size(89, 17);
            this.lblCellNo.TabIndex = 29;
            this.lblCellNo.Text = "Cell Number:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(580, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(580, 130);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(80, 17);
            this.lblLastName.TabIndex = 27;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(577, 72);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(80, 17);
            this.lblFirstName.TabIndex = 26;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(574, 25);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(63, 17);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "Guest ID";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(733, 424);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 37);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(621, 424);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 37);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 22;
            // 
            // dgvDelete
            // 
            this.dgvDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelete.Location = new System.Drawing.Point(28, 12);
            this.dgvDelete.Name = "dgvDelete";
            this.dgvDelete.RowHeadersWidth = 51;
            this.dgvDelete.RowTemplate.Height = 24;
            this.dgvDelete.Size = new System.Drawing.Size(481, 254);
            this.dgvDelete.TabIndex = 40;
            // 
            // DeleteForm
            // 
            this.ClientSize = new System.Drawing.Size(980, 563);
            this.Controls.Add(this.dgvDelete);
            this.Controls.Add(this.cbxSearchBy);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.tbxCellNo);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.tbxLastName);
            this.Controls.Add(this.tbxFirstName);
            this.Controls.Add(this.tbxGuestID);
            this.Controls.Add(this.lblEnter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblCellNo);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteForm";
            this.Load += new System.EventHandler(this.DeleteForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int guestID = (int)dgvDelete.SelectedRows[0].Cells["Guest_ID"].Value;
            if (!int.TryParse(dgvDelete.SelectedRows[0].Cells["Guest_ID"].Value?.ToString(), out guestID))
            {
                errorProvider.SetError(dgvDelete, "Invalid Guest ID.");
                return;
            }

            // Confirm the deletion
            DialogResult result = MessageBox.Show("Are you sure you want to remove this booking?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call the method with both guestID and bookingRef
                    RemoveRoleFromDatabase(guestID);
                    // Reload data to reflect the changes
                    LoadRolesData();
                    MessageBox.Show("Booking removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while removing the booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            GuestForm back = new GuestForm();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
        }

        private void dgvDelete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDelete.SelectionChanged += dgvUpdate_SelectionChanged;
        }

        private void DeleteForm_Load_1(object sender, EventArgs e)
        {
            PopulateDataGrid();
            PopulateComboBoxes();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string selectedField = cbxSearchBy.SelectedItem.ToString();
            string search = tbxSearch.Text;

            string query = $"SELECT * FROM GUEST WHERE {selectedField} LIKE @search";

            using (var conn = new SqlConnection(constring))
            using (var command = new SqlCommand(query, conn))
            {
                conn.Open();
                command.Parameters.AddWithValue("@search", "%" + search + "%");
                adapter.SelectCommand = command;
                dataset.Clear();
                adapter.Fill(dataset, "GUEST");
                dgvDelete.DataSource = dataset.Tables["GUEST"];
            }
        }
    }
}
