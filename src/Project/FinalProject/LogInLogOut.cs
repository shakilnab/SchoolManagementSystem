using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject;

public class LogInLogOut
{
    //-------------------
    //Admin log-in method
    //-------------------
    public static void AdminLogIn(string username, string password)
    {
        using (var db = new FinalProjectDbContext())
        {
            var admin = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.UserType == "Admin");
            if (admin != null)
            {
                Console.WriteLine("Welcome admin, please select an option: ");
                MainMenu.AdminMainMenu();
            }
            else
            {
                Console.WriteLine("Log in failed. Please try again.");
            }
        }
    }

    //---------------------
    //Teacher log-in method
    //---------------------
    public static void TeacherLogIn(string username, string password)
    {
        using (var db = new FinalProjectDbContext())
        {
            var teacher = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.UserType == "Teacher");
            var teacherAgain = db.Teachers.FirstOrDefault(u => u.UserName == username);
            if (teacher != null)
            {
                Console.WriteLine("Welcome " + teacherAgain.TeacherName+", Please select an option:");
                MainMenu.TeacherMainMenu(teacherAgain.Id);
            }
            else
            {
                Console.WriteLine("Log in failed. Please try again.");
            }
        }
    }
    //------------------------------
    //Log out method (Admin-Teacher)
    //------------------------------
    public static void LogOut()
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("Logged out. Thanks for using our application.");
        Console.WriteLine("=============================================");
        
        Console.WriteLine();
        HomePage.Homepage();
    }
}
