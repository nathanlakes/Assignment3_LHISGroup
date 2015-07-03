namespace Assignment3_LHISGroup.UI
{
    partial class ManageClientsWindow
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
            this.ClientsDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactPersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engagedTofirstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engagedTosurnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.AddClientButton = new System.Windows.Forms.Button();
            this.UpdateClientButton = new System.Windows.Forms.Button();
            this.clientTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.ClientTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientsDataGridView
            // 
            this.ClientsDataGridView.AllowUserToAddRows = false;
            this.ClientsDataGridView.AllowUserToDeleteRows = false;
            this.ClientsDataGridView.AutoGenerateColumns = false;
            this.ClientsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ClientsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ClientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.contactPersonDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.mobileDataGridViewTextBoxColumn,
            this.homePhoneDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.engagedTofirstnameDataGridViewTextBoxColumn,
            this.engagedTosurnameDataGridViewTextBoxColumn});
            this.ClientsDataGridView.DataSource = this.clientBindingSource;
            this.ClientsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ClientsDataGridView.Name = "ClientsDataGridView";
            this.ClientsDataGridView.ReadOnly = true;
            this.ClientsDataGridView.RowTemplate.Height = 28;
            this.ClientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientsDataGridView.Size = new System.Drawing.Size(1078, 329);
            this.ClientsDataGridView.TabIndex = 0;
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
            // contactPersonDataGridViewTextBoxColumn
            // 
            this.contactPersonDataGridViewTextBoxColumn.DataPropertyName = "contactPerson";
            this.contactPersonDataGridViewTextBoxColumn.HeaderText = "contactPerson";
            this.contactPersonDataGridViewTextBoxColumn.Name = "contactPersonDataGridViewTextBoxColumn";
            this.contactPersonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mobileDataGridViewTextBoxColumn
            // 
            this.mobileDataGridViewTextBoxColumn.DataPropertyName = "mobile";
            this.mobileDataGridViewTextBoxColumn.HeaderText = "mobile";
            this.mobileDataGridViewTextBoxColumn.Name = "mobileDataGridViewTextBoxColumn";
            this.mobileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // homePhoneDataGridViewTextBoxColumn
            // 
            this.homePhoneDataGridViewTextBoxColumn.DataPropertyName = "homePhone";
            this.homePhoneDataGridViewTextBoxColumn.HeaderText = "homePhone";
            this.homePhoneDataGridViewTextBoxColumn.Name = "homePhoneDataGridViewTextBoxColumn";
            this.homePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // engagedTofirstnameDataGridViewTextBoxColumn
            // 
            this.engagedTofirstnameDataGridViewTextBoxColumn.DataPropertyName = "engagedTo_firstname";
            this.engagedTofirstnameDataGridViewTextBoxColumn.HeaderText = "engagedTo_firstname";
            this.engagedTofirstnameDataGridViewTextBoxColumn.Name = "engagedTofirstnameDataGridViewTextBoxColumn";
            this.engagedTofirstnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // engagedTosurnameDataGridViewTextBoxColumn
            // 
            this.engagedTosurnameDataGridViewTextBoxColumn.DataPropertyName = "engagedTo_surname";
            this.engagedTosurnameDataGridViewTextBoxColumn.HeaderText = "engagedTo_surname";
            this.engagedTosurnameDataGridViewTextBoxColumn.Name = "engagedTosurnameDataGridViewTextBoxColumn";
            this.engagedTosurnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "Client";
            this.clientBindingSource.DataSource = this.modelDataSet;
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AddClientButton
            // 
            this.AddClientButton.BackColor = System.Drawing.Color.White;
            this.AddClientButton.Location = new System.Drawing.Point(35, 13);
            this.AddClientButton.Name = "AddClientButton";
            this.AddClientButton.Size = new System.Drawing.Size(166, 47);
            this.AddClientButton.TabIndex = 1;
            this.AddClientButton.Text = "Add Client";
            this.AddClientButton.UseVisualStyleBackColor = false;
            this.AddClientButton.Click += new System.EventHandler(this.AddClientButton_Click);
            // 
            // UpdateClientButton
            // 
            this.UpdateClientButton.BackColor = System.Drawing.Color.White;
            this.UpdateClientButton.Location = new System.Drawing.Point(322, 13);
            this.UpdateClientButton.Name = "UpdateClientButton";
            this.UpdateClientButton.Size = new System.Drawing.Size(183, 47);
            this.UpdateClientButton.TabIndex = 2;
            this.UpdateClientButton.Text = "Update Client";
            this.UpdateClientButton.UseVisualStyleBackColor = false;
            this.UpdateClientButton.Click += new System.EventHandler(this.UpdateClientButton_Click);
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UpdateClientButton);
            this.panel1.Controls.Add(this.AddClientButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 67);
            this.panel1.TabIndex = 3;
            // 
            // ManageClientsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1078, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClientsDataGridView);
            this.Name = "ManageClientsWindow";
            this.Text = "Manage Clients";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageClientsWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageClientsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ClientsDataGridView;
        private System.Windows.Forms.Button AddClientButton;
        private System.Windows.Forms.Button UpdateClientButton;
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private ModelDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactPersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn engagedTofirstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn engagedTosurnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
    }
}