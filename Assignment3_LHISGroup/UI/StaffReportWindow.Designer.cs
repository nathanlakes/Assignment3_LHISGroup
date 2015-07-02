namespace Assignment3_LHISGroup.UI
{
    partial class StaffReportWindow
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
            this.StaffTasksListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // StaffTasksListView
            // 
            this.StaffTasksListView.Location = new System.Drawing.Point(38, 87);
            this.StaffTasksListView.Name = "StaffTasksListView";
            this.StaffTasksListView.Size = new System.Drawing.Size(419, 255);
            this.StaffTasksListView.TabIndex = 0;
            this.StaffTasksListView.UseCompatibleStateImageBehavior = false;
            // 
            // StaffReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 448);
            this.Controls.Add(this.StaffTasksListView);
            this.Name = "StaffReportWindow";
            this.Text = "Staff Report ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView StaffTasksListView;
    }
}