using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
using static World.WorldDelegates;
namespace TheLastSurvivors
{
    public class Menu
    {
        ShowUserMessage message1 = Write;
        ShowUserMessage message2 = WriteLine;

        //GreetUser Menu for greeting every user, will create new player and will load already created players
        public static void GreetUser()
        {
            string choice;
            bool loaded;
            bool choiceCheck;
            PlayerCharacter user = new PlayerCharacter();
            Console.WriteLine("------------Welcome to The Last Survivors!------------");
            Console.WriteLine("Is this your first time playing? ");
            choice = Console.ReadLine();
            choice.ToLower();
            do
            {
                switch (choice)
                {
                    case "no":
                        do
                        {
                            choiceCheck = true;
                            Console.WriteLine("Whats your name?");
                            string name = Console.ReadLine();
                            Console.WriteLine("What's your password? ");
                            string password = Console.ReadLine();
                            loaded = DatabaseControls.LoadPlayer(name, password);
                        } while (loaded == false);
                        Console.WriteLine(Lists.currentPlayer[0].Name + " loaded.");
                        break;
                    case "yes":
                        choiceCheck = true;
                        CreateNewPlayer.CreateCharacter();
                        break;
                    default:
                        choiceCheck = false;
                        Console.WriteLine("Please enter yes or no.");
                        choice = Console.ReadLine();
                        break;
                }
            } while (choiceCheck == false);
        }
        //General Game menu for character's decision, This has been rewritten to be a little cleaner
        //Everytime we do something besides exit the game, we load our current enemies list, which is 
        //a list of enemies that are at the same x and y location of our player. 
        public static void GameMenu()
        {
            bool keepGoing = true;
            PlayerCharacter user = Lists.currentPlayer[0];
            Mob.GetCurrentEnemies();
            Console.WriteLine("Welcome " + user.Name + "!");
            Console.WriteLine("You are currently in " + Arrays.Map[user.XLocation, user.YLocation].Name);
            Console.WriteLine("The " + Arrays.Map[user.XLocation, user.YLocation].Name + " is " + Arrays.Map[user.XLocation, user.YLocation].Description);
            do
            {
                Mob.GetCurrentEnemies();
                Console.WriteLine("What would you like to do? ");
                Console.WriteLine("---------------------");
                string decision = Console.ReadLine().ToLower();
                switch (decision)
                {
                    //This will let us use move x as a move input
                    case string a when a.Contains("move"):
                        string direction;
                        if (decision.Contains(' '))
                        {
                            string[] twoWordDecision = decision.Split(' ');
                            direction = twoWordDecision[1];
                            string output = Map.MoveCharacter(user, direction);
                            Console.WriteLine(output);
                        }
                        else
                        {
                            Console.WriteLine("Which way would you like to move? ");
                            Console.WriteLine("---------------------");
                            direction = Console.ReadLine();
                            string output = Map.MoveCharacter(user, direction);
                            Console.WriteLine(output);
                        }
                        keepGoing = true;
                        break;
                    case "attack":
                        int counter = 0;
                        Console.WriteLine("Who would you like to attack? ");
                        foreach (Mob npc in Lists.CurrentEnemies)
                        {
                            Console.WriteLine(npc.Name);
                        }
                        string enemy = Console.ReadLine().ToLower();
                        foreach (Mob npc in Lists.CurrentEnemies)
                        {
                            if (npc.Name.ToLower().Equals(enemy))
                            {
                                npc.HealthPoints = Combat.attack(Lists.currentPlayer[0], npc);
                                if (npc.HealthPoints > 0)
                                {
                                    Lists.currentPlayer[0].HealthPoints = Combat.attack(npc, Lists.currentPlayer[0]);
                                } 
                                counter++;
                            }
                        }
                        if (counter == 0)
                        {
                            Console.WriteLine("No enemy exists.");
                        }
                        break;
                    case "look":
                        //Look around and display the current room's description
                        //ALso will create a list of current enemies for the user to see, 
                        //Right now the max amount of enemies they will see is one,
                        //That's just because of the limited enemy locations. 
                        Console.WriteLine(Arrays.Map[user.XLocation, user.YLocation].Name);
                        Console.WriteLine(Arrays.Map[user.XLocation, user.YLocation].Description);
                        foreach (Mob npc in Lists.CurrentEnemies)
                        {
                            Console.WriteLine("Enemies: ");
                            Console.WriteLine(npc.Name);
                        }
                        break;
                    case string a when a.Contains("look at"):
                        string[] choices = decision.Split(' ');
                        string interest = choices[2];
                        foreach(Character character in Lists.CurrentEnemies) 
                        {
                            if (character.Name.ToLower().Equals(interest))
                            {
                                Console.WriteLine("You see a " + character.Name + " with " + character.HealthPoints + ".");
                                Console.WriteLine("The " + character.Name + " is holding a " + character.Weapon.Name);
                            }
                            else
                            {
                                Console.WriteLine("There is no enemy by that name here.");
                            }
                        }
                        break;
                        //All 3 of these cases do the same thing
                    case "take":
                    case "pickup":
                    case "grab":
                        Console.WriteLine("What would you like to pickup?");
                        string input = Console.ReadLine().ToLower();
                        foreach (Item item in Arrays.Map[user.XLocation, user.YLocation].Inventory)
                        {
                            if (input.Equals(item.Name.ToLower()))
                            {
                                Item.TakeItem(item, user);
                                Console.WriteLine("You've picked up " + item.Name);
                            }
                        }
                        break;
                    case "exit":
                        keepGoing = false;
                        break;
                    default:
                        keepGoing = true;
                        break;
                }
                //Die option, ends the current game
                if (user.HealthPoints < 0)
                {
                    Console.WriteLine("You have died.");
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine("You are currently in " + Arrays.Map[user.XLocation, user.YLocation].Name);
                }
            } while (keepGoing == true);
            //thank user for playing. 
            Console.WriteLine("Thanks for playing!");
            Console.ReadLine();

        }
    }
}

