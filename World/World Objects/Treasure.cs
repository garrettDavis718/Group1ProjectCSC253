using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //treasure class
    public class Treasure : Item
    {
        //properties
        public double Value { get; set; }
        public Treasure()
        {
            
        }
        public Treasure(double value, int id, double weight, string name, string desc, int locationID) :
            base(id, name, weight, desc, locationID)
        {
            Value = value;
        }
        public Treasure(double value, int id, double weight, string name, string desc) :
            base(id, name, weight, desc)
        {
            Value = value;
        }




  
    }
}
