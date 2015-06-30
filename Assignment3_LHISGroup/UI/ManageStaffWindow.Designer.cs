namespace Assignment3_LHISGroup.UI
{
    partial class ManageStaffWindow
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
            this.StaffDataGridView = new System.Windows.Forms.DataGridView();
            this.AddStaffButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StaffDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StaffDataGridView
            // 
            this.StaffDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.StaffDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StaffDataGridView.Location = new System.Drawing.Point(34, 26);
            this.StaffDataGridView.Name = "StaffDataGridView";
            this.StaffDataGridView.RowTemplate.Height = 28;
            this.StaffDataGridView.Size = new System.Drawing.Size(649, 212);
            this.StaffDataGridView.TabIndex = 0;
            // 
            // AddStaffButton
            // 
            this.AddStaffButton.BackColor = System.Drawing.Color.White;
            this.AddStaffButton.Location = new System.Drawing.Point(104, 276);
            this.AddStaffButton.Name = "AddStaffButton";
            this.AddStaffButton.Size = new System.Drawing.Size(173, 42);
            this.AddStaffButton.TabIndex = 1;
            this.AddStaffButton.Text = "Add Staff";
            this.AddStaffButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(423, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update Staff";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ManageStaffWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(725, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddStaffButton);
            this.Controls.Add(this.StaffDataGridView);
            this.Name = "ManageStaffWindow";
            this.Text = "Manage Staff";
            ((System.ComponentModel.ISupportInitialize)(this.StaffDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView StaffDataGridView;
        private System.Windows.Forms.Button AddStaffButton;
        private System.Windows.Forms.Button button1;
    }
}