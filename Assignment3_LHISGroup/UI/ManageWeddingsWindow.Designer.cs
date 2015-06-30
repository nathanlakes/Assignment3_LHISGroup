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
            this.WeddingsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddWeddingButton = new System.Windows.Forms.Button();
            this.UpdateWeddingButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WeddingsDataGridView
            // 
            this.WeddingsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.WeddingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeddingsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.WeddingsDataGridView.Name = "WeddingsDataGridView";
            this.WeddingsDataGridView.RowTemplate.Height = 28;
            this.WeddingsDataGridView.Size = new System.Drawing.Size(813, 255);
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
            // 
            // ManageWeddingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(837, 410);
            this.Controls.Add(this.DeleteWeddingButton);
            this.Controls.Add(this.UpdateWeddingButton);
            this.Controls.Add(this.AddWeddingButton);
            this.Controls.Add(this.WeddingsDataGridView);
            this.Name = "ManageWeddingsWindow";
            this.Text = "ManageWeddingsWindow";
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WeddingsDataGridView;
        private System.Windows.Forms.Button AddWeddingButton;
        private System.Windows.Forms.Button UpdateWeddingButton;
        private System.Windows.Forms.Button DeleteWeddingButton;
    }
}