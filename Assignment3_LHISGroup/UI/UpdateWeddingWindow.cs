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
    public partial class UpdateWeddingWindow : Form
    {
        DbController db;
        MainWindow mainWin;
        public UpdateWeddingWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            db = d;
            mainWin = w;
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            UI.EventReportWindow win = new UI.EventReportWindow(mainWin, db);
            win.Visible = true;
        }
    }
}
