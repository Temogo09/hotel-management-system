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

namespace Project3
{
    public partial class Login : Form
    {
        private string con = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter adap;
        SqlDataReader reader;

        public string UniversalConnectionString()
        {
            return "Data Source=RELEBOHILE;Initial Catalog=Hotel Management System;Integrated Security=True";
        }

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size((int)(workingArea.Width * 0.2455), (int)(workingArea.Height * 0.6));
            this.Location = new Point((workingArea.Width - this.Width) / 2, (workingArea.Height - this.Height) / 2);
        }
        private bool ValidateInput(out string username, out string password)
        {
            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || username == "Enter your username...")
            {
                MessageBox.Show("Please enter a valid username.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();  // Focus on the username field
                return false;
            }

            if (string.IsNullOrWhiteSpace(password) || password == "Enter your password...")
            {
                MessageBox.Show("Please enter a valid password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();  // Focus on the password field
                return false;
            }

            return true;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            if (!ValidateInput(out username, out password))
            {
                return;
            }

            //SqlConnection conn = new SqlConnection(con);
            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    //if (conn.State == ConnectionState.Closed)
                    //{
                    //    conn.Open();
                    //}
                    conn.Open();
                    // Corrected SQL query to use parameters
                    string query = "SELECT R.JobTitle FROM LOGIN_INFO L JOIN EMPLOYEE E ON L.Employee_ID = E.Employee_ID JOIN ROLES R ON E.Roles_ID = R.Roles_ID WHERE L.Username = @Username AND L.Password = @Password";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
                    adapter.SelectCommand.Parameters.AddWithValue("@Password", password);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string role = dt.Rows[0]["JobTitle"].ToString().Trim();

                        // Handle different roles
                        if (role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
                        {
                            // Open Manager's form
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else if (role.Equals("Receptionist", StringComparison.OrdinalIgnoreCase))
                        {
                            // Open Receptionist's form
                            frmMain ReceptionistForm = new frmMain();
                            ReceptionistForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Unknown role.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("O thula pale"); //(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //finally
                //{
                //    conn.Close();
                //}
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
