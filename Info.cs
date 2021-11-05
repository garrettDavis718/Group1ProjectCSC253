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
        public static string GetPlayerRace()
        {
            bool tryAgain;
            Console.WriteLine("What is your character's race? (Human, Robot, Elf)");
            string characterRace = Console.ReadLine();
            do
            {

                if (Validation.TestRace(characterRace) == true)
                {
                    tryAgain = false;


                }
                else
                {
                    Console.WriteLine("Please enter your character's race");
                    characterRace = Console.ReadLine();
                    tryAgain = true;

                }
            }
            while (tryAgain == true);
            return characterRace;
        }



        //Request player class and check if it exists
        public static string GetPlayerClass()
        {
            bool tryAgain;
            Console.WriteLine("What is your character's class? (Road Warrior, Gunslinger, Mechanic)");
            string playerClass = Console.ReadLine();
            do
            {
                if (Validation.TestClass(playerClass) == true)
                {
                    tryAgain = false;
                }
                else
                {
                    Console.WriteLine("Please enter your character's class.");
                    playerClass = Console.ReadLine();
                    tryAgain = true;
                }
            }
            while (tryAgain == true);
            return playerClass;
        }



        public static PlayerCharacter GetPlayer()
        {
            //Start by asking for name
            Console.WriteLine("What is your name? ");
            //initialize variable and assign
            string userName = Console.ReadLine();
            //initialize password
            string password;
            //set our variable for our while loop
            int keepGoing;
            //do while to run it at least once
            do
            {
                //Prompt user for password
                Console.WriteLine("What is your password? ");
                //assign password
                password = Console.ReadLine();
                //Run our uppercase tester method on our password string, this will give us a true or false dending on the user's password input
                bool upperTest = Validation.TestUpper(password);
                //Run lowercase tester method, same way
                bool lowerTest = Validation.TestLower(password);
                //Run Special character test to see if the password string contains as special character
                bool specialTest = Validation.TestSpecial(password);
                //Call final testing method that will let the user know if they're password has some sort of issue, this will tell the user what is wrong with their
                //particular entry
                bool passwordTest = Validation.TestPassword(upperTest, lowerTest, specialTest);
                //This is just a short if statement to make our tests run again if they are failed the first time
                if (passwordTest == true)
                {
                    keepGoing = 1;
                }
                //assign 0 to our keepGoing variable to end the do while loop
                else keepGoing = 0;
            } while (keepGoing == 0);
            //Prompt for user's character's race(not currently validated, need to set races)
            string characterRace = GetPlayerRace();
            //Prompt for user's character's class(not currently validated, need to set classes)
            string characterClass = Info.GetPlayerClass();
            //initialize our current user as a playerCharacter object
            PlayerCharacter user;
            user = new PlayerCharacter(userName, password, characterRace, characterClass, 25, 15, 0, 0);
            //return the user's created character;
            return user;

        }




 
       
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
