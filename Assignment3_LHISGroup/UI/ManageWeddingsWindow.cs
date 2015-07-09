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
using Assignment3_LHISGroup.Support_Classes;

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
            PopulateWeddingDGV();
        }

        //
        // Populate the DataGridView properly, using the
        // controller.
        public void PopulateWeddingDGV()
        {
            DataGridView dgv = WeddingsDataGridView;
            DataTable dt = new DataTable();
            {
                string[] titles = new string[]{
                    "ID", 
                    "Title",
                    "Client 1",
                    "Client 2",
                    "Start Date",
                    "Event Date",
                    "Wedding Planner",
                    "Status",
                    "Description"
                };

                for (int i = 0; i < titles.Length; i++)
                {
                    dt.Columns.Add(titles[i], System.Type.GetType("System.String"));
                }
            }

            dgv.DataSource = dt;


            // Add DataRows
            try
            {
                List<Wedding> weddList = db.GetAllWeddings();

                foreach (Wedding wed in weddList)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = wed.ID;
                    dr["Title"] = wed.Title;
                    dr["Client 1"] = wed.Client1.Firstname + " " + wed.Client1.Surname;
                    dr["Client 2"] = wed.Client2.Firstname + " " + wed.Client2.Surname;
                    dr["Start Date"] = wed.StartDate.ToShortDateString();
                    dr["Event Date"] = wed.EventDate.ToShortDateString();
                    dr["Wedding Planner"] = wed.WeddingPlanner.FirstName + " " + wed.WeddingPlanner.Surname;
                    dr["Status"] = wed.WeddingStatus.ToString();
                    dr["Description"] = wed.Description;

                    dt.Rows.Add(dr);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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

            string s = WeddingsDataGridView.Rows[WeddingsDataGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
            int wid = Convert.ToInt32(s);

            Wedding wed = db.FindWedding(wid);
            UpdateForm();

            if (wed != null)
            {

                if (!mainWin.UpdateWeddingWindow.Visible)
                {
                    mainWin.UpdateWeddingWindow.PopulateDataFields(wed);
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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            PopulateWeddingDGV();
        }

        private void WindowActivated(object sender, EventArgs e)
        {
            PopulateWeddingDGV();
        }

    }
}
