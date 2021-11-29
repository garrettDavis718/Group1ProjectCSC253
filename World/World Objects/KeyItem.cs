using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class KeyItem : Item
    {
        public KeyItem()
        {
            Name = "Default";
        }
        public KeyItem(int id, double weight, string name, string desc, int locationID) :
            base(id, name, weight, desc, locationID)
        {
            ID = id;
            Name = name;
            Desc = desc;
            Weight = weight;
        }
        public KeyItem(int id, double weight, string name, string desc) : 
            base(id, name, weight, desc)
        {
            ID = id;
            Name = name;
            Desc = desc;
            Weight = weight;
        }
        public static KeyItem GetKeyItem(string keyName)
        {
            KeyItem output = new KeyItem();
            foreach (KeyItem key in Lists.KeyItems)
            {
                if (key.Name.ToLower().Equals(keyName.ToLower()))
                {
                    output = key;
                }
            }
            return output;
        }
    }
}
