using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //treasure class
    public class Treasure
    {
        //properties
        private string _treasureId;
        private string _name;
        private double _value;
        private string _desc;
        private string _isQuestItem;
        //Constructor
        public Treasure(string treasureId, string name, double value, string desc, string isQuestItem)
        {
            _treasureId = treasureId;
            _name = name;
            _value = value;
            _desc = desc;
            _isQuestItem = isQuestItem;
        }
        //properties
        public string TreasureId
        {
            get { return _treasureId; }
            set { _treasureId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Value
        {
            get { return _value; }
            set { _value = value; }
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
