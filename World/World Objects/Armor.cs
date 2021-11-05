using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.World_Objects
{
    //Armor Item
    public class Armor : Item
    {
        public int ArmorClass { get; set; }
        public Armor()
        {
            
        }
        public Armor(int armorClass, int id, string name, string desc) :
            base(id, name, desc)
        {
            ArmorClass = armorClass;   
        }
    }
}
