using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment3_LHISGroup.Reports;

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


        private Support_Classes.Wedding ExtractSelectedRow()
        {
            if (WeddingsDataGridView.SelectedRows.Count > 0 && WeddingsDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                int id = (int) WeddingsDataGridView.SelectedRows[0].Cells[0].Value;
                return db.FindWedding(id);
            }
            else
            {
                return null;
            }
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
            Support_Classes.Wedding wedding = ExtractSelectedRow();
            if (wedding != null)
            {
                mainWin.UpdateWeddingWindow.PopulateDataFields(wedding);
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
                MessageBox.Show("No row selected");
            }            
        }


        private void DeleteWeddingButton_Click(object sender, EventArgs e)
        {
            string s = WeddingsDataGridView.Rows[WeddingsDataGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
            int w = Convert.ToInt32( s );

            Support_Classes.Wedding delete = ExtractSelectedRow();
            try
            {
                db.DeleteWedding(delete.ID);
                MessageBox.Show("Wedding delted successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Exception thrown");
            }

            db.DeleteWedding(w);
            UpdateForm();
        }


        private void ManageWeddingsWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Wedding' table. You can move, or remove it, as needed.
            this.weddingTableAdapter.Fill(this.modelDataSet.Wedding);

        }


        private void GraphButton_Click(object sender, EventArgs e)
        {
            EventProgressGraph graphReport = new EventProgressGraph(this);
            graphReport.Show();
        }


        private void ProgressButton_Click(object sender, EventArgs e)
        {
            EventProgressReport progReport = new EventProgressReport(this);
            progReport.Show();
        }


        private void ReportButton_Click(object sender, EventArgs e)
        {
            EventReport eventReport = new EventReport();
            eventReport.Show();
        }

    }
}
