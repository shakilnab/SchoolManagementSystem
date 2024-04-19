using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject;

public class HomePage
{
    public static void Homepage()
    {
        while (true)
        {
            Console.WriteLine("Please login:");
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.WriteLine();

            using (var db = new FinalProjectDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    if (user.UserType == "Admin")
                    {
                        LogInLogOut.AdminLogIn(username, password);
                    }
                    else if (user.UserType == "Teacher")
                    {
                        LogInLogOut.TeacherLogIn(username, password);
                    }
                }

                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }
        }
    }
}
