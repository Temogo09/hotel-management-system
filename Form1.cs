using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project3;
using HotelManagement_System;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button btnLogOut;
        private Button btnGuest;
        private Button btnBooking;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            bookingForm booking = new bookingForm();
            booking.Show();

            this.Hide();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            GuestForm guest = new GuestForm();
            guest.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnGuest = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(11, 253);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(77, 34);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "&LogOut";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // btnGuest
            // 
            this.btnGuest.Location = new System.Drawing.Point(11, 101);
            this.btnGuest.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(77, 34);
            this.btnGuest.TabIndex = 4;
            this.btnGuest.Text = "&Guest";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click_1);
            // 
            // btnBooking
            // 
            this.btnBooking.Location = new System.Drawing.Point(11, 16);
            this.btnBooking.Margin = new System.Windows.Forms.Padding(2);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(77, 34);
            this.btnBooking.TabIndex = 3;
            this.btnBooking.Text = "&Booking";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(679, 486);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.btnBooking);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private void btnGuest_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBooking_Click_1(object sender, EventArgs e)
        {

        }
    }
}
