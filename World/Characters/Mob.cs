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
        public int ID { get; set; }
        public Mob()
        {
            
        }
        public Mob( string name, int healthPoints, int armorClass, int xLocation, int yLocation, Weapon weapon) :
            base(name, healthPoints, armorClass, xLocation, yLocation, weapon)
        {
        }
        public Mob(int id, string name, int healthPoints, int armorClass, int xLocation, int yLocation, Weapon weapon) :
            base(name, healthPoints, armorClass, xLocation, yLocation, weapon)
        {
            ID = id;
        }
        public Mob(int id, string name, int healthPoints, int armorClass, int xLocation, int yLocation) :
            base(name, healthPoints, armorClass, xLocation, yLocation)
        {
            ID = id;
        }
        public static void GetCurrentEnemies()
        {
            Lists.CurrentEnemies.Clear();
            foreach (Mob npc in Lists.Mobs)
            {
                if (npc.XLocation == Lists.currentPlayer[0].XLocation && npc.YLocation == Lists.currentPlayer[0].YLocation
                    && npc.HealthPoints > 0)
                {
                    Lists.CurrentEnemies.Add(npc);
                }
            }
        }
    }
}
