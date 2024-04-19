using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject;

public class MainMenu
{
    //----------------------
    //Admin main menu method
    //----------------------
    public static void AdminMainMenu()
    {
        while (true)
        {
            Console.WriteLine("1) Create class.");
            Console.WriteLine("2) Create subject.");
            Console.WriteLine("3) Create teacher.");
            Console.WriteLine("4) View classes.");
            Console.WriteLine("5) View subjects.");
            Console.WriteLine("6) View teachers.");
            Console.WriteLine("7) Log out.");
            Console.WriteLine("8) Exit.");

            
            Console.Write("Enter your choice: ");
            
            string adminChoice = Console.ReadLine();
            Console.WriteLine();

            switch (adminChoice)
            {
                case "1":
                    AdminFunctionality.CreateClass();
                    break;
                case "2":
                    AdminFunctionality.CreateSubject();
                    break;
                case "3":
                    AdminFunctionality.CreateTeacher();
                    break;
                case "4":
                    AdminFunctionality.ViewClasses();
                    break;
                case "5":
                    AdminFunctionality.ViewSubjects();
                    break;
                case "6":
                    AdminFunctionality.ViewTeachers();
                    break;
                case "7":
                    LogInLogOut.LogOut();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;       
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    //------------------------
    //Teacher main menu method
    //------------------------
    public static void TeacherMainMenu(int teacherId)
    {
        
        while (true)
        {
            Console.WriteLine("1) Add students.");
            Console.WriteLine("2) Show students.");
            Console.WriteLine("3) Insert grades.");
            Console.WriteLine("4) View grades.");
            Console.WriteLine("5) Log out.");
            Console.WriteLine("6) Exit.");
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine("Note: You can view all classes students but can not manipulate.");
            Console.WriteLine("You can only manipulate if you are assigned. Thank you.");
            Console.WriteLine("===============================================================");
            Console.WriteLine();



            Console.Write("Enter your choice: ");

            string teacherChoice = Console.ReadLine();
            Console.WriteLine();

            switch (teacherChoice)
            {
                case "1":
                    TeacherFunctionality.AddStudent(teacherId);
                    break;
                case "2":
                    TeacherFunctionality.ShowStudent(teacherId);
                    break;
                case "3":
                    TeacherFunctionality.InsertGrade(teacherId);
                    break;
                case "4":
                    TeacherFunctionality.ViewGrade(teacherId);
                    break;
                case "5":
                    LogInLogOut.LogOut();                    
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

