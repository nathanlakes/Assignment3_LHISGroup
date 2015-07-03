using System;
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
    public partial class UpdateTaskWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        
        public UpdateTaskWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            this.db = d;
            this.mainWin = w;
        }

        private void UpdateTaskWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
