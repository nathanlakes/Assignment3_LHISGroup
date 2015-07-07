namespace Assignment3_LHISGroup.UI
{
    partial class ManageTasksWindow
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
            this.components = new System.ComponentModel.Container();
            this.TasksDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeByDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualCompletionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffOnJobFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weddingIDFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.UpdateTaskButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            this.taskTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.TaskTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StaffComboBox = new System.Windows.Forms.ComboBox();
            this.WeddingComboBox = new System.Windows.Forms.ComboBox();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MarkCompleteButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FilterStaffButton = new System.Windows.Forms.Button();
            this.FilterWeddingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.AllowUserToAddRows = false;
            this.TasksDataGridView.AllowUserToDeleteRows = false;
            this.TasksDataGridView.AutoGenerateColumns = false;
            this.TasksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TasksDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.TasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.priorityDataGridViewTextBoxColumn,
            this.completeByDateDataGridViewTextBoxColumn,
            this.actualCompletionDateDataGridViewTextBoxColumn,
            this.staffOnJobFKDataGridViewTextBoxColumn,
            this.weddingIDFKDataGridViewTextBoxColumn});
            this.TasksDataGridView.DataSource = this.taskBindingSource;
            this.TasksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TasksDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TasksDataGridView.MultiSelect = false;
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.ReadOnly = true;
            this.TasksDataGridView.RowTemplate.Height = 28;
            this.TasksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TasksDataGridView.Size = new System.Drawing.Size(992, 628);
            this.TasksDataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "priority";
            this.priorityDataGridViewTextBoxColumn.HeaderText = "priority";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            this.priorityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // completeByDateDataGridViewTextBoxColumn
            // 
            this.completeByDateDataGridViewTextBoxColumn.DataPropertyName = "completeByDate";
            this.completeByDateDataGridViewTextBoxColumn.HeaderText = "completeByDate";
            this.completeByDateDataGridViewTextBoxColumn.Name = "completeByDateDataGridViewTextBoxColumn";
            this.completeByDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actualCompletionDateDataGridViewTextBoxColumn
            // 
            this.actualCompletionDateDataGridViewTextBoxColumn.DataPropertyName = "actualCompletionDate";
            this.actualCompletionDateDataGridViewTextBoxColumn.HeaderText = "actualCompletionDate";
            this.actualCompletionDateDataGridViewTextBoxColumn.Name = "actualCompletionDateDataGridViewTextBoxColumn";
            this.actualCompletionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // staffOnJobFKDataGridViewTextBoxColumn
            // 
            this.staffOnJobFKDataGridViewTextBoxColumn.DataPropertyName = "staffOnJob_FK";
            this.staffOnJobFKDataGridViewTextBoxColumn.HeaderText = "staffOnJob_FK";
            this.staffOnJobFKDataGridViewTextBoxColumn.Name = "staffOnJobFKDataGridViewTextBoxColumn";
            this.staffOnJobFKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // weddingIDFKDataGridViewTextBoxColumn
            // 
            this.weddingIDFKDataGridViewTextBoxColumn.DataPropertyName = "weddingID_FK";
            this.weddingIDFKDataGridViewTextBoxColumn.HeaderText = "weddingID_FK";
            this.weddingIDFKDataGridViewTextBoxColumn.Name = "weddingIDFKDataGridViewTextBoxColumn";
            this.weddingIDFKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataMember = "Task";
            this.taskBindingSource.DataSource = this.modelDataSet;
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.BackColor = System.Drawing.Color.White;
            this.AddTaskButton.Location = new System.Drawing.Point(43, 22);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(108, 43);
            this.AddTaskButton.TabIndex = 1;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = false;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // UpdateTaskButton
            // 
            this.UpdateTaskButton.BackColor = System.Drawing.Color.White;
            this.UpdateTaskButton.Location = new System.Drawing.Point(329, 22);
            this.UpdateTaskButton.Name = "UpdateTaskButton";
            this.UpdateTaskButton.Size = new System.Drawing.Size(131, 43);
            this.UpdateTaskButton.TabIndex = 2;
            this.UpdateTaskButton.Text = "Update Task";
            this.UpdateTaskButton.UseVisualStyleBackColor = false;
            this.UpdateTaskButton.Click += new System.EventHandler(this.UpdateTaskButton_Click);
            // 
            // DeleteWeddingButton
            // 
            this.DeleteWeddingButton.BackColor = System.Drawing.Color.White;
            this.DeleteWeddingButton.Location = new System.Drawing.Point(176, 22);
            this.DeleteWeddingButton.Name = "DeleteWeddingButton";
            this.DeleteWeddingButton.Size = new System.Drawing.Size(131, 43);
            this.DeleteWeddingButton.TabIndex = 3;
            this.DeleteWeddingButton.Text = "Delete Task";
            this.DeleteWeddingButton.UseVisualStyleBackColor = false;
            this.DeleteWeddingButton.Click += new System.EventHandler(this.DeleteWeddingButton_Click);
            // 
            // taskTableAdapter
            // 
            this.taskTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FilterWeddingButton);
            this.panel1.Controls.Add(this.FilterStaffButton);
            this.panel1.Controls.Add(this.StaffComboBox);
            this.panel1.Controls.Add(this.WeddingComboBox);
            this.panel1.Controls.Add(this.ClearFilterButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UpdateTaskButton);
            this.panel1.Controls.Add(this.DeleteWeddingButton);
            this.panel1.Controls.Add(this.AddTaskButton);
            this.panel1.Controls.Add(this.MarkCompleteButton);
            this.panel1.Controls.Add(this.ExportButton);
            this.panel1.Controls.Add(this.PrintButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 216);
            this.panel1.TabIndex = 4;
            // 
            // StaffComboBox
            // 
            this.StaffComboBox.FormattingEnabled = true;
            this.StaffComboBox.Location = new System.Drawing.Point(208, 90);
            this.StaffComboBox.Name = "StaffComboBox";
            this.StaffComboBox.Size = new System.Drawing.Size(208, 28);
            this.StaffComboBox.TabIndex = 11;
            // 
            // WeddingComboBox
            // 
            this.WeddingComboBox.FormattingEnabled = true;
            this.WeddingComboBox.Location = new System.Drawing.Point(205, 152);
            this.WeddingComboBox.Name = "WeddingComboBox";
            this.WeddingComboBox.Size = new System.Drawing.Size(211, 28);
            this.WeddingComboBox.TabIndex = 10;
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.BackColor = System.Drawing.Color.White;
            this.ClearFilterButton.Location = new System.Drawing.Point(438, 98);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(75, 67);
            this.ClearFilterButton.TabIndex = 9;
            this.ClearFilterButton.Text = "Clear Filters";
            this.ClearFilterButton.UseVisualStyleBackColor = false;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(812, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter By Wedding";
            // 
            // MarkCompleteButton
            // 
            this.MarkCompleteButton.BackColor = System.Drawing.Color.White;
            this.MarkCompleteButton.Location = new System.Drawing.Point(549, 22);
            this.MarkCompleteButton.Name = "MarkCompleteButton";
            this.MarkCompleteButton.Size = new System.Drawing.Size(202, 42);
            this.MarkCompleteButton.TabIndex = 4;
            this.MarkCompleteButton.Text = "Mark As Complete";
            this.MarkCompleteButton.UseVisualStyleBackColor = false;
            // 
            // ExportButton
            // 
            this.ExportButton.BackColor = System.Drawing.Color.White;
            this.ExportButton.Location = new System.Drawing.Point(549, 90);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(208, 41);
            this.ExportButton.TabIndex = 5;
            this.ExportButton.Text = "Export To CSV";
            this.ExportButton.UseVisualStyleBackColor = false;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(546, 145);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(211, 41);
            this.PrintButton.TabIndex = 6;
            this.PrintButton.Text = "Print Report";
            this.PrintButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(812, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter By Staff";
            // 
            // FilterStaffButton
            // 
            this.FilterStaffButton.BackColor = System.Drawing.Color.White;
            this.FilterStaffButton.Location = new System.Drawing.Point(32, 90);
            this.FilterStaffButton.Name = "FilterStaffButton";
            this.FilterStaffButton.Size = new System.Drawing.Size(153, 41);
            this.FilterStaffButton.TabIndex = 12;
            this.FilterStaffButton.Text = "Filter By Staff";
            this.FilterStaffButton.UseVisualStyleBackColor = false;
            this.FilterStaffButton.Click += new System.EventHandler(this.FilterStaffButton_Click);
            // 
            // FilterWeddingButton
            // 
            this.FilterWeddingButton.BackColor = System.Drawing.Color.White;
            this.FilterWeddingButton.Location = new System.Drawing.Point(32, 145);
            this.FilterWeddingButton.Name = "FilterWeddingButton";
            this.FilterWeddingButton.Size = new System.Drawing.Size(153, 40);
            this.FilterWeddingButton.TabIndex = 13;
            this.FilterWeddingButton.Text = "Filter By Wedding";
            this.FilterWeddingButton.UseVisualStyleBackColor = false;
            this.FilterWeddingButton.Click += new System.EventHandler(this.FilterWeddingButton_Click);
            // 
            // ManageTasksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(992, 628);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TasksDataGridView);
            this.Name = "ManageTasksWindow";
            this.Text = "Manage Tasks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageTasksWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageTasksWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TasksDataGridView;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Button UpdateTaskButton;
        private System.Windows.Forms.Button DeleteWeddingButton;
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private ModelDataSetTableAdapters.TaskTableAdapter taskTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeByDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualCompletionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffOnJobFKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weddingIDFKDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MarkCompleteButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.ComboBox StaffComboBox;
        private System.Windows.Forms.ComboBox WeddingComboBox;
        private System.Windows.Forms.Button ClearFilterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FilterStaffButton;
        private System.Windows.Forms.Button FilterWeddingButton;
    }
}