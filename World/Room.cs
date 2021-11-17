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
        public List<Character> Characters { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Door> Doors { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }

        //Current Way to populate our current room with characters
        public static void getCharacters()
        {
            Mob.GetCurrentEnemies();
            List<Character> character = new List<Character>();
            Room currentRoom = Arrays.Map[Lists.currentPlayer[0].XLocation, Lists.currentPlayer[0].YLocation];
            currentRoom = new Room(currentRoom.Name, currentRoom.Description, currentRoom.XLocation,
                currentRoom.YLocation, character);
            currentRoom.Characters.Add(Lists.currentPlayer[0]);
            foreach (Mob npc in Lists.CurrentEnemies)
            {
                currentRoom.Characters.Add(npc);
            }
            Console.WriteLine(currentRoom.Characters[1].Name);
        }

        //room constructor
        public Room(string name, string description, int xLocation, int yLocation, string enemy)
        {
            _name = name;
            _description = description;
            XLocation = xLocation;
            YLocation = yLocation;

        }
        public Room(string name, string description, int xLocation, int yLocation, List<Character> characters)
        {
            _name = name;
            _description = description;
            XLocation = xLocation;

            YLocation = yLocation;
            Characters = characters;
        }
        public Room(string name, string description, int xLocation, int yLocation, List<Character> characters, List<Item> inventory)
        {
            _name = name;
            _description = description;
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

        //method to get the current room based on the roomindex paramter
        public static Room GetRoom(int roomIndex)
        {
            Room currentRoom = Lists.rooms[roomIndex];
            return currentRoom;
        }


    }
}
