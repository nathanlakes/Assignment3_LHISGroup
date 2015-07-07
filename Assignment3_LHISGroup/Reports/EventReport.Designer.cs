namespace Assignment3_LHISGroup.Reports
{
    partial class EventReport
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
            this.EventListBox = new System.Windows.Forms.ListBox();
            this.WeddingDetailsGridView = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompleteBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompletionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignedto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingDetailsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EventListBox
            // 
            this.EventListBox.FormattingEnabled = true;
            this.EventListBox.Location = new System.Drawing.Point(12, 30);
            this.EventListBox.Name = "EventListBox";
            this.EventListBox.Size = new System.Drawing.Size(138, 342);
            this.EventListBox.TabIndex = 0;
            this.EventListBox.SelectedIndexChanged += new System.EventHandler(this.EventListBox_SelectedIndexChanged);
            // 
            // WeddingDetailsGridView
            // 
            this.WeddingDetailsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.WeddingDetailsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.WeddingDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeddingDetailsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.TaskPriority,
            this.CompleteBy,
            this.CompletionDate,
            this.Assignedto});
            this.WeddingDetailsGridView.Location = new System.Drawing.Point(173, 30);
            this.WeddingDetailsGridView.Name = "WeddingDetailsGridView";
            this.WeddingDetailsGridView.Size = new System.Drawing.Size(691, 352);
            this.WeddingDetailsGridView.TabIndex = 1;
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
            // Assignedto
            // 
            this.Assignedto.HeaderText = "Staff Assigned To Task";
            this.Assignedto.Name = "Assignedto";
            this.Assignedto.Width = 109;
            // 
            // EventReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 394);
            this.Controls.Add(this.WeddingDetailsGridView);
            this.Controls.Add(this.EventListBox);
            this.Name = "EventReport";
            this.Text = "EventReport";
            ((System.ComponentModel.ISupportInitialize)(this.WeddingDetailsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox EventListBox;
        private System.Windows.Forms.DataGridView WeddingDetailsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompleteBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompletionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignedto;
    }
}