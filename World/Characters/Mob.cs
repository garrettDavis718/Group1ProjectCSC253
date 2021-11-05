using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //Mob class
    public class Mob : Character
    {
        
        public Mob(string name, int healthPoints, int armorClass, int xLocation, int yLocation) :
            base(name, healthPoints, armorClass, xLocation, yLocation)
        {
        }
    }
}
