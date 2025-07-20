using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement_System
{
    public partial class MaintainEmployees : Form
    {
        public MaintainEmployees()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee employees = new AddEmployee();

            employees.MdiParent = this.MdiParent;
            employees.Dock = DockStyle.Fill;
            employees.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateEmployee employees = new frmUpdateEmployee();

            employees.MdiParent = this.MdiParent;
            employees.Dock = DockStyle.Fill;
            employees.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveEmployee employees = new RemoveEmployee();

            employees.MdiParent = this.MdiParent;
            employees.Dock = DockStyle.Fill;
            employees.Show();
            this.Hide();
        }
    }
}
