
namespace HotelManagement_System
{
    partial class MaintainRoles
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
            this.gbxMaintainRoles = new System.Windows.Forms.GroupBox();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.gbxMaintainRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMaintainRoles
            // 
            this.gbxMaintainRoles.Controls.Add(this.btnDeleteRole);
            this.gbxMaintainRoles.Controls.Add(this.btnAddRole);
            this.gbxMaintainRoles.Location = new System.Drawing.Point(21, 25);
            this.gbxMaintainRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxMaintainRoles.Name = "gbxMaintainRoles";
            this.gbxMaintainRoles.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxMaintainRoles.Size = new System.Drawing.Size(288, 319);
            this.gbxMaintainRoles.TabIndex = 3;
            this.gbxMaintainRoles.TabStop = false;
            this.gbxMaintainRoles.Text = "Choose an operation";
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRole.BackColor = System.Drawing.Color.Black;
            this.btnDeleteRole.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteRole.FlatAppearance.BorderSize = 0;
            this.btnDeleteRole.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteRole.Location = new System.Drawing.Point(62, 190);
            this.btnDeleteRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(156, 80);
            this.btnDeleteRole.TabIndex = 12;
            this.btnDeleteRole.Text = "Delete Role";
            this.btnDeleteRole.UseVisualStyleBackColor = false;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRole.BackColor = System.Drawing.Color.Black;
            this.btnAddRole.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddRole.FlatAppearance.BorderSize = 0;
            this.btnAddRole.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddRole.Location = new System.Drawing.Point(62, 60);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(156, 71);
            this.btnAddRole.TabIndex = 11;
            this.btnAddRole.Text = "Add New Roles";
            this.btnAddRole.UseVisualStyleBackColor = false;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // MaintainRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 381);
            this.Controls.Add(this.gbxMaintainRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MaintainRoles";
            this.Text = "Maintain Roles";
            this.Load += new System.EventHandler(this.MaintainRoles_Load);
            this.gbxMaintainRoles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxMaintainRoles;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnDeleteRole;
    }
}