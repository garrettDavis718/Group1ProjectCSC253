using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static World.WorldDelegates;

namespace World
{
    //Item Class used for creating item objects and storing them in our item list, will be used in future iterations
    public class Item
    {
        ShowUserMessage message1 = Write;
        ShowUserMessage message2 = WriteLine;

        //constructors
        public int ID { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int LocationID { get; set; }


        //Item Custom constructor
        public Item()
        {
            
        }
        public Item(int id, string name, string desc)
        {
            ID = id;
            Name = name;
            Desc = desc;
        }
        public Item(int id, string name, double weight, string desc)
        {
            ID = id;
            Weight = weight;
            Name = name;
            Desc = desc;
        }
        //Overload for Items that need a location
        public Item(int id, string name, double weight, string desc, int locationID)
        {
            ID = id;
            Weight = weight;
            Name = name;
            Desc = desc;
            LocationID = locationID;
        }
        public static void DropItem(string droppedItem, PlayerCharacter user)
        {
            Room room = Map.GetLocation(user);
            for (int i = 0; i < user.Inventory.Count; i++)
            {
                if (user.Inventory[i].Name.ToLower().Equals(droppedItem.ToLower()))
                {
                    Arrays.Map[user.XLocation, user.YLocation].Inventory.Add(user.Inventory[i]);
                    user.Inventory.RemoveAt(i);
                    Console.WriteLine("Dropped " + droppedItem + " in " + room);
                }
                else
                {
                    Console.WriteLine("No item by this name");
                }
            }
        }
        public static void TakeItem(Item item, PlayerCharacter user)
        {
            if (user.Weight < 50)
            {
                user.Inventory.Add(item);
            }
            else
            {
                //Console writeline, needs fix
                WriteLine("You are too heavy to pick this item up.");
            }
            
        }
        
        





    }
}
