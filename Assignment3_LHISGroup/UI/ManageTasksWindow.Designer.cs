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
            this.TasksDataGridView = new System.Windows.Forms.DataGridView();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.UpdateTaskButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.TasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGridView.Location = new System.Drawing.Point(12, 12);
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.RowTemplate.Height = 28;
            this.TasksDataGridView.Size = new System.Drawing.Size(676, 272);
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
            // 
            // DeleteWeddingButton
            // 
            this.DeleteWeddingButton.BackColor = System.Drawing.Color.White;
            this.DeleteWeddingButton.Location = new System.Drawing.Point(433, 362);
            this.DeleteWeddingButton.Name = "DeleteWeddingButton";
            this.DeleteWeddingButton.Size = new System.Drawing.Size(131, 43);
            this.DeleteWeddingButton.TabIndex = 3;
            this.DeleteWeddingButton.Text = "Delete Wedding";
            this.DeleteWeddingButton.UseVisualStyleBackColor = false;
            // 
            // ManageTasksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(700, 433);
            this.Controls.Add(this.DeleteWeddingButton);
            this.Controls.Add(this.UpdateTaskButton);
            this.Controls.Add(this.AddTaskButton);
            this.Controls.Add(this.TasksDataGridView);
            this.Name = "ManageTasksWindow";
            this.Text = "Manage Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TasksDataGridView;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Button UpdateTaskButton;
        private System.Windows.Forms.Button DeleteWeddingButton;
    }
}