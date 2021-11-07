using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class Combat
    {
        public static Random rand = new Random();
        public static int attack(Character attacker, Character defender)
        {
            int toHit = rand.Next(0, 21);
            if (toHit > defender.ArmorClass)
            {
                int damage = attacker.Weapon.Damage;
                defender.HealthPoints -= damage;
                Console.WriteLine(attacker.Name + " attacks " + defender.Name + " with their " + attacker.Weapon.Name + " for " + attacker.Weapon.Damage + " " + attacker.Weapon.DmgType
                    + " Damage.");
                if (defender.HealthPoints < 0)
                {
                    Console.WriteLine(attacker.Name + " has killed " + defender.Name);
                }
                return defender.HealthPoints;
            }
            else
            {
                Console.WriteLine(attacker.Name + " misses");
                return defender.HealthPoints;
            }
        }
    }
}
