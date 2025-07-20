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

namespace HotelManagement_System
{
    public partial class MaintainRoles : Form
    {
        public MaintainRoles()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            
            AddRole newRole = new AddRole();
            newRole.MdiParent = this.MdiParent;
            newRole.Dock = DockStyle.Fill;
            newRole.Show();
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            RemoveRole deleteRole = new RemoveRole();
            deleteRole.MdiParent = this.MdiParent;
            deleteRole.Dock = DockStyle.Fill;
            deleteRole.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }

        private void MaintainRoles_Load(object sender, EventArgs e)
        {

        }
    }
}
