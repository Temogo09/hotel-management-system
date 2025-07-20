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
using WindowsFormsApp1;
using HotelManagement_System;


namespace Project3
{
    public partial class Dashboard : Form
    {
        private Panel panel1;
        private Button button2;
        private Button button1;
        private Label lblEntityName;
        private Button btnEmployees;
        private ToolTip toolTip1;
        private IContainer components;
        private Button btnRoles;
        private Button btnLogOut;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pbxManagerBackground;
        private Button btnReports;

        public Dashboard()
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

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployeeForm = new AddEmployee();
            addEmployeeForm.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveEmployee removeEmployeeForm = new RemoveEmployee();
            removeEmployeeForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddRole addRoleForm = new AddRole();
            addRoleForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RemoveRole removeRoleForm = new RemoveRole();
            removeRoleForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login LoginForm = new Login();
            LoginForm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEntityName = new System.Windows.Forms.Label();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReports = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbxManagerBackground = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxManagerBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblEntityName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(166, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 49);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(788, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "__";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(846, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblEntityName
            // 
            this.lblEntityName.AutoSize = true;
            this.lblEntityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntityName.Location = new System.Drawing.Point(12, 8);
            this.lblEntityName.Name = "lblEntityName";
            this.lblEntityName.Size = new System.Drawing.Size(178, 25);
            this.lblEntityName.TabIndex = 2;
            this.lblEntityName.Text = "Hotel RahaTower";
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.Black;
            this.btnEmployees.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Location = new System.Drawing.Point(3, 3);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(159, 44);
            this.btnEmployees.TabIndex = 2;
            this.btnEmployees.Text = "Employees";
            this.toolTip1.SetToolTip(this.btnEmployees, "Click here to display the booking form");
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.Black;
            this.btnRoles.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.ForeColor = System.Drawing.Color.White;
            this.btnRoles.Location = new System.Drawing.Point(3, 53);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(159, 44);
            this.btnRoles.TabIndex = 3;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Black;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(3, 153);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(159, 44);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.btnEmployees);
            this.flowLayoutPanel1.Controls.Add(this.btnRoles);
            this.flowLayoutPanel1.Controls.Add(this.btnReports);
            this.flowLayoutPanel1.Controls.Add(this.btnLogOut);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(166, 526);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Black;
            this.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(3, 103);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(159, 44);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // pbxManagerBackground
            // 
            this.pbxManagerBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxManagerBackground.Image = global::HotelManagement_System.Properties.Resources.logo_silver;
            this.pbxManagerBackground.Location = new System.Drawing.Point(166, 49);
            this.pbxManagerBackground.Name = "pbxManagerBackground";
            this.pbxManagerBackground.Size = new System.Drawing.Size(901, 477);
            this.pbxManagerBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxManagerBackground.TabIndex = 7;
            this.pbxManagerBackground.TabStop = false;
            // 
            // Dashboard
            // 
            this.ClientSize = new System.Drawing.Size(1067, 526);
            this.Controls.Add(this.pbxManagerBackground);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxManagerBackground)).EndInit();
            this.ResumeLayout(false);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Login loginPage = new Login();
            loginPage.Show();
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Login loginPage = new Login();
            loginPage.Show();
            this.Close();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            pbxManagerBackground.Visible = false;
            MaintainEmployees employeesForm = new MaintainEmployees();

            employeesForm.MdiParent = this;
            employeesForm.Dock = DockStyle.Fill;
            employeesForm.Show();

            btnReports.Enabled = true;
            btnRoles.Enabled = true;
            btnEmployees.Enabled = false;

            btnReports.BackColor = Color.Black;
            btnRoles.BackColor = Color.Black;
            btnEmployees.BackColor = Color.White;

        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            pbxManagerBackground.Visible = false;
            MaintainRoles rolesForm = new MaintainRoles();

            rolesForm.MdiParent = this;
            rolesForm.Dock = DockStyle.Fill;
            rolesForm.Show();

            btnReports.Enabled = true;
            btnRoles.Enabled = false;
            btnEmployees.Enabled = true;

            btnReports.BackColor = Color.Black;
            btnRoles.BackColor = Color.White;
            btnEmployees.BackColor = Color.Black;
            btnEmployees.ForeColor = Color.White;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            pbxManagerBackground.Visible = false;
            Reports reportsForm = new Reports();

            reportsForm.MdiParent = this;
            reportsForm.Dock = DockStyle.Fill;
            reportsForm.Show();

            btnReports.Enabled = false;
            btnRoles.Enabled = true;
            btnEmployees.Enabled = true;

            btnReports.BackColor = Color.White;
            btnRoles.BackColor = Color.Black;
            btnEmployees.BackColor = Color.Black;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
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

        private void btnEmployee_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
