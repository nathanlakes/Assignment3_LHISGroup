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
    public partial class ManageClientsWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public ManageClientsWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            mainWin.NewClientWindow.Visible = true;
        }

        private void UpdateClientButton_Click(object sender, EventArgs e)
        {
            mainWin.UpdateClientWindow.Visible = true;
        }
    }
}
