namespace Assignment3_LHISGroup.Reports
{
    partial class EventTaskReport
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
            this.TaskDetailsView = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompleteByDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompletionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeddingAssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllTaskDetailsLabel = new System.Windows.Forms.Label();
            this.GenerateReportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDetailsView)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskDetailsView
            // 
            this.TaskDetailsView.AllowUserToDeleteRows = false;
            this.TaskDetailsView.AllowUserToOrderColumns = true;
            this.TaskDetailsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TaskDetailsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TaskDetailsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskDetailsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.TaskDescription,
            this.TaskPriority,
            this.CompleteByDate,
            this.CompletionDate,
            this.AssignedTo,
            this.WeddingAssignedTo});
            this.TaskDetailsView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TaskDetailsView.Location = new System.Drawing.Point(12, 44);
            this.TaskDetailsView.Name = "TaskDetailsView";
            this.TaskDetailsView.ShowEditingIcon = false;
            this.TaskDetailsView.Size = new System.Drawing.Size(969, 399);
            this.TaskDetailsView.TabIndex = 0;
            this.TaskDetailsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TaskDetailsView_CellContentClick);
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Task Name";
            this.TaskName.Name = "TaskName";
            this.TaskName.Width = 80;
            // 
            // TaskDescription
            // 
            this.TaskDescription.HeaderText = "Task Description";
            this.TaskDescription.Name = "TaskDescription";
            this.TaskDescription.Width = 103;
            // 
            // TaskPriority
            // 
            this.TaskPriority.HeaderText = "Task Priority";
            this.TaskPriority.Name = "TaskPriority";
            this.TaskPriority.Width = 83;
            // 
            // CompleteByDate
            // 
            this.CompleteByDate.HeaderText = "Due Date";
            this.CompleteByDate.Name = "CompleteByDate";
            this.CompleteByDate.Width = 72;
            // 
            // CompletionDate
            // 
            this.CompletionDate.HeaderText = "Completion Date";
            this.CompletionDate.Name = "CompletionDate";
            this.CompletionDate.Width = 101;
            // 
            // AssignedTo
            // 
            this.AssignedTo.HeaderText = "StaffAssigned";
            this.AssignedTo.Name = "AssignedTo";
            this.AssignedTo.Width = 97;
            // 
            // WeddingAssignedTo
            // 
            this.WeddingAssignedTo.HeaderText = "Wedding Assigned To";
            this.WeddingAssignedTo.Name = "WeddingAssignedTo";
            this.WeddingAssignedTo.Width = 114;
            // 
            // AllTaskDetailsLabel
            // 
            this.AllTaskDetailsLabel.AutoSize = true;
            this.AllTaskDetailsLabel.Location = new System.Drawing.Point(442, 28);
            this.AllTaskDetailsLabel.Name = "AllTaskDetailsLabel";
            this.AllTaskDetailsLabel.Size = new System.Drawing.Size(80, 13);
            this.AllTaskDetailsLabel.TabIndex = 1;
            this.AllTaskDetailsLabel.Text = "All Task Details";
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Location = new System.Drawing.Point(460, 451);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(104, 30);
            this.GenerateReportButton.TabIndex = 2;
            this.GenerateReportButton.Text = "Generate Report";
            this.GenerateReportButton.UseVisualStyleBackColor = true;
            this.GenerateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // EventTaskReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 486);
            this.Controls.Add(this.GenerateReportButton);
            this.Controls.Add(this.AllTaskDetailsLabel);
            this.Controls.Add(this.TaskDetailsView);
            this.Name = "EventTaskReport";
            this.Text = "EventTaskReport";
            ((System.ComponentModel.ISupportInitialize)(this.TaskDetailsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskDetailsView;
        private System.Windows.Forms.Label AllTaskDetailsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompleteByDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompletionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeddingAssignedTo;
        private System.Windows.Forms.Button GenerateReportButton;
    }
}