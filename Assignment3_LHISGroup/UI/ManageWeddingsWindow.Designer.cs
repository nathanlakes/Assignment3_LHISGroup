namespace Assignment3_LHISGroup.UI
{
    partial class ManageWeddingsWindow
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
            this.WeddingsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddWeddingButton = new System.Windows.Forms.Button();
            this.UpdateWeddingButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.weddingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.weddingTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.WeddingTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client1FKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client2FKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weddingPlannerFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // WeddingsDataGridView
            // 
            this.WeddingsDataGridView.AutoGenerateColumns = false;
            this.WeddingsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.WeddingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeddingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.client1FKDataGridViewTextBoxColumn,
            this.client2FKDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.eventDateDataGridViewTextBoxColumn,
            this.weddingPlannerFKDataGridViewTextBoxColumn});
            this.WeddingsDataGridView.DataSource = this.weddingBindingSource;
            this.WeddingsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.WeddingsDataGridView.Name = "WeddingsDataGridView";
            this.WeddingsDataGridView.RowTemplate.Height = 28;
            this.WeddingsDataGridView.Size = new System.Drawing.Size(753, 255);
            this.WeddingsDataGridView.TabIndex = 0;
            // 
            // AddWeddingButton
            // 
            this.AddWeddingButton.BackColor = System.Drawing.Color.White;
            this.AddWeddingButton.Location = new System.Drawing.Point(169, 291);
            this.AddWeddingButton.Name = "AddWeddingButton";
            this.AddWeddingButton.Size = new System.Drawing.Size(154, 41);
            this.AddWeddingButton.TabIndex = 1;
            this.AddWeddingButton.Text = "Add Wedding";
            this.AddWeddingButton.UseVisualStyleBackColor = false;
            this.AddWeddingButton.Click += new System.EventHandler(this.AddWeddingButton_Click);
            // 
            // UpdateWeddingButton
            // 
            this.UpdateWeddingButton.BackColor = System.Drawing.Color.White;
            this.UpdateWeddingButton.Location = new System.Drawing.Point(546, 291);
            this.UpdateWeddingButton.Name = "UpdateWeddingButton";
            this.UpdateWeddingButton.Size = new System.Drawing.Size(158, 41);
            this.UpdateWeddingButton.TabIndex = 2;
            this.UpdateWeddingButton.Text = "Update Wedding";
            this.UpdateWeddingButton.UseVisualStyleBackColor = false;
            this.UpdateWeddingButton.Click += new System.EventHandler(this.UpdateWeddingButton_Click);
            // 
            // DeleteWeddingButton
            // 
            this.DeleteWeddingButton.BackColor = System.Drawing.Color.White;
            this.DeleteWeddingButton.Location = new System.Drawing.Point(546, 349);
            this.DeleteWeddingButton.Name = "DeleteWeddingButton";
            this.DeleteWeddingButton.Size = new System.Drawing.Size(158, 40);
            this.DeleteWeddingButton.TabIndex = 3;
            this.DeleteWeddingButton.Text = "Delete Button";
            this.DeleteWeddingButton.UseVisualStyleBackColor = false;
            this.DeleteWeddingButton.Click += new System.EventHandler(this.DeleteWeddingButton_Click);
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // weddingBindingSource
            // 
            this.weddingBindingSource.DataMember = "Wedding";
            this.weddingBindingSource.DataSource = this.modelDataSet;
            // 
            // weddingTableAdapter
            // 
            this.weddingTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // client1FKDataGridViewTextBoxColumn
            // 
            this.client1FKDataGridViewTextBoxColumn.DataPropertyName = "client_1_FK";
            this.client1FKDataGridViewTextBoxColumn.HeaderText = "client_1_FK";
            this.client1FKDataGridViewTextBoxColumn.Name = "client1FKDataGridViewTextBoxColumn";
            // 
            // client2FKDataGridViewTextBoxColumn
            // 
            this.client2FKDataGridViewTextBoxColumn.DataPropertyName = "client_2_FK";
            this.client2FKDataGridViewTextBoxColumn.HeaderText = "client_2_FK";
            this.client2FKDataGridViewTextBoxColumn.Name = "client2FKDataGridViewTextBoxColumn";
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "startDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "startDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            // 
            // eventDateDataGridViewTextBoxColumn
            // 
            this.eventDateDataGridViewTextBoxColumn.DataPropertyName = "eventDate";
            this.eventDateDataGridViewTextBoxColumn.HeaderText = "eventDate";
            this.eventDateDataGridViewTextBoxColumn.Name = "eventDateDataGridViewTextBoxColumn";
            // 
            // weddingPlannerFKDataGridViewTextBoxColumn
            // 
            this.weddingPlannerFKDataGridViewTextBoxColumn.DataPropertyName = "weddingPlanner_FK";
            this.weddingPlannerFKDataGridViewTextBoxColumn.HeaderText = "weddingPlanner_FK";
            this.weddingPlannerFKDataGridViewTextBoxColumn.Name = "weddingPlannerFKDataGridViewTextBoxColumn";
            // 
            // ManageWeddingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(776, 410);
            this.Controls.Add(this.DeleteWeddingButton);
            this.Controls.Add(this.UpdateWeddingButton);
            this.Controls.Add(this.AddWeddingButton);
            this.Controls.Add(this.WeddingsDataGridView);
            this.Name = "ManageWeddingsWindow";
            this.Text = "ManageWeddingsWindow";
            this.Load += new System.EventHandler(this.ManageWeddingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WeddingsDataGridView;
        private System.Windows.Forms.Button AddWeddingButton;
        private System.Windows.Forms.Button UpdateWeddingButton;
        private System.Windows.Forms.Button DeleteWeddingButton;
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource weddingBindingSource;
        private ModelDataSetTableAdapters.WeddingTableAdapter weddingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn client1FKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn client2FKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weddingPlannerFKDataGridViewTextBoxColumn;
    }
}