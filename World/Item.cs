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
        private double _weight;
        private string _name;
        private string _desc;



        //Item Custom constructor
        public Item(int id, double weight, string name, string desc)
        {
            ID = id;
            _weight = weight;
            _name = name;
            _desc = desc;

        }



        //Parameters
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }


       
    }
}
