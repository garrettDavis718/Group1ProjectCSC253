using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class Door
    {
        public int ID { get; set; }
        public int KeyID { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Direction { get; set; }
        public string IsLocked { get; set; }

        public Door()
        { }
        public Door(int id, int keyID, int xLocation, int yLocation, string name, string desc, string direction, string isLocked)
        {
            ID = id;
            KeyID = keyID;
            XLocation = xLocation;
            YLocation = yLocation;
            Name = name;
            Desc = desc;
            Direction = direction;
            IsLocked = isLocked;
        }
        //method to unlock door
        //includes console.writeLine
        public static void UnlockDoor(Door door, KeyItem key)
        {
            if (door.KeyID.Equals(key.ID))
            {
                door.IsLocked = "false";
            }
            else
            {
                Console.WriteLine("This is the wrong key.");
            }
        }
    }
}
