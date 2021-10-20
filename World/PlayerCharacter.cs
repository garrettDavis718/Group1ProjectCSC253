using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //Playercharacter class
    public class PlayerCharacter
    {
        //properties of PC
        private string _name;
        private double _healthPoints;
        private double _armorClass;
        private string _password;
        private string _race;
        private string _characterClass;
        public int Location { get; set; }
        private Weapon _weapon;

        public PlayerCharacter(string name, string password, string race, string characterClass)
        {
            Name = name;
            Password = password;
            Race = race;
            CharacterClass = characterClass;
        }
        public PlayerCharacter(string name, string password, double healthPoints, double armorClass, string race, string characterClass, int location)
        {
            Name = name;
            HealthPoints = healthPoints;
            ArmorClass = armorClass;
            Password = password;
            Race = race;
            CharacterClass = characterClass;
            Location = location;
        }
        public PlayerCharacter(string name, string password)
        {
            _name = name;
            _password = password;
        }
        public PlayerCharacter()
        {
            Name = "";
            Password = "";
        }
        //Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public double HealthPoints
        {
            get { return _healthPoints; }
            set { _healthPoints = value; }
        }
        public double ArmorClass
        {
            get { return _armorClass; }
            set { _armorClass = value; }
        }
        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }
        public string CharacterClass
        {
            get { return _characterClass; }
            set { _characterClass = value; }
        }
       
        public Weapon Weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }
        
        

    }
}
