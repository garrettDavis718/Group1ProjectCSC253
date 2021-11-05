using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class Weapon : Item
    {
        
        public string DmgType { get; set; }
        public int Damage { get; set; }
        public Weapon()
        {

        }
        public Weapon(string dmgType, int damage, int id, double weight, string name, string desc) :
            base(id, name, weight, desc)
        {
            DmgType = dmgType;
            Damage = damage;
        }
    }
}
