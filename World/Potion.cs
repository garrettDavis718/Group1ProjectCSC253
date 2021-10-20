using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //potion class
    public class Potion
    {
        //properties of potions
        private string _name;
        private string _desc;
        private string _potionId;
        public int PotionPoints { get; set; }


        //Potion constructor
        public Potion(string potionId, string name, string desc, int potionPoints)
        {
            _potionId = potionId;
            _name = name;
            _desc = desc;
            PotionPoints = potionPoints;
        }
        //potion properties
        public string PotionId
        {
            get { return _potionId; }
            set { _potionId = value; }
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
