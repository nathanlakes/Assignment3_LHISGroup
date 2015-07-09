namespace Assignment3_LHISGroup.Reports
{
    partial class EventProgressReport
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
            this.GenerateEventReportButton = new System.Windows.Forms.Button();
            this.WeddingDetailsLabel = new System.Windows.Forms.Label();
            this.WeddingListLabel = new System.Windows.Forms.Label();
            this.WedTasksView = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompleteBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompletionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeddingDetailsView = new System.Windows.Forms.DataGridView();
            this.WeddingTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeddingTasksLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WedTasksView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingDetailsView)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateEventReportButton
            // 
            this.GenerateEventReportButton.Location = new System.Drawing.Point(270, 428);
            this.GenerateEventReportButton.Name = "GenerateEventReportButton";
            this.GenerateEventReportButton.Size = new System.Drawing.Size(143, 29);
            this.GenerateEventReportButton.TabIndex = 9;
            this.GenerateEventReportButton.Text = "Generate Progress Report";
            this.GenerateEventReportButton.UseVisualStyleBackColor = true;
            this.GenerateEventReportButton.Click += new System.EventHandler(this.GenerateEventReportButton_Click);
            // 
            // WeddingDetailsLabel
            // 
            this.WeddingDetailsLabel.AutoSize = true;
            this.WeddingDetailsLabel.Location = new System.Drawing.Point(310, 7);
            this.WeddingDetailsLabel.Name = "WeddingDetailsLabel";
            this.WeddingDetailsLabel.Size = new System.Drawing.Size(85, 13);
            this.WeddingDetailsLabel.TabIndex = 8;
            this.WeddingDetailsLabel.Text = "Wedding Details";
            // 
            // WeddingListLabel
            // 
            this.WeddingListLabel.AutoSize = true;
            this.WeddingListLabel.Location = new System.Drawing.Point(-122, 10);
            this.WeddingListLabel.Name = "WeddingListLabel";
            this.WeddingListLabel.Size = new System.Drawing.Size(69, 13);
            this.WeddingListLabel.TabIndex = 7;
            this.WeddingListLabel.Text = "Wedding List";
            // 
            // WedTasksView
            // 
            this.WedTasksView.AllowUserToDeleteRows = false;
            this.WedTasksView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.WedTasksView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.WedTasksView.BackgroundColor = System.Drawing.Color.White;
            this.WedTasksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WedTasksView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.TaskPriority,
            this.CompleteBy,
            this.CompletionDate});
            this.WedTasksView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.WedTasksView.Location = new System.Drawing.Point(12, 213);
            this.WedTasksView.MultiSelect = false;
            this.WedTasksView.Name = "WedTasksView";
            this.WedTasksView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WedTasksView.Size = new System.Drawing.Size(698, 209);
            this.WedTasksView.TabIndex = 6;
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Task Name";
            this.TaskName.Name = "TaskName";
            this.TaskName.Width = 80;
            // 
            // TaskPriority
            // 
            this.TaskPriority.HeaderText = "Task Priority";
            this.TaskPriority.Name = "TaskPriority";
            this.TaskPriority.Width = 83;
            // 
            // CompleteBy
            // 
            this.CompleteBy.HeaderText = "Complete By Date";
            this.CompleteBy.Name = "CompleteBy";
            this.CompleteBy.Width = 87;
            // 
            // CompletionDate
            // 
            this.CompletionDate.HeaderText = "Completion Date";
            this.CompletionDate.Name = "CompletionDate";
            this.CompletionDate.Width = 101;
            // 
            // WeddingDetailsView
            // 
            this.WeddingDetailsView.AllowUserToDeleteRows = false;
            this.WeddingDetailsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.WeddingDetailsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.WeddingDetailsView.BackgroundColor = System.Drawing.Color.White;
            this.WeddingDetailsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeddingDetailsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WeddingTitle,
            this.StartDate,
            this.EventDate});
            this.WeddingDetailsView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.WeddingDetailsView.Location = new System.Drawing.Point(12, 23);
            this.WeddingDetailsView.MultiSelect = false;
            this.WeddingDetailsView.Name = "WeddingDetailsView";
            this.WeddingDetailsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WeddingDetailsView.Size = new System.Drawing.Size(698, 171);
            this.WeddingDetailsView.TabIndex = 10;
            this.WeddingDetailsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WeddingDetailsView_CellContentClick);
            this.WeddingDetailsView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.WeddingDetailsView_RowEnter);
            // 
            // WeddingTitle
            // 
            this.WeddingTitle.HeaderText = "Wedding Title";
            this.WeddingTitle.Name = "WeddingTitle";
            this.WeddingTitle.Width = 98;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.Width = 80;
            // 
            // EventDate
            // 
            this.EventDate.HeaderText = "Event Date";
            this.EventDate.Name = "EventDate";
            this.EventDate.Width = 86;
            // 
            // WeddingTasksLabel
            // 
            this.WeddingTasksLabel.AutoSize = true;
            this.WeddingTasksLabel.Location = new System.Drawing.Point(300, 197);
            this.WeddingTasksLabel.Name = "WeddingTasksLabel";
            this.WeddingTasksLabel.Size = new System.Drawing.Size(82, 13);
            this.WeddingTasksLabel.TabIndex = 11;
            this.WeddingTasksLabel.Text = "Wedding Tasks";
            // 
            // EventProgressReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(724, 469);
            this.Controls.Add(this.WeddingTasksLabel);
            this.Controls.Add(this.WeddingDetailsView);
            this.Controls.Add(this.GenerateEventReportButton);
            this.Controls.Add(this.WeddingDetailsLabel);
            this.Controls.Add(this.WeddingListLabel);
            this.Controls.Add(this.WedTasksView);
            this.Name = "EventProgressReport";
            this.Text = "EventProgressReport";
            ((System.ComponentModel.ISupportInitialize)(this.WedTasksView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingDetailsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateEventReportButton;
        private System.Windows.Forms.Label WeddingDetailsLabel;
        private System.Windows.Forms.Label WeddingListLabel;
        private System.Windows.Forms.DataGridView WedTasksView;
        private System.Windows.Forms.DataGridView WeddingDetailsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompleteBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompletionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeddingTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventDate;
        private System.Windows.Forms.Label WeddingTasksLabel;
    }
}