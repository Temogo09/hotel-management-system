using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project3
{
    public partial class AddRole : Form
    {
        private string sConnection = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        private Label label1;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private Button btnAddRole;
        private Button btnBack;
        private ErrorProvider errorProvider;

        public AddRole()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
        }

        private void AddRoleToDatabase(string roleName)
        {
            string query = "INSERT INTO ROLES (JobTitle) VALUES (@JobTitle)";
            using (SqlConnection conn = new SqlConnection(sConnection))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", roleName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AddRole_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private bool RoleExistsInDatabase(string roleName)
        {
            string query = "SELECT COUNT(*) FROM ROLES WHERE JobTitle = @JobTitle";
            using (SqlConnection conn = new SqlConnection(sConnection))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", roleName);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add Role:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 22);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnAddRole);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 274);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding A New Role";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(152, 204);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 45);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRole.BackColor = System.Drawing.Color.Black;
            this.btnAddRole.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddRole.FlatAppearance.BorderSize = 0;
            this.btnAddRole.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddRole.Location = new System.Drawing.Point(152, 125);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(129, 45);
            this.btnAddRole.TabIndex = 11;
            this.btnAddRole.Text = "Add Role";
            this.btnAddRole.UseVisualStyleBackColor = false;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // AddRole
            // 
            this.ClientSize = new System.Drawing.Size(579, 335);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddRole";
            this.Text = "Add Role";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            string addedRole = textBox1.Text;

            // Clear previous errors
            errorProvider.Clear();

            if (string.IsNullOrEmpty(addedRole))
            {
                // Set the error on the textBox1 control
                errorProvider.SetError(textBox1, "Please enter a role to add.");
                return;
            }

            // Check if the role already exists in the database
            if (RoleExistsInDatabase(addedRole))
            {
                // Display an error using ErrorProvider if the role already exists
                errorProvider.SetError(textBox1, "Role already exists.");
                return;
            }

            // Ask for confirmation before adding the role
            DialogResult result = MessageBox.Show("Are you sure you want to add a new role?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Add role to the database
                AddRoleToDatabase(addedRole);

                MessageBox.Show($"{addedRole} role added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
