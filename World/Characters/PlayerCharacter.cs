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

        public PlayerCharacter()
        {
            
        }
        public PlayerCharacter(string name, string Pasword)
        { 
            Name = name;
            Password = Password;
        }
        public PlayerCharacter(string name, string password, string race, string playerClass, int healthPoints, int armorClass, int xLocation, int yLocation) :
            base(name, healthPoints, armorClass, xLocation, yLocation)
        {
            Password = password;
            Race = race;
            PlayerClass = playerClass;
        }
    }
}
