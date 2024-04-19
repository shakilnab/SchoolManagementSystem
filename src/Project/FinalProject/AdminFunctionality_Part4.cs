using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public partial class AdminFunctionality
    {

        //-------------------------------------
        //6th option method----->View Teachers
        //-------------------------------------
        public static void ViewTeachers()
        {
            using (var db = new FinalProjectDbContext())
            {
                var teachers = db.Teachers.ToList();
                var teachersAgain = db.Users.Where(t => t.UserType == "Teacher").ToList();

                Console.WriteLine("List of teachers available in the system:");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(" Teacher Name              | Username                     ");
                Console.WriteLine("----------------------------------------------------------");

                for (int i = 0; i < teachers.Count; i++)
                {
                    string teacherName = teachers[i].TeacherName.PadRight(25);
                    string username = teachersAgain[i].Username.PadRight(25);
                    Console.WriteLine($" {teacherName} | {username}  ");
                }

                Console.WriteLine();
                Console.WriteLine("Available teachers are viewed successfully.✓✓✓");
                Console.WriteLine("==========================================================");

                while (true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1. Edit teacher data.");
                    Console.WriteLine("2. Delete teacher.");
                    Console.WriteLine("3. Go to admin panel main menu.");
                    Console.Write("Enter your choice: ");
                    //Console.WriteLine();
                    var adminChoice = Console.ReadLine();

                    switch (adminChoice)
                    {
                        case "1":
                            EditTeacher();
                            break;
                        case "2":
                            DeleteTeacher();
                            break;
                        case "3":
                            MainMenu.AdminMainMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. ❌ Please try again.");
                            Console.WriteLine("====================================");
                            break;
                    }
                }
                
            }
        }




        //--------------------------------------
        //6-->>1 option method----->Edit teacher
        //--------------------------------------
        public static void EditTeacher()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.Write("Enter teacher username to edit: ");
                var username = Console.ReadLine();
                var teacherToEdit = db.Users.FirstOrDefault(u => u.Username == username);
                if(teacherToEdit==null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Teacher not found. ❌❌❌");
                    Console.WriteLine("==========================");
                    return;

                }

                Console.Write("Enter teacher new full name: ");
                var name = Console.ReadLine();
                Console.Write("Enter teacher new username: ");
                var newUsername = Console.ReadLine();
                Console.Write("Enter teacher new password: ");
                var newPassword = Console.ReadLine();

                var teacher = db.Users.FirstOrDefault(t => t.Username == username && t.UserType == "Teacher");
                var teacherAgain = db.Teachers.FirstOrDefault(t => t.UserName == username);
                if (teacher != null && teacherAgain != null)
                {
                    teacher.Username = newUsername;
                    teacher.Password = newPassword;

                    teacherAgain.TeacherName = name;
                    teacherAgain.UserName = newUsername;

                    db.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Teacher data updated successfully.✓✓✓");
                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                }
            }
        }

        //----------------------------------------
        //6-->>2 option method----->Delete teacher
        //----------------------------------------
        public static void DeleteTeacher()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.Write("Enter teacher username to remove: ");
                string username = Console.ReadLine();

                var teacher = db.Users.FirstOrDefault(t => t.Username == username && t.UserType == "Teacher");
                var teacherAgain = db.Teachers.FirstOrDefault(t => t.UserName == username);
                if (teacher != null && teacherAgain != null)
                {
                    db.Users.Remove(teacher);
                    db.Teachers.Remove(teacherAgain);
                    db.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Teacher removed successfully.✓✓✓");
                    Console.WriteLine("================================");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Teacher not found.❌❌❌");
                    Console.WriteLine("=========================");
                    Console.WriteLine();
                }
            }
        }
    }
}
