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
            this.AddClientButton = new System.Windows.Forms.Button();
            this.UpdateClientButton = new System.Windows.Forms.Button();
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.ClientTableAdapter();
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
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientsDataGridView
            // 
            this.ClientsDataGridView.AutoGenerateColumns = false;
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
            this.ClientsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ClientsDataGridView.Name = "ClientsDataGridView";
            this.ClientsDataGridView.RowTemplate.Height = 28;
            this.ClientsDataGridView.Size = new System.Drawing.Size(1053, 227);
            this.ClientsDataGridView.TabIndex = 0;
            // 
            // AddClientButton
            // 
            this.AddClientButton.BackColor = System.Drawing.Color.White;
            this.AddClientButton.Location = new System.Drawing.Point(131, 270);
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
            this.UpdateClientButton.Location = new System.Drawing.Point(388, 270);
            this.UpdateClientButton.Name = "UpdateClientButton";
            this.UpdateClientButton.Size = new System.Drawing.Size(183, 47);
            this.UpdateClientButton.TabIndex = 2;
            this.UpdateClientButton.Text = "Update Client";
            this.UpdateClientButton.UseVisualStyleBackColor = false;
            this.UpdateClientButton.Click += new System.EventHandler(this.UpdateClientButton_Click);
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "Client";
            this.clientBindingSource.DataSource = this.modelDataSet;
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "firstname";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "firstname";
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "surname";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            // 
            // contactPersonDataGridViewTextBoxColumn
            // 
            this.contactPersonDataGridViewTextBoxColumn.DataPropertyName = "contactPerson";
            this.contactPersonDataGridViewTextBoxColumn.HeaderText = "contactPerson";
            this.contactPersonDataGridViewTextBoxColumn.Name = "contactPersonDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // mobileDataGridViewTextBoxColumn
            // 
            this.mobileDataGridViewTextBoxColumn.DataPropertyName = "mobile";
            this.mobileDataGridViewTextBoxColumn.HeaderText = "mobile";
            this.mobileDataGridViewTextBoxColumn.Name = "mobileDataGridViewTextBoxColumn";
            // 
            // homePhoneDataGridViewTextBoxColumn
            // 
            this.homePhoneDataGridViewTextBoxColumn.DataPropertyName = "homePhone";
            this.homePhoneDataGridViewTextBoxColumn.HeaderText = "homePhone";
            this.homePhoneDataGridViewTextBoxColumn.Name = "homePhoneDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // engagedTofirstnameDataGridViewTextBoxColumn
            // 
            this.engagedTofirstnameDataGridViewTextBoxColumn.DataPropertyName = "engagedTo_firstname";
            this.engagedTofirstnameDataGridViewTextBoxColumn.HeaderText = "engagedTo_firstname";
            this.engagedTofirstnameDataGridViewTextBoxColumn.Name = "engagedTofirstnameDataGridViewTextBoxColumn";
            // 
            // engagedTosurnameDataGridViewTextBoxColumn
            // 
            this.engagedTosurnameDataGridViewTextBoxColumn.DataPropertyName = "engagedTo_surname";
            this.engagedTosurnameDataGridViewTextBoxColumn.HeaderText = "engagedTo_surname";
            this.engagedTosurnameDataGridViewTextBoxColumn.Name = "engagedTosurnameDataGridViewTextBoxColumn";
            // 
            // ManageClientsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1078, 329);
            this.Controls.Add(this.UpdateClientButton);
            this.Controls.Add(this.AddClientButton);
            this.Controls.Add(this.ClientsDataGridView);
            this.Name = "ManageClientsWindow";
            this.Text = "Manage Clients";
            this.Load += new System.EventHandler(this.ManageClientsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
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
    }
}