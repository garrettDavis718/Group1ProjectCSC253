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
        private double _weight;
        private string _name;
        private string _desc;
        private string _isQuestItem;



        //Item Custom constructor
        public Item(double weight, string name, string desc, string isQuestItem)
        {
            _weight = weight;
            _name = name;
            _desc = desc;
            _isQuestItem = isQuestItem;
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



        public string IsQuestItem
        {
            get { return _isQuestItem; }
            set { _isQuestItem = value; }
        }          
    }
}
