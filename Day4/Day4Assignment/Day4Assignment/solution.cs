using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Assignment
{
    class solution
    {
        private int question;

        public void qn1(int num)
        {
            if (num > 0)
            {
                for (int i = 0; i <= num; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public void qn2(int num)
        {
            if(num % 2 == 1)
            {
                Console.WriteLine("Odd number");
            }
            else
                Console.WriteLine("Even Number");
        }

        public void qn3(int num1, int num2)
        {
            if (num1 > num2)
            {
                Console.WriteLine(num1 + "is the greater number");
            }
            else if (num1 < num2)
            {
                Console.WriteLine(num2 + "is the greater number");
            }
            else
                Console.WriteLine("The numbers are equal");
        }
        public void qn4(int num1, int num2,int num3)
        {
            int theGreaternum = num1;
            theGreaternum = compareGreater(theGreaternum, num2);
            theGreaternum = compareGreater(theGreaternum, num3);
            Console.WriteLine(theGreaternum + " is the greater number.");

        }
        public int compareGreater(int num1,int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
                return num2;
        }
        public void qn5(int num1,int num2)
        {
            if (num1 > num2)
            {
                printBetweenNum(num2, num1);
            }
            else
                printBetweenNum(num1, num2);
        }
        public void printBetweenNum(int num1,int num2)
        {
            for (int i = num1; i < num2; i++)
            {
                Console.WriteLine(i);
            }
        }
        public void qn6(int num1)
        {
            bool prime = true;
            if (num1 > 1)
            {
                for (int i = 2; i < num1; i++)
                {
                    if (num1 % i == 0)
                    {
                        prime = false;
                    }
                }
            }
            else
                prime = false;

            if (prime)
            {
                Console.WriteLine(num1 + " is prime number.");
            }
            else
                Console.WriteLine(num1 + " is not prime number.");
        }
        public void qn7(int num1, int num2)
        {
            if (num1 > num2)
            {
                printBetweenNumQ7(num2, num1);
            }
            else
                printBetweenNumQ7(num1, num2);
        }
        public void printBetweenNumQ7(int num1, int num2)
        {
            for (int i = num1; i < num2; i++)
            {
                qn6(i);
                //Console.WriteLine(i);
            }
        }
        public void qn8()
        {
            int sum = 0;
            int num1 = Int32.Parse(Console.ReadLine());
            while (num1 > 0)
            {
                if(num1%7 == 0)
                {
                    sum += num1;
                }
                num1 = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Total number is:" + sum);
        }
        public void qn9(int num1)
        {
            int num1st = 0;
            int num2nd = 0;
            int num3rd = 0;
            int num4th = 0;
            if (num1 > 999 && num1 < 10000)
            {
                num4th = num1 % 10;
                num3rd = ((num1 - num4th) % 100) / 10;
                num2nd = ((num1 - num4th - num3rd * 10) % 1000) / 100;
                num1st = ((num1 - num4th - num3rd * 10 - num2nd * 100) % 10000) / 1000;
                int sum = num1st + num2nd + num3rd + num4th;
                Console.WriteLine("Result is: " + sum);
            }
            else
                Console.WriteLine("Enter a number between 1000-9999");
        }
        public void qn10(int num1)
        {
            int num1st = 0;
            int num2nd = 0;
            int num3rd = 0;
            int num4th = 0;
            if (num1 > 999 && num1 < 10000)
            {
                num4th = num1 % 10;
                num3rd = ((num1 - num4th) % 100) / 10;
                num2nd = ((num1 - num4th - num3rd * 10) % 1000) / 100;
                num1st = ((num1 - num4th - num3rd * 10 - num2nd * 100) % 10000) / 1000;

                if (num1st == num4th && num2nd == num3rd)
                {
                    Console.WriteLine(num1 + " is plaindrome.");
                }
                else
                    Console.WriteLine(num1 + " is not Plaindrome.");
            }
        }
        public void qn11(int num1,int num2)
        {
            int total = num1;
            for (int i = 1; i < num2; i++)
            {
                total = total * num1;
            }
            Console.WriteLine(num1 + " to the power of "+num2+" is:"+total);
        }
        public void qn12(int num1)
        {
            int curNum = num1;
            while (curNum > 9)
            {
                curNum = checkHappy(curNum);
            }
            if (curNum == 1)
            {
                Console.WriteLine(num1 +" is a happy number.");
            }
            else
                Console.WriteLine(num1 + " is not a happy number.");

        }
        private int checkHappy(int num1)
        {
            int rem = 0, sum = 0;
            while (num1 > 0)
            {
                rem = num1 % 10;
                sum = sum + (rem * rem);
                num1 = num1 / 10;
            }
            return sum;
        }
    }
}