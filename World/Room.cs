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
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        private string _enemy;



        //room constructor
        public Room(string name, string desc, string exit, int xLocation, int yLocation, string enemy)
        {
            _name = name;
            _desc = desc;
            _exit = exit;
            XLocation = xLocation;
            YLocation = yLocation;
            _enemy = enemy;

        }



        //default room constructor
        public Room()
        {
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





        public string Enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }



        //method to get the current room based on the roomindex paramter
        public static Room GetRoom(int roomIndex)
        {
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
