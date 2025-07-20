
namespace HotelManagement_System
{
    partial class Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReport2 = new System.Windows.Forms.Button();
            this.btnReport1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReport2
            // 
            this.btnReport2.Location = new System.Drawing.Point(15, 158);
            this.btnReport2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReport2.Name = "btnReport2";
            this.btnReport2.Size = new System.Drawing.Size(695, 66);
            this.btnReport2.TabIndex = 3;
            this.btnReport2.Text = "Income received ";
            this.btnReport2.UseVisualStyleBackColor = true;
            this.btnReport2.Click += new System.EventHandler(this.btnReport2_Click);
            // 
            // btnReport1
            // 
            this.btnReport1.Location = new System.Drawing.Point(15, 14);
            this.btnReport1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReport1.Name = "btnReport1";
            this.btnReport1.Size = new System.Drawing.Size(695, 71);
            this.btnReport1.TabIndex = 2;
            this.btnReport1.Text = "Top 10 peak weeks ";
            this.btnReport1.UseVisualStyleBackColor = true;
            this.btnReport1.Click += new System.EventHandler(this.btnReport1_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 299);
            this.Controls.Add(this.btnReport2);
            this.Controls.Add(this.btnReport1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReport2;
        private System.Windows.Forms.Button btnReport1;
    }
}