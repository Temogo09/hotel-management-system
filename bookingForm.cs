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
    public partial class bookingForm : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAddBooking;
        private Button btnDeleteGuest;
        private Button button1;
        private Button btnBack;

        public bookingForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successful");
            this.Close();
        }

        private void cBoxPaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2();
            add.Show();
            this.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form3 update = new Form3();
            update.Show();
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 delete = new Form4();
            delete.Show();
            this.Close();

        }

        private void bookingForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddBooking = new System.Windows.Forms.Button();
            this.btnDeleteGuest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddBooking);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteGuest);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.btnBack);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(48, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 283);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnAddBooking
            // 
            this.btnAddBooking.BackColor = System.Drawing.Color.Black;
            this.btnAddBooking.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddBooking.FlatAppearance.BorderSize = 0;
            this.btnAddBooking.ForeColor = System.Drawing.Color.White;
            this.btnAddBooking.Location = new System.Drawing.Point(4, 4);
            this.btnAddBooking.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBooking.Name = "btnAddBooking";
            this.btnAddBooking.Size = new System.Drawing.Size(176, 54);
            this.btnAddBooking.TabIndex = 3;
            this.btnAddBooking.Text = "Add a Booking";
            this.btnAddBooking.UseVisualStyleBackColor = false;
            this.btnAddBooking.Click += new System.EventHandler(this.btnAddBooking_Click);
            // 
            // btnDeleteGuest
            // 
            this.btnDeleteGuest.BackColor = System.Drawing.Color.Black;
            this.btnDeleteGuest.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteGuest.FlatAppearance.BorderSize = 0;
            this.btnDeleteGuest.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGuest.Location = new System.Drawing.Point(4, 66);
            this.btnDeleteGuest.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteGuest.Name = "btnDeleteGuest";
            this.btnDeleteGuest.Size = new System.Drawing.Size(176, 54);
            this.btnDeleteGuest.TabIndex = 4;
            this.btnDeleteGuest.Text = "Change Booking Details";
            this.btnDeleteGuest.UseVisualStyleBackColor = false;
            this.btnDeleteGuest.Click += new System.EventHandler(this.btnDeleteGuest_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(4, 128);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 54);
            this.button1.TabIndex = 6;
            this.button1.Text = "Delete Booking";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(4, 190);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(176, 54);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // bookingForm
            // 
            this.ClientSize = new System.Drawing.Size(1059, 621);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "bookingForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            String message = "Going back will log you out, are you sure want to log out?";
            String caption = "Logout";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Login loginPage = new Login();
                loginPage.Show();

                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 delete = new Form4();
            delete.MdiParent = this.MdiParent;
            delete.Dock = DockStyle.Fill;
            delete.Show();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            String message = "Has the guest made a booking with us before?";
            String caption = "Add booking";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Login loginPage = new Login();
                loginPage.Show();

                this.Close();
            }
            else
            {
                Form2 newGuestBooking = new Form2();
                newGuestBooking.MdiParent = this.MdiParent;
                newGuestBooking.Dock = DockStyle.Fill;
                newGuestBooking.Show();
            }
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            Form3 deleteGuest = new Form3();
            deleteGuest.MdiParent = this.MdiParent;
            deleteGuest.Dock = DockStyle.Fill;
            deleteGuest.Show();
            this.Hide();

            
        }
    }
}
