﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3_LHISGroup.UI
{
    public partial class ManageSuppliersWindow : Form
    {
        public ManageSuppliersWindow()
        {
            InitializeComponent();
        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            UI.NewSupplierWindow win = new UI.NewSupplierWindow();
            win.Visible = true;
        }

        private void UpdateSupplierbutton_Click(object sender, EventArgs e)
        {
            UI.UpdateSupplierWindow win = new UI.UpdateSupplierWindow();
            win.Visible = true;
        }

     
    }
}