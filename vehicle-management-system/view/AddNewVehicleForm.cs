using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vehicale_management_system.model;
using vehicale_management_system.controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vehicale_management_system.view
{
    public partial class AddNewVehicleForm : Form
    {
        private Controller controller;
        private List<String> colorList;
        private String regNo;
        private String modelNumber;
        private int numberOfSeats;
        
        public AddNewVehicleForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblOne_Click(object sender, EventArgs e)
        {

        }

        private void lblTwo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        


        //add vehicle
        private void btnAdd_Click(object sender, EventArgs e)
        {

          
            try {

                // check all feilds are filled
                if (checkfeilds())
                {
                    //validate seats amount
                    numberOfSeats = int.Parse(txtNumberOfSeats.Text);
                    if (numberOfSeats < 1000 && numberOfSeats > 0)
                    {
                        //check register number
                        if (isValidRegNo(txtRegNum.Text))
                        {

                            //check is color input
                            if (checkColor()) {

                                //set colors list with conditions
                                addColors();

                                controller = new Controller();
                                //pass objects to controoler
                                bool bl = Controller.addVehicle(new Vehicle(txtRegNum.Text, txtModel.Text, int.Parse(txtNumberOfSeats.Text)), new Colors(txtRegNum.Text, colorList));

                                if (bl)
                                {
                                    MessageBox.Show("Vehicle successfully added", "Add vehicle");
                                    clearMeth();
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle not added", "Add Vehicle");

                                }

                            }
                            else {
                                MessageBox.Show("Please Input vehicle color");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Allready This Vehicle Registerd");
                        }

                    }
                    else {
                        MessageBox.Show("Input valid seats amount");
                    }
                   
                    

                }
                else {
                    MessageBox.Show("All feilds are required");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Add Vehicle");
            }
        }


        //check all feilds are filled ort not
        private bool checkfeilds() {

            if (txtRegNum.Text == "" || txtModel.Text == "" || txtNumberOfSeats.Text == "")
            {   

                return false;               
            }
            else {
                return true;
            }
        }



        // check registation nuber
        private bool isValidRegNo(String regNo)
        {

            bool bl = Controller.checkRegNo(regNo);
            if (bl)
            {
                return false;
            }
            return true;
            
        }


        //add colors 
        public void addColors() {

            colorList = new List<string>();

            //check color combo boxes
            if (comBoxColor1.Text != "")
            {
                colorList.Add(comBoxColor1.Text);
            }

            if (comBoxColor2.Text != "" && comBoxColor2.Text!= comBoxColor1.Text)
            {
                colorList.Add(comBoxColor2.Text);
            }

            if (comBoxColor3.Text != "" && comBoxColor3.Text!= comBoxColor2.Text && comBoxColor3.Text!= comBoxColor1.Text)
            {
                colorList.Add(comBoxColor3.Text);
            }

        }

        //check collor combo box
        public bool checkColor() {

            if (comBoxColor1.Text == "" && comBoxColor2.Text == "" && comBoxColor3.Text == "")
            {
                return false;
            }
            else
            {
                return true;

            }

        }

        //clear all feilds
        private void button2_Click(object sender, EventArgs e)
        {
            clearMeth();

        }

        public void clearMeth()
        {
            txtRegNum.Clear();
            txtModel.Clear();
            txtNumberOfSeats.Clear();
            comBoxColor1.Items.Clear();
            comBoxColor2.Items.Clear();
            comBoxColor3.Items.Clear();
        }

        // back function
        private void btnBack_Click(object sender, EventArgs e)
        {
            new HomePageForm().Show();
            this.Hide();
        }
    }
}
