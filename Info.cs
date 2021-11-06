using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;


namespace TheLastSurvivors
{
    public static class Info
    {
        //Class for when the user wants information, hasn't been implemented yet, could be merged into menu class potentially
        public static void CreateNewCharacter(PlayerCharacter newUser)
        {
            StreamWriter outputFile;

            try
            {
                outputFile = File.AppendText("players.csv");
                outputFile.WriteLine($"{newUser.Name},{newUser.Password},{newUser.Race},{newUser.PlayerClass}, {newUser.HealthPoints}, " +
                    $"{newUser.ArmorClass}, {newUser.XLocation}, {newUser.YLocation}");
                outputFile.Close();
                Console.WriteLine("New player created! Welcome to the game!");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Console.WriteLine(message);
            }
        }




       



        //Ask for player information and test if it exists
        public static PlayerCharacter RequestPlayerCreds()
        {
            bool tryAgain;
            Console.WriteLine("Please enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string pass = Console.ReadLine();
            do
            { 
                if (Validation.TestForUser(name, pass) == true)
                {
                    tryAgain = false;
                }
                else
                {
                    Console.WriteLine("Please enter your Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Please enter your password: ");
                    pass = Console.ReadLine();
                    tryAgain = true;
                }
            }
            while (tryAgain == true);
            DatabaseControls.LoadPlayer(name, pass);
            PlayerCharacter user = Lists.currentPlayer[0];
            return user;
        }



        //Request player race and check if race exists
        



       


       
        




 
       
        public static void GetEnemy(string name)
        {

            foreach (Mob npc in Lists.Mobs)
            {
                if (name.ToLower().Equals(npc.Name.ToLower()))
                {
                    Lists.CurrentEnemies.Clear();
                    Lists.CurrentEnemies.Add(npc);
                }

            }
        }



        //use this method to determine the current weapon for the player
        public static void GetWeapon(string characterClass)
        {
            DatabaseControls.LoadWeapons();

            if (characterClass == "Gunslinger")
            {
                Lists.CurrentWeapon[0] = Lists.Weapons[0];
            }
            else if (characterClass == "Road Warrior")
            {
                Lists.CurrentWeapon[0] = Lists.Weapons[1];
            }
            else if (characterClass == "mechanic")
            {
                Lists.CurrentWeapon[0] = Lists.Weapons[2];
            }
            else if (characterClass == "admin")
            {
                Lists.CurrentWeapon[0] = Lists.Weapons[3];
            }

        }






    }
}
