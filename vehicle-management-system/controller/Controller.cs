using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vehicale_management_system.model;

namespace vehicale_management_system.controller
{
    internal class Controller
    {
        private static SqlConnection sqlConnection;
        private static List<Vehicle> vehicle;
        //add vehicle
        public static bool addVehicle(Vehicle vehicle,Colors colors ) {

            try {
                if (vehicle != null)
                {
                    //connect with database
                    sqlConnection = DBController.getInstance().getConnection();
                    sqlConnection.Open();

                    //add vehicle data to database
                    SqlCommand cmdVehicle = new SqlCommand("INSERT INTO Vehicles VALUES(@RegNo,@ModelName,@NumberOfSeats)",sqlConnection);
                    cmdVehicle.Parameters.AddWithValue("@RegNo", vehicle.getRegNo());
                    cmdVehicle.Parameters.AddWithValue("@ModelName", vehicle.getModelName());
                    cmdVehicle.Parameters.AddWithValue("@NumberOfSeats", vehicle.getNumberOfSeats());
                    int x = cmdVehicle.ExecuteNonQuery();
                    int y = 0;

                        // Add colours to colors table
                        if (x > 0)
                        {
                            foreach (String item in colors.getColors())
                            {
                                SqlCommand cmdColor = new SqlCommand("INSERT INTO Colors VALUES(@RegNo,@ColorName)", sqlConnection);
                                cmdColor.Parameters.AddWithValue("@RegNo", colors.getRegNo());
                                cmdColor.Parameters.AddWithValue("@ColorName", item);
                                y = cmdColor.ExecuteNonQuery();
                            }
                        }


                    return y > 0;
                }
                else
                {
                    return false;
                }

            }
            catch ( Exception e )
            {
                MessageBox.Show(e.Message,"Add Vehicle");
            }finally { 
                sqlConnection.Close();
            }
            return false;

        
        }


        //check registation number
        public static bool checkRegNo(String regNo) {
            try 
            {   
                //connect with databse
                sqlConnection = DBController.getInstance().getConnection();
                sqlConnection.Open();

                //select from databse
                SqlCommand cmd = new SqlCommand("SELECT *FROM Vehicles WHERE RegNo=@RegNo", sqlConnection);
                cmd.Parameters.AddWithValue("@RegNo",regNo);
                if (cmd.ExecuteReader().Read()) { 
                    return true;
                }

                return false;           }
            catch ( Exception e )
            {
                MessageBox.Show(e.Message, "Check Reg No");

            }
            finally 
            { 
                sqlConnection.Close(); 
            }
            return false;
        
        }


        // retrieve all vehicles Data(load data)
        public static List<Vehicle> viewVehicles()
        {
            try { 
                sqlConnection= DBController.getInstance().getConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT RegNo, ModelName, NumberOfSeats FROM Vehicles ORDER BY ModelName ASC", sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                //create list for store vehicle objects
                vehicle = new List<Vehicle>();

                while (reader.Read()) { 
                    //create new vehicle object
                    //add object to list
                    vehicle.Add(new Vehicle(reader["RegNo"].ToString(), reader["ModelName"].ToString(), int.Parse(reader["NumberOfSeats"].ToString())));
                }

                return vehicle;
            }catch ( Exception e )
            {
                MessageBox.Show(e.Message,"Load Vehicles");
            }finally { sqlConnection.Close(); }
            return null;
        }
    }
}
