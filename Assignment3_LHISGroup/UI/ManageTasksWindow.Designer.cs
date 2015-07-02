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
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.UpdateTaskButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.TaskTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeByDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualCompletionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffOnJobFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weddingIDFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.AutoGenerateColumns = false;
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
            this.TasksDataGridView.Location = new System.Drawing.Point(12, 12);
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.RowTemplate.Height = 28;
            this.TasksDataGridView.Size = new System.Drawing.Size(850, 272);
            this.TasksDataGridView.TabIndex = 0;
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.BackColor = System.Drawing.Color.White;
            this.AddTaskButton.Location = new System.Drawing.Point(103, 299);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(108, 47);
            this.AddTaskButton.TabIndex = 1;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = false;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // UpdateTaskButton
            // 
            this.UpdateTaskButton.BackColor = System.Drawing.Color.White;
            this.UpdateTaskButton.Location = new System.Drawing.Point(433, 299);
            this.UpdateTaskButton.Name = "UpdateTaskButton";
            this.UpdateTaskButton.Size = new System.Drawing.Size(131, 46);
            this.UpdateTaskButton.TabIndex = 2;
            this.UpdateTaskButton.Text = "Update Task";
            this.UpdateTaskButton.UseVisualStyleBackColor = false;
            this.UpdateTaskButton.Click += new System.EventHandler(this.UpdateTaskButton_Click);
            // 
            // DeleteWeddingButton
            // 
            this.DeleteWeddingButton.BackColor = System.Drawing.Color.White;
            this.DeleteWeddingButton.Location = new System.Drawing.Point(433, 362);
            this.DeleteWeddingButton.Name = "DeleteWeddingButton";
            this.DeleteWeddingButton.Size = new System.Drawing.Size(131, 43);
            this.DeleteWeddingButton.TabIndex = 3;
            this.DeleteWeddingButton.Text = "Delete Task";
            this.DeleteWeddingButton.UseVisualStyleBackColor = false;
            this.DeleteWeddingButton.Click += new System.EventHandler(this.DeleteWeddingButton_Click);
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataMember = "Task";
            this.taskBindingSource.DataSource = this.modelDataSet;
            // 
            // taskTableAdapter
            // 
            this.taskTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "priority";
            this.priorityDataGridViewTextBoxColumn.HeaderText = "priority";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            // 
            // completeByDateDataGridViewTextBoxColumn
            // 
            this.completeByDateDataGridViewTextBoxColumn.DataPropertyName = "completeByDate";
            this.completeByDateDataGridViewTextBoxColumn.HeaderText = "completeByDate";
            this.completeByDateDataGridViewTextBoxColumn.Name = "completeByDateDataGridViewTextBoxColumn";
            // 
            // actualCompletionDateDataGridViewTextBoxColumn
            // 
            this.actualCompletionDateDataGridViewTextBoxColumn.DataPropertyName = "actualCompletionDate";
            this.actualCompletionDateDataGridViewTextBoxColumn.HeaderText = "actualCompletionDate";
            this.actualCompletionDateDataGridViewTextBoxColumn.Name = "actualCompletionDateDataGridViewTextBoxColumn";
            // 
            // staffOnJobFKDataGridViewTextBoxColumn
            // 
            this.staffOnJobFKDataGridViewTextBoxColumn.DataPropertyName = "staffOnJob_FK";
            this.staffOnJobFKDataGridViewTextBoxColumn.HeaderText = "staffOnJob_FK";
            this.staffOnJobFKDataGridViewTextBoxColumn.Name = "staffOnJobFKDataGridViewTextBoxColumn";
            // 
            // weddingIDFKDataGridViewTextBoxColumn
            // 
            this.weddingIDFKDataGridViewTextBoxColumn.DataPropertyName = "weddingID_FK";
            this.weddingIDFKDataGridViewTextBoxColumn.HeaderText = "weddingID_FK";
            this.weddingIDFKDataGridViewTextBoxColumn.Name = "weddingIDFKDataGridViewTextBoxColumn";
            // 
            // ManageTasksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(869, 433);
            this.Controls.Add(this.DeleteWeddingButton);
            this.Controls.Add(this.UpdateTaskButton);
            this.Controls.Add(this.AddTaskButton);
            this.Controls.Add(this.TasksDataGridView);
            this.Name = "ManageTasksWindow";
            this.Text = "Manage Tasks";
            this.Load += new System.EventHandler(this.ManageTasksWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
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
    }
}