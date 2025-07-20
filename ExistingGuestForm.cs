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

namespace Project3
{
    public partial class ExistingGuestForm : Form
    {
        public ExistingGuestForm()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            txtEmail.TextChanged += txtEmail_TextChanged;
        }

        private ErrorProvider errorProvider;
        private string cnnString = @"Data Source=MSI;Initial Catalog=Hotel Management System;Integrated Security=True";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds = new DataSet();
        private string selectedSearch;
        private string selectedGuestID;
        
        private void PopulateDataGrid()
        {
            using(SqlConnection conn = new SqlConnection(cnnString))
            {
                string selectQuery = "SELECT * FROM Guest";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                adapter.SelectCommand = cmd;
                ds.Clear();
                adapter.Fill(ds, "Guest");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Guest";

            }
            
        }
        private void PopulateCombobox()
        {
            cmbSearch.Items.Clear();
            cmbSearch.Items.AddRange(new string[] { "First Name", "Surname", "Email", "Cell Number" });
                
        }
        private void ExistingGuestForm_Load(object sender, EventArgs e)
        {
            calendarCheckIn.Value = DateTime.Today;
            calendarCheckOut.Value = DateTime.Today.AddDays(1);
            CalendarExpiry.MaxDate = DateTime.Today.AddYears(10);

            PopulateDataGrid();
            PopulateCombobox();
           /* if(cmbSearch.SelectedItem ==null || string.IsNullOrEmpty(txtSearch.Text)
            {
                //error provider
            }*/

            if(dataGridView1.SelectedRows.Count >0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                selectedGuestID = selectedRow.Cells["Guest_ID"].Value ?. ToString();

                txtGuestId.Text = selectedRow.Cells["Guest_ID"].Value?.ToString();
                txtName.Text = selectedRow.Cells["Guest_ID"].Value?.ToString();
                txtSurname.Text = selectedRow.Cells["Guest_ID"].Value?.ToString();
                txtEmail.Text = selectedRow.Cells["Guest_ID"].Value?.ToString();
                txtCellNum.Text = selectedRow.Cells["CellNumber"].Value?.ToString();

                txtGuestId.ReadOnly = true;
                txtName.ReadOnly = true;
                txtSurname.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtCellNum.ReadOnly = true;
            }
           
        }

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            string room_type = cmbRoomType.SelectedItem.ToString();
            DateTime check_in = calendarCheckIn.Value;
            DateTime check_out = calendarCheckOut.Value;
            int numAdults = int.Parse(cmbAdults.SelectedValue.ToString());
            int numKids = int.Parse(cmbKids.SelectedValue.ToString());
            int duration = (check_out - check_in).Days;
            try
            {

                string query = "INSERT INTO GUEST (FName, LName, Email, CellNumber) " +
                                       "VALUES (@FName, @LName, @Email, @CellNumber);" +
                                       "DECLARE @NewGuestID INT SET @NewGuestID = SCOPE_IDENTITY(); " +
                                       "INSERT INTO BOOKINGS (Guest_ID, Check_In, Check_Out, NumAdults, NumChildren, Duration)" +
                                       "VALUES (@NewGuestID, @Check_In, @Check_Out, @NumAdults, @NumChildren, @Duration);";
             

                string nameOnCard = txtNameOnCard.Text;
                int cardNumber = int.Parse(txtCardNumber.Text);
                int cvv = int.Parse(txtCvv.Text);
                DateTime expiryDate = CalendarExpiry.Value;
                if (room_type == null && check_in == null && check_out == null && numAdults ==null && numKids ==null)
                {
                    //

                }
                string updatedField;
                string updatedValue;
                if(!string.IsNullOrEmpty(txtName.Text))
                {
                    updatedField = "FName";
                    updatedValue = txtName.Text;
                }

                else if (!string.IsNullOrEmpty(txtSurname.Text))
                {
                    updatedField = "LName";
                    updatedValue = txtSurname.Text;
                }
                else if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    updatedField = "Email";
                    updatedValue = txtEmail.Text;
                }
                else if (!string.IsNullOrEmpty(txtCellNum.Text))
                {
                    updatedField = "CellNumber";
                    updatedValue = txtCellNum.Text;
                }
                else
                {
                    //enter error provider
                }

