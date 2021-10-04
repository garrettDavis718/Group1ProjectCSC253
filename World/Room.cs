using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World
{
    //room class
    public class Room
    {
        //room properties
        private string _name;
        private string _desc;
        private string _exit;
        private string _roomId;
        private string _enemy;

        //room constructor
        public Room(string name, string desc, string exit, string roomId, string enemy)
        {
            _name = name;
            _desc = desc;
            _exit = exit;
            _roomId = roomId;
            _enemy = enemy;

        }
        //default room constructor
        public Room()
        {
            _name = Name;
            _desc = Desc;
            _exit = Exit;
            _roomId = RoomId;

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public string Exit
        {
            get { return _exit; }
            set { _exit = value; }
        }
        public string RoomId
        {
            get{ return _roomId; }
            set{ _roomId = value; }
        }
        public string Enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }

        //method to get the current room based on the roomindex paramter
        public static Room GetRoom(int roomIndex)
        {
            Info.LoadRooms();
            Room currentRoom = Lists.rooms[roomIndex];
            return currentRoom;
        }
        //method to get the current room's index based on which way the user decided to move
        public static int MoveRoom(int roomIndex, string direction)
        {
            direction = direction.ToLower();

            if ((direction == "n" || direction == "north") && roomIndex < 19)
            {
                roomIndex++;
            }
            else if ((direction == "s" || direction == "south") && roomIndex > 0)
            {
                roomIndex--;
            }
            else { };
           
            return roomIndex;
        }
        
    }
}
