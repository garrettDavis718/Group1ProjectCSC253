using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //This Class will build our map and populat our map array with the rooms from out db.
    public class Map
    {
        public static void BuildMap(List<Room> rooms)
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Room defaultRoom = new Room("Default");
                    Arrays.Map[x, y]= defaultRoom;
                }
            }
            foreach (Room var in rooms)
            {
                Arrays.Map[var.XLocation, var.YLocation] = var;
            }
        }
        //method for moving characters(pc/npc) to a desired location w/ validation
        //BUG if location is < 0 break
        public static string MoveCharacter(Character character, string direction)
        {
            string output = " ";
            direction.ToLower();
            switch (direction)
            {
                case "north":
                case "n":
                    //if location to north is named "Default" we will not actually move, if location is At top of Map we will not move
                    if (character.YLocation == 20 || Arrays.Map[character.XLocation, character.YLocation + 1].Name.Equals("Default"))
                    {
                        output = "Cannot currently travel North";
                        break;
                    }
                    //Character will be pushed up 1 in the 2d Map array
                    else
                    {
                        character.YLocation += 1;
                        output = "You've moved North to " + Arrays.Map[character.XLocation, character.YLocation].Name;
                        Mob.GetCurrentEnemies();
                        break;
                    }
                case "south":
                case "s":
                    if (character.YLocation == 0 || Arrays.Map[character.XLocation, character.YLocation - 1].Name.Equals("Default"))
                    {
                        output = "Cannot currently travel South";
                        break;
                    }
                    else
                    {
                        character.YLocation -= 1;
                        output = "You've moved South to " + Arrays.Map[character.XLocation, character.YLocation].Name;
                        Mob.GetCurrentEnemies();
                        break;
                    }
                case "west":
                case "w":
                    if (character.XLocation == 20 || Arrays.Map[character.XLocation + 1, character.YLocation].Name.Equals("Default"))
                    {
                        output = "Cannot currently travel West";
                        break;
                    }
                    else
                    {
                        character.XLocation += 1;
                        output = "You've moved West to " + Arrays.Map[character.XLocation, character.YLocation].Name;
                        Mob.GetCurrentEnemies();
                        break;
                    }
                case "east":
                case "e":
                    if (character.XLocation == 0 || Arrays.Map[character.XLocation - 1, character.YLocation].Name.Equals("Default"))
                    {
                        output = "Cannot currently travel East";
                        break;
                    }
                    else
                    {
                        character.XLocation -= 1;
                        output = "You've moved East to " + Arrays.Map[character.XLocation, character.YLocation].Name;
                        Mob.GetCurrentEnemies();
                        break;
                    }
            }
            return output;
        }
    }
}
