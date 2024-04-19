using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject;

public partial class TeacherFunctionality
{

    //--------------------------------------
    // Method for Edit Student. (Option 2.1)
    //--------------------------------------
    public static void EditStudent(int teacherId)
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
                Console.WriteLine("You are not assigned to any class. You do not have edit permission.");
                Console.WriteLine("===================================================================");
                return;
            }
            Console.WriteLine("Classes assigned to you: ");
            foreach (var classId in teacherClassses)
            {
                var classsName = db.Classes.Find(classId)?.ClassName;

                Console.WriteLine("  " + classsName);


            }

            Console.WriteLine("Provide following information to edit a student data:");
            //Console.WriteLine();
            Console.Write("Enter class name: ");
            var className = Console.ReadLine();
            var selectedClass = db.Classes.FirstOrDefault(c => c.ClassName == className && teacherClassses.Contains(c.Id));
            if (selectedClass == null)
            {
                Console.WriteLine();
                Console.WriteLine("You are not assigned to this class.");
                Console.WriteLine("===================================");
                return;
            }

            Console.Write("Enter student previous name: ");
            var studentPreviousName = Console.ReadLine();
            Console.Write("Enter student new name: ");
            var studentNewName = Console.ReadLine();

            Console.WriteLine();

            var studentToEdit = db.Students.FirstOrDefault(s => s.StudentName == studentPreviousName);
            if (studentToEdit != null)
            {
                studentToEdit.StudentName = studentNewName;
                db.SaveChanges();
                Console.WriteLine("Student name updated successfully.✓✓✓");
                Console.WriteLine("=====================================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Student not found. ❌ Try again.");
                Console.WriteLine("================================");
                Console.WriteLine();
            }
        }
    }



    //----------------------------------------
    // Method for Delete Student. (Option 2.2)
    //----------------------------------------
    public static void DeleteStudent(int teacherId)
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
                Console.WriteLine("You are not assigned to any class. You do not have delete permission.");
                Console.WriteLine("===================================================================");
                return;
            }
            Console.WriteLine("Classes assigned to you: ");
            foreach (var classId in teacherClassses)
            {
                var classsName = db.Classes.Find(classId)?.ClassName;

                Console.WriteLine("  " + classsName);


            }

            Console.WriteLine("Provide following information to delete a student:");
            //Console.WriteLine();
            Console.Write("Enter class name: ");
            var className = Console.ReadLine();
            var selectedClass = db.Classes.FirstOrDefault(c => c.ClassName == className && teacherClassses.Contains(c.Id));
            if (selectedClass == null)
            {
                Console.WriteLine();
                Console.WriteLine("You are not assigned to this class.");
                Console.WriteLine("===================================");
                return;
            }

            Console.Write("Enter student name: ");
            var studentToDeleteName = Console.ReadLine();
            Console.Write("Enter student Id: ");
            var studentToDeleteId =int.Parse(Console.ReadLine()) ;

            var studentToDelete = db.Students.FirstOrDefault(s => s.Id==studentToDeleteId && s.StudentName==studentToDeleteName);

            if (studentToDelete != null)
            {
                db.Students.Remove(studentToDelete);
                Console.WriteLine();
                Console.WriteLine("Student deleted successfully.✓✓✓");
                Console.WriteLine("================================");
                Console.WriteLine();
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Student not found. ❌ Please try again.");
                Console.WriteLine("=======================================");
                Console.WriteLine();
            }
        }
    }
    
}
