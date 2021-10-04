using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class Weapon
    {
        private string _name;
        private int _price;
        private string _damageType;
        private int _damage;
        private string _desc;

        public Weapon(string name, int price, string damageType, int damage, string desc)
        {
            Name = name;
            Price = price;
            DamageType = damageType;
            Damage = damage;
            Desc = desc;
        }
        public Weapon()
        {
            Name = "";
            Price = 0;
            DamageType = "";
            Damage = 0;
            Desc = ""; 
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string DamageType
        {
            get { return _damageType; }
            set { _damageType = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; } 
        }

    }
}
