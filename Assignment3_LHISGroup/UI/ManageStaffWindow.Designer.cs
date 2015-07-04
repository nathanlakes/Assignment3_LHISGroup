namespace Assignment3_LHISGroup.UI
{
    partial class ManageStaffWindow
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
            this.StaffDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.AddStaffButton = new System.Windows.Forms.Button();
            this.UpdateStaffButton = new System.Windows.Forms.Button();
            this.staffTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.StaffTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.StaffDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StaffDataGridView
            // 
            this.StaffDataGridView.AllowUserToAddRows = false;
            this.StaffDataGridView.AllowUserToDeleteRows = false;
            this.StaffDataGridView.AllowUserToOrderColumns = true;
            this.StaffDataGridView.AutoGenerateColumns = false;
            this.StaffDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StaffDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.StaffDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StaffDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.StaffDataGridView.DataSource = this.staffBindingSource;
            this.StaffDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StaffDataGridView.Location = new System.Drawing.Point(0, 0);
            this.StaffDataGridView.MultiSelect = false;
            this.StaffDataGridView.Name = "StaffDataGridView";
            this.StaffDataGridView.ReadOnly = true;
            this.StaffDataGridView.RowTemplate.Height = 28;
            this.StaffDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StaffDataGridView.Size = new System.Drawing.Size(1001, 362);
            this.StaffDataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "firstname";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "firstname";
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "surname";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // staffBindingSource
            // 
            this.staffBindingSource.DataMember = "Staff";
            this.staffBindingSource.DataSource = this.modelDataSetBindingSource;
            // 
            // modelDataSetBindingSource
            // 
            this.modelDataSetBindingSource.DataSource = this.modelDataSet;
            this.modelDataSetBindingSource.Position = 0;
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AddStaffButton
            // 
            this.AddStaffButton.BackColor = System.Drawing.Color.White;
            this.AddStaffButton.Location = new System.Drawing.Point(30, 14);
            this.AddStaffButton.Name = "AddStaffButton";
            this.AddStaffButton.Size = new System.Drawing.Size(173, 42);
            this.AddStaffButton.TabIndex = 1;
            this.AddStaffButton.Text = "Add Staff";
            this.AddStaffButton.UseVisualStyleBackColor = false;
            this.AddStaffButton.Click += new System.EventHandler(this.AddStaffButton_Click);
            // 
            // UpdateStaffButton
            // 
            this.UpdateStaffButton.BackColor = System.Drawing.Color.White;
            this.UpdateStaffButton.Location = new System.Drawing.Point(242, 15);
            this.UpdateStaffButton.Name = "UpdateStaffButton";
            this.UpdateStaffButton.Size = new System.Drawing.Size(174, 41);
            this.UpdateStaffButton.TabIndex = 2;
            this.UpdateStaffButton.Text = "Update Staff";
            this.UpdateStaffButton.UseVisualStyleBackColor = false;
            this.UpdateStaffButton.Click += new System.EventHandler(this.UpdateStaffButton_Click);
            // 
            // staffTableAdapter
            // 
            this.staffTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UpdateStaffButton);
            this.panel1.Controls.Add(this.AddStaffButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 72);
            this.panel1.TabIndex = 3;
            // 
            // ManageStaffWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1001, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StaffDataGridView);
            this.Name = "ManageStaffWindow";
            this.Text = "Manage Staff";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageStaffWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageStaffWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StaffDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView StaffDataGridView;
        private System.Windows.Forms.Button AddStaffButton;
        private System.Windows.Forms.Button UpdateStaffButton;
        private System.Windows.Forms.BindingSource modelDataSetBindingSource;
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource staffBindingSource;
        private ModelDataSetTableAdapters.StaffTableAdapter staffTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
    }
}