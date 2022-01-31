using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Patient : User
    {
        string remarks;
        string status;

        public Patient()
        {
        }

        public Patient(int uId, string uName, string uPassword, int uAge) : base(uId, uName, uPassword, uAge)
        {
            id = uId;
            name = uName;
            password = uPassword;
            age = uAge;
            remarks = "";
            status = "";
        }
        public override void optionCaller()
        {
            bool exit = false;
            while (!exit)
            {
                int optionNo;
                Console.WriteLine("Choose from the options \n1.View  your appointments \n2.View your past appointments \n3. Pay for an appointment\n4. Make new appointment\n0.Exit");
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
                    DoPayment();
                }
                else if (optionNo == 4)
                {
                    AddAppointment();
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
        public void DoPayment()
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
                    item.payAppointment();
                }
            }
            if (!exist)
            {
                Console.WriteLine("Invalid appt id.");
            }
        }
        public virtual void AddAppointment()
        {
            int apptId = apptList.Count + 1;
            Console.WriteLine("Please enter your Id");
            int num;
            while (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Please enter a valid id.");
            }
            Console.WriteLine("Please enter the date.");
            DateTime dt;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry");

            }
            Console.WriteLine("Enter timeslot");
            int hour = 0;
            bool validTime = false;
            while (!validTime)
            {
                while (!Int32.TryParse(Console.ReadLine(), out hour))
                {
                    Console.WriteLine("Please enter a valid time");
                }
                if (hour > 17 || hour < 8)
                {
                    Console.WriteLine("Please enter a valid time");
                }
                else
                {
                    validTime = true;
                }
            }
            TimeSpan ts = new TimeSpan(hour, 0, 0);
            dt = dt.Date + ts;
            bool avail = true;
            foreach (var item in apptList)
            {
                if (dt == item.getDt() && item.getDID() == 1)
                {
                    avail = false;
                    Console.WriteLine("Appointment slot taken unavailable to book at this timing.");
                }
            }
            if (avail)
            {
                Console.WriteLine("Appointment for " + num + " is at " + dt.ToString("dd/MM/yyyy HH:mm"));
                apptList.Add(new Appointment(apptId, num, dt));
            }
        }

    }
}
