namespace Assignment3_LHISGroup.UI
{
    partial class NewWeddingWindow
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
            this.ClearButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EventDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StaffComboBox = new System.Windows.Forms.ComboBox();
            this.ClientComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EngagedComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NewClientButton = new System.Windows.Forms.Button();
            this.modelDataSet = new Assignment3_LHISGroup.ModelDataSet();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientTableAdapter = new Assignment3_LHISGroup.ModelDataSetTableAdapters.ClientTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(204, 451);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(65, 54);
            this.ClearButton.TabIndex = 45;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.White;
            this.CreateButton.Location = new System.Drawing.Point(275, 451);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(129, 54);
            this.CreateButton.TabIndex = 44;
            this.CreateButton.Text = "CREATE";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(204, 334);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.StartDateTimePicker.TabIndex = 43;
            // 
            // EventDateTimePicker
            // 
            this.EventDateTimePicker.Location = new System.Drawing.Point(204, 294);
            this.EventDateTimePicker.Name = "EventDateTimePicker";
            this.EventDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.EventDateTimePicker.TabIndex = 42;
            // 
            // StaffComboBox
            // 
            this.StaffComboBox.FormattingEnabled = true;
            this.StaffComboBox.Location = new System.Drawing.Point(204, 384);
            this.StaffComboBox.Name = "StaffComboBox";
            this.StaffComboBox.Size = new System.Drawing.Size(200, 28);
            this.StaffComboBox.TabIndex = 41;
            // 
            // ClientComboBox
            // 
            this.ClientComboBox.FormattingEnabled = true;
            this.ClientComboBox.Location = new System.Drawing.Point(204, 72);
            this.ClientComboBox.Name = "ClientComboBox";
            this.ClientComboBox.Size = new System.Drawing.Size(200, 28);
            this.ClientComboBox.TabIndex = 40;
            this.ClientComboBox.SelectionChangeCommitted += new System.EventHandler(this.ClientComboBox_SelectionChangeCommitted);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(204, 183);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(200, 83);
            this.DescriptionTextBox.TabIndex = 39;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(204, 32);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(200, 26);
            this.NameTextBox.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Wedding Planner";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Client";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Wedding Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Name";
            // 
            // EngagedComboBox
            // 
            this.EngagedComboBox.FormattingEnabled = true;
            this.EngagedComboBox.Location = new System.Drawing.Point(204, 118);
            this.EngagedComboBox.Name = "EngagedComboBox";
            this.EngagedComboBox.Size = new System.Drawing.Size(200, 28);
            this.EngagedComboBox.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Engaged To";
            // 
            // NewClientButton
            // 
            this.NewClientButton.BackColor = System.Drawing.Color.White;
            this.NewClientButton.Location = new System.Drawing.Point(36, 451);
            this.NewClientButton.Name = "NewClientButton";
            this.NewClientButton.Size = new System.Drawing.Size(94, 53);
            this.NewClientButton.TabIndex = 48;
            this.NewClientButton.Text = "Add Client";
            this.NewClientButton.UseVisualStyleBackColor = false;
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
            // NewWeddingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(439, 536);
            this.Controls.Add(this.NewClientButton);
            this.Controls.Add(this.EngagedComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.EventDateTimePicker);
            this.Controls.Add(this.StaffComboBox);
            this.Controls.Add(this.ClientComboBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewWeddingWindow";
            this.Text = "New Wedding";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewWeddingWindow_FormClosing);
            this.Load += new System.EventHandler(this.NewWeddingWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker EventDateTimePicker;
        private System.Windows.Forms.ComboBox StaffComboBox;
        private System.Windows.Forms.ComboBox ClientComboBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EngagedComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button NewClientButton;
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private ModelDataSetTableAdapters.ClientTableAdapter clientTableAdapter;

    }
}