using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //Mob class
    public class Mob
    {
        //properties
        private string _mobId;
        private string _name;
        private double _healthPoints;
        private double _manaPoints;
        private string _desc;
        private double _armorClass;
        private int _roomIndex;
        


        //constructor
        public Mob(string mobId, string name, double healthPoints, double manaPoints, double armorClass, string desc, int roomIndex)
        {
            _mobId = mobId;
            _name = name;
            _healthPoints = healthPoints;
            _manaPoints = manaPoints;
            _desc = desc;
            _armorClass = armorClass;
            _roomIndex = roomIndex;
        }



        //default constructor
        public Mob()
        {
            _mobId = MobId;
            _name = Name;
            _healthPoints = HealthPoints;
            _manaPoints = ManaPoints;
            _desc = Desc;
            _armorClass = ArmorClass;
            _roomIndex = RoomIndex;
        }



        //properties
        public string MobId
        {
            get { return _mobId; }
            set { _mobId = value; }
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public double HealthPoints
        {
            get { return _healthPoints; }
            set { _healthPoints = value; }
        }



        public double ManaPoints
        {
            get { return _manaPoints; }
            set { _manaPoints = value; }
        }



        public double ArmorClass
        {
            get { return _armorClass ; }
            set { _armorClass = value; }
        }



        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }



        public int RoomIndex
        {
            get { return _roomIndex; }
            set { _roomIndex = value; }
        }
    }
}
