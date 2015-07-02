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
    public partial class ManageStaffWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public ManageStaffWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private void AddStaffButton_Click(object sender, EventArgs e)
        {
            UI.NewStaffWindow win = new UI.NewStaffWindow();
            win.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainWin.UpdateStaffWindow.Visible = true;
        }
    }
}
