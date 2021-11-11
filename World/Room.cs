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
        private string _description;
        private string _exit;
        public List<Character> Characters { get; set; }
        public List<Item> Inventory { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }

        //Current Way to populate our current room with characters
        public static void getCharacters()
        {
            Mob.GetCurrentEnemies();
            List<Character> character = new List<Character>();
            Room currentRoom = Arrays.Map[Lists.currentPlayer[0].XLocation, Lists.currentPlayer[0].YLocation];
            currentRoom = new Room(currentRoom.Name, currentRoom.Description, currentRoom.Exit, currentRoom.XLocation,
                currentRoom.YLocation, character);
            currentRoom.Characters.Add(Lists.currentPlayer[0]);
            foreach (Mob npc in Lists.CurrentEnemies)
            {
                currentRoom.Characters.Add(npc);
            }
            Console.WriteLine(currentRoom.Characters[1].Name);
        }

        //room constructor
        public Room(string name, string description, string exit, int xLocation, int yLocation, string enemy)
        {
            _name = name;
            _description = description;
            _exit = exit;
            XLocation = xLocation;
            YLocation = yLocation;

        }
        public Room(string name, string description, string exit, int xLocation, int yLocation, List<Character> characters)
        {
            _name = name;
            _description = description;
            _exit = exit;
            XLocation = xLocation;

            YLocation = yLocation;
            Characters = characters;
        }
        public Room(string name, string description, string exit, int xLocation, int yLocation, List<Character> characters, List<Item> inventory)
        {
            _name = name;
            _description = description;
            _exit = exit;
            XLocation = xLocation;
            Inventory = inventory;
            YLocation = yLocation;
            Characters = characters;
        }

        public Room(string name)
        {
            _name = name;
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



        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }



        public string Exit
        {
            get { return _exit; }
            set { _exit = value; }
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
