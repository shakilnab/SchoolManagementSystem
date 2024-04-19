using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
namespace FinalProject;

public partial class TeacherFunctionality
{
    //-----------------------
    // 3. Insert Grade Mathod
    //-----------------------
    public static void InsertGrade(int teacherId)
    {
        using (var db = new FinalProjectDbContext())
        {
            var teacherClassses = db.ClassSubjectTeachers
                .Where(cst => cst.TeacherId == teacherId)
                .Select(cst => cst.ClassId)
                .ToHashSet();

            if (teacherClassses.Count == 0)
            {
                Console.WriteLine("You are not assigned to any class.");
                Console.WriteLine("==================================");
                Console.WriteLine();

                return;
            }
            Console.WriteLine("Classes assigned to you: ");
            foreach (var classId in teacherClassses)
            {
                var classsName = db.Classes.Find(classId)?.ClassName;
                Console.WriteLine("  " + classsName);
            }

            Console.Write("Enter class name: ");
            var className = Console.ReadLine();

            var classsId = db.Classes.Where(c => c.ClassName == className).Select(c => c.Id).FirstOrDefault();
            var classExist = db.ClassSubjectTeachers.FirstOrDefault(c => c.ClassId == classsId && c.TeacherId == teacherId);
            if (classExist == null)
            {
                Console.WriteLine();
                Console.WriteLine("You are not assigned to this class.");
                Console.WriteLine("===================================");
                Console.WriteLine();
                return;
            }



            var teacherSubjectClasses = db.ClassSubjectTeachers
                .Where(cst => cst.TeacherId == teacherId)
                .Select(cst => cst.SubjectId)
                .ToHashSet();
            if (teacherSubjectClasses.Count == 0)
            {
                Console.WriteLine("You are not assigned to any subjects.");
                Console.WriteLine("=====================================");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Subjects assigned to you: ");
            foreach (var subjectId in teacherSubjectClasses)
            {
                var subName = db.Subjects.Find(subjectId)?.SubjectName;
                Console.WriteLine("  " + subName);
            }



            Console.Write("Enter subject name: ");
            var subjectName = Console.ReadLine();
            var subId = db.Subjects.Where(s => s.SubjectName == subjectName).Select(s => s.Id).FirstOrDefault();
            var subExist = db.ClassSubjectTeachers.FirstOrDefault(s => s.SubjectId == subId && s.TeacherId == teacherId);
            if (subExist == null)
            {
                Console.WriteLine();
                Console.WriteLine("You are not assigned for this subjects.");
                Console.WriteLine("=======================================");
                Console.WriteLine();
                return;
            }



            Console.Write("Enter student name: ");
            var studentName = Console.ReadLine();

            var studentExists = db.Students.FirstOrDefault(s => s.StudentName == studentName && s.ClassId==classsId);


            if (studentExists == null)
            {
                Console.WriteLine();
                Console.WriteLine("There is no student having this name.");
                Console.WriteLine("=====================================");
                Console.WriteLine();
                return;
            }
            var gradeExist = db.Grades.Any(g => g.SubjectName == subjectName && g.ClassName == className && g.StudentName == studentName);
            if (gradeExist)
            {
                Console.WriteLine();
                Console.WriteLine("Grade already assigned.");
                Console.WriteLine("=======================");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Grade should lie between 0 to 5.00.....");
            Console.Write("Enter firstTerm grade: ");
            var firstTerm = double.Parse(Console.ReadLine());
            Console.Write("Enter midTerm grade: ");
            var midTerm = double.Parse(Console.ReadLine());
            Console.Write("Enter finalTerm grade: ");
            var finalTerm = double.Parse(Console.ReadLine());

            if (!(firstTerm >= 0.00 && firstTerm <= 5.00 && midTerm >= 0.00 && midTerm <= 5.00 && finalTerm >= 0.00 && finalTerm <= 5.00))
            {
                Console.WriteLine(".....Grade should lie between 0 to 5.00.....");
                Console.WriteLine(".....Enter grade again.....");
                Console.Write("Enter firstTerm grade: ");
                firstTerm = double.Parse(Console.ReadLine());
                Console.Write("Enter midTerm grade: ");
                midTerm = double.Parse(Console.ReadLine());
                Console.Write("Enter finalTerm grade: ");
                finalTerm = double.Parse(Console.ReadLine());
            }

            var newGrade = new Grade
            {
                ClassName = className,
                SubjectName = subjectName,
                StudentName = studentName,
                FirstTerm = firstTerm,
                MidTerm = midTerm,
                FinalTerm = finalTerm
            };


            db.Grades.Add(newGrade);
            db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Grade added successfully.");
            Console.WriteLine("=========================");
            Console.WriteLine();
        }

    }

    //---------------------
    // 4. View Grade Mathod
    //---------------------
    public static void ViewGrade(int teacherId)
    {
        
        using (var db = new FinalProjectDbContext())
        {
            
            Console.WriteLine("All teachers can view grade.\nBut he/she can insert grade if he/she is assigned for this specific subject to this specific class.");
            Console.WriteLine();
            Console.Write("Enter class name: ");
            var className = Console.ReadLine();
            var existingClass = db.Classes.FirstOrDefault(c => c.ClassName == className);
            if(existingClass==null)
            {
                Console.WriteLine();
                Console.WriteLine("Class not found.");
                Console.WriteLine("================");
                Console.WriteLine();
                return;
            }

            Console.Write("Enter subject name: ");
            var subjectName = Console.ReadLine();
            var existingsubject = db.Subjects.FirstOrDefault(s => s.SubjectName == subjectName);
            if (existingsubject == null)
            {
                Console.WriteLine();
                Console.WriteLine("Subject not found.");
                Console.WriteLine("==================");
                Console.WriteLine();
                return;
            }

            var gradeToShow = db.Grades
                .Where(g=> g.ClassName == className && g.SubjectName == subjectName)
                 .Select(c => new {c.StudentName, c.FirstTerm, c.MidTerm, c.FinalTerm})
                    .ToList();
            if(gradeToShow.Count==0)
            {
                Console.WriteLine("The list is empty. Teacher needs to insert grades.");
                Console.WriteLine("==================================================");
                Console.WriteLine();
                return;
            }
            ConsoleTable.From(gradeToShow).Write();
            Console.WriteLine();
        }

    }
}
