using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UnderstandingAddApplication
{
    class Program
    {
        SqlConnection conn;
        SqlCommand cmdInsert;

        class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        void RegisterUser()
        {
            cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "insert into tblUser values(@un,@pass,@name,@age)";
            cmdInsert.Connection = conn;
            User user = TakeUserDetailsFromConsole();
            cmdInsert.Parameters.Add("@un", SqlDbType.VarChar, 20);
            cmdInsert.Parameters[0].Value = user.Username;
            cmdInsert.Parameters.AddWithValue("@pass", user.Password);
            cmdInsert.Parameters.AddWithValue("@name", user.Name);
            cmdInsert.Parameters.AddWithValue("@age", user.Age);
            //conn.Open();
            int result = cmdInsert.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("User Registrerd");

        }
        User TakeUserDetailsFromConsole()
        {
            User user = new User();
            Console.WriteLine("Please enter your preferred username");
            user.Username = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter your password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Please Retype the password");
                string password = Console.ReadLine();
                if (password == user.Password)
                {
                    break;
                }
                Console.WriteLine("Password Mismatch.");
                Console.WriteLine("Lets  try again!!!");
            } while (true);
            Console.WriteLine("Please enter your full name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Please enter your age");
            user.Age = Convert.ToInt32(Console.ReadLine());
            return user;
        }
        void updatePassword()
        {
            //update tblUser set pass = 12345 where un = 'test123'
            cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "update tblUser set pass = 12345 where un = 'test123'";
            cmdInsert.Connection = conn;

            int result = cmdInsert.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("updated password for rows:" + result);

        }
        public Program()
        {
            conn = new SqlConnection(@"Data Source=;Integrated Security=true;Initial Catalog=dotnetTest;");
            conn.Open();
            Console.WriteLine("Connected");
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            program.updatePassword();
            Console.ReadKey();
        }
    }
}
