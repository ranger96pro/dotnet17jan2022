using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    public partial class Coords
    {
        private int x;
        private int y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Coords
    {
        public void PrintCoords()
        {
            Console.WriteLine("Coords: {0},{1}", x, y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Coords myCoords = new Coords(10, 15);
            myCoords.PrintCoords();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
