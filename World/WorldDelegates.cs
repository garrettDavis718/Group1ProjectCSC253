using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
using System.Collections; // May Not be necessary

namespace World
{
    public class WorldDelegates
    {
        public delegate void ShowUserMessage(string message);

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void Write(string message)
        {
            Console.Write(message);
        }
    }
}
