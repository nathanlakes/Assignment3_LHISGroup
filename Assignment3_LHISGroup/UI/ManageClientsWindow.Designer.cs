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
            this.ClientsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddClientButton = new System.Windows.Forms.Button();
            this.UpdateClientButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientsDataGridView
            // 
            this.ClientsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ClientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsDataGridView.Location = new System.Drawing.Point(54, 29);
            this.ClientsDataGridView.Name = "ClientsDataGridView";
            this.ClientsDataGridView.RowTemplate.Height = 28;
            this.ClientsDataGridView.Size = new System.Drawing.Size(588, 210);
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
            // 
            // ManageClientsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(689, 329);
            this.Controls.Add(this.UpdateClientButton);
            this.Controls.Add(this.AddClientButton);
            this.Controls.Add(this.ClientsDataGridView);
            this.Name = "ManageClientsWindow";
            this.Text = "ManageClientsWindow";
            ((System.ComponentModel.ISupportInitialize)(this.ClientsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ClientsDataGridView;
        private System.Windows.Forms.Button AddClientButton;
        private System.Windows.Forms.Button UpdateClientButton;
    }
}