using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //Playercharacter class.
    public class PlayerCharacter : Character
    {
        //properties of PC
        public string Password { get; set; }
        public string Race { get; set; }
        public string PlayerClass { get; set; }

        public static string GetItem(PlayerCharacter user, Item item)
        {
            string output;
            double invWeight = 0;
            foreach (Item _item in user.Inventory)
            {
                invWeight += _item.Weight;
            }
            if (invWeight + item.Weight > 20)
            {
                output = "Cannot pickup " + item.Weight;
            }
            else
            {
                output = user.Name + " picks up " + item.Name;
                user.Inventory.Add(item);
            }
            return output;  
        }
        public PlayerCharacter()
        {

        }
        public PlayerCharacter(string name)
        {
            Name = name;
        }
        public PlayerCharacter(string name, string password, string race, string playerClass, int healthPoints, int armorClass, int xLocation, int yLocation) :
            base(name, healthPoints, armorClass, xLocation, yLocation)
        {
            Password = password;
            Race = race;
            PlayerClass = playerClass;
        }
        public PlayerCharacter(string name, string password, string race, string playerClass, int healthPoints, int armorClass, 
             int xLocation, int yLocation, Weapon weapon, List<Item> inventory) :
            base(name, healthPoints, armorClass, xLocation, yLocation, weapon, inventory)
        {
            Password = password;
            Race = race;
            PlayerClass = playerClass;
        }

        public PlayerCharacter(string name, string password, string race, string playerClass, int healthPoints, int armorClass, int xLocation, int yLocation, Weapon weapon) :
            base(name, healthPoints, armorClass, xLocation, yLocation, weapon)
        {
            Password = password;
            Race = race;
            PlayerClass = playerClass;
        }
    }
}
