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
using WindowsFormsApp1;
using HotelManagement_System;

namespace Project3
{
    public partial class RemoveRole : Form
    {
        private string connectionString = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter adap;
        private DataGridView dataGridViewRemoveRole;
        private Button button2;
        private Button button1;
        SqlDataReader reader;
        public RemoveRole()
        {
            InitializeComponent();
        }
        private void LoadRolesData()
        {
            string query = "SELECT Roles_ID, JobTitle FROM ROLES";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewRemoveRole.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void RemoveRoleFromDatabase(int roleId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM ROLES WHERE Roles_ID = @Roles_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Roles_ID", roleId);
                cmd.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RemoveRole_Load(object sender, EventArgs e)
        {
            LoadRolesData();
        }

        private void InitializeComponent()
        {
            this.dataGridViewRemoveRole = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemoveRole)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRemoveRole
            // 
            this.dataGridViewRemoveRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRemoveRole.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRemoveRole.Name = "dataGridViewRemoveRole";
            this.dataGridViewRemoveRole.RowHeadersWidth = 51;
            this.dataGridViewRemoveRole.RowTemplate.Height = 24;
            this.dataGridViewRemoveRole.Size = new System.Drawing.Size(718, 323);
            this.dataGridViewRemoveRole.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(478, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // RemoveRole
            // 
            this.ClientSize = new System.Drawing.Size(787, 451);
            this.Controls.Add(this.dataGridViewRemoveRole);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoveRole";
            this.Load += new System.EventHandler(this.RemoveRole_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemoveRole)).EndInit();
            this.ResumeLayout(false);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewRemoveRole.SelectedRows.Count > 0) // Ensure a row is selected
            {
                // Get the Roles_ID of the selected row
                int roleId = Convert.ToInt32(dataGridViewRemoveRole.SelectedRows[0].Cells["Roles_ID"].Value);

                // Confirmation dialog
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this role?", "Confirm Remove", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Remove the role from the database
                    RemoveRoleFromDatabase(roleId);

                    // Reload the roles data to reflect the changes
                    LoadRolesData();

                    MessageBox.Show("Role removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a role to remove.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MaintainRoles back = new MaintainRoles();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
        }

        private void RemoveRole_Load_1(object sender, EventArgs e)
        {
            LoadRolesData();
        }
    }
}
