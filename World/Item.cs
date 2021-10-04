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
        private double _price;
        private string _name;
        private string _desc;
        private bool _questItem;


        //Item Custom constructor
        public Item(double price, string name, string desc, bool questItem)
        {
            _price = price;
            _name = name;
            _desc = desc;
            _questItem = questItem;
        }
        //Parameters
        public double Price
        {
            get { return _price; }
            set { _price = value; }
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
        public bool QuestItem
        {
            get { return _questItem; }
            set { _questItem = value; }
        }
        
        


    }
}
