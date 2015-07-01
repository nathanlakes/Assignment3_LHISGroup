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
        public UpdateWeddingWindow()
        {
            InitializeComponent();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            UI.EventReportWindow win = new UI.EventReportWindow(this);
            win.Visible = true;
        }
    }
}
