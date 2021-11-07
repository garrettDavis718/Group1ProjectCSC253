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
        public static Weapon GetWeapon(PlayerCharacter user)
        {
            string playerClass = user.PlayerClass.ToLower();
            Weapon output = new Weapon();
            switch (playerClass)
            {
                case "berzerker":
                    output = Lists.Weapons[1];
                    break;
                case "gunslinger":
                    output = Lists.Weapons[0];
                    break;
                case "scrapper":
                    output = Lists.Weapons[5];
                    break;
                case "engineer":
                    output = Lists.Weapons[2];
                    break;
                default:
                    output = Lists.Weapons[7];
                    break;
            }
            return output;
        }
        public static Weapon GetWeapon(Mob npc)
        {
            Weapon output = new Weapon();
            switch (npc.Name)
            {
                case "Mutant":
                    output = Lists.Weapons[1];  
                    break;
                case "Skeleton":
                    output = Lists.Weapons[0];
                    break;
                case "War Machine":
                    output = Lists.Weapons[6];
                    break;
                case "Zombie Scientist":
                    output = Lists.Weapons[4];
                    break;
                case "Astronaut Zombie":
                    output = Lists.Weapons[7];
                    break;
                default:
                    output = Lists.Weapons[0];
                    break;
            }
            return output;
        }
    }
}
