﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Assignment3_LHISGroup.Support_Classes;

namespace Assignment3_LHISGroup
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //DbController db = new DbController();


            // DEBUGGING
            Support_Classes.Staff s = new Support_Classes.Staff("Me", "Me", "nl@mail.com", "0888548", "goat",
                Support_Classes.Staff.Status.active);

            Support_Classes.Task t = new Support_Classes.Task("moo", "moo",
                Support_Classes.Task.Priority.high, new DateTime(2015, 5, 20), s);

            Console.WriteLine(t.CompletionDate);
        }
    }
}
