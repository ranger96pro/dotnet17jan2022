using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Doctor : User
    {
        string experience;
        string speciality;
        public Doctor()
        {
        }

        public Doctor(int uId, string uName, string uPassword, int uAge) : base(uId, uName, uPassword, uAge)
        {
            id = uId;
            name = uName;
            password = uPassword;
            age = uAge;
        //    DateTime dt = new DateTime(2022, 02, 22, 8, 30, 0);
        //    apptList.Add(new Appointment(1, 101,2, dt));
        //    dt = new DateTime(2022, 01, 24, 10, 00, 0);
        //    apptList.Add(new Appointment(2, 1,1, dt));
        }
        public string Experience { get; set; }
        public string Speciality { get; set; }
        public void raisePaymentReq()
        {
            printPastAppointment();
            Console.WriteLine("Enter the appointment id");
            int optionNo;
            while (!Int32.TryParse(Console.ReadLine(), out optionNo))
            {

                Console.WriteLine("Please enter a valid option");
            }
            bool exist = false;
            foreach (var item in apptList)
            {
                if (optionNo == item.getID())
                {
                    exist = true;
                    string remarks = "";
                    int amtToCollect = 0;
                    Console.WriteLine("Please enter any remarks:");
                    remarks = Console.ReadLine();
                    Console.WriteLine("Enter amount to collect.");
                    while (!Int32.TryParse(Console.ReadLine(),out amtToCollect))
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                    item.addPayment(remarks, amtToCollect);
                }
            }
            if (!exist)
            {
                Console.WriteLine("Invalid appt id.");
            }
        }

        public override void optionCaller()
        {
            bool exit = false;
            while (!exit)
            {
                int optionNo;
                Console.WriteLine("Choose from the options \n1.View  your appointments \n2.View your past appointments \n3. Raise payment request for an appointment\n0.Exit");
                while (!Int32.TryParse(Console.ReadLine(), out optionNo))
                {
                    Console.WriteLine("Please enter a valid option");
                }
                if (optionNo == 1)
                {
                    printAllAppointment();
                }
                else if (optionNo == 2)
                {
                    printPastAppointment();
                }
                else if (optionNo == 3)
                {
                    raisePaymentReq();
                }
                else if (optionNo == 0)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                    optionCaller();
                }
            }
        }
    }
}
