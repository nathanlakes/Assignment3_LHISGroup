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
            this.UpdateStaffButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StaffDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StaffDataGridView
            // 
            this.StaffDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.StaffDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StaffDataGridView.Location = new System.Drawing.Point(12, 12);
            this.StaffDataGridView.Name = "StaffDataGridView";
            this.StaffDataGridView.RowTemplate.Height = 28;
            this.StaffDataGridView.Size = new System.Drawing.Size(701, 226);
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
            this.AddStaffButton.Click += new System.EventHandler(this.AddStaffButton_Click);
            // 
            // button1
            // 
            this.UpdateStaffButton.BackColor = System.Drawing.Color.White;
            this.UpdateStaffButton.Location = new System.Drawing.Point(423, 276);
            this.UpdateStaffButton.Name = "button1";
            this.UpdateStaffButton.Size = new System.Drawing.Size(174, 41);
            this.UpdateStaffButton.TabIndex = 2;
            this.UpdateStaffButton.Text = "Update Staff";
            this.UpdateStaffButton.UseVisualStyleBackColor = false;
            this.UpdateStaffButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManageStaffWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(725, 362);
            this.Controls.Add(this.UpdateStaffButton);
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
        private System.Windows.Forms.Button UpdateStaffButton;
    }
}