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
namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private ErrorProvider errorProvider;
        string connection = "Data Source=DESKTOP-KKRLFK7;Initial Catalog = Hotel Database; Integrated Security = True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        DataSet ds;
        private Button btnMakeBooking;
        private TextBox txtCellNo;
        private Label label11;
        private TextBox txtEmail;
        private Label label10;
        private TextBox txtLName;
        private Button btnCalculate;
        private Label lblAmounts;
        private Label lblAmount;
        private Label label15;
        private Label label6;
        private TextBox txtCVV;
        private Label label14;
        private TextBox txtCardNo;
        private Label label13;
        private TextBox txtNameCard;
        private Label label12;
        private DateTimePicker dateTimePicker3;
        private Label label16;
        private GroupBox groupBox3;
        private Label label9;
        private TextBox txtName;
        private Button btnBack;
        private GroupBox groupBox2;
        private Label label8;
        private Button btnSave;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private DateTimePicker dateTimePicker2;
        private ComboBox cBoxKids;
        private ComboBox cBoxAdults;
        private ComboBox cBoxRoomType;
        private GroupBox groupBox1;
        public static int iMax_Guests;

        public Form2()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            txtEmail.TextChanged += txtEmail_TextChanged;
            txtName.KeyPress += txtName_KeyPress;
            txtLName.KeyPress += txtLName_KeyPress;
            this.AutoScroll = true;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddDays(1);
            dateTimePicker3.MaxDate = DateTime.Today.AddYears(10);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNo.Text.Length > 16)
            {
                txtCardNo.Text = txtCardNo.Text.Substring(0, 16);
                txtCardNo.SelectionStart = txtCardNo.Text.Length;
            }
        }

        private void cBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cBoxAdults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Booking Made Successfully");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCVV_TextChanged(object sender, EventArgs e)
        {
            if (txtCVV.Text.Length > 4)
            {
                txtCVV.Text = txtCVV.Text.Substring(0, 4);
                txtCVV.SelectionStart = txtCVV.Text.Length;
            }
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }

        private void txtCellNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCellNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only alphabetic characters and control keys (like backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only alphabetic characters and control keys (like backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void InitializeComponent()
        {
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.txtCellNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblAmounts = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNameCard = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cBoxKids = new System.Windows.Forms.ComboBox();
            this.cBoxAdults = new System.Windows.Forms.ComboBox();
            this.cBoxRoomType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Location = new System.Drawing.Point(613, 438);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(194, 42);
            this.btnMakeBooking.TabIndex = 13;
            this.btnMakeBooking.Text = "Make A Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // txtCellNo
            // 
            this.txtCellNo.Location = new System.Drawing.Point(134, 279);
            this.txtCellNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCellNo.Name = "txtCellNo";
            this.txtCellNo.Size = new System.Drawing.Size(200, 30);
            this.txtCellNo.TabIndex = 4;
            this.txtCellNo.TextChanged += new System.EventHandler(this.txtCellNo_TextChanged_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Cell Number:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(134, 215);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 30);
            this.txtEmail.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Email:";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(134, 146);
            this.txtLName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(200, 30);
            this.txtLName.TabIndex = 2;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(355, 258);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(123, 30);
            this.btnCalculate.TabIndex = 12;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click_1);
            // 
            // lblAmounts
            // 
            this.lblAmounts.AutoSize = true;
            this.lblAmounts.Location = new System.Drawing.Point(150, 258);
            this.lblAmounts.Name = "lblAmounts";
            this.lblAmounts.Size = new System.Drawing.Size(17, 25);
            this.lblAmounts.TabIndex = 16;
            this.lblAmounts.Text = ".";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(144, 253);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 25);
            this.lblAmount.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 209);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 20);
            this.label15.TabIndex = 14;
            this.label15.Text = "Expiry Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Total Amount:";
            // 
            // txtCVV
            // 
            this.txtCVV.Location = new System.Drawing.Point(144, 154);
            this.txtCVV.Margin = new System.Windows.Forms.Padding(4);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(200, 30);
            this.txtCVV.TabIndex = 11;
            this.txtCVV.TextChanged += new System.EventHandler(this.txtCVV_TextChanged_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "CVV";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(144, 92);
            this.txtCardNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCardNo.MaxLength = 16;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(200, 30);
            this.txtCardNo.TabIndex = 10;
            this.txtCardNo.TextChanged += new System.EventHandler(this.txtCardNo_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "Card Number";
            // 
            // txtNameCard
            // 
            this.txtNameCard.Location = new System.Drawing.Point(144, 31);
            this.txtNameCard.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameCard.Name = "txtNameCard";
            this.txtNameCard.Size = new System.Drawing.Size(200, 30);
            this.txtNameCard.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Name on Card";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "MM/yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(144, 207);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 30);
            this.dateTimePicker3.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(423, -9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 17);
            this.label16.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox3.Controls.Add(this.btnCalculate);
            this.groupBox3.Controls.Add(this.lblAmounts);
            this.groupBox3.Controls.Add(this.lblAmount);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtCVV);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtCardNo);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtNameCard);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.dateTimePicker3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 300);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Card Details";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Last Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(134, 73);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 30);
            this.txtName.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(613, 522);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(141, 29);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtCellNo);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtLName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 350);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Personal Details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "First Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(215, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Check-In:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Check-Out:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Adults:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kids:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(214, 241);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 30);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Room Type:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(215, 309);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 30);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // cBoxKids
            // 
            this.cBoxKids.FormattingEnabled = true;
            this.cBoxKids.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cBoxKids.Location = new System.Drawing.Point(214, 167);
            this.cBoxKids.Name = "cBoxKids";
            this.cBoxKids.Size = new System.Drawing.Size(200, 33);
            this.cBoxKids.TabIndex = 7;
            // 
            // cBoxAdults
            // 
            this.cBoxAdults.FormattingEnabled = true;
            this.cBoxAdults.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cBoxAdults.Location = new System.Drawing.Point(215, 111);
            this.cBoxAdults.Name = "cBoxAdults";
            this.cBoxAdults.Size = new System.Drawing.Size(199, 33);
            this.cBoxAdults.TabIndex = 6;
            this.cBoxAdults.SelectedIndexChanged += new System.EventHandler(this.cBoxAdults_SelectedIndexChanged_1);
            // 
            // cBoxRoomType
            // 
            this.cBoxRoomType.FormattingEnabled = true;
            this.cBoxRoomType.Items.AddRange(new object[] {
            "STANDARD",
            "DELUXE",
            "SUITE"});
            this.cBoxRoomType.Location = new System.Drawing.Point(215, 49);
            this.cBoxRoomType.Name = "cBoxRoomType";
            this.cBoxRoomType.Size = new System.Drawing.Size(200, 33);
            this.cBoxRoomType.TabIndex = 5;
            this.cBoxRoomType.SelectedIndexChanged += new System.EventHandler(this.cBoxRoomType_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.cBoxKids);
            this.groupBox1.Controls.Add(this.cBoxAdults);
            this.groupBox1.Controls.Add(this.cBoxRoomType);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(613, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 401);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Details";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(1283, 729);
            this.Controls.Add(this.btnMakeBooking);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load_1);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bookingForm back = new bookingForm();
            back.MdiParent = this.MdiParent;
            back.Dock = DockStyle.Fill;
            back.Show();
            this.Close();
            
        }

        private int GetGuestID()
        {
            int guestID = -1;

            try
            {
                using (conn = new SqlConnection(connection))
                {
                    conn.Open();

                    // First, check if the guest already exists based on email
                    string queryCheck = "SELECT Guest_ID FROM GUESTS WHERE Email = @Email";
                    comm = new SqlCommand(queryCheck, conn);
                    comm.Parameters.AddWithValue("@Email", txtEmail.Text);

                    var result = comm.ExecuteScalar();

                    if (result != null) // If guest exists
                    {
                        guestID = Convert.ToInt32(result);
                    }
                    else // If guest doesn't exist, insert new guest and get the new Guest_ID
                    {
                        string queryInsert = "INSERT INTO GUESTS (FirstName, LastName, Email, CellNo) " +
                                             "OUTPUT INSERTED.Guest_ID " +
                                             "VALUES (@FirstName, @LastName, @Email, @CellNo)";

                        comm = new SqlCommand(queryInsert, conn);
                        comm.Parameters.AddWithValue("@FirstName", txtName.Text);
                        comm.Parameters.AddWithValue("@LastName", txtLName.Text);
                        comm.Parameters.AddWithValue("@Email", txtEmail.Text);
                        comm.Parameters.AddWithValue("@CellNo", txtCellNo.Text);

                        // Execute the query and get the inserted Guest_ID
                        guestID = (int)comm.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Guest ID: " + ex.Message);
            }

            return guestID;
        }


        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Booking Made Successfully");    
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtLName.Text;
            string email = txtEmail.Text;
            string cellNo = txtCellNo.Text;
            string room_type = cBoxRoomType.SelectedItem.ToString();

            DateTime checkin = dateTimePicker1.Value;
            DateTime checkout = dateTimePicker2.Value;
            /*string numAdults = cBoxAdults.Text;
            string numChildren = cBoxKids.Text;*/
            int numAdults = int.Parse(cBoxAdults.Text);
            int numChildren = int.Parse(cBoxKids.Text);
            int duration = (checkout - checkin).Days;
            
            try
            {
               

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                 string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(cellNo))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                // Establish a connection to the database
                using (conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "INSERT INTO GUEST (FName, LName, Email, CellNumber) " +
                                   "VALUES (@FName, @LName, @Email, @CellNumber);" +
                                   "DECLARE @NewGuestID INT SET @NewGuestID = SCOPE_IDENTITY(); " +
                                   "INSERT INTO BOOKINGS (Guest_ID, Check_In, Check_Out, NumAdults, NumChildren, Duration)" +
                                   "VALUES (@NewGuestID, @Check_In, @Check_Out, @NumAdults, @NumChildren, @Duration);";

                    // Create SQL Command
                    using (comm = new SqlCommand(query, conn))
                    {
                        // Add parameters to SQL Command
                        comm.Parameters.AddWithValue("@FName", name);
                        comm.Parameters.AddWithValue("@LName", surname);
                        comm.Parameters.AddWithValue("@Email", email);
                        comm.Parameters.AddWithValue("@CellNumber", cellNo);

                        //change this CODE
                        //comm.Parameters.AddWithValue("@Guest_ID", );
                        comm.Parameters.AddWithValue("@Check_In", checkin);
                        comm.Parameters.AddWithValue("@Check_Out", checkout);
                        comm.Parameters.AddWithValue("@NumAdults", numAdults);
                        comm.Parameters.AddWithValue("@NumChildren", numChildren);
                        comm.Parameters.AddWithValue("@Duration", duration);

                        // Execute the command
                        comm.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Customer information saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Check-out must be after the check-in date");
                return;
            }
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string surname = txtLName.Text;
                string email = txtEmail.Text;
                string cellNo = txtCellNo.Text;
                string room_type = cBoxRoomType.SelectedItem.ToString();

                DateTime checkin = dateTimePicker1.Value;
                DateTime checkout = dateTimePicker2.Value;
                int numAdults = int.Parse(cBoxAdults.Text);
                int numChildren = int.Parse(cBoxAdults.Text);

                int duration = (checkout - checkin).Days;


                DateTime selectedDate = new DateTime(dateTimePicker3.Value.Year, dateTimePicker3.Value.Month, DateTime.DaysInMonth(dateTimePicker3.Value.Year, dateTimePicker3.Value.Month));
                int ratesPerNightAdult = 0;
                int ratesPerNightChild = 0;
                int totalAmount = 0;
                using (SqlConnection conne = new SqlConnection(connection))
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
            catch(Exception ex)
            {
                MessageBox.Show("An error ocuured" + ex);
            }
            
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

        private void cBoxRoomType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cBoxRoomType.SelectedIndex == 0)
            {
                cBoxAdults.Items.Clear();
                cBoxKids.Items.Clear();

                for (int i = 0; i <= 2; i++)
                {
                    cBoxAdults.Items.Add(i.ToString());
                    cBoxKids.Items.Add(i.ToString());
                }

                iMax_Guests = 2;
            }
            else if (cBoxAdults.SelectedIndex == 1)
            {
                cBoxAdults.Items.Clear();
                cBoxKids.Items.Clear();

                for (int i = 0; i <= 4; i++)
                {
                    cBoxAdults.Items.Add(i.ToString());
                    cBoxKids.Items.Add(i.ToString());
                }

                iMax_Guests = 4;
            }

            else if (cBoxRoomType.SelectedIndex == 2)
            {
                cBoxAdults.Items.Clear();
                cBoxKids.Items.Clear();

                for (int i = 0; i <= 6; i++)
                {
                    cBoxAdults.Items.Add(i.ToString());
                    cBoxKids.Items.Add(i.ToString());
                }

                iMax_Guests = 6;
            }
        }

        private void cBoxAdults_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int iNum_Of_Adults = int.Parse(cBoxAdults.SelectedItem.ToString());
            int iNum_Of_Kids = iMax_Guests - iNum_Of_Adults;

            cBoxKids.Items.Clear();

            for (int i = 0; i <= iNum_Of_Kids; i++)
            {
                cBoxKids.Items.Add(i.ToString());
            }
        }

        private void txtCVV_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCVV.Text.Length > 4)
            {
                txtCVV.Text = txtCVV.Text.Substring(0, 4);
                txtCVV.SelectionStart = txtCVV.Text.Length;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            }
        }

        private void txtCardNo_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNo.Text.Length > 16)
            {
                txtCardNo.Text = txtCardNo.Text.Substring(0, 16);
                txtCardNo.SelectionStart = txtCardNo.Text.Length;
            }
        }

        private void txtCellNo_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCellNo.Text.Length > 10)
            {
                txtCellNo.Text = txtCellNo.Text.Substring(0, 10);
                txtCellNo.SelectionStart = txtCellNo.Text.Length;
            }
        }
    }
}
