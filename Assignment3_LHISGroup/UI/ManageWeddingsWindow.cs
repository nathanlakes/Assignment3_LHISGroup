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
        MainWindow mainWin;
        DbController db;
        public ManageWeddingsWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        public void UpdateForm()
        {
            this.weddingTableAdapter.Fill(this.modelDataSet.Wedding);
            WeddingsDataGridView.Update();
            WeddingsDataGridView.Refresh();
            this.Refresh();
        }

        private void ManageWeddingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }

        private void AddWeddingButton_Click(object sender, EventArgs e)
        {
            mainWin.NewWeddingWindow.Visible = true;
        }

        private void UpdateWeddingButton_Click(object sender, EventArgs e)
        {
            mainWin.UpdateWeddingWindow.Visible = true;
        }

        private void DeleteWeddingButton_Click(object sender, EventArgs e)
        {

        }

        private void ManageWeddingsWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Wedding' table. You can move, or remove it, as needed.
            this.weddingTableAdapter.Fill(this.modelDataSet.Wedding);

        }
    }
}
