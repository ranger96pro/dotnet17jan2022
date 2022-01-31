using System;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.testSolution();
            Console.ReadKey();

        }
        void BinaryGap()
        {

            int gap = 0;
            int maxGap = 0;
            long num1;
            while (!long.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Please enter a valid number.");
            }
            string binary = Convert.ToString(num1, 2);
            foreach (var item in binary)
            {
                if (Int32.Parse(item.ToString()) == 0)
                {
                    gap++;
                }
                else if (Int32.Parse(item.ToString()) == 1)
                {
                    if (gap > maxGap)
                    {
                        maxGap = gap;
                    }
                    gap = 0;
                }
            }
            Console.WriteLine("The longest gap is:" + maxGap);

        }
        void Day6Q1()
        {
            long num1 = 0;
            bool valid = false;
            while (!valid)
            {
                while (!long.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Please enter a valid number");
                }
                if (num1>9999999999999999 || num1 < 1000000000000000)
                {
                    Console.WriteLine("Please enter a 16 digit number.");
                }
                else
                {
                    valid = true;
                }
            }
            string numStr = num1.ToString();
            string reverseNumStr = "";
            for (int i = 0; i <numStr.Length; i++)
            {
                reverseNumStr += numStr[numStr.Length - i-1];
            }
            long reversedNum = long.Parse(reverseNumStr);
            Console.WriteLine("Reversed number:" + reverseNumStr);
            int count = 0;
            int sumDblDigit = 0;
            foreach (var item in reverseNumStr)
            {
                //Console.WriteLine(item);
                if (count%2==1)
                {
                    if (Int32.Parse(item.ToString()) * 2 > 9)
                    {
                        int tempConvert = Int32.Parse(item.ToString()) * 2;
                        //Console.WriteLine(tempConvert);
                        //Console.WriteLine(tempConvert.ToString()[0]);
                        //Console.WriteLine(tempConvert.ToString()[1]);
                        sumDblDigit += tempConvert % 10;
                        sumDblDigit += (tempConvert - (tempConvert % 10))/10;

                    }
                    else
                    {
                        //Console.WriteLine(Int32.Parse(item.ToString()));
                        sumDblDigit += 2*Int32.Parse(item.ToString());


                    }
                }
                else
                {
                    //Console.WriteLine(Int32.Parse(item.ToString()));
                    sumDblDigit += Int32.Parse(item.ToString());
                    //Console.WriteLine(sumDblDigit);
                }
                //Console.WriteLine(sumDblDigit);
                count++;
            }
            //Console.WriteLine(sumDblDigit);

            int check = sumDblDigit % 10;
            if (check == 0)
            {
                Console.WriteLine("Is Valid");
            }
            else
            {
                Console.WriteLine("Is not Valid");
            }

        }
        void Day6Q2()
        {
            Console.WriteLine("Enter 11 numbers.");
            int[] num = new int[11];
            for (int i = 0; i < num.Length; i++)
            {
                while (!Int32.TryParse(Console.ReadLine(),out num[i]))
                {
                    Console.WriteLine("please enter a number");
                }
            }
            string numStr = num.ToString();
            for (int i = 0; i < num.Length; i++)
            {
                bool repeat = false;
                for (int a = 0; a < num.Length; a++)
                {
                    if (!(i == a))
                    {
                        if (num [i] == num[a])
                        {
                            repeat = true;
                        }
                    }
                }
                if (!repeat)
                {
                    Console.WriteLine(num[i]);
                }
            }
        }
        void testSolution()
        {
            int N = 8;
            string bits = Convert.ToString(N, 2);
            int longest = 0;
            int count = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                    count++;

                else
                {
                    longest = Math.Max(count, longest);
                    count = 0;
                }
            }
            Console.WriteLine(longest); ;
        }

    }
}
