using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vehicale_management_system.view
{
    public partial class HomePageForm : Form
    {
        public HomePageForm()
        {
            InitializeComponent();
        }


        //navigate to Add vehicle page
        private void button1_Click(object sender, EventArgs e)
        {
            new AddNewVehicleForm().Show();
            this.Hide();
        }

        //Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // navigate to view page
        private void button3_Click(object sender, EventArgs e)
        {
            new ViewVehicleForm().Show();
            this.Hide();
        }
    }
}
