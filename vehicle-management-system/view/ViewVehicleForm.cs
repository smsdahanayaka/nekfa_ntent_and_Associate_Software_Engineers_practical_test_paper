using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vehicale_management_system.controller;
using vehicale_management_system.model;

namespace vehicale_management_system.view
{
    public partial class ViewVehicleForm : Form
    {
        private List<Vehicle> vehicle;
        public ViewVehicleForm()
        {
            InitializeComponent();

            //load all registations to view(View details)
            viewVehicles();
        }

        private void lblTwo_Click(object sender, EventArgs e)
        {

        }

        //back function
        private void btnBack_Click(object sender, EventArgs e)
        {
            new HomePageForm().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // retrieve all vehicles 
        public void viewVehicles()
        {
           
           vehicle= Controller.viewVehicles();
            if (vehicle!=null) {

                foreach (Vehicle vehicleNew in vehicle) 
                {
                   // add data to rows in datagrid
                    dataGridView1.Rows.Add(vehicleNew.getRegNo(),vehicleNew.getModelName(),vehicleNew.getNumberOfSeats());
                }

            }
        }
    }
}