                using (SqlConnection connection = new SqlConnection(cnnString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //command.Parameters.AddWithValue("@Guest_ID", );
                        command.Parameters.AddWithValue("@Check_In", check_in);
                        command.Parameters.AddWithValue("@Check_Out", check_out);
                        command.Parameters.AddWithValue("@NumAdults", numAdults);
                        command.Parameters.AddWithValue("@NumChildren", numKids);
                        command.Parameters.AddWithValue("@Duration", duration);

                        command.ExecuteNonQuery();

                    }
                }
                MessageBox.Show("Guest data saved!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (calendarCheckIn.Value >= calendarCheckOut.Value)
            {
                MessageBox.Show("Check-out must be after the check-in date");
                return;
            }
            
            DateTime selectedDate = new DateTime(CalendarExpiry.Value.Year, CalendarExpiry.Value.Month, DateTime.DaysInMonth(CalendarExpiry.Value.Year, CalendarExpiry.Value.Month));
           
            
            this.Close();

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string cellNo = txtEmail.Text;
            string room_type = cmbRoomType.SelectedItem.ToString();

            DateTime checkin = calendarCheckIn.Value;
            DateTime checkout = calendarCheckOut.Value;
            int numAdults = int.Parse(cmbAdults.Text);
            int numChildren = int.Parse(cmbKids.Text);

            int duration = (checkout - checkin).Days;


            DateTime selectedDate = new DateTime(CalendarExpiry.Value.Year, CalendarExpiry.Value.Month, DateTime.DaysInMonth(CalendarExpiry.Value.Year, calendarCheckIn.Value.Month));
            int ratesPerNightAdult = 0;
            int ratesPerNightChild = 0;
            int totalAmount = 0;
            using (SqlConnection conne = new SqlConnection(cnnString))
            {
                conne.Open();
                string rateQuery = "SELECT AdultPrice, ChildPrice FROM Room WHERE RoomName = @room_type";
                using (SqlCommand rateCommand = new SqlCommand(rateQuery, conne))
                {
                    rateCommand.Parameters.AddWithValue("@room_type", room_type);
                    using (SqlDataReader reader = rateCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ratesPerNightChild = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("ChildPrice")));
                            ratesPerNightAdult = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("AdultPrice")));
                        }
                    }
                }
            }
            // Calculate total amount
            totalAmount = ((ratesPerNightAdult * numAdults) + (ratesPerNightChild * numChildren)) * duration;
            lblAmounts.Text = totalAmount.ToString("C");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Booking made successfully!");
        }
        private void txtCellNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits or control keys (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Restrict input to 10 digits
            TextBox textBox = (TextBox)sender;
            if (char.IsDigit(e.KeyChar) && textBox.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }
        private void txtCellNum_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits or control keys (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Restrict input to 16 digits
            if (char.IsDigit(e.KeyChar) && ((TextBox)sender).Text.Length >= 16)
            {
                e.Handled = true;
            }
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Length > 16)
            {
                txtCardNumber.Text = txtCardNumber.Text.Substring(0, 16);
                txtCardNumber.SelectionStart = txtCardNumber.Text.Length;
            }
        }

        private void txtCvv_TextChanged(object sender, EventArgs e)
        {
            if (txtCvv.Text.Length > 4)
            {
                txtCvv.Text = txtCvv.Text.Substring(0, 4);
                txtCvv.SelectionStart = txtCvv.Text.Length;
            }
        }

        private void txtCvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits or control keys (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Restrict input to 4 digits
            if (char.IsDigit(e.KeyChar) && ((TextBox)sender).Text.Length >= 4)
            {
                e.Handled = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            /*GuestForm back = new GuestForm();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
            */
        }
    }
 }

