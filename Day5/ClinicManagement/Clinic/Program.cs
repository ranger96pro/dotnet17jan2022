using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Program
    {
        
        Doctor doc = new Doctor(1, "john", "abc", 20);
        Patient pat = new Patient(101, "mary", "abc", 30);
        List<Appointment> apptList = new List<Appointment>();
        static void Main(string[] args)
        {
            //List<Appointment> apptList = new List<Appointment>();
            //DateTime dt = new DateTime(2022, 02, 22, 8, 30, 0);
            //Appointment[] apptArr = new Appointment[2];
            //apptArr[0] = new Appointment(1, 101, dt);
            //apptList.Add(new Appointment(1, 101, dt));
            //dt = new DateTime(2022, 01, 24, 10, 00, 0);
            //apptArr[1] = new Appointment(2, 102,dt);
            //apptList.Add(new Appointment(2, 102, dt));

            //foreach (var item in apptList)
            //{
            //    item.printAppointment();
            //}

            
            Program p = new Program();
            //p.apptList

            DateTime dt = new DateTime(2022, 02, 22, 8, 0, 0);
            p.apptList.Add(new Appointment(1, 101, 1, dt));
            dt = new DateTime(2022, 01, 24, 10, 00, 0);
            p.apptList.Add(new Appointment(2, 101, 1, dt));
            p.doc.passAppt(p.apptList);
            p.pat.passAppt(p.apptList);
            p.startUp();
            Console.ReadKey();
        }
        void startUp()
        {
            int optionNo;
            Console.WriteLine("Welcome to the clinic \nKey in 1 if you are a doctor\nkey in 2 if you are a patient\nKey in 3 to exit");
            while (!Int32.TryParse(Console.ReadLine(), out optionNo))
            {
                Console.WriteLine("Please enter a valid option");
            }
            if (optionNo == 1)
            {
                Console.WriteLine("Please enter your username");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                string password = Console.ReadLine();
                if (username == doc.UserName && password == doc.Password)
                {
                    doc.optionCaller();
                }
                else
                {
                    Console.WriteLine("Wrong pw or username");
                }
                startUp();
            }
            else if (optionNo == 2)
            {
                Console.WriteLine("Please enter your username");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                string password = Console.ReadLine();
                if (username == pat.UserName && password == pat.Password)
                {
                    pat.optionCaller();
                }
                else
                {
                    Console.WriteLine("Wrong pw or username");
                }
                startUp();
            }
            else if (optionNo == 3)
            {
                Console.WriteLine("Exiting");
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
                startUp();
            }
        }
    }
}
