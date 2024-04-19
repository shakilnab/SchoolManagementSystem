using System;
using System.Linq;

namespace FinalProject;

public partial class AdminFunctionality
{
    //----------------------------------------
    // Method for creating a class. (Option 1)
    //----------------------------------------
    public static void CreateClass()
    {
        using (var db = new FinalProjectDbContext())
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Provide following information to create a class:");
            Console.Write("Class name: ");
            var name = Console.ReadLine();

            var newClass = new ClassS { ClassName = name };
            db.Classes.Add(newClass);
            db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Class created successfully.✓✓✓");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }
    }

    //------------------------------------------
    // Method for creating a subject. (Option 2)
    //------------------------------------------
    public static void CreateSubject()
    {
        using (var db = new FinalProjectDbContext())
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Provide following information to create a subject:");
            Console.Write("Subject name: ");
            var name = Console.ReadLine();

            var newSubject = new Subject { SubjectName = name };
            db.Subjects.Add(newSubject);
            db.SaveChanges();

            Console.WriteLine();
            Console.WriteLine("Subject created successfully.✓✓✓");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }

    //------------------------------------------
    // Method for creating a teacher. (Option 3)
    //------------------------------------------
    public static void CreateTeacher()
    {
        using (var db = new FinalProjectDbContext())
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Provide following information to create a teacher:");
            Console.Write("Teacher name: ");
            var name = Console.ReadLine();
            Console.Write("Teacher username: ");
            var username = Console.ReadLine();
            Console.Write("Teacher password: ");
            var password = Console.ReadLine();

            var newUser = new User { Username = username, Password = password, UserType = "Teacher" };
            db.Users.Add(newUser);
            db.SaveChanges();

            var newTeacher = new Teacher { TeacherName = name, UserName = username };
            db.Teachers.Add(newTeacher);
            db.SaveChanges();

            Console.WriteLine();
            Console.WriteLine("Teacher created successfully.✓✓✓");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }
}



