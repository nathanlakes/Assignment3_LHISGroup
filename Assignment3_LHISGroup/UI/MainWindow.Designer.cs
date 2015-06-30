﻿namespace Assignment3_LHISGroup
{
    partial class MainWindow
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
            this.ManageEventsButton = new System.Windows.Forms.Button();
            this.ManageClientsButton = new System.Windows.Forms.Button();
            this.ManageSuppliersButton = new System.Windows.Forms.Button();
            this.ManageStaffButton = new System.Windows.Forms.Button();
            this.NewClientButton = new System.Windows.Forms.Button();
            this.NewEventButton = new System.Windows.Forms.Button();
            this.NewStaffButton = new System.Windows.Forms.Button();
            this.NewSupplierButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManageEventsButton
            // 
            this.ManageEventsButton.BackColor = System.Drawing.Color.White;
            this.ManageEventsButton.Location = new System.Drawing.Point(60, 26);
            this.ManageEventsButton.Name = "ManageEventsButton";
            this.ManageEventsButton.Size = new System.Drawing.Size(183, 63);
            this.ManageEventsButton.TabIndex = 0;
            this.ManageEventsButton.Text = "Manage Events";
            this.ManageEventsButton.UseVisualStyleBackColor = false;
            // 
            // ManageClientsButton
            // 
            this.ManageClientsButton.BackColor = System.Drawing.Color.White;
            this.ManageClientsButton.Location = new System.Drawing.Point(60, 117);
            this.ManageClientsButton.Name = "ManageClientsButton";
            this.ManageClientsButton.Size = new System.Drawing.Size(183, 64);
            this.ManageClientsButton.TabIndex = 1;
            this.ManageClientsButton.Text = "Manage Clients";
            this.ManageClientsButton.UseVisualStyleBackColor = false;
            // 
            // ManageSuppliersButton
            // 
            this.ManageSuppliersButton.BackColor = System.Drawing.Color.White;
            this.ManageSuppliersButton.Location = new System.Drawing.Point(60, 376);
            this.ManageSuppliersButton.Name = "ManageSuppliersButton";
            this.ManageSuppliersButton.Size = new System.Drawing.Size(183, 73);
            this.ManageSuppliersButton.TabIndex = 2;
            this.ManageSuppliersButton.Text = "Manage Suppliers";
            this.ManageSuppliersButton.UseVisualStyleBackColor = false;
            // 
            // ManageStaffButton
            // 
            this.ManageStaffButton.BackColor = System.Drawing.Color.White;
            this.ManageStaffButton.Location = new System.Drawing.Point(60, 265);
            this.ManageStaffButton.Name = "ManageStaffButton";
            this.ManageStaffButton.Size = new System.Drawing.Size(183, 72);
            this.ManageStaffButton.TabIndex = 3;
            this.ManageStaffButton.Text = "Manage Staff";
            this.ManageStaffButton.UseVisualStyleBackColor = false;
            // 
            // NewClientButton
            // 
            this.NewClientButton.BackColor = System.Drawing.Color.White;
            this.NewClientButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NewClientButton.Location = new System.Drawing.Point(275, 117);
            this.NewClientButton.Name = "NewClientButton";
            this.NewClientButton.Size = new System.Drawing.Size(183, 64);
            this.NewClientButton.TabIndex = 4;
            this.NewClientButton.Text = "New Client";
            this.NewClientButton.UseVisualStyleBackColor = false;
            // 
            // NewEventButton
            // 
            this.NewEventButton.BackColor = System.Drawing.Color.White;
            this.NewEventButton.Location = new System.Drawing.Point(275, 26);
            this.NewEventButton.Name = "NewEventButton";
            this.NewEventButton.Size = new System.Drawing.Size(183, 63);
            this.NewEventButton.TabIndex = 5;
            this.NewEventButton.Text = "New Event";
            this.NewEventButton.UseVisualStyleBackColor = false;
            // 
            // NewStaffButton
            // 
            this.NewStaffButton.BackColor = System.Drawing.Color.White;
            this.NewStaffButton.Location = new System.Drawing.Point(275, 265);
            this.NewStaffButton.Name = "NewStaffButton";
            this.NewStaffButton.Size = new System.Drawing.Size(183, 72);
            this.NewStaffButton.TabIndex = 6;
            this.NewStaffButton.Text = "New Staff";
            this.NewStaffButton.UseVisualStyleBackColor = false;
            // 
            // NewSupplierButton
            // 
            this.NewSupplierButton.BackColor = System.Drawing.Color.White;
            this.NewSupplierButton.Location = new System.Drawing.Point(275, 376);
            this.NewSupplierButton.Name = "NewSupplierButton";
            this.NewSupplierButton.Size = new System.Drawing.Size(183, 73);
            this.NewSupplierButton.TabIndex = 7;
            this.NewSupplierButton.Text = "New Supplier";
            this.NewSupplierButton.UseVisualStyleBackColor = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(534, 486);
            this.Controls.Add(this.NewSupplierButton);
            this.Controls.Add(this.NewStaffButton);
            this.Controls.Add(this.NewEventButton);
            this.Controls.Add(this.NewClientButton);
            this.Controls.Add(this.ManageStaffButton);
            this.Controls.Add(this.ManageSuppliersButton);
            this.Controls.Add(this.ManageClientsButton);
            this.Controls.Add(this.ManageEventsButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "Start Screen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ManageEventsButton;
        private System.Windows.Forms.Button ManageClientsButton;
        private System.Windows.Forms.Button ManageSuppliersButton;
        private System.Windows.Forms.Button ManageStaffButton;
        private System.Windows.Forms.Button NewClientButton;
        private System.Windows.Forms.Button NewEventButton;
        private System.Windows.Forms.Button NewStaffButton;
        private System.Windows.Forms.Button NewSupplierButton;
    }
}

