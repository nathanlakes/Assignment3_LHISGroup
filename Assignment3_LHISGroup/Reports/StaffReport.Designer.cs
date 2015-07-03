namespace Assignment3_LHISGroup.Reports
{
    partial class StaffReport
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
            this.StaffListBox = new System.Windows.Forms.ListBox();
            this.StaffListLabel = new System.Windows.Forms.Label();
            this.TasksView = new System.Windows.Forms.DataGridView();
            this.Tasks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskCompleteBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TasksView)).BeginInit();
            this.SuspendLayout();
            // 
            // StaffListBox
            // 
            this.StaffListBox.FormattingEnabled = true;
            this.StaffListBox.Location = new System.Drawing.Point(12, 44);
            this.StaffListBox.Name = "StaffListBox";
            this.StaffListBox.Size = new System.Drawing.Size(175, 134);
            this.StaffListBox.TabIndex = 0;
            this.StaffListBox.SelectedIndexChanged += new System.EventHandler(this.StaffListBox_SelectedIndexChanged);
            // 
            // StaffListLabel
            // 
            this.StaffListLabel.AutoSize = true;
            this.StaffListLabel.Location = new System.Drawing.Point(13, 25);
            this.StaffListLabel.Name = "StaffListLabel";
            this.StaffListLabel.Size = new System.Drawing.Size(81, 13);
            this.StaffListLabel.TabIndex = 1;
            this.StaffListLabel.Text = "Active Staff List";
            // 
            // TasksView
            // 
            this.TasksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tasks,
            this.Description,
            this.TaskCompleteBy});
            this.TasksView.Location = new System.Drawing.Point(251, 44);
            this.TasksView.Name = "TasksView";
            this.TasksView.Size = new System.Drawing.Size(378, 347);
            this.TasksView.TabIndex = 2;
            this.TasksView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TasksView_CellContentClick);
            // 
            // Tasks
            // 
            this.Tasks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tasks.HeaderText = "Tasks Required";
            this.Tasks.Name = "Tasks";
            this.Tasks.Width = 98;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Description.HeaderText = "Task Description";
            this.Description.Name = "Description";
            this.Description.Width = 103;
            // 
            // TaskCompleteBy
            // 
            this.TaskCompleteBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TaskCompleteBy.HeaderText = "Task Completion Date";
            this.TaskCompleteBy.Name = "TaskCompleteBy";
            this.TaskCompleteBy.Width = 125;
            // 
            // StaffReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 433);
            this.Controls.Add(this.TasksView);
            this.Controls.Add(this.StaffListLabel);
            this.Controls.Add(this.StaffListBox);
            this.Name = "StaffReport";
            this.Text = "StaffReport";
            this.Load += new System.EventHandler(this.StaffReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TasksView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox StaffListBox;
        private System.Windows.Forms.Label StaffListLabel;
        private System.Windows.Forms.DataGridView TasksView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskCompleteBy;
    }
}