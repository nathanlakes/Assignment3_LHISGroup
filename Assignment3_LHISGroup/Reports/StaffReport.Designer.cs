﻿namespace Assignment3_LHISGroup.Reports
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
            this.ActiveStaffListLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TasksView)).BeginInit();
            this.SuspendLayout();
            // 
            // StaffListBox
            // 
            this.StaffListBox.BackColor = System.Drawing.Color.White;
            this.StaffListBox.FormattingEnabled = true;
            this.StaffListBox.Location = new System.Drawing.Point(12, 44);
            this.StaffListBox.Name = "StaffListBox";
            this.StaffListBox.Size = new System.Drawing.Size(121, 381);
            this.StaffListBox.TabIndex = 0;
            this.StaffListBox.SelectedIndexChanged += new System.EventHandler(this.StaffListBox_SelectedIndexChanged);
            // 
            // StaffListLabel
            // 
            this.StaffListLabel.AutoSize = true;
            this.StaffListLabel.Location = new System.Drawing.Point(32, 28);
            this.StaffListLabel.Name = "StaffListLabel";
            this.StaffListLabel.Size = new System.Drawing.Size(81, 13);
            this.StaffListLabel.TabIndex = 1;
            this.StaffListLabel.Text = "Active Staff List";
            // 
            // TasksView
            // 
            this.TasksView.AllowUserToDeleteRows = false;
            this.TasksView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TasksView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TasksView.BackgroundColor = System.Drawing.Color.White;
            this.TasksView.ColumnHeadersHeight = 20;
            this.TasksView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tasks,
            this.Description,
            this.TaskCompleteBy});
            this.TasksView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TasksView.Location = new System.Drawing.Point(168, 44);
            this.TasksView.Name = "TasksView";
            this.TasksView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TasksView.ShowEditingIcon = false;
            this.TasksView.Size = new System.Drawing.Size(685, 377);
            this.TasksView.TabIndex = 2;
            // 
            // Tasks
            // 
            this.Tasks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tasks.HeaderText = "Tasks Required";
            this.Tasks.Name = "Tasks";
            this.Tasks.Width = 107;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Description.HeaderText = "Task Description";
            this.Description.Name = "Description";
            this.Description.Width = 112;
            // 
            // TaskCompleteBy
            // 
            this.TaskCompleteBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TaskCompleteBy.HeaderText = "Task Completion Date";
            this.TaskCompleteBy.Name = "TaskCompleteBy";
            this.TaskCompleteBy.Width = 137;
            // 
            // ActiveStaffListLabel
            // 
            this.ActiveStaffListLabel.AutoSize = true;
            this.ActiveStaffListLabel.Location = new System.Drawing.Point(439, 28);
            this.ActiveStaffListLabel.Name = "ActiveStaffListLabel";
            this.ActiveStaffListLabel.Size = new System.Drawing.Size(81, 13);
            this.ActiveStaffListLabel.TabIndex = 3;
            this.ActiveStaffListLabel.Text = "Active Staff List";
            // 
            // StaffReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(880, 451);
            this.Controls.Add(this.ActiveStaffListLabel);
            this.Controls.Add(this.TasksView);
            this.Controls.Add(this.StaffListLabel);
            this.Controls.Add(this.StaffListBox);
            this.DoubleBuffered = true;
            this.Name = "StaffReport";
            this.Text = "StaffReport";
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
        private System.Windows.Forms.Label ActiveStaffListLabel;
    }
}