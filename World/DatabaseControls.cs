﻿using Dapper;
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
using static World.WorldDelegates;


namespace World
{
    //This is my databasecontrols class, We control info within our database from here
    public class DatabaseControls
    {
        ShowUserMessage message1 = Write;
        ShowUserMessage message2 = WriteLine;

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
                cnn.Execute("insert into Players (Name, Password, Race, PlayerClass, HealthPoints, ArmorClass, XLocation, YLocation) " +
                    "values (@Name, @Password, @Race, @PlayerClass, @HealthPoints, @ArmorClass, @XLocation, @YLocation)", user);
            }
            
        }
        //method for saving the game of an existing player, not really used yet
        public static void SaveGame(PlayerCharacter user)
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                cnn.Execute("UPDATE Players SET HealthPoints = @HealthPoints, XLocation = @XLocation, YLocation = @YLocation " +
                    "WHERE Name LIKE @Name AND Password LIKE @Password", user);
            }
        }
        //method to load items
        public static void LoadItems()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Item>("SELECT * FROM Items", new DynamicParameters());
                Lists.Items = output.ToList();
            }
        }
        //Load Mobs List and Load their specific weapons into their Object
        public static void LoadMobs()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Mob>("SELECT * FROM mobs", new DynamicParameters());
                List<Mob> tempList = output.ToList();
                foreach (Mob npc in tempList)
                {
                    Weapon weapon = Weapon.GetWeapon(npc);
                    Mob mob = new Mob(npc.ID, npc.Name, npc.HealthPoints, npc.ArmorClass, npc.XLocation, npc.YLocation, weapon);
                    Lists.Mobs.Add(mob);
                }
            }
        }
        //Method that will load potions into our application
        public static void LoadPotions()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Potion>("SELECT * FROM potions", new DynamicParameters());
                Lists.Potions =  output.ToList();
            }
        }
        //Method that will load Treasures into our application
        public static void LoadTreasures()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Treasure>("SELECT * FROM Treasure", new DynamicParameters());
                Lists.Treasures = output.ToList();
            }
        }
        //Method that will load Weapons into our application
        public static void LoadWeapons()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Weapon>("SELECT * FROM Weapons", new DynamicParameters());
                Lists.Weapons = output.ToList();
            }
        }
        //Method that will load KeyItems into our application
        public static void LoadKeyItems()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<KeyItem>("SELECT * FROM KeyItems", new DynamicParameters());
                Lists.KeyItems =  output.ToList();
            }
        }
        //Method to load doors
        public static void LoadDoors()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<Door>("SELECT * From Doors", new DynamicParameters());
                Lists.Doors = output.ToList();
            }
        }
        //Method to load rooms
        public static void LoadRooms()
        {
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                List<Character> characters = new List<Character>();
                List<Room> tempList = new List<Room>();
                var output = cnn.Query<Room>("SELECT * From Rooms", new DynamicParameters());
                tempList = output.ToList();
                foreach (Room room in tempList)
                {
                    Door door = Room.GetDoor(room);
                    KeyItem key = Room.GetKeyItem(room);
                    List<Item> inventory = new List<Item> { key };
                    List<Door> doors = new List<Door>() { door };
                    Room room2 = new Room(room.Name, room.Description, room.XLocation, room.YLocation, room.ID, characters, inventory, doors);
                    Lists.rooms.Add(room2);
                }
            }
        }
        //method that will load a player from the db, and inject them with a weapon depending on the character's class
        public static bool LoadPlayer(string userName, string password)
        {
            PlayerCharacter user = new PlayerCharacter();
            bool loaded;
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                List<Item> inventory = new List<Item>();
                var output = cnn.Query<PlayerCharacter>("SELECT * FROM Players WHERE Name Like @Name AND Password Like @Password", new { Name = userName, Password = password});
                List<PlayerCharacter> tempList = new List<PlayerCharacter>();
                tempList = output.ToList();
                if (tempList.Count > 0)
                {
                    user = new PlayerCharacter(tempList[0].Name, tempList[0].Password, tempList[0].Race, tempList[0].PlayerClass, tempList[0].HealthPoints,
                        tempList[0].ArmorClass, tempList[0].XLocation, tempList[0].YLocation);
                    Weapon weapon = Weapon.GetWeapon(user);
                    user = new PlayerCharacter(tempList[0].Name, tempList[0].Password, tempList[0].Race, tempList[0].PlayerClass, tempList[0].HealthPoints,
                        tempList[0].ArmorClass, tempList[0].XLocation, tempList[0].YLocation, weapon, inventory);
                    loaded = true;
                    Lists.currentPlayer.Add(user);
                }
                else 
                {
                    WriteLine("Incorrect Credentials");
                    loaded = false;
                }
            }
            return loaded;
        }
        //method that will check if a player exits and return the results as a bool
        public static bool CheckForPlayer(string name)
        {
            bool results;
            using (IDbConnection cnn = new SQLiteConnection(CreateConnectionString()))
            {
                var output = cnn.Query<PlayerCharacter>("SELECT * from Players WHERE Name Like @Name", new { Name = name});
                List<PlayerCharacter> tempList = output.ToList();
                if (tempList.Count > 0)
                {
                    results = true;
                }
                else 
                {
                    results = false;
                }
            }
            return results;
        }
    }
}
