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
    public partial class frmUpdateEmployee : Form
    {
 

        private string connection = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        private DataTable employeeDataTable;

        DataSet ds = new DataSet();
        SqlDataAdapter adapter;
        private void dataGridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void UpdateEmployeeDetails_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();

            cbxSearchBy.Items.AddRange(new string[] { "Fname", "Lname", "IDNumber", "MaritalStatus", "CellNumber" });
            cbxFieldToUpdate.Items.AddRange(new string[] { "Fname", "Lname", "IDNumber", "MaritalStatus", "CellNumber" });

            txtEmployeeID.ReadOnly = true;
            txtRoleID.ReadOnly = true;
            txtFname.ReadOnly = true;
            txtLname.ReadOnly = true;
            txtIDNumber.ReadOnly = true;
            txtMaritalStatus.ReadOnly = true;
            txtCellNumber.ReadOnly = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
           

            // Clear previous errors
            errorProviderUpdateEmployee.Clear();

            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                errorProviderUpdateEmployee.SetError(cbxFieldToUpdate, "Please select a record to update.");
                return;
            }

            // Determine which textbox has a value
            string updateField = null;
            string updateValue = null;

            // Update only one field
            if (txtFname.ReadOnly == false && !string.IsNullOrEmpty(txtFname.Text))
            {
                updateField = "Fname";
                updateValue = txtFname.Text;
            }
            else if (txtLname.ReadOnly == false && !string.IsNullOrEmpty(txtLname.Text))
            {
                updateField = "Lname";
                updateValue = txtLname.Text;
            }
            else if (txtIDNumber.ReadOnly == false && !string.IsNullOrEmpty(txtIDNumber.Text))
            {
                updateField = "IDNumber";
                updateValue = txtIDNumber.Text;
            }
            else if (txtMaritalStatus.ReadOnly == false && !string.IsNullOrEmpty(txtMaritalStatus.Text))
            {
                updateField = "MaritalStatus";
                updateValue = txtMaritalStatus.Text;
            }
            else if (txtCellNumber.ReadOnly == false && !string.IsNullOrEmpty(txtCellNumber.Text))
            {
                updateField = "CellNumber";
                updateValue = txtCellNumber.Text;
            }
            else
            {
                errorProviderUpdateEmployee.SetError(cbxFieldToUpdate, "Please provide a value for the selected field.");
                return;
            }

            if (cbxFieldToUpdate.SelectedItem == null)
            {
                MessageBox.Show("Please select a field to update.");
                return;
            }

            string id = txtEmployeeID.Text;

            string updateQuery = $"UPDATE EMPLOYEE SET {updateField} = @value WHERE Employee_ID = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@value", updateValue);
                    command.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Updated successfully!");
                        LoadEmployeeData();
                    }
                    else
                    {
                        MessageBox.Show("No records updated. Please check the employee ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
        public frmUpdateEmployee()
        {
            InitializeComponent();
            dataGridViewEmployee.SelectionChanged += dataGridViewEmployee_SelectionChanged;
            this.AutoScroll = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MaintainEmployees back = new MaintainEmployees();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
            this.Close();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e) { }

        private void dataGridViewEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEmployee.SelectedRows.Count > 0)
            {
                // Populate the textboxes based on the selected row
                txtEmployeeID.Text = dataGridViewEmployee.SelectedRows[0].Cells["Employee_ID"].Value.ToString();
                txtRoleID.Text = dataGridViewEmployee.SelectedRows[0].Cells["Roles_ID"].Value.ToString();
                txtFname.Text = dataGridViewEmployee.SelectedRows[0].Cells["Fname"].Value.ToString();
                txtLname.Text = dataGridViewEmployee.SelectedRows[0].Cells["Lname"].Value.ToString();
                txtIDNumber.Text = dataGridViewEmployee.SelectedRows[0].Cells["IDNumber"].Value.ToString();
                txtMaritalStatus.Text = dataGridViewEmployee.SelectedRows[0].Cells["MaritalStatus"].Value.ToString();
                txtCellNumber.Text = dataGridViewEmployee.SelectedRows[0].Cells["CellNumber"].Value.ToString();
            }
        }

        private void LoadEmployeeData(string field = "", string filter = "")
        {
            string query = "SELECT Employee_ID, Roles_ID, Fname, Lname, IDNumber, MaritalStatus, CellNumber FROM EMPLOYEE";

            try
            {
                // Create a new connection to the database
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewEmployee.DataSource = dt;
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle any SQL errors
                MessageBox.Show($"A database error occurred: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any other errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxSearchBy.SelectedItem == null || string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string selectedField = cbxSearchBy.SelectedItem.ToString();
            string search = txtSearch.Text;

            string query = $"SELECT * FROM EMPLOYEE WHERE {selectedField} LIKE @search";

            using (SqlConnection conn = new SqlConnection(connection))
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@search", "%" + search + "%");
                adapter.SelectCommand = command;
                ds.Clear();
                adapter.Fill(ds, "EMPLOYEE");
                dataGridViewEmployee.DataSource = ds;
                dataGridViewEmployee.DataMember = "EMPLOYEE";
            }
        }
        private void cbxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFieldToUpdate.SelectedIndex == 0)
            {
                txtFname.ReadOnly = false;
            }
            else if (cbxFieldToUpdate.SelectedIndex == 1)
            {
                txtLname.ReadOnly = false;
            }
            else if (cbxFieldToUpdate.SelectedIndex == 2)
            {
                txtIDNumber.ReadOnly = false;
            }
            else if (cbxFieldToUpdate.SelectedIndex == 3)
            {
                txtMaritalStatus.ReadOnly = false;
            }
            else if (cbxFieldToUpdate.SelectedIndex == 4)
            {
                txtCellNumber.ReadOnly = false;
            }
        }
    }
}

