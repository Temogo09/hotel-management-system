using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement_System;
using Project3;
using WindowsFormsApp1;

namespace HotelManagement_System
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            Report1 report1 = new Report1();

            report1.MdiParent = this.MdiParent;
            report1.Dock = DockStyle.Fill;
            report1.Show();
            this.Hide();
        }

        private void btnReport2_Click(object sender, EventArgs e)
        {
            Report2 report2 = new Report2();

            report2.MdiParent = this.MdiParent;
            report2.Dock = DockStyle.Fill;
            report2.Show();
            this.Hide();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }
    }
}
