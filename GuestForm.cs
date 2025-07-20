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
using WindowsFormsApp1;


namespace WindowsFormsApp1
{
    public partial class GuestForm : Form
    {
        private Button btnAddGuest;
        private Button btnDeleteGuest;
        private Button btnBack;
        private FlowLayoutPanel flowLayoutPanel1;

        public GuestForm()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successful");
            this.Close();

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateForm update = new UpdateForm();
            update.Show();
            this.Close();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteForm delete = new DeleteForm();
            delete.Show();
            this.Close();
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.btnDeleteGuest = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddGuest);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteGuest);
            this.flowLayoutPanel1.Controls.Add(this.btnBack);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 147);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 222);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.BackColor = System.Drawing.Color.Black;
            this.btnAddGuest.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddGuest.FlatAppearance.BorderSize = 0;
            this.btnAddGuest.ForeColor = System.Drawing.Color.White;
            this.btnAddGuest.Location = new System.Drawing.Point(4, 4);
            this.btnAddGuest.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(176, 54);
            this.btnAddGuest.TabIndex = 3;
            this.btnAddGuest.Text = "Update Guest Details";
            this.btnAddGuest.UseVisualStyleBackColor = false;
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
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
            this.btnDeleteGuest.Text = "Delete Guest Details";
            this.btnDeleteGuest.UseVisualStyleBackColor = false;
            this.btnDeleteGuest.Click += new System.EventHandler(this.btnDeleteGuest_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(4, 128);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(176, 54);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // GuestForm
            // 
            this.ClientSize = new System.Drawing.Size(884, 514);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GuestForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            UpdateForm updateGuest = new UpdateForm();
            updateGuest.MdiParent = this.MdiParent;
            updateGuest.Dock = DockStyle.Fill;
            updateGuest.Show();
            this.Hide();
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            //if (this.MdiParent != null)
            //{
            //    this.MdiParent.Activate();
            //}

            DeleteForm deleteGuest = new DeleteForm();
            deleteGuest.MdiParent = this.MdiParent;  
            deleteGuest.Dock = DockStyle.Fill;
            deleteGuest.Show();
            this.Hide(); 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            String message = "Going back will log you out, are you sure want to log out?";
            String caption = "Logout";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Login loginPage = new Login();
                loginPage.Show();

                frmMain main = new frmMain();
                main.Close();
                this.Close();
            }
        }
    }
}
