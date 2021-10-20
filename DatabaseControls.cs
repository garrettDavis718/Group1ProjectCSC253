using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;

namespace TheLastSurvivors
{
    //This is my databasecontrols class, We control info within our database from here
    public class DatabaseControls
    {
        //Save Game method, takes in user and the part of the database that needs to be local to the user
        public static void SaveGame(PlayerCharacter user)
        {
            string connectionString = CreateConnectionString();
            //setup our sqlConnection to our connectionstring that is local to the user
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //Create our sqlCommand
                using (SqlCommand cmd = new SqlCommand())
                {
                    //Connection and paramaters for our SqlCommand
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Players (Name, Password, HealthPoints, ArmorClass, Location, Race, PlayerClass) " +
                        "VALUES (@Name, @Password, @HealthPoints, @ArmorClass, @Location, @Race, @PlayerClass)";

                    //define the parameter values
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = user.Name;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 15).Value = user.Password;
                    cmd.Parameters.Add("@HealthPoints", SqlDbType.Int).Value = user.HealthPoints;
                    cmd.Parameters.Add("@ArmorClass", SqlDbType.Int).Value = user.ArmorClass;
                    cmd.Parameters.Add("@Location", SqlDbType.Int).Value = user.Location;
                    cmd.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = user.Race;
                    cmd.Parameters.Add("@PlayerClass", SqlDbType.VarChar, 50).Value = user.CharacterClass;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        //get directory for db location and create the connectionString for use within our DbControls class
        public static string CreateConnectionString()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string directory = Directory.GetParent(workingDirectory).Parent.FullName;
            directory += @"\LASTNIGHTDATABASE.MDF";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + directory + ";Integrated Security=True;Connect Timeout=30";
            return connectionString;
        }
        //Method that tests for existing user
        public static bool CheckForUser(string userName, string userPass)
        {

            string connectionString = CreateConnectionString();
            bool results;
            string Command = "Select Count(*) FROM Players WHERE Name like @Name AND Password like @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(Command, connection))
            {
                connection.Open();
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = userName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 15).Value = userPass;

                int userCount = (int)cmd.ExecuteScalar();
                if (userCount > 0)
                {
                    Console.WriteLine("This user already exists.");
                    results = true;
                }
                else
                {
                    results = false;
                }
                return results;
            }
        }
        //Method that will load items into our application
        public static void LoadItems()
        {
            string connectionString = CreateConnectionString();
            string query = "SELECT * FROM Items";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        double itemWeight;
                        double.TryParse(dr["ItemWeight"].ToString(), out itemWeight);
                        Item item = new Item(itemWeight, dr["ItemName"].ToString(), dr["ItemDesc"].ToString(), dr["IsQuestItem"].ToString());
                        Lists.Items.Add(item);

                    }
                }
            }
        }
        //Method that will load mobs into our application
        public static void LoadMobs()
        {
           
        }
        //Method that will load potions into our application
        public static void LoadPotions()
        {
            string connectionString = CreateConnectionString();
            string query = "SELECT * FROM Potions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int potionPoints;
                        int.TryParse(dr["PotionPoints"].ToString(), out potionPoints);
                        Potion potion = new Potion(dr["PotionId"].ToString(), dr["PotionName"].ToString(), dr["PotionDescription"].ToString(), potionPoints);
                        Lists.Potions.Add(potion);

                    }
                }
            }
        }
        //Method to load rooms
        public static void LoadRooms()
        {
            string connectionString = CreateConnectionString();
            string query = "SELECT * FROM Rooms";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string roomId = dr["Id"].ToString();
                        string roomName = dr["Name"].ToString();
                        string roomExit = dr["Exit"].ToString();
                        string roomDesc = dr["Description"].ToString();
                        string roomEnemy = dr["Mob"].ToString();

                        Room room = new Room(roomName, roomDesc, roomExit, roomId, roomEnemy);
                        Lists.rooms.Add(room);

                    }
                }
            }
        }
        //Method to load Treasure
        public static void LoadTreasure()
        {
            string connectionString = CreateConnectionString();
            string query = "SELECT * FROM Treasure";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string treasureId = dr["Id"].ToString();
                        string treasureName = dr["TreasureName"].ToString();
                        double treasurePrice;
                        double.TryParse(dr["Price"].ToString(), out treasurePrice);
                        string treasureDesc = dr["Description"].ToString();
                        string isQuestItem = dr["IsQuestItem"].ToString();

                        Treasure treasure = new Treasure(treasureId, treasureName, treasurePrice, treasureDesc, isQuestItem);
                        Lists.Treasures.Add(treasure);

                    }
                }
            }
        }
        //Method to load Weapons
        public static void LoadWeapons()
        {
            string connectionString = CreateConnectionString();
            string query = "SELECT * FROM Weapons";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string weaponName = dr["WeaponName"].ToString();
                        int weaponCost;
                        int.TryParse(dr["WeaponCost"].ToString(), out weaponCost);
                        string weaponDmgType = dr["WeaponDmgType"].ToString();
                        int weaponDmg;
                        int.TryParse(dr["WeaponDamage"].ToString(), out weaponDmg);
                        string weaponDesc = dr["WeaponDescription"].ToString();

                        Weapon weapon = new Weapon(weaponName, weaponCost, weaponDmgType, weaponDmg, weaponDesc);
                        Lists.Weapons.Add(weapon);

                    }
                }
            }
        }
        //method take in username and password and gets the rest of the user's information from the database (players table)
        public static void LoadPlayer(string userName, string userPass)
        {
            string connectionString = CreateConnectionString();
            string query = "SELECT * FROM Players WHERE Name like @Name AND Password like @Pass";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 20).Value = userName;
                    cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 20).Value = userPass;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string PCName = dr["Name"].ToString();
                        string PCPass = dr["Password"].ToString();
                        int PCHP;
                        int.TryParse(dr["HealthPoints"].ToString(), out PCHP);
                        int PCAC;
                        int.TryParse(dr["ArmorClass"].ToString(), out PCAC);
                        int PCLocation;
                        int.TryParse(dr["Location"].ToString(), out PCLocation);
                        string PCRace = dr["Race"].ToString();
                        string PCClass = dr["PlayerClass"].ToString();

                        PlayerCharacter user = new PlayerCharacter(PCName, PCPass, PCHP, PCAC, PCRace, PCClass, PCLocation);
                        Lists.currentPlayer.Add(user);
                    }
                }
            }
        }



        public static void DeleteTest()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TheLastSurvivors.Properties.Settings.LastNightDataBaseConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            World.LastNightDataBaseDataSetTableAdapters.TestTableAdapter testTableAdapter = new World.LastNightDataBaseDataSetTableAdapters.TestTableAdapter();
            DataTable testTable = new DataTable();

            testTableAdapter.Delete(1, "Name");


        }
        //select from db table
        //    SqlDataReader dr = cmd.ExecuteReader();

        //                while (dr.Read())
        //                {
        //                    string testName = dr["TestName"].ToString();
        //    string id = dr["Id"].ToString();
        //    Console.WriteLine(testName + " " + id);
        //                }
        //dr.Close();



    }
}
