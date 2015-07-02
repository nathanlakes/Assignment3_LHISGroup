namespace Assignment3_LHISGroup.UI
{
    partial class NewTaskWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HighRadioButton = new System.Windows.Forms.RadioButton();
            this.MediumRadioButton = new System.Windows.Forms.RadioButton();
            this.LowRadioButton = new System.Windows.Forms.RadioButton();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.StaffComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CompleteByDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CompletionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // HighRadioButton
            // 
            this.HighRadioButton.AutoSize = true;
            this.HighRadioButton.Location = new System.Drawing.Point(245, 25);
            this.HighRadioButton.Name = "HighRadioButton";
            this.HighRadioButton.Size = new System.Drawing.Size(118, 24);
            this.HighRadioButton.TabIndex = 2;
            this.HighRadioButton.TabStop = true;
            this.HighRadioButton.Text = "High Priority";
            this.HighRadioButton.UseVisualStyleBackColor = true;
            // 
            // MediumRadioButton
            // 
            this.MediumRadioButton.Location = new System.Drawing.Point(245, 55);
            this.MediumRadioButton.Name = "MediumRadioButton";
            this.MediumRadioButton.Size = new System.Drawing.Size(141, 24);
            this.MediumRadioButton.TabIndex = 0;
            this.MediumRadioButton.TabStop = true;
            this.MediumRadioButton.Text = "Medium Priority";
            this.MediumRadioButton.UseVisualStyleBackColor = true;
            // 
            // LowRadioButton
            // 
            this.LowRadioButton.Location = new System.Drawing.Point(245, 85);
            this.LowRadioButton.Name = "LowRadioButton";
            this.LowRadioButton.Size = new System.Drawing.Size(126, 24);
            this.LowRadioButton.TabIndex = 0;
            this.LowRadioButton.TabStop = true;
            this.LowRadioButton.Text = "Low Priority";
            this.LowRadioButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(51, 473);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(102, 54);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.White;
            this.CreateButton.Location = new System.Drawing.Point(159, 473);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(227, 54);
            this.CreateButton.TabIndex = 3;
            this.CreateButton.Text = "CREATE";
            this.CreateButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Staff";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 54);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(211, 26);
            this.NameTextBox.TabIndex = 7;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(12, 149);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(374, 129);
            this.DescriptionTextBox.TabIndex = 8;
            // 
            // StaffComboBox
            // 
            this.StaffComboBox.FormattingEnabled = true;
            this.StaffComboBox.Location = new System.Drawing.Point(86, 301);
            this.StaffComboBox.Name = "StaffComboBox";
            this.StaffComboBox.Size = new System.Drawing.Size(300, 28);
            this.StaffComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Completed By Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Completion Date";
            // 
            // CompleteByDateTimePicker
            // 
            this.CompleteByDateTimePicker.Location = new System.Drawing.Point(186, 371);
            this.CompleteByDateTimePicker.Name = "CompleteByDateTimePicker";
            this.CompleteByDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.CompleteByDateTimePicker.TabIndex = 12;
            // 
            // CompletionDateTimePicker
            // 
            this.CompletionDateTimePicker.Location = new System.Drawing.Point(186, 415);
            this.CompletionDateTimePicker.Name = "CompletionDateTimePicker";
            this.CompletionDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.CompletionDateTimePicker.TabIndex = 13;
            // 
            // NewTaskWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(420, 562);
            this.Controls.Add(this.CompletionDateTimePicker);
            this.Controls.Add(this.CompleteByDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StaffComboBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.LowRadioButton);
            this.Controls.Add(this.MediumRadioButton);
            this.Controls.Add(this.HighRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewTaskWindow";
            this.Text = "New Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton HighRadioButton;
        private System.Windows.Forms.RadioButton MediumRadioButton;
        private System.Windows.Forms.RadioButton LowRadioButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.ComboBox StaffComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker CompleteByDateTimePicker;
        private System.Windows.Forms.DateTimePicker CompletionDateTimePicker;
    }
}