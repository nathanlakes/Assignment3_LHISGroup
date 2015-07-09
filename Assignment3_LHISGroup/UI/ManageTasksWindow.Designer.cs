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
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.UpdateTaskButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            this.taskTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.TaskTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MarkCompleteButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.weddingIDFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffOnJobFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualCompletionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeByDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TasksDataGridView = new System.Windows.Forms.DataGridView();
            this.FilterStaffButton = new System.Windows.Forms.Button();
            this.FilterWeddingButton = new System.Windows.Forms.Button();
            this.WeddingComboBox = new System.Windows.Forms.ComboBox();
            this.StaffComboBox = new System.Windows.Forms.ComboBox();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.AddTaskButton.Location = new System.Drawing.Point(14, 13);
            this.AddTaskButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(72, 28);
            this.AddTaskButton.TabIndex = 1;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = false;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // UpdateTaskButton
            // 
            this.UpdateTaskButton.BackColor = System.Drawing.Color.White;
            this.UpdateTaskButton.Location = new System.Drawing.Point(204, 13);
            this.UpdateTaskButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateTaskButton.Name = "UpdateTaskButton";
            this.UpdateTaskButton.Size = new System.Drawing.Size(87, 28);
            this.UpdateTaskButton.TabIndex = 2;
            this.UpdateTaskButton.Text = "Update Task";
            this.UpdateTaskButton.UseVisualStyleBackColor = false;
            this.UpdateTaskButton.Click += new System.EventHandler(this.UpdateTaskButton_Click);
            // 
            // DeleteWeddingButton
            // 
            this.DeleteWeddingButton.BackColor = System.Drawing.Color.White;
            this.DeleteWeddingButton.Location = new System.Drawing.Point(102, 13);
            this.DeleteWeddingButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteWeddingButton.Name = "DeleteWeddingButton";
            this.DeleteWeddingButton.Size = new System.Drawing.Size(87, 28);
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
            this.panel1.Controls.Add(this.UpdateTaskButton);
            this.panel1.Controls.Add(this.DeleteWeddingButton);
            this.panel1.Controls.Add(this.AddTaskButton);
            this.panel1.Controls.Add(this.MarkCompleteButton);
            this.panel1.Controls.Add(this.PrintButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 294);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 140);
            this.panel1.TabIndex = 4;
            // 
            // MarkCompleteButton
            // 
            this.MarkCompleteButton.BackColor = System.Drawing.Color.White;
            this.MarkCompleteButton.Location = new System.Drawing.Point(687, 58);
            this.MarkCompleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.MarkCompleteButton.Name = "MarkCompleteButton";
            this.MarkCompleteButton.Size = new System.Drawing.Size(135, 27);
            this.MarkCompleteButton.TabIndex = 4;
            this.MarkCompleteButton.Text = "Mark As Complete";
            this.MarkCompleteButton.UseVisualStyleBackColor = false;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(687, 98);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(2);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(135, 27);
            this.PrintButton.TabIndex = 6;
            this.PrintButton.Text = "Generate Task Report";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // weddingIDFKDataGridViewTextBoxColumn
            // 
            this.weddingIDFKDataGridViewTextBoxColumn.DataPropertyName = "weddingID_FK";
            this.weddingIDFKDataGridViewTextBoxColumn.HeaderText = "weddingID_FK";
            this.weddingIDFKDataGridViewTextBoxColumn.Name = "weddingIDFKDataGridViewTextBoxColumn";
            this.weddingIDFKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // staffOnJobFKDataGridViewTextBoxColumn
            // 
            this.staffOnJobFKDataGridViewTextBoxColumn.DataPropertyName = "staffOnJob_FK";
            this.staffOnJobFKDataGridViewTextBoxColumn.HeaderText = "staffOnJob_FK";
            this.staffOnJobFKDataGridViewTextBoxColumn.Name = "staffOnJobFKDataGridViewTextBoxColumn";
            this.staffOnJobFKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actualCompletionDateDataGridViewTextBoxColumn
            // 
            this.actualCompletionDateDataGridViewTextBoxColumn.DataPropertyName = "actualCompletionDate";
            this.actualCompletionDateDataGridViewTextBoxColumn.HeaderText = "actualCompletionDate";
            this.actualCompletionDateDataGridViewTextBoxColumn.Name = "actualCompletionDateDataGridViewTextBoxColumn";
            this.actualCompletionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // completeByDateDataGridViewTextBoxColumn
            // 
            this.completeByDateDataGridViewTextBoxColumn.DataPropertyName = "completeByDate";
            this.completeByDateDataGridViewTextBoxColumn.HeaderText = "completeByDate";
            this.completeByDateDataGridViewTextBoxColumn.Name = "completeByDateDataGridViewTextBoxColumn";
            this.completeByDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "priority";
            this.priorityDataGridViewTextBoxColumn.HeaderText = "priority";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            this.priorityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.TasksDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.TasksDataGridView.MultiSelect = false;
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.ReadOnly = true;
            this.TasksDataGridView.RowTemplate.Height = 28;
            this.TasksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TasksDataGridView.Size = new System.Drawing.Size(833, 434);
            this.TasksDataGridView.TabIndex = 0;
            // 
            // FilterStaffButton
            // 
            this.FilterStaffButton.BackColor = System.Drawing.Color.White;
            this.FilterStaffButton.Location = new System.Drawing.Point(13, 64);
            this.FilterStaffButton.Margin = new System.Windows.Forms.Padding(2);
            this.FilterStaffButton.Name = "FilterStaffButton";
            this.FilterStaffButton.Size = new System.Drawing.Size(102, 27);
            this.FilterStaffButton.TabIndex = 12;
            this.FilterStaffButton.Text = "Filter By Staff";
            this.FilterStaffButton.UseVisualStyleBackColor = false;
            this.FilterStaffButton.Click += new System.EventHandler(this.FilterStaffButton_Click);
            // 
            // FilterWeddingButton
            // 
            this.FilterWeddingButton.BackColor = System.Drawing.Color.White;
            this.FilterWeddingButton.Location = new System.Drawing.Point(13, 100);
            this.FilterWeddingButton.Margin = new System.Windows.Forms.Padding(2);
            this.FilterWeddingButton.Name = "FilterWeddingButton";
            this.FilterWeddingButton.Size = new System.Drawing.Size(102, 26);
            this.FilterWeddingButton.TabIndex = 13;
            this.FilterWeddingButton.Text = "Filter By Wedding";
            this.FilterWeddingButton.UseVisualStyleBackColor = false;
            this.FilterWeddingButton.Click += new System.EventHandler(this.FilterWeddingButton_Click);
            // 
            // WeddingComboBox
            // 
            this.WeddingComboBox.FormattingEnabled = true;
            this.WeddingComboBox.Location = new System.Drawing.Point(130, 105);
            this.WeddingComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.WeddingComboBox.Name = "WeddingComboBox";
            this.WeddingComboBox.Size = new System.Drawing.Size(161, 21);
            this.WeddingComboBox.TabIndex = 10;
            // 
            // StaffComboBox
            // 
            this.StaffComboBox.FormattingEnabled = true;
            this.StaffComboBox.Location = new System.Drawing.Point(131, 64);
            this.StaffComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.StaffComboBox.Name = "StaffComboBox";
            this.StaffComboBox.Size = new System.Drawing.Size(160, 21);
            this.StaffComboBox.TabIndex = 11;
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.BackColor = System.Drawing.Color.White;
            this.ClearFilterButton.Location = new System.Drawing.Point(307, 72);
            this.ClearFilterButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(50, 44);
            this.ClearFilterButton.TabIndex = 9;
            this.ClearFilterButton.Text = "Clear Filters";
            this.ClearFilterButton.UseVisualStyleBackColor = false;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // ManageTasksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(833, 434);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TasksDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageTasksWindow";
            this.Text = "Manage Tasks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageTasksWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageTasksWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Button UpdateTaskButton;
        private System.Windows.Forms.Button DeleteWeddingButton;
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private ModelDataSetTableAdapters.TaskTableAdapter taskTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MarkCompleteButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn weddingIDFKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffOnJobFKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualCompletionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeByDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView TasksDataGridView;
        private System.Windows.Forms.Button FilterWeddingButton;
        private System.Windows.Forms.Button FilterStaffButton;
        private System.Windows.Forms.ComboBox StaffComboBox;
        private System.Windows.Forms.ComboBox WeddingComboBox;
        private System.Windows.Forms.Button ClearFilterButton;
    }
}