using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    //combat class that currently has the user do 0-20 damage based on a random number
    public class Combat
    {
        //Damage method
        public static int SwingWeapon()
        {
            //initialize a new random
            Random r = new Random();
            //initailize our damage integer and set it to equal a random number between 0-20
            int toHit = r.Next(0, 21);
            //return our damage
            return toHit;
        }
        //method that gives the health of the enemy after we try attacking them, can fail
        public static double HitCheck(int toHit, double dmg, Mob enemy, string weaponName)
        {
            double healthLeft = enemy.HealthPoints;
            if (toHit >= enemy.ArmorClass)
            {
                Console.WriteLine("You hit for " + dmg + " damage with your " + weaponName);
                healthLeft = enemy.HealthPoints - dmg;
                return healthLeft;
            }
            else 
            {
                Console.WriteLine("You do not hit.");
                return healthLeft;
            }
        }
        //method to prompt for who the user would like to attack
        public static void AttackWho(string enemy, int roomIndex)
        {
            bool keepGoing;
            //do while to validate input
            do
            {
                //leave out checking for granny, we don't want to fight her
                if (enemy.ToLower() != ("dog") && enemy.ToLower() != "mutant" && enemy.ToLower() != "skeleton" && enemy.ToLower() != "merchant" && enemy.ToLower() != "none"
                    && enemy.ToLower() != "war machine" && enemy.ToLower() != "zombie scientist" && enemy.ToLower() != "zombie doctor" && enemy.ToLower() != "dinosaur"
                    && enemy.ToLower() != "elvis impersonator" && enemy.ToLower() != "mario" && enemy.ToLower() != "merchant2" && enemy.ToLower() != "islander zombie" && enemy.ToLower() != "astronaut ghost"
                    && enemy.ToLower() != "zebra") 
                {
                    Console.WriteLine("Please enter a real enemy.");
                    enemy = Console.ReadLine();
                    enemy.Trim();
                    keepGoing = true;
                }
                //none option to cancel attack choice
                else if (enemy == "none")
                {
                    Console.WriteLine("You decide against attacking. ");
                    keepGoing = false;
                }
                //else if everything else passes
                else
                {
                    //set currentEnemy to our user's input. this inputs the enemy into our currentenemy list
                    Info.GetEnemy(enemy);
                    //if the enemy we chose in in the same room as us
                    if (Lists.CurrentEnemies[0].RoomIndex != roomIndex)
                    {
                        //Prompt user to reinput their choice, as the one they've chosen isn't in our room
                        Console.WriteLine("You cannot see that enemy nearby. Please enter a nearby enemy or none to cancel.");
                        enemy = Console.ReadLine();
                        enemy.Trim();
                        keepGoing = true;
                    }
                    //everything passes we execute the attack with our current weapon
                    else
                    {
                        //get our tohit int which checks if we beat their armor class
                        int toHit = Combat.SwingWeapon();
                        //hardcoded damage(for now)
                        int dmg;
                        Lists.CurrentWeapon[0] = Info.GetWeapon(Lists.currentPlayer[0].CharacterClass);
                        dmg = Lists.CurrentWeapon[0].Damage;
                        //update the healthpoint of our current enemy
                        Lists.CurrentEnemies[0].HealthPoints = Combat.HitCheck(toHit, dmg, Lists.CurrentEnemies[0], Lists.CurrentWeapon[0].Name);
                        //get out of the do while
                        keepGoing = false;
                        //check if we've killed the enemy
                        if (Lists.CurrentEnemies[0].HealthPoints <= 0)
                        {
                            Console.WriteLine("Youve killed the enemy.");
                            Lists.CurrentEnemies.Remove(Lists.CurrentEnemies[0]);
                        }
                        else
                        {
                            Console.WriteLine(Lists.CurrentEnemies[0].Name + " still lives with "
                                + Lists.CurrentEnemies[0].HealthPoints + " health left.");
                        }
                    }
                }
            }
            while (keepGoing == true);
        }
        //Method for getting the health of either us or a mob after they've taken damage, this method hasn't been implemented yet
        public static int GetHealth(int health, int dmg)
        {
            //initialize our newHealth variable
            int newHealth;
            //newHealth is goingto be equal to health - damage from our parameters
            newHealth = health - dmg;
            //return newHealth
            return newHealth;
        }
    }
}
