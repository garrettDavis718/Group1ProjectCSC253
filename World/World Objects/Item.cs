using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //Item Class used for creating item objects and storing them in our item list, will be used in future iterations
    public class Item
    {
        //constructors
        public int ID { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }


        //Item Custom constructor
        public Item()
        {
            
        }
        public Item(int id, string name, string desc)
        {
            ID = id;
            Name = name;
            Desc = desc;
        }
        public Item(int id, string name, double weight, string desc)
        {
            ID = id;
            Weight = weight;
            Name = name;
            Desc = desc;
        }






    }
}
