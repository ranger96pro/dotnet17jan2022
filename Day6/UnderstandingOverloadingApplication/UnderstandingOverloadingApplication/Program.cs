using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOverloadingApplication
{
    class Program
    {
        public Program()
        {

        }
        public Program(int i)
        {
            Console.WriteLine("overloaded");
        }
        void Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("The sum of {0} and {1} is {2}",num1,num2,sum);

        }
        void Add(int num1)
        {
            int sum = num1++;
            Console.WriteLine("The incremented value of {0} is {1}",num1,sum);
        }
        void Add(string str1,string str2)
        {
            string res = str1 + " " + str2;
            Console.WriteLine("The Concat value of {0} and {1} is {2}");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Add("Hello", "World");
            program.Add(10, 20);
            program.Add(20);

            Console.ReadKey();
        }
    }
}
