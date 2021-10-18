using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace World
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
                    catch(SqlException ex)
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
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + directory  + ";Integrated Security=True;Connect Timeout=30";
            return connectionString;
  }
        //Method that tests for existing user
        public static bool CheckForUser(PlayerCharacter user)
        {

            string connectionString = CreateConnectionString();
            bool results;
            string Command = "Select Count(*) FROM Players WHERE Name like @Name AND Password like @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(Command, connection))
            {
                connection.Open();
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = user.Name;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 15).Value = user.Password;
                
                int userCount = (int) cmd.ExecuteScalar();
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
        public static void LoadMobs()
        {
           
        }
        public static void LoadPotions()
        {
            string connectionString = CreateConnectionString();
            string query = "Select * From Potions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        string potionId = dr["PotionId"].ToString();
                        string potionName = dr["PotionName"].ToString();
                        string potionDescription = dr["PotionDescription"].ToString();
                        Potion potion = new Potion(potionId, potionName, potionDescription);
                        Console.WriteLine(potion.Name);
                    }
                    connection.Close();
                }
            }


        }
        //Delete example
        public static void DeleteTest()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TheLastSurvivors.Properties.Settings.LastNightDataBaseConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            LastNightDataBaseDataSetTableAdapters.TestTableAdapter testTableAdapter = new LastNightDataBaseDataSetTableAdapters.TestTableAdapter();
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
