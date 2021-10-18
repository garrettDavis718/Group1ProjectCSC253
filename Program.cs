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
* This program is the second sprint of my text adventure game "The Last Surivors" 
* Program successfully updated to github
*/
namespace TheLastSurvivors
{
    public class Program
    {   
        
        //Load Objects from Database
        //Change logic to incorporate db
        //Check if download works from github
        public static void Main(string[] args)
        {
            //Run my first menu for entering the game and gettin the player's information
            //Menu.EntryMenu();
            //Call our main menu method for the primary decision structure of my program
            //Menu.MainMenu();
            DatabaseControls.LoadPotions();
            Console.Read();
            

        }
  

    }
}

