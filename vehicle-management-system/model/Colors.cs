using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicale_management_system.model
{
    internal class Colors
    {
        private List<String> colors;
        private String regNo;
        public Colors() { }

        public Colors(String regNo, List<String> colors) 
        {
            this.colors = colors;
            this.regNo = regNo;
            
        }

        public void setRegNo(String regNo)
        {
            this.regNo = regNo;
        }
        public void setColors(List<String> colors)
        {
            this.colors = colors;
        }
        public String getRegNo()
        {
            return regNo;
        }
        public List<String> getColors()
        {
            return colors;
        }

       

    }
}
