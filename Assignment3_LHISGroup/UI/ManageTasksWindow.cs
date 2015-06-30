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
    public partial class ManageTasksWindow : Form
    {
        public ManageTasksWindow()
        {
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            UI.NewTaskWindow win = new UI.NewTaskWindow();
            win.Visible = true;
        }

        private void UpdateTaskButton_Click(object sender, EventArgs e)
        {
            UI.UpdateTaskWindow win = new UI.UpdateTaskWindow();
            win.Visible = true;
        }
    }
}
