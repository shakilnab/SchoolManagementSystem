using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace FinalProject;

public partial class TeacherFunctionality
{
    //------------------------------------
    // Method for Add Student. (Option 1)
    //------------------------------------
    public static void AddStudent(int teacherId)
    {

        using (var db = new FinalProjectDbContext())
        {
            var teacherClassses = db.ClassSubjectTeachers
                .Where(cst => cst.TeacherId == teacherId)
                .Select(cst => cst.ClassId)
                .ToHashSet();

            if (teacherClassses.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You are not assigned to any class.");
                Console.WriteLine("==================================");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Classes assigned to you: ");
            foreach(var classId in teacherClassses)
            {
                var classsName = db.Classes.Find(classId)?.ClassName;
               
                Console.WriteLine("  "+classsName);
                

            }

            Console.WriteLine("Provide following information to add a student to a specific class:");
            Console.Write("Enter class name: ");

            var className = Console.ReadLine();
            var selectedClass = db.Classes.FirstOrDefault(c => c.ClassName == className && teacherClassses.Contains(c.Id));
            if (selectedClass == null)
            {
                Console.WriteLine();
                Console.WriteLine("You are not assigned to this class.");
                Console.WriteLine("===================================");
                Console.WriteLine();
                return;
            }

            Console.Write("Enter student name: ");
            var studentName = Console.ReadLine();
            Console.WriteLine();
            var newStudent = new Student
            {
                StudentName = studentName,
                ClassS = selectedClass
            };

            db.Students.Add(newStudent);
            db.SaveChanges();
            Console.WriteLine("Student added successfully.");
            Console.WriteLine("===========================");
            Console.WriteLine();
        }
    }
    //------------------------------------
    // Method for Show Student. (Option 2)
    //------------------------------------
    public static void ShowStudent(int teacherId)
    {
        using(var db = new FinalProjectDbContext())
        {
            Console.WriteLine("Provide following information to show students:");
            //Console.WriteLine();
            Console.Write("Enter class name: ");
            var className = Console.ReadLine();
            Console.WriteLine();

            var selectedClass = db.Classes.FirstOrDefault(c => c.ClassName == className);
            if(selectedClass==null)
            {
                Console.WriteLine("Class not found.");
                Console.WriteLine("================");
                return;
            }
            var studentInClass = db.Students.Where(s => s.ClassId == selectedClass.Id).ToList();
            Console.WriteLine("Students in "+ selectedClass.ClassName);

            if (studentInClass.Count() == 0)
            {
                Console.WriteLine("There is no student in this class.");
                Console.WriteLine("==================================");
                Console.WriteLine();
                return;
            }

            var studentForPrint = db.Students
                .Where(s => s.ClassId == selectedClass.Id)
                    .Select(c => new { c.Id, c.StudentName }).ToList();

            ConsoleTable.From(studentForPrint).Write();
            Console.WriteLine();
            



            if (studentInClass.Count() != 0)
            {
                Console.WriteLine("What you want to do?");
                Console.WriteLine("1) Edit student name.");
                Console.WriteLine("2) Delete student.");
                Console.WriteLine("3) Go to main menu.");
                Console.Write("Enter your choice: ");
                var teacherChoice = Console.ReadLine();
                Console.WriteLine();

                switch (teacherChoice)
                {
                    case "1":
                        EditStudent(teacherId);
                        break;
                    case "2":
                        DeleteStudent(teacherId);
                        break;
                    case "3":
                        MainMenu.TeacherMainMenu(teacherId);
                        break;                  

                }

            }


        }

    }
    
    
}

