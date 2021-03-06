﻿namespace Assignment3_LHISGroup.UI
{
    partial class EventReportWindow
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
            this.EventReportButton = new System.Windows.Forms.Button();
            this.EventTaskReportButton = new System.Windows.Forms.Button();
            this.EventProgressReportButton = new System.Windows.Forms.Button();
            this.EventProgressGraphButton = new System.Windows.Forms.Button();
            this.StaffReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EventReportButton
            // 
            this.EventReportButton.BackColor = System.Drawing.Color.White;
            this.EventReportButton.Location = new System.Drawing.Point(40, 168);
            this.EventReportButton.Name = "EventReportButton";
            this.EventReportButton.Size = new System.Drawing.Size(303, 38);
            this.EventReportButton.TabIndex = 31;
            this.EventReportButton.Text = "Event Report";
            this.EventReportButton.UseVisualStyleBackColor = false;
            this.EventReportButton.Click += new System.EventHandler(this.EventReportButton_Click);
            // 
            // EventTaskReportButton
            // 
            this.EventTaskReportButton.BackColor = System.Drawing.Color.White;
            this.EventTaskReportButton.Location = new System.Drawing.Point(40, 229);
            this.EventTaskReportButton.Name = "EventTaskReportButton";
            this.EventTaskReportButton.Size = new System.Drawing.Size(303, 38);
            this.EventTaskReportButton.TabIndex = 30;
            this.EventTaskReportButton.Text = "Event Task Report";
            this.EventTaskReportButton.UseVisualStyleBackColor = false;
            this.EventTaskReportButton.Click += new System.EventHandler(this.EventTaskReportButton_Click);
            // 
            // EventProgressReportButton
            // 
            this.EventProgressReportButton.BackColor = System.Drawing.Color.White;
            this.EventProgressReportButton.Location = new System.Drawing.Point(40, 103);
            this.EventProgressReportButton.Name = "EventProgressReportButton";
            this.EventProgressReportButton.Size = new System.Drawing.Size(303, 38);
            this.EventProgressReportButton.TabIndex = 29;
            this.EventProgressReportButton.Text = "Event Progress Report";
            this.EventProgressReportButton.UseVisualStyleBackColor = false;
            this.EventProgressReportButton.Click += new System.EventHandler(this.EventProgressReportButton_Click);
            // 
            // EventProgressGraphButton
            // 
            this.EventProgressGraphButton.BackColor = System.Drawing.Color.White;
            this.EventProgressGraphButton.Location = new System.Drawing.Point(40, 40);
            this.EventProgressGraphButton.Name = "EventProgressGraphButton";
            this.EventProgressGraphButton.Size = new System.Drawing.Size(303, 38);
            this.EventProgressGraphButton.TabIndex = 28;
            this.EventProgressGraphButton.Text = "Event Progress Graph";
            this.EventProgressGraphButton.UseVisualStyleBackColor = false;
            this.EventProgressGraphButton.Click += new System.EventHandler(this.EventProgressGraphButton_Click);
            // 
            // StaffReportButton
            // 
            this.StaffReportButton.BackColor = System.Drawing.Color.White;
            this.StaffReportButton.Location = new System.Drawing.Point(40, 297);
            this.StaffReportButton.Name = "StaffReportButton";
            this.StaffReportButton.Size = new System.Drawing.Size(303, 38);
            this.StaffReportButton.TabIndex = 32;
            this.StaffReportButton.Text = "Staff Report";
            this.StaffReportButton.UseVisualStyleBackColor = false;
            // 
            // EventReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(409, 385);
            this.Controls.Add(this.StaffReportButton);
            this.Controls.Add(this.EventReportButton);
            this.Controls.Add(this.EventTaskReportButton);
            this.Controls.Add(this.EventProgressReportButton);
            this.Controls.Add(this.EventProgressGraphButton);
            this.Name = "EventReportWindow";
            this.Text = "Event Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventReportWindow_FormClosing);
            this.Load += new System.EventHandler(this.EventReportWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EventReportButton;
        private System.Windows.Forms.Button EventTaskReportButton;
        private System.Windows.Forms.Button EventProgressReportButton;
        private System.Windows.Forms.Button EventProgressGraphButton;
        private System.Windows.Forms.Button StaffReportButton;
    }
}