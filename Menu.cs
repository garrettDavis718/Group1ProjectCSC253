using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
namespace TheLastSurvivors
{
    public class Menu
    {
        //GreetUser Menu for greeting a first time user
        public static void GreetUser()
        {
            Console.WriteLine("Thank you for playing my game, this is the second iteration of it so it is still fairly simple. (enter to continue)");
            Console.ReadLine();
            Console.WriteLine("For now you will be able to go on a tour of the world we have created thus far. And fight some of the enemies");
            Console.ReadLine();
            Console.WriteLine("We're also going to create a new character for you to play as, so remember your chosen name and password!");
            Console.ReadLine();
        }



        //Menu that is seen as soon as you open our game, this will find out if your a new or returning member
        public static void EntryMenu()
        {
            //set our bool for do while statement
            bool repeat;
            //Prompt user if they've played before
            Console.WriteLine("Have you played The Last Survivors before? ");
            string decision = Console.ReadLine();
            //determine what to do with user based on input, also force entry to lower-case for easier checking
            decision = decision.ToLower();
            do
            {
                //if they have played before we go right in without explanation
                if (decision == "yes")
                {
                    PlayerCharacter user = Info.RequestPlayerCreds();
                    Console.WriteLine("Player found!" + "(" + user.Name + ")");


                    Console.WriteLine("Great to see you again " + user.Name);
                    //stop the method from repeating
                    repeat = false;
                }
                //new player so they will get some direction
                else if (decision == "no")
                {
                    //greet user
                    GreetUser();
                    //get player information from user
                    PlayerCharacter user = Info.GetPlayer();
                    bool keepGoing;
                    //do while to check if user exists
                    do
                    {

                        if (DatabaseControls.CheckForUser(user.Name, user.Password) == false)
                        {
                            DatabaseControls.SaveGame(user);
                            keepGoing = false;
                        }
                        else
                        {
                            Console.WriteLine("These credentials have already been used, please try another set or reopen the program and login to your already created user.");
                            user = Info.GetPlayer();
                            keepGoing = true;
                        }
                    }
                    while (keepGoing == true); 
                    Info.FindExistingCharacter(user.Name, user.Password);
                    user = Lists.currentPlayer[0];
                    //set username for future use when referring to player
                    string userName = user.Name;
                    //This method is supposed to add the new player to add the player to the current list of players, but It's not implemented correctly yet
                    //PlayerCharacter.AddNewPlayer(user);
                    //Greet user
                    Console.WriteLine("It's great to meet you " + userName + "! \nNow let's get started.");
                    //stop method from repeating
                    repeat = false;
                }
                else
                {
                    //validation for user's input, forces method to repeat
                    Console.WriteLine("Please enter yes or no: ");
                    decision = Console.ReadLine();
                    decision = decision.ToLower();
                    repeat = true;
                }
            }
            while (repeat == true);
        }




        //main menu method
        public static void MainMenu()
        {
            DatabaseControls.LoadItems();
            DatabaseControls.LoadMobs();
            DatabaseControls.LoadPotions();
            DatabaseControls.LoadRooms();
            DatabaseControls.LoadTreasure();
            DatabaseControls.LoadWeapons();
            PlayerCharacter user = Lists.currentPlayer[0];
            //show main menu to user and ask for input
            Console.WriteLine("What would you like to do?\nMove\nAttack\nLook\nExit ");
            //assign variable for decision to be used in switch statement
            string decision;
            //establish initial roomIndex number
            int roomIndex = 0;
            //set our current room
            Room currentRoom;
            //set our decision
            decision = Console.ReadLine();
            //force decision to lower for easier validation
            decision = decision.ToLower();
            //set variable keepGoing for our do While loop
            int keepGoing;
            do
            {
                //switch statement with decision string as the case
                switch (decision)
                {
                    //case move will ask user which way they would like to travel and tell them which room they've made it to
                    case "move":
                        Console.WriteLine("Which way would you like to move?\nNorth(n)\nSouth(s)");
                        string choice = Console.ReadLine();
                        roomIndex = Room.MoveRoom(roomIndex, choice);
                        currentRoom = Room.GetRoom(roomIndex);
                        Console.WriteLine("You are currently in " + currentRoom.Name);
                        Console.WriteLine("What would you like to do next? ");
                        decision = Console.ReadLine();
                        decision = decision.ToLower();
                        keepGoing = 0;
                        break;
                    //case attack will call the damage method so and print the user's damage, also it will tell the user their current room
                    case "attack":
                        Info.GetWeapon(user.CharacterClass);
                        Weapon currentWeapon = Lists.CurrentWeapon[0];
                        currentRoom = Room.GetRoom(roomIndex);
                        Console.WriteLine("What would you like to attack?(type none to cancel)");
                        string enemyName;
                        //generate a small list of mobs that the user can see, only shows nearby enemies
                        foreach (Mob npc in Lists.Mobs)
                        {
                            //checks that the npc is in the same room and has health
                            if (roomIndex == npc.RoomIndex && npc.HealthPoints > 0)
                            {
                                enemyName = npc.Name;
                                //Write the enemy to a line so the user can see
                                Console.WriteLine(enemyName);
                            }
                        }
                        //Ask the user who they would like to attack
                        Console.WriteLine("Who you want to attack? ");
                        //save a string of the user's choice of enemy
                        string enemy = Console.ReadLine();
                        //run our atatckWho combat class with our current room and our enemy choice
                        Combat.AttackWho(enemy, roomIndex);
                        //Show where the user is and give their room's name
                        Console.WriteLine("You are currently in " + currentRoom.Name);
                        Console.WriteLine("What would you like to do next? ");
                        decision = Console.ReadLine();
                        decision = decision.ToLower();
                        keepGoing = 0;
                        break;
                    //case look will show the user the description of the room
                    //Will also let the user know what enemies are around, if any
                    case "look":
                        currentRoom = Room.GetRoom(roomIndex);
                        Console.WriteLine("You are currently in " + currentRoom.Name +
                            "you see " + currentRoom.Desc);
                        foreach (Mob npc in Lists.Mobs)
                        {
                            if (roomIndex == npc.RoomIndex && npc.HealthPoints > 0)
                            {
                                Console.WriteLine("You see a " + npc.Name);
                            }
                        }
                        Console.WriteLine("What would you like to do next? ");
                        decision = Console.ReadLine();
                        decision = decision.ToLower();
                        keepGoing = 0;
                        break;
                    //exit case ends the statment
                    case "exit":
                        keepGoing = 1;
                        break;
                    //default case for when the user misinputs
                    default:
                        Console.WriteLine("Please choose one of the following: \nMove\nAttack\nLook\nExit");
                        decision = Console.ReadLine();
                        decision = decision.ToLower();
                        keepGoing = 0;
                        break;
                }
                //while for loop
            } while (keepGoing == 0);
        }
    }
}
