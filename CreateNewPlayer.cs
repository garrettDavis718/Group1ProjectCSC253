using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;

namespace TheLastSurvivors
{
    public class CreateNewPlayer
    {
        //method for creating a new player
        public static void CreateCharacter()
        {
            Weapon weapon = new Weapon();
            List<Item> inventory = new List<Item>();
            string passCheck;
            string password;
            string name;
            int healthPoints = 0;
            int armorClass = 0;
            int xLocation = 0;
            int yLocation = 0;
            bool raceCheck;
            bool classCheck;
            bool nameCheck;
            bool nameValid;
            Console.WriteLine("        Create New Player        ");
            Console.WriteLine("=================================");
            Console.WriteLine("Enter Character Name: ");
            do
            {
                name = Console.ReadLine();
                nameCheck = DatabaseControls.CheckForPlayer(name);
                nameValid = Validation.ValidateName(name);
                if (nameCheck == false && nameValid == true)
                {
                    Console.WriteLine(name + " Available!");
                }
                else 
                {
                    Console.WriteLine(name + " is unavailable. Please try again");
                }
            } while (nameCheck == true || nameValid == false);
            do
            {
                Console.WriteLine("Enter player password: ");
                password = Console.ReadLine();
                passCheck = Validation.TestPassword(password);
                Console.WriteLine(passCheck);
            } while (passCheck != "Taken!");
            Console.WriteLine("What race is your character? (Input Number Choice)");
            Console.WriteLine("1. Human");
            Console.WriteLine("2. Mutant");
            Console.WriteLine("3. Alien");
            Console.WriteLine("4. Robot");
            string race = Console.ReadLine();
            //race choices
            do
            {
                switch (race)
                {
                    case "1":
                        race = "Human";
                        raceCheck = true;
                        break;
                    case "2":
                        race = "Mutant";
                        raceCheck = true;
                        break;
                    case "3":
                        race = "Alien";
                        raceCheck = true;
                        break;
                    case "4":
                        race = "Robot";
                        raceCheck = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Please enter 1-4:");
                        race = Console.ReadLine();
                        raceCheck = false;
                        break;
                }
            } while (raceCheck == false);
            Console.WriteLine(race + " selected!");
            //Class Choices
            Console.WriteLine("Choose your Class:  (input number choice)");
            Console.WriteLine("1. Berzerker");
            Console.WriteLine("2. Gunslinger");
            Console.WriteLine("3. Scrapper");
            Console.WriteLine("4. Engineer");
            string playerClass = Console.ReadLine();
            playerClass.ToLower();
            do
            {
                switch (playerClass)
                {
                    case "1":
                        weapon = Lists.Weapons[1];
                        classCheck = true;
                        playerClass = "Berzerker";
                        healthPoints = 65;
                        armorClass = 18;
                        break;
                    case "2":
                        weapon = Lists.Weapons[0];
                        classCheck = true;
                        playerClass = "Gunslinger";
                        healthPoints = 55;
                        armorClass = 15;
                        break;
                    case "3":
                        weapon = Lists.Weapons[5];
                        classCheck = true;
                        playerClass = "Scrapper";
                        healthPoints = 60;
                        armorClass = 17;
                        break;
                    case "4":
                        weapon = Lists.Weapons[2];
                        classCheck = true;
                        playerClass = "Engineer";
                        healthPoints = 60;
                        armorClass = 17;
                        break;
                    default:
                        classCheck = false;
                        Console.WriteLine("Incorrect input. Please enter 1-4");
                        Console.ReadLine();
                        break;
                }
            } while (classCheck == false);
            Console.WriteLine(playerClass + " selected!");
            PlayerCharacter user = new PlayerCharacter(name, password, race, playerClass, healthPoints, armorClass, xLocation, yLocation, weapon, inventory);
            DatabaseControls.CreateNewPlayer(user);
            Lists.currentPlayer.Add(user);


        }
    }
}
