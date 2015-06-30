namespace Assignment3_LHISGroup.UI
{
    partial class ManageSuppliersWindow
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
            this.SuppliersDataGridView = new System.Windows.Forms.DataGridView();
            this.AddSupplierButton = new System.Windows.Forms.Button();
            this.UpdateSupplierbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SuppliersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SuppliersDataGridView
            // 
            this.SuppliersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SuppliersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SuppliersDataGridView.Location = new System.Drawing.Point(12, 12);
            this.SuppliersDataGridView.Name = "SuppliersDataGridView";
            this.SuppliersDataGridView.RowTemplate.Height = 28;
            this.SuppliersDataGridView.Size = new System.Drawing.Size(921, 299);
            this.SuppliersDataGridView.TabIndex = 0;
            // 
            // AddSupplierButton
            // 
            this.AddSupplierButton.BackColor = System.Drawing.Color.White;
            this.AddSupplierButton.Location = new System.Drawing.Point(204, 351);
            this.AddSupplierButton.Name = "AddSupplierButton";
            this.AddSupplierButton.Size = new System.Drawing.Size(149, 36);
            this.AddSupplierButton.TabIndex = 1;
            this.AddSupplierButton.Text = "Add Supplier";
            this.AddSupplierButton.UseVisualStyleBackColor = false;
            this.AddSupplierButton.Click += new System.EventHandler(this.AddSupplierButton_Click);
            // 
            // UpdateSupplierbutton
            // 
            this.UpdateSupplierbutton.BackColor = System.Drawing.Color.White;
            this.UpdateSupplierbutton.Location = new System.Drawing.Point(515, 351);
            this.UpdateSupplierbutton.Name = "UpdateSupplierbutton";
            this.UpdateSupplierbutton.Size = new System.Drawing.Size(158, 35);
            this.UpdateSupplierbutton.TabIndex = 2;
            this.UpdateSupplierbutton.Text = "Update Supplier";
            this.UpdateSupplierbutton.UseVisualStyleBackColor = false;
            this.UpdateSupplierbutton.Click += new System.EventHandler(this.UpdateSupplierbutton_Click);
            // 
            // ManageSuppliersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(945, 416);
            this.Controls.Add(this.UpdateSupplierbutton);
            this.Controls.Add(this.AddSupplierButton);
            this.Controls.Add(this.SuppliersDataGridView);
            this.Name = "ManageSuppliersWindow";
            this.Text = "Manage Suppliers";
            ((System.ComponentModel.ISupportInitialize)(this.SuppliersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SuppliersDataGridView;
        private System.Windows.Forms.Button AddSupplierButton;
        private System.Windows.Forms.Button UpdateSupplierbutton;
    }
}