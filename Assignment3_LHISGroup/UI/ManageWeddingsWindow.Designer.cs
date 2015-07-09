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
            this.weddingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.AddWeddingButton = new System.Windows.Forms.Button();
            this.UpdateWeddingButton = new System.Windows.Forms.Button();
            this.DeleteWeddingButton = new System.Windows.Forms.Button();
            this.weddingTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.WeddingTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GraphButton = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.ProgressButton = new System.Windows.Forms.Button();
            this.weddingBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // WeddingsDataGridView
            // 
            this.WeddingsDataGridView.AllowUserToAddRows = false;
            this.WeddingsDataGridView.AllowUserToDeleteRows = false;
            this.WeddingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WeddingsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.WeddingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeddingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeddingsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.WeddingsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.WeddingsDataGridView.MultiSelect = false;
            this.WeddingsDataGridView.Name = "WeddingsDataGridView";
            this.WeddingsDataGridView.ReadOnly = true;
            this.WeddingsDataGridView.RowTemplate.Height = 28;
            this.WeddingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WeddingsDataGridView.Size = new System.Drawing.Size(914, 221);
            this.WeddingsDataGridView.TabIndex = 0;
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
            this.AddWeddingButton.Location = new System.Drawing.Point(25, 14);
            this.AddWeddingButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddWeddingButton.Name = "AddWeddingButton";
            this.AddWeddingButton.Size = new System.Drawing.Size(103, 27);
            this.AddWeddingButton.TabIndex = 1;
            this.AddWeddingButton.Text = "Add Wedding";
            this.AddWeddingButton.UseVisualStyleBackColor = false;
            this.AddWeddingButton.Click += new System.EventHandler(this.AddWeddingButton_Click);
            // 
            // UpdateWeddingButton
            // 
            this.UpdateWeddingButton.BackColor = System.Drawing.Color.White;
            this.UpdateWeddingButton.Location = new System.Drawing.Point(311, 15);
            this.UpdateWeddingButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateWeddingButton.Name = "UpdateWeddingButton";
            this.UpdateWeddingButton.Size = new System.Drawing.Size(105, 27);
            this.UpdateWeddingButton.TabIndex = 2;
            this.UpdateWeddingButton.Text = "Update Wedding";
            this.UpdateWeddingButton.UseVisualStyleBackColor = false;
            this.UpdateWeddingButton.Click += new System.EventHandler(this.UpdateWeddingButton_Click);
            // 
            // DeleteWeddingButton
            // 
            this.DeleteWeddingButton.BackColor = System.Drawing.Color.White;
            this.DeleteWeddingButton.Location = new System.Drawing.Point(173, 15);
            this.DeleteWeddingButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteWeddingButton.Name = "DeleteWeddingButton";
            this.DeleteWeddingButton.Size = new System.Drawing.Size(105, 26);
            this.DeleteWeddingButton.TabIndex = 3;
            this.DeleteWeddingButton.Text = "Delete Wedding";
            this.DeleteWeddingButton.UseVisualStyleBackColor = false;
            this.DeleteWeddingButton.Click += new System.EventHandler(this.DeleteWeddingButton_Click);
            // 
            // weddingTableAdapter
            // 
            this.weddingTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GraphButton);
            this.panel1.Controls.Add(this.ReportButton);
            this.panel1.Controls.Add(this.ProgressButton);
            this.panel1.Controls.Add(this.AddWeddingButton);
            this.panel1.Controls.Add(this.DeleteWeddingButton);
            this.panel1.Controls.Add(this.UpdateWeddingButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 221);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 92);
            this.panel1.TabIndex = 4;
            // 
            // GraphButton
            // 
            this.GraphButton.BackColor = System.Drawing.Color.White;
            this.GraphButton.Location = new System.Drawing.Point(25, 58);
            this.GraphButton.Margin = new System.Windows.Forms.Padding(2);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(103, 27);
            this.GraphButton.TabIndex = 9;
            this.GraphButton.Text = "Progress Graph";
            this.GraphButton.UseVisualStyleBackColor = false;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.BackColor = System.Drawing.Color.White;
            this.ReportButton.Location = new System.Drawing.Point(311, 58);
            this.ReportButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(105, 27);
            this.ReportButton.TabIndex = 8;
            this.ReportButton.Text = "Event Report";
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // ProgressButton
            // 
            this.ProgressButton.BackColor = System.Drawing.Color.White;
            this.ProgressButton.Location = new System.Drawing.Point(173, 58);
            this.ProgressButton.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressButton.Name = "ProgressButton";
            this.ProgressButton.Size = new System.Drawing.Size(105, 27);
            this.ProgressButton.TabIndex = 7;
            this.ProgressButton.Text = "Progress Printout";
            this.ProgressButton.UseVisualStyleBackColor = false;
            this.ProgressButton.Click += new System.EventHandler(this.ProgressButton_Click);
            // 
            // weddingBindingSource1
            // 
            this.weddingBindingSource1.DataMember = "Wedding";
            this.weddingBindingSource1.DataSource = this.modelDataSet;
            // 
            // ManageWeddingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(914, 313);
            this.Controls.Add(this.WeddingsDataGridView);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageWeddingsWindow";
            this.Text = "ManageWeddingsWindow";
            this.Activated += new System.EventHandler(this.WindowActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageWeddingsWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageWeddingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WeddingsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weddingBindingSource1)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Button ProgressButton;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.BindingSource weddingBindingSource1;
    }
}