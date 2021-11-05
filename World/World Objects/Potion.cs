using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //potion class
    public class Potion : Item
    {
        //properties of potions
        public int HealthPoints { get; set; }
        public Potion()
        {

        }
        public Potion(int healthPoints, int id, double weight, string name, string desc) :
            base(id, name, weight, desc)
        {
            HealthPoints = healthPoints;
        }
    }
}
