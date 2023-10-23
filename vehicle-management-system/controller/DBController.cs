using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vehicale_management_system.controller
{
    internal class DBController
    {
        private static DBController dbConnection;
        private SqlConnection sqlConnection;

        public DBController()
        {
            try {
                //set sql connection
                sqlConnection = new SqlConnection("Data Source=SMS-DAHANAYAKA\\SQLEXPRESS;Initial Catalog=vehicle;Integrated Security=True;Pooling=False");
                Console.WriteLine("connection successfull");
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message,"Error");
            }

            
        }
        public SqlConnection getConnection() {
            
            //return cvonnection(sql)
            return sqlConnection;
        }

        public static DBController getInstance() {
            if (dbConnection==null) { 
                
                //set object for dbController
                dbConnection = new DBController();
            }

            //return single DBController object
            return dbConnection;
        }
    }
}
