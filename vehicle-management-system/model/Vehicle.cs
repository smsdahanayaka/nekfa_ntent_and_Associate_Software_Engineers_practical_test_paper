using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicale_management_system.model
{
    
    internal class Vehicle
    {
       
        private String regNo;
        private String modelName;
        private int numberOfSeats;

        
        public Vehicle() { 
        
        }
        public Vehicle(String regNo,String modelName, int numberOfSeats)
        {
            this.regNo = regNo;
            this.modelName = modelName;
            this.numberOfSeats = numberOfSeats;
            

        }

        public void setRegNo(String regNo)
        {
            this.regNo = regNo;
        }

        public void setnumberOfSeats(int numberOfSeats)
        {
            this.numberOfSeats = numberOfSeats;
        }

        public void setModelName(String modelName)
        {
            this.modelName = modelName;
        }

        public String getRegNo()
        {
            return regNo;
        }
        public String getModelName()
        {
            return modelName;
        }

        public int getNumberOfSeats() 
        {
            return numberOfSeats;
        }

        
       


    }
}
