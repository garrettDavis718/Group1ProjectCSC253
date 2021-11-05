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
*/
namespace TheLastSurvivors
{
    public class Program
    {
        //Load Objects from Database
        //Fix weapons/attack functions for db update
        public static void Main(string[] args)
        {
            //Run my first menu for entering the game and gettin the player's information
            //Menu.EntryMenu();
            //Call our main menu method for the primary decision structure of my program
            //Menu.MainMenu(); 
            PlayerCharacter user = new PlayerCharacter("Garrett", "Password1", "Elf", "Gunslinger", 50, 15, 0, 0);
            DatabaseControls.SaveGame(user);
            Console.WriteLine("Saved");
            Console.ReadLine();
        }
    }
}

