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
            if (!mainWin.NewWeddingWindow.Visible)
            {
                mainWin.NewWeddingWindow.Visible = true;
            }
            else
            {
                mainWin.NewWeddingWindow.Focus();
            }
            
        }

        private void UpdateWeddingButton_Click(object sender, EventArgs e)
        {
            if (WeddingsDataGridView.SelectedRows.Count > 0 && WeddingsDataGridView.SelectedRows[0].Cells[0] != null)
            {
                int id = (int) WeddingsDataGridView.SelectedRows[0].Cells[0].Value;

                if (!mainWin.UpdateWeddingWindow.Visible)
                {
                    mainWin.UpdateWeddingWindow.Visible = true;
                }
                else
                {
                    mainWin.UpdateWeddingWindow.Focus();
                }
            }
            else
            {

            }

            
            
        }

        private void DeleteWeddingButton_Click(object sender, EventArgs e)
        {

        }

        private void ManageWeddingsWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Wedding' table. You can move, or remove it, as needed.
            //this.weddingTableAdapter.Fill(this.modelDataSet.Wedding);

        }

    }
}
