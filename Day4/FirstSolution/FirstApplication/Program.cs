using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World");
            Program p = new Program();
            p.Greet("Nihao");
            Console.ReadKey();
        }
        void PrintName()
        {
            Console.WriteLine("HELLO G3");
        }
        void PrintAnyName(string name)
        {
            Console.WriteLine("HELLO "+ name);
        }
        void Greet(string greet)
        {
            string name;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine(greet+" "+name)
        }
    }
}
