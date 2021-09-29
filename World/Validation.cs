using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace World
{
    public static class Validation
    {
        public static bool TestRace(string characterRace)
        {
            bool result;
            characterRace = characterRace.ToUpper();
            if (characterRace == "HUMAN" || characterRace == "ELF" || characterRace == "DWARF"
                || characterRace == "DOG" || characterRace == "ROBOT" || characterRace == "ADMIN")
            {
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }
        public static bool TestClass(string characterClass)
        {
            bool results;
            characterClass = characterClass.ToUpper();
            if (characterClass == "ROAD WARRIOR" || characterClass == "GUNSLINGER" || characterClass == "MECHANIC"
                || characterClass == "ADMIN")
            {
                results = true;
                return results;
            }
            else
            {
                results = false;
                return results;
            }

        }
        //Method for testing if theirs an upper-cased letter in a string, used for password validation
        public static bool TestUpper(string password)
        {
            //set a bool for return
            bool testResults;
            //counter that will count everytime an uppercased letter is used in our string, if we have at least one, the bool should return true
            int counter = 0;
            foreach (char letter in password)
            {
                //if uppercased letter increment our counter
                if (char.IsUpper(letter))
                {
                    counter++;
                }
                //nothing happening in else, because we do not want to manipulate counter if there isn't an uppercased letter
                else { }
            }
            //if statment for checkign if our counter is above 0
            if (counter > 0)
            {
                testResults = true;
            }
            else
            {
                testResults = false;
            }
            //return our results based on password entry
            return testResults;
        }
        //basically the same method as before, just using char.IsLower() method
        public static bool TestLower(string password)
        {
            bool testResults;
            int counter = 0;
            foreach (char letter in password)
            {

                if (char.IsLower(letter))
                {
                    counter++;
                }
                else { }
            }
            if (counter > 0)
            {
                testResults = true;
            }
            else
            {
                testResults = false;
            }
            return testResults;
        }
        //IMPROVE CODE HERE
        //This method will check to see if the password string contains any of the following special characters, if it does it will return a true boolean (testResults)
        public static bool TestSpecial(string password)
        {
            //set our bool variable
            bool testResults;
            //if statement to check our string for special characters
            if (password.Contains('!') || password.Contains('@') || password.Contains('#') || password.Contains('$') || password.Contains('%')
                || password.Contains('^') || password.Contains('&') || password.Contains('*') || password.Contains('(') || password.Contains('('))
            {
                testResults = true;
            }
            else
            {
                testResults = false;
            }
            //return our bool for user to see
            return testResults;
        }
        //final password tester that will each earlier test to see what needs to be changed about the user's specific input, requires all previous tests answer's as paramaters
        public static bool TestPassword(bool upper, bool lower, bool special)
        {
            //set our bool
            bool result;
            //check if our first bool is false, if so let the user know
            if (upper != true)
            {
                result = false;
                Console.WriteLine("Please enter an upper-cased letter in your password. ");
            }
            //check if second bool is false, if so let user know
            else if (lower != true)
            {
                result = false;
                Console.WriteLine("Please enter a lower-cased letter in your password.");
            }
            //chekc if third bool is false, if so let user know
            else if (special != true)
            {
                result = false;
                Console.WriteLine("Please enter a special character in your password.");
            }
            //If all bools come back true then we set our test result so we will finally set our password
            else { result = true; }
            return result;
        }
        //See if user exists with given information, returns a bool
        public static bool TestForUser(string name, string pass)
        {
            bool results = false;
            StreamReader inputFile;
            try
            {
                inputFile = File.OpenText("players.csv");
                foreach (string line in File.ReadAllLines("players.csv"))
                {

                    string[] token = line.Split(',');
                    if (token[0].ToLower().Equals(name.ToLower()) && token[1].Equals(pass))
                    {
                        results = true;
                    }     
                }
                inputFile.Close();
                return results;

            }
            catch (Exception ex)
            {
                results = false;
                return results;
            }
        }
    }
}
