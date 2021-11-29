using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static World.WorldDelegates;

namespace World
{
    public class Door
    {
        ShowUserMessage message1 = Write;
        ShowUserMessage message2 = WriteLine;

        public int ID { get; set; }
        public int KeyID { get; set; }
        public int RoomID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Direction { get; set; }
        public string IsLocked { get; set; }

        public Door()
        {
            Name = "Default";
            IsLocked = "false";
        }
        public Door(int id, int keyID, int roomID, string name, string desc, string direction, string isLocked)
        {
            ID = id;
            KeyID = keyID;
            RoomID = roomID;
            Name = name;
            Desc = desc;
            Direction = direction;
            IsLocked = isLocked;
        }
        //method to unlock door
        //includes console.writeLine
        public static void UnlockDoor(Door door, KeyItem key, PlayerCharacter user)
        {
            if (door.KeyID.Equals(key.ID))
            {
                for (int i = 0; i < Lists.Doors.Count; i++)
                {
                    if (Lists.Doors[i].KeyID.Equals(key.ID))
                    {
                        Lists.Doors[i].IsLocked = "False";
                    }
                }
                Console.WriteLine(Arrays.Map[user.XLocation, user.YLocation].Doors[0].Name + " has been unlocked.");
            }
            else
            {
                WriteLine("This is the wrong key.");
            }
        }
        public static bool CheckIfDoorLocked(int x, int y, string direction)
        {
            bool results = false;
            Room room = Arrays.Map[x, y];
            if (!room.Doors[0].Name.Equals("Default"))
            {
                if (room.Doors[0].IsLocked.Equals("true"))
                {
                    if (room.Doors[0].Direction.Equals(direction))
                    {
                        results = true;
                    }
                }
            }
            return results;
        }
    }
}
