using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using World;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
/**
* 09/26/21
* CSC 253
* Garrett Davis & Zach Fegan & Mateo Friend
* This program is the third sprint, This incorporates database controls into the program, currently breaks when attacking, needs to have combat and info classes fixed
* Program successfully updated to github
* TODO Use item option, open containers, inventory functionality
*/
namespace TheLastSurvivors
{
    public class Program
    {

        public static void Main(string[] args)
        {
            DatabaseControls.LoadKeyItems();
            DatabaseControls.LoadDoors();
            DatabaseControls.LoadRooms();
            DatabaseControls.LoadPotions();
            DatabaseControls.LoadWeapons();
            DatabaseControls.LoadMobs();
            DatabaseControls.LoadItems();
            DatabaseControls.LoadTreasures();
            Map.BuildMap(Lists.rooms);
            //Run my first menu for entering the game and gettin the player's information
            Console.ReadLine();
            Menu.GreetUser();
            Room.getCharacters();
            Menu.GameMenu();
            //Call our main menu method for the primary decision structure of my program


        }
    }
}

