using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class User
    {
        protected int id;
        protected string name;
        protected string userName;
        protected string password;
        protected int age;
        protected List<Appointment> apptList = new List<Appointment>();
        public User()
        {

        }
        public User(int uId,string uName,string uPassword,int uAge)
        {
            id = uId;
            name = uName;
            userName = name + id.ToString();
            password = uPassword;
            age = uAge;


        }
        public void passAppt(List<Appointment> apptListTemp)
        {
            apptList = apptListTemp;
        }
        public string UserName { 
            get
            { return userName; }
            set
            {
                userName = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public virtual void AddAppointment(int apptId,out int rApptId)
        {
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
            Console.WriteLine("Appointment for " + num + " is at " + dt.ToString("dd/MM/yyyy HH:mm"));
            apptList.Add(new Appointment(apptId, num, dt));
            rApptId = apptId;
            rApptId++;
        }
        public virtual void printAllAppointment()
        {
            var myAppoint = apptList.Where(e => e.getPID() == id || e.getDID() == id);
            foreach (var item in myAppoint)
            {
                item.printAppointment();
            }
            //foreach (var item in apptList)
            //{
            //    if (id == item.getPID() || id == item.getDID())
            //    {
            //        item.printAppointment();
            //    }
            //}
        }
        public virtual void printPastAppointment()
        {
            var myAppoint = apptList.Where(e => DateTime.Compare(DateTime.Now, e.getDt()) > 0 && (e.getPID() == id || e.getDID() == id) );

            foreach (var item in myAppoint)
            {
                item.printAppointment();
            }
            //foreach (var item in apptList)
            //{
            //    if (DateTime.Compare(DateTime.Now, item.getDt()) > 0)
            //    {
            //        if (id == item.getPID() || id == item.getDID())
            //        {
            //            item.printAppointment();
            //        }
            //    }
            //}
        }
        public virtual void printFutureAppointment()
        {
            var myAppoint = apptList.Where(e => DateTime.Compare(DateTime.Now, e.getDt()) < 0 && (e.getPID() == id || e.getDID() == id));

            foreach (var item in myAppoint)
            {
                item.printAppointment();
            }
            //foreach (var item in apptList)
            //{
            //    if (DateTime.Compare(DateTime.Now, item.getDt()) < 0)
            //    {
            //        if (id == item.getPID() || id == item.getDID())
            //        {
            //            item.printAppointment();
            //        }
            //    }
            //}
        }
        public virtual void optionCaller()
        {
            bool exit = false;
            while (!exit)
            {
                int optionNo;
                Console.WriteLine("Choose from the options \n1.View  your appointments \n2.View your past appointments\n0.Exit");
                while (!Int32.TryParse(Console.ReadLine(),out optionNo))
                {
                    Console.WriteLine("Please enter a valid option");
                }
                if (optionNo == 1)
                {
                    printAllAppointment();
                }
                if (optionNo == 2)
                {
                    printPastAppointment();
                }
            }
            
        }
    }
}
