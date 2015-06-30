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
        public ManageClientsWindow()
        {
            InitializeComponent();
        }

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            UI.NewClientWindow win = new UI.NewClientWindow();
            win.Visible = true;
        }

        private void UpdateClientButton_Click(object sender, EventArgs e)
        {
            UI.UpdateClientWindow win = new UI.UpdateClientWindow();
            win.Visible = true;
        }
    }
}
