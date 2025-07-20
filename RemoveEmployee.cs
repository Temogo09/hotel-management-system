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


namespace HotelManagement_System
{
    public partial class RemoveEmployee : Form
    {

        private string con = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        SqlCommand com = new SqlCommand();
        private Button button2;
        private Button button1;
        private DataGridView dataGridViewRemove;
        DataSet ds = new DataSet();
        //SqlDataAdapter adap;
        //SqlDataReader reader;

        public RemoveEmployee()
        {
            InitializeComponent();
        }

        private void LoadEmployeeData()
        {
            string query = "SELECT Employee_ID, Fname, Lname, IDNumber, MaritalStatus, CellNumber, Roles_ID FROM EMPLOYEE";
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewRemove.DataSource = dt;
                    dataGridViewRemove.Columns["Employee_ID"].HeaderText = "Employee ID"; // Rename column header
                    dataGridViewRemove.Columns["Fname"].HeaderText = "First Name"; // Rename column header
                    dataGridViewRemove.Columns["Lname"].HeaderText = "Last Name"; // Rename column header
                    dataGridViewRemove.Columns["IDNumber"].HeaderText = "ID Number"; // Rename column header
                    dataGridViewRemove.Columns["MaritalStatus"].HeaderText = "Marital Status"; // Rename column header
                    dataGridViewRemove.Columns["CellNumber"].HeaderText = "Cell Number"; // Rename column header
                    dataGridViewRemove.Columns["Roles_ID"].HeaderText = "Role ID"; // Rename column header
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"A database error occurred while loading employee data: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRolesData()
        {
            string query = "SELECT Roles_ID, JobTitle FROM ROLES";
            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRemove.DataSource = dt;
            }
        }

        /*private void RemoveRoleFromDatabase(int roleId)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "DELETE FROM ROLES WHERE Roles_ID = @Roles_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Roles_ID", roleId);
                cmd.ExecuteNonQuery();
            }
        }*/

        private void RemoveEmployeeFromDatabase(int employeeId)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    string query = "DELETE FROM EMPLOYEE WHERE Employee_ID = @Employee_ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Employee_ID", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewRemove = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(361, 314);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 314);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridViewRemove
            // 
            this.dataGridViewRemove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRemove.Location = new System.Drawing.Point(11, 11);
            this.dataGridViewRemove.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRemove.Name = "dataGridViewRemove";
            this.dataGridViewRemove.RowHeadersWidth = 51;
            this.dataGridViewRemove.RowTemplate.Height = 24;
            this.dataGridViewRemove.Size = new System.Drawing.Size(516, 284);
            this.dataGridViewRemove.TabIndex = 3;
            // 
            // RemoveEmployee
            // 
            this.ClientSize = new System.Drawing.Size(805, 470);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewRemove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoveEmployee";
            this.Load += new System.EventHandler(this.RemoveEmployee_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemove)).EndInit();
            this.ResumeLayout(false);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewRemove.SelectedRows.Count > 0) // Check if a row is selected
            {
                // Get the Employee_ID of the selected row
                int employeeId = Convert.ToInt32(dataGridViewRemove.SelectedRows[0].Cells["Employee_ID"].Value);

                // Confirmation dialog
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this employee?", "Confirm Remove", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Remove the employee from the database
                    RemoveEmployeeFromDatabase(employeeId);

                    // Reload the employee data to reflect the changes
                    LoadEmployeeData();

                    MessageBox.Show("Employee removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to remove.", "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveEmployee_Load_1(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MaintainEmployees back = new MaintainEmployees();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
        }
    }
}
