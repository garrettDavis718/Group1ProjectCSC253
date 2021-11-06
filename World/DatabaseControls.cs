using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World
{
    //This is my databasecontrols class, We control info within our database from here
    public class DatabaseControls
    {

        //connectstring setup
        public static string CreateConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //method for saving the game of the new player
        public static void CreateNewPlayer(PlayerCharacter user)
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                cnn.Execute("insert into Players (Name, Password, Race, Class, HealthPoints, ArmorClass, XLocation, YLocation) " +
                    "values (@Name, @Password, @Race, @PlayerClass, @HealthPoints, @ArmorClass, @XLocation, @YLocation)", user);
            }

        }
        //method for saving the game of an existing player
        public static void SaveGame(PlayerCharacter user)
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                cnn.Execute("UPDATE Players SET HealthPoints = @HealthPoints, XLocation = @XLocation, YLocation = @YLocation " +
                    "WHERE Name LIKE @Name AND Password LIKE @Password", user);
            }
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
        public static List<Item> LoadItems()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Item>("SELECT * FROM Items", new DynamicParameters());
                return output.ToList();
            }
        }
        //Load Mobs List
        public static List<Mob> LoadMobs()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Mob>("SELECT * FROM mobs", new DynamicParameters());
                return output.ToList();
            }
        }
        //Method that will load potions into our application
        public static List<Potion> LoadPotions()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Potion>("SELECT * FROM potions", new DynamicParameters());
                return output.ToList();
            }
        }
        //Method that will load Treasures into our application
        public static List<Treasure> LoadTreasures()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Treasure>("SELECT * FROM Treasure", new DynamicParameters());
                return output.ToList();
            }
        }
        //Method that will load Weapons into our application
        public static List<Weapon> LoadWeapons()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Weapon>("SELECT * FROM Weapons", new DynamicParameters());
                return output.ToList();
            }
        }
        //Method that will load KeyItems into our application
        public static List<KeyItem> LoadKeyItems()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<KeyItem>("SELECT * FROM KeyItems", new DynamicParameters());
                return output.ToList();
            }
        }



        //Method to load rooms
        public static List<Room> LoadRooms()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Room>("SELECT * From Rooms", new DynamicParameters());
                return output.ToList();
            }
        }

        //method take in username and password and gets the rest of the user's information from the database (players table)
        public static void LoadPlayer(string userName, string userPass)
        {
            string connectionString = CreateConnectionString();
            string query = "SELECT * FROM Players WHERE Name like @Name AND Password like @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 20).Value = userName;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = userPass;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string PCName = dr["Name"].ToString();
                        string PCPass = dr["Password"].ToString();
                        int.TryParse(dr["HealthPoints"].ToString(), out int PCHP);
                        int.TryParse(dr["ArmorClass"].ToString(), out int PCAC);
                        int.TryParse(dr["XLocation"].ToString(), out int XLocation);
                        int.TryParse(dr["YLocation"].ToString(), out int YLocation);
                        string PCRace = dr["Race"].ToString();
                        string PCClass = dr["PlayerClass"].ToString();

                        PlayerCharacter user = new PlayerCharacter(PCName, PCPass, PCClass, PCRace, PCHP, PCAC, XLocation, YLocation);
                        Lists.currentPlayer.Add(user);
                    }
                }
            }
        }
    }
}
