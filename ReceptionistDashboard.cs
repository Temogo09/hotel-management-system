using System;
using System.Drawing;
using System.Windows.Forms;
using Project3;
using WindowsFormsApp1;

namespace HotelManagement_System
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // Center the form and set its size
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size((int)(workingArea.Width * 0.75), (int)(workingArea.Height * 0.90));
            this.Location = new Point((workingArea.Width - this.Width) / 2, (workingArea.Height - this.Height) / 2);

            // Set the form to be an MDI container
            this.IsMdiContainer = true;
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            pbxReceptionistBackground.Visible = false;
            bookingForm myBookingForm = new bookingForm();

            myBookingForm.MdiParent = this;
            myBookingForm.Dock = DockStyle.Fill;
            myBookingForm.Show();



            btnBooking.Enabled = false;
            btnGuests.Enabled = true;

            btnGuests.BackColor = Color.Black;
            btnBooking.BackColor = Color.Red;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Handle logout functionality
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            // Handle guests functionality
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String message = "Are you sure want to log out?";
            String caption = "Logout?";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Login loginPage = new Login();
                loginPage.Show();

                this.Close();
            }
        }

        private void btnGuests_Click_1(object sender, EventArgs e)
        {
            pbxReceptionistBackground.Visible = false;
            GuestForm guest = new GuestForm();
            guest.MdiParent = this;
            guest.Dock = DockStyle.Fill;
            guest.Show();


            btnGuests.Enabled = false;
            btnBooking.Enabled = true;

            btnGuests.BackColor = Color.Red;
            btnBooking.BackColor = Color.Black;
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            String message = "Are you sure want to log out?";
            String caption = "Logout";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Login loginPage = new Login();
                loginPage.Show();

                this.Close();
            }
        }
    }
}