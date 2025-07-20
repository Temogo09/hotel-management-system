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
using HotelManagement_System;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        string connection = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBox2;
        private Label label1;
        private ComboBox comboBox1;
        private Button button1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button btnBack;
        DataSet ds;

        public Form3()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void populateDataGrid()
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

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            string populate = "SELECT * FROM BOOKINGS";

            SqlCommand command = new SqlCommand(populate, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Booking_ref"].ToString());


                }
                reader.Close();

            }

            comboBox2.Items.Add("NumAdults").ToString();
            comboBox2.Items.Add("NumChildren").ToString();
            comboBox2.Items.Add("Duration").ToString();

            adap = new SqlDataAdapter();
            ds = new DataSet();
            command = new SqlCommand(populate, conn);
            adap.SelectCommand = command;
            adap.Fill(ds, "BOOKINGS");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "BOOKINGS";

            conn.Close();
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(253, 575);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Value:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(284, 528);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(206, 24);
            this.comboBox2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Please select whatyou want to update:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(253, 487);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(899, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 47);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enter Booking Reference:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(970, 460);
            this.dataGridView1.TabIndex = 10;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(855, 559);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(155, 54);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(1068, 623);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bookingForm back = new bookingForm();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();

        }


        private void Form3_Load_1(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "SELECT Booking_ref FROM BOOKINGS";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["Booking_ref"].ToString());
                        }
                    }
                }

                // Populate fields to update
                comboBox2.Items.Add("NumAdults");
                comboBox2.Items.Add("NumChildren");
                comboBox2.Items.Add("Duration");

                populateDataGrid();
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Update the selected record based on the user's input
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                try
                {
                    using (conn = new SqlConnection(connection))
                    {
                        conn.Open();
                        string column = comboBox2.SelectedItem.ToString();
                        string bookingRef = comboBox1.SelectedItem.ToString();
                        string newValue = textBox1.Text;

                        string updateQuery = $"UPDATE BOOKINGS SET {column} = @Value WHERE Booking_ref = @BookingRef";
                        using (comm = new SqlCommand(updateQuery, conn))
                        {
                            comm.Parameters.AddWithValue("@Value", newValue);
                            comm.Parameters.AddWithValue("@BookingRef", bookingRef);
                            comm.ExecuteNonQuery();
                            MessageBox.Show("Booking updated successfully!");

                            // Refresh the DataGridView
                            populateDataGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating booking: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
            

        }
    }
}
