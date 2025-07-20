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
using Project3;
using WindowsFormsApp1;
using HotelManagement_System;

namespace WindowsFormsApp1
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            dgvUpdate.SelectionChanged += dgvUpdate_SelectionChanged;
            this.AutoScroll = true;
        }



        private string constring = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet dataset = new DataSet();
        private string selectedField;
        private string selectedGuest_ID;
        private Button button1;
        private TextBox tbxSearch;
        private Label label9;
        private Label label8;
        private ComboBox cbxChoice;
        private Label label7;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private Label label2;
        private Button btnBack;
        private Label label4;
        private Label label3;
        private Button btnUpdate;
        private ComboBox cbxSearchBy;
        private Label label1;
        private DataGridView dgvUpdate;
        private ErrorProvider errorProvider = new ErrorProvider();


        private void PopulateDataGrid()
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                conn.Open();
                string query = "SELECT * FROM GUEST";
                SqlCommand command = new SqlCommand(query, conn);
                adapter.SelectCommand = command;
                dataset.Clear();
                adapter.Fill(dataset, "GUEST");
                dgvUpdate.DataSource = dataset;
                dgvUpdate.DataMember = "GUEST";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {

            PopulateDataGrid();
            PopulateComboBoxes();

        }

        private void PopulateComboBoxes()
        {
            cbxChoice.Items.Clear();
            cbxSearchBy.Items.Clear();

            cbxSearchBy.Items.AddRange(new string[] { "FName", "LName", "Email", "CellNumber" });
            cbxChoice.Items.AddRange(new string[] { "FName", "LName", "Email", "CellNumber" });
        }

        private void dgvUpdate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUpdate.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvUpdate.SelectedRows[0];
                selectedGuest_ID = selectedRow.Cells["Guest_ID"].Value?.ToString();

                // Populate textboxes with data from the selected row
                textBox1.Text = selectedRow.Cells["Guest_ID"].Value?.ToString();
                textBox2.Text = selectedRow.Cells["FName"].Value?.ToString();
                textBox3.Text = selectedRow.Cells["LName"].Value?.ToString();
                textBox4.Text = selectedRow.Cells["Email"].Value?.ToString();
                textBox5.Text = selectedRow.Cells["CellNumber"].Value?.ToString();

                // Set textboxes to ReadOnly
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            GuestForm guest = new GuestForm();
            guest.Show();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxChoice = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvUpdate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(144, 406);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(100, 22);
            this.tbxSearch.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Enter text/value:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 43;
            // 
            // cbxChoice
            // 
            this.cbxChoice.FormattingEnabled = true;
            this.cbxChoice.Location = new System.Drawing.Point(286, 445);
            this.cbxChoice.Name = "cbxChoice";
            this.cbxChoice.Size = new System.Drawing.Size(121, 24);
            this.cbxChoice.TabIndex = 42;
            this.cbxChoice.SelectedIndexChanged += new System.EventHandler(this.cbxChoice_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 17);
            this.label7.TabIndex = 41;
            this.label7.Text = "Select what you would like to update:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(812, 242);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 40;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(812, 189);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 39;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(812, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 38;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(812, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 37;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(812, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(723, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "CellNumber:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(720, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Last Name:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(829, 422);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 48);
            this.btnBack.TabIndex = 32;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "GuestID:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(688, 422);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 47);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbxSearchBy
            // 
            this.cbxSearchBy.FormattingEnabled = true;
            this.cbxSearchBy.Location = new System.Drawing.Point(129, 365);
            this.cbxSearchBy.Name = "cbxSearchBy";
            this.cbxSearchBy.Size = new System.Drawing.Size(215, 24);
            this.cbxSearchBy.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Search by:";
            // 
            // dgvUpdate
            // 
            this.dgvUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdate.Location = new System.Drawing.Point(41, 12);
            this.dgvUpdate.Name = "dgvUpdate";
            this.dgvUpdate.RowHeadersWidth = 51;
            this.dgvUpdate.RowTemplate.Height = 24;
            this.dgvUpdate.Size = new System.Drawing.Size(586, 288);
            this.dgvUpdate.TabIndex = 47;
            this.dgvUpdate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // UpdateForm
            // 
            this.ClientSize = new System.Drawing.Size(977, 562);
            this.Controls.Add(this.dgvUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxChoice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbxSearchBy);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.Load += new System.EventHandler(this.UpdateForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            GuestForm back = new GuestForm();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateField = null;
            string updateValue = null;


            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                updateField = "FName";
                updateValue = textBox2.Text;
            }
            else if (!string.IsNullOrEmpty(textBox3.Text))
            {
                updateField = "LName";
                updateValue = textBox3.Text;
            }
            else if (!string.IsNullOrEmpty(textBox4.Text))
            {
                updateField = "Email";
                updateValue = textBox4.Text;
            }
            else if (!string.IsNullOrEmpty(textBox5.Text))
            {
                updateField = "CellNumber";
                updateValue = textBox5.Text;
            }
            else
            {
                errorProvider.SetError(textBox2, "Please enter a value to update.");
                return;
            }
            string selectedField = cbxChoice.SelectedItem.ToString();
            string id = textBox1.Text;



            // Construct the update query dynamically based on the selected field
            string updateQuery = $"UPDATE GUEST SET {updateField} = @value WHERE Guest_ID = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@value", updateValue);
                    command.Parameters.AddWithValue("id", id);

                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Updated successfully!");
                        PopulateDataGrid(); 
                    }
                    else
                    {
                        MessageBox.Show("No records updated. Please check the booking reference.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void UpdateForm_Load_1(object sender, EventArgs e)
        {
            PopulateComboBoxes();

            using (SqlConnection conn = new SqlConnection(constring))
            {
                conn.Open();
                string query = "SELECT * FROM GUEST";
                SqlCommand command = new SqlCommand(query, conn);
                adapter.SelectCommand = command;
                dataset.Clear();
                adapter.Fill(dataset, "GUEST");
                dgvUpdate.DataSource = dataset;
                dgvUpdate.DataMember = "GUEST";
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string selectedField = cbxSearchBy.SelectedItem.ToString();
            string search = tbxSearch.Text;

            string query = $"SELECT * FROM GUEST WHERE {selectedField} LIKE @search";

            using (SqlConnection conn = new SqlConnection(constring))
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@search", "%" + search + "%");
                adapter.SelectCommand = command;
                dataset.Clear();
                adapter.Fill(dataset, "GUEST");
                dgvUpdate.DataSource = dataset;
                dgvUpdate.DataMember = "GUEST";
            }
        }

        private void cbxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChoice.SelectedIndex == 0)
            {
                textBox2.ReadOnly = false;
            }
            else if (cbxChoice.SelectedIndex == 1)
            {
                textBox3.ReadOnly = false;
            }
            else if (cbxChoice.SelectedIndex == 2)
            {
                textBox4.ReadOnly = false;
            }
            else
            {
                textBox5.ReadOnly = false;
            }
        }
    }
}