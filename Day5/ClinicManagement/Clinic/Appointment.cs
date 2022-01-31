using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Appointment
    {
        int id;
        int pId;
        public int dId { get; set; }
        DateTime dt;
        string remarks = "";
        string status = "";
        bool raised = false;
        bool paid = false;
        int amountToPay = 0;
        public Appointment()
        {

        }
        public Appointment(int num, int num2, int num3, DateTime aDt)
        {
            id = num;
            pId = num2;
            dId = num3;
            dt = aDt;
        }
        public Appointment(int num, int num2, DateTime aDt)
        {
            id = num;
            pId = num2;
            dId = 1;//default doctor
            dt = aDt;
        }
        public void printAppointment()
        {
            Console.WriteLine("Appointment Id: " + id);
            Console.WriteLine("Patient Id: " + pId);
            Console.WriteLine("Doctor Id: " + dId);
            Console.WriteLine("Date: " + dt.ToString("dd/MM/yyyy"));
            Console.WriteLine("Time: " + dt.ToString("H:mm"));
            if (raised)
            {
                Console.WriteLine("Remarks: " + remarks);
                Console.WriteLine("Amount: " + amountToPay);
                if (paid)
                {
                    Console.WriteLine("Payment status: Paid");
                }
                else
                {
                    Console.WriteLine("Payment status: Pending Payment");
                }
            }
        }
        public int getID()
        {
            return id;
        }
        public int getPID()
        {
            return pId;
        }
        public int getDID()
        {
            return dId;
        }
        public DateTime getDt()
        {
            return dt;
        }
        public void chgAppointmentDateTime(DateTime newDt)
        {
            dt = newDt;
        }
        public void addPayment(string rm,int amt)
        {
            raised = true;
            remarks = rm;
            amountToPay = amt;
            if (amountToPay == 0)
            {
                paid = true;
            }
            else
            {
                paid = false;
            }
        }
        public void payAppointment()
        {
            paid = true;
            amountToPay = 0;
        }
    }
}
