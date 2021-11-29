using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public static class Lists
    {
        public static List<PlayerCharacter> currentPlayer = new List<PlayerCharacter>();
        public static List<Room> currentRoom = new List<Room>();
        public static List<Room> rooms = new List<Room>();
        public static List<Mob> Mobs = new List<Mob>();
        public static List<Treasure> Treasures = new List<Treasure>();
        public static List<Potion> Potions = new List<Potion>();
        public static List<Item> Items = new List<Item>();
        public static List<Character> CurrentEnemies = new List<Character>();
        public static List<Weapon> Weapons = new List<Weapon>();
        public static List<Weapon> CurrentWeapon = new List<Weapon>();
        public static List<Door> Doors = new List<Door>();
        public static List<KeyItem> KeyItems = new List<KeyItem>();
    }
}
