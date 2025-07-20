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
    public partial class AddEmployee : Form
    {
        private string connection = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";

        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        private GroupBox groupBox2;
        private TextBox txtUsername;
        private Label label3;
        private Label label6;
        private TextBox txtPassword;
        private DataGridView dataGridViewAddEmplyee;
        private ErrorProvider errorProviderAddEmployee;
        private IContainer components;
        private Button button2;
        private Button button1;
        private GroupBox groupBox1;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private Label label8;
        private ComboBox cbxMarried;
        private Label label4;
        private Label label7;
        private ComboBox cbxRole;
        private Label label5;
        private TextBox txtIDNumber;
        private TextBox txtSurname;
        private TextBox txtNumber;
        SqlDataAdapter adapter;
        //SqlDataReader reader;
        public AddEmployee()
        {
            InitializeComponent();
        }

        private bool ValidateEmployeeInput(string fname, string lname, string idNumber, string cellNumber, string username, string password)
        {
            // Add input validation as needed
            if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(idNumber) ||
                string.IsNullOrWhiteSpace(cellNumber) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields must be filled out.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void AddEmployeeToDatabase(string fname, string lname, string idNumber, int maritalStatus, string cellNumber, string username, string password, int roleID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    // Insert into EMPLOYEE table

                    string insertEmployeeQuery = @"INSERT INTO EMPLOYEE (Roles_ID, Fname, Lname, IDNumber, MaritalStatus, CellNumber)
                                               VALUES (@Roles_ID, @Fname, @Lname, @IDNumber, @MaritalStatus, @CellNumber);
                                               SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(insertEmployeeQuery, conn);
                    cmd.Parameters.AddWithValue("@Roles_ID", roleID);
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                    cmd.Parameters.AddWithValue("@MaritalStatus", maritalStatus);
                    cmd.Parameters.AddWithValue("@CellNumber", cellNumber);

                    int employeeID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LoadRoles()
        {
            string query = "SELECT Roles_ID, JobTitle FROM ROLES";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbxRole.DataSource = dt;
                cbxRole.DisplayMember = "JobTitle";
                cbxRole.ValueMember = "Roles_ID";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadEmployeeData();
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
                    dataGridViewAddEmplyee.DataSource = dt;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.dataGridViewAddEmplyee = new System.Windows.Forms.DataGridView();
            this.errorProviderAddEmployee = new System.Windows.Forms.ErrorProvider(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxMarried = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDNumber = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddEmplyee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddEmployee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Location = new System.Drawing.Point(394, 255);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(379, 250);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LogIn Informtion";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(135, 53);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(195, 22);
            this.txtUsername.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 145);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(195, 22);
            this.txtPassword.TabIndex = 8;
            // 
            // dataGridViewAddEmplyee
            // 
            this.dataGridViewAddEmplyee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddEmplyee.Location = new System.Drawing.Point(34, 41);
            this.dataGridViewAddEmplyee.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewAddEmplyee.Name = "dataGridViewAddEmplyee";
            this.dataGridViewAddEmplyee.RowHeadersWidth = 51;
            this.dataGridViewAddEmplyee.Size = new System.Drawing.Size(739, 201);
            this.dataGridViewAddEmplyee.TabIndex = 24;
            // 
            // errorProviderAddEmployee
            // 
            this.errorProviderAddEmployee.ContainerControl = this;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(626, 529);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 55);
            this.button2.TabIndex = 10;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 529);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 55);
            this.button1.TabIndex = 9;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 22);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(191, 22);
            this.txtName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxMarried);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxRole);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIDNumber);
            this.groupBox1.Controls.Add(this.txtSurname);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Location = new System.Drawing.Point(34, 255);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(336, 330);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 278);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Role:";
            // 
            // cbxMarried
            // 
            this.cbxMarried.FormattingEnabled = true;
            this.cbxMarried.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cbxMarried.Location = new System.Drawing.Point(121, 224);
            this.cbxMarried.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMarried.Name = "cbxMarried";
            this.cbxMarried.Size = new System.Drawing.Size(191, 24);
            this.cbxMarried.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Surname";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Is Married:";
            // 
            // cbxRole
            // 
            this.cbxRole.FormattingEnabled = true;
            this.cbxRole.Items.AddRange(new object[] {
            "Manager",
            "Receptionist"});
            this.cbxRole.Location = new System.Drawing.Point(121, 274);
            this.cbxRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Size = new System.Drawing.Size(191, 24);
            this.cbxRole.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "CellNo";
            // 
            // txtIDNumber
            // 
            this.txtIDNumber.Location = new System.Drawing.Point(121, 118);
            this.txtIDNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDNumber.Name = "txtIDNumber";
            this.txtIDNumber.Size = new System.Drawing.Size(191, 22);
            this.txtIDNumber.TabIndex = 3;
            this.txtIDNumber.TextChanged += new System.EventHandler(this.txtIDNumber_TextChanged);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(121, 69);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(191, 22);
            this.txtSurname.TabIndex = 2;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(121, 167);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(191, 22);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // AddEmployee
            // 
            this.ClientSize = new System.Drawing.Size(816, 638);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewAddEmplyee);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEmployee";
            this.Load += new System.EventHandler(this.AddEmployee_Load_1);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddEmplyee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddEmployee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private int GetRoleID(string role)
        {
            int roleID = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "SELECT Roles_ID FROM ROLES WHERE JobTitle = @Role";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Role", role);
                    roleID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Role ID: " + ex.Message);
            }
            return roleID;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Retrieve input values from the form
            string fname = txtName.Text.Trim();
            string lname = txtSurname.Text.Trim();
            string idNumber = txtIDNumber.Text.Trim();
            string cellNumber = txtNumber.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            int maritalStatus = cbxMarried.SelectedIndex; // Assuming the ComboBox is populated with marital statuses
            int roleID = GetRoleID(cbxRole.SelectedItem?.ToString()); // Get the Role ID based on selected role

            // Validate input before adding employee
            if (ValidateEmployeeInput(fname, lname, idNumber, cellNumber, username, password))
            {
                // Add the employee to the database
                AddEmployeeToDatabase(fname, lname, idNumber, maritalStatus, cellNumber, username, password, roleID);
                MessageBox.Show("Employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh employee data after adding a new employee
                LoadEmployeeData();
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            MaintainEmployees back = new MaintainEmployees();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
        }

        private void AddEmployee_Load_1(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void txtIDNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtIDNumber.Text.Length > 13)
            {
                txtIDNumber.Text = txtIDNumber.Text.Substring(0, 13);
                txtIDNumber.SelectionStart = txtIDNumber.Text.Length;
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.Length > 10)
            {
                txtNumber.Text = txtNumber.Text.Substring(0, 10);
                txtNumber.SelectionStart = txtNumber.Text.Length;
            }
        }
    }
}
