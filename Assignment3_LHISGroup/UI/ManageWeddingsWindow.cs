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
    public partial class ManageWeddingsWindow : Form
    {
        public ManageWeddingsWindow()
        {
            InitializeComponent();
        }

        private void AddWeddingButton_Click(object sender, EventArgs e)
        {
            UI.NewWeddingWindow win = new UI.NewWeddingWindow();
            win.Visible = true;
        }

        private void UpdateWeddingButton_Click(object sender, EventArgs e)
        {
            UI.UpdateWeddingWindow win = new UI.UpdateWeddingWindow();
            win.Visible = true;
        }
    }
}
