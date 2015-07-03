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
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client1FKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client2FKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weddingPlannerFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weddingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.AddWeddingButton = new System.Windows.Forms.Button();
            this.UpdateWeddingButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            this.weddingTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.WeddingTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WeddingsDataGridView
            // 
            this.WeddingsDataGridView.AllowUserToAddRows = false;
            this.WeddingsDataGridView.AllowUserToDeleteRows = false;
            this.WeddingsDataGridView.AutoGenerateColumns = false;
            this.WeddingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.WeddingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeddingsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.WeddingsDataGridView.MultiSelect = false;
            this.WeddingsDataGridView.Name = "WeddingsDataGridView";
            this.WeddingsDataGridView.ReadOnly = true;
            this.WeddingsDataGridView.RowTemplate.Height = 28;
            this.WeddingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WeddingsDataGridView.Size = new System.Drawing.Size(776, 410);
            this.WeddingsDataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // client1FKDataGridViewTextBoxColumn
            // 
            this.client1FKDataGridViewTextBoxColumn.DataPropertyName = "client_1_FK";
            this.client1FKDataGridViewTextBoxColumn.HeaderText = "client_1_FK";
            this.client1FKDataGridViewTextBoxColumn.Name = "client1FKDataGridViewTextBoxColumn";
            this.client1FKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // client2FKDataGridViewTextBoxColumn
            // 
            this.client2FKDataGridViewTextBoxColumn.DataPropertyName = "client_2_FK";
            this.client2FKDataGridViewTextBoxColumn.HeaderText = "client_2_FK";
            this.client2FKDataGridViewTextBoxColumn.Name = "client2FKDataGridViewTextBoxColumn";
            this.client2FKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "startDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "startDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventDateDataGridViewTextBoxColumn
            // 
            this.eventDateDataGridViewTextBoxColumn.DataPropertyName = "eventDate";
            this.eventDateDataGridViewTextBoxColumn.HeaderText = "eventDate";
            this.eventDateDataGridViewTextBoxColumn.Name = "eventDateDataGridViewTextBoxColumn";
            this.eventDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // weddingPlannerFKDataGridViewTextBoxColumn
            // 
            this.weddingPlannerFKDataGridViewTextBoxColumn.DataPropertyName = "weddingPlanner_FK";
            this.weddingPlannerFKDataGridViewTextBoxColumn.HeaderText = "weddingPlanner_FK";
            this.weddingPlannerFKDataGridViewTextBoxColumn.Name = "weddingPlannerFKDataGridViewTextBoxColumn";
            this.weddingPlannerFKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // weddingBindingSource
            // 
            this.weddingBindingSource.DataMember = "Wedding";
            this.weddingBindingSource.DataSource = this.modelDataSet;
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AddWeddingButton
            // 
            this.AddWeddingButton.BackColor = System.Drawing.Color.White;
            this.AddWeddingButton.Location = new System.Drawing.Point(38, 22);
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
            this.UpdateWeddingButton.Location = new System.Drawing.Point(466, 23);
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
            this.DeleteWeddingButton.Location = new System.Drawing.Point(259, 23);
            this.DeleteWeddingButton.Name = "DeleteWeddingButton";
            this.DeleteWeddingButton.Size = new System.Drawing.Size(158, 40);
            this.DeleteWeddingButton.TabIndex = 3;
            this.DeleteWeddingButton.Text = "Delete Button";
            this.DeleteWeddingButton.UseVisualStyleBackColor = false;
            this.DeleteWeddingButton.Click += new System.EventHandler(this.DeleteWeddingButton_Click);
            // 
            // weddingTableAdapter
            // 
            this.weddingTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddWeddingButton);
            this.panel1.Controls.Add(this.DeleteWeddingButton);
            this.panel1.Controls.Add(this.UpdateWeddingButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 93);
            this.panel1.TabIndex = 4;
            // 
            // ManageWeddingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(776, 410);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.WeddingsDataGridView);
            this.Name = "ManageWeddingsWindow";
            this.Text = "ManageWeddingsWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageWeddingsWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageWeddingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
    }
}