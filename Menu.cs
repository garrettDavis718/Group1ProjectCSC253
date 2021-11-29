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
            WriteLine("------------Welcome to The Last Survivors!------------");
            WriteLine("Is this your first time playing? ");
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
                            WriteLine("Whats your name?");
                            string name = Console.ReadLine();
                            WriteLine("What's your password? ");
                            string password = Console.ReadLine();
                            loaded = DatabaseControls.LoadPlayer(name, password);
                        } while (loaded == false);
                        WriteLine(Lists.currentPlayer[0].Name + " loaded.");
                        break;
                    case "yes":
                        choiceCheck = true;
                        CreateNewPlayer.CreateCharacter();
                        break;
                    default:
                        choiceCheck = false;
                        WriteLine("Please enter yes or no.");
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
            WriteLine("Welcome " + user.Name + "!");
            WriteLine("You are currently in " + Arrays.Map[user.XLocation, user.YLocation].Name);
            WriteLine("The " + Arrays.Map[user.XLocation, user.YLocation].Name + " is " + Arrays.Map[user.XLocation, user.YLocation].Description);
            do
            {
                Mob.GetCurrentEnemies();
                WriteLine("What would you like to do? ");
                WriteLine("---------------------");
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
                            WriteLine(output);
                        }
                        else
                        {
                            WriteLine("Which way would you like to move? ");
                            WriteLine("---------------------");
                            direction = Console.ReadLine();
                            string output = Map.MoveCharacter(user, direction);
                            WriteLine(output);
                        }
                        keepGoing = true;
                        break;
                    case string a when a.Contains("attack"):
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
                            WriteLine("No enemy exists.");
                        }
                        break;
                    case "look":
                        //Look around and display the current room's description
                        //ALso will create a list of current enemies for the user to see, 
                        //Right now the max amount of enemies they will see is one,
                        //That's just because of the limited enemy locations. 
                        WriteLine(Arrays.Map[user.XLocation, user.YLocation].Name);
                        WriteLine(Arrays.Map[user.XLocation, user.YLocation].Description);
                        foreach (Mob npc in Lists.CurrentEnemies)
                        {
                            WriteLine("Enemies: ");
                            WriteLine(npc.Name);
                        }
                        break;
                    case string a when a.Contains("look at"):
                        string[] choices = decision.Split(' ');
                        if (choices.Length > 2)
                        {
                            string interest = choices[2];
                            if (choices.Length > 3)
                            {
                                interest += ' ';
                                interest += choices[3];
                                WriteLine(interest);
                            }

                            foreach (Character character in Lists.CurrentEnemies)
                            {
                                if (character.Name.ToLower().Equals(interest.ToLower()))
                                {
                                    WriteLine("You see a " + character.Name + " with " + character.HealthPoints + "health points.");
                                    WriteLine("The " + character.Name + " is holding a " + character.Weapon.Name);
                                }

                            }
                            foreach (Item item in Arrays.Map[user.XLocation, user.YLocation].Inventory)
                            {
                                WriteLine(item.Name.ToLower());
                                WriteLine(item.Desc);
                                if (item.Name.ToLower().Equals(interest.ToLower()))
                                {
                                    WriteLine(item.Desc);
                                }
                            }
                            foreach (Door door in Arrays.Map[user.XLocation, user.YLocation].Doors)
                            {
                                if (door.Name.ToLower().Equals(interest.ToLower()))
                                {
                                    WriteLine(door.Desc);
                                }
                            }
                        }
                        break;
                        //All 3 of these cases do the same thing
                    case "take":
                    case "pickup":
                    case "grab":
                        Console.WriteLine("What would you like to pickup?");
                        string input = Console.ReadLine().ToLower();
                        Item takenItem = new Item();
                        foreach (Item item in Arrays.Map[user.XLocation, user.YLocation].Inventory)
                        {
                            if (input.Equals(item.Name.ToLower()))
                            {
                                takenItem = item;
                                Item.TakeItem(item, user);
                                WriteLine("You've picked up " + item.Name);
                            }
                        }
                        for (int i = 0; i < Arrays.Map[user.XLocation, user.YLocation].Inventory.Count; i++)
                        {
                            int count = 0;
                            if (count < 1 && Arrays.Map[user.XLocation, user.YLocation].Inventory[i].Equals(takenItem))
                            {
                                Arrays.Map[user.XLocation, user.YLocation].Inventory.RemoveAt(i);
                                count++;
                            }
                        }

                        break;
                    case "drop":
                        WriteLine("   Inventory   ");
                        WriteLine("----------------");
                        foreach (Item item in user.Inventory)
                        {
                            WriteLine(item.Name);
                        }
                        string droppedItem = Console.ReadLine();
                        Item.DropItem(droppedItem, user);
                        break;
                    case "use":
                        WriteLine("What would you like to use? ");
                        foreach (Item item in user.Inventory)
                        {
                            WriteLine(item.Name); 
                        }
                        string usedItem = Console.ReadLine();
                        string doorChoice = "";
                        KeyItem keyChoice = new KeyItem();
                        foreach (Item item in user.Inventory)
                        {
                            if (usedItem.ToLower().Equals(item.Name.ToLower()))
                            {
                                keyChoice = KeyItem.GetKeyItem(usedItem);
                                WriteLine("What would you like to use the " + item.Name + " on? " );
                                doorChoice = Console.ReadLine();
                            }
                        }
                        foreach (Door door in Arrays.Map[user.XLocation, user.YLocation].Doors)
                        {
                            if (doorChoice.ToLower().Equals(door.Name.ToLower()))
                            {
                                Door.UnlockDoor(door, keyChoice, user);
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
                    WriteLine("You have died.");
                    keepGoing = false;
                }
                else
                {
                    WriteLine("You are currently in " + Arrays.Map[user.XLocation, user.YLocation].Name);
                }
            } while (keepGoing == true);
            //thank user for playing. 
            WriteLine("Thanks for playing!");
            Console.ReadLine();

        }
    }
}

