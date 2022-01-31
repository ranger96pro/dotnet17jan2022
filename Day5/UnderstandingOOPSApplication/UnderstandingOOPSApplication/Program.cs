﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApplication
{
    class Program
    {
        int iInstanceNum1 = 0;
        static int iStaticNum1 = 0;
        static void Main(string[] args)
        {
            Program p1 = new Program();
            Program p2 = new Program();
            Console.WriteLine("Values before increment");
            Console.WriteLine("P1");
            p1.PrintValues();
            Console.WriteLine("P2");
            p2.PrintValues();
            p1.Increment();
            Console.WriteLine("Values After increment");
            Console.WriteLine("P1");
            p1.PrintValues();
            p2.Increment();
            Console.WriteLine("P2");
            p2.PrintValues();
            Console.ReadLine();
        }
        void Increment()
        {
            iInstanceNum1++;
            iStaticNum1++;
        }
        void PrintValues()
        {
            Console.WriteLine("The value of instance num1 is {0}", iInstanceNum1);
            Console.WriteLine("The value of static num1 is {0}", iStaticNum1);
        }
    }
}
