using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public partial class AdminFunctionality
    {
        //------------------------------------
        //5th option method----->View Subjects
        //------------------------------------
        public static void ViewSubjects()
        {
            using (var db = new FinalProjectDbContext())
            {
                var subjects = db.Subjects.ToList();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Following subjects are present in the system: ");
                //Console.WriteLine();

                foreach (var subject in subjects)
                {
                    Console.WriteLine(" "+subject.SubjectName);
                }
                Console.WriteLine("Available subjects are viewed successfully.✓✓✓");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine();
                while(true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1. Edit subject.");
                    Console.WriteLine("2. Delete subject.");
                    Console.WriteLine("3. Assign a teacher.");
                    Console.WriteLine("4. Go to admin panel main menu.");

                    Console.Write("Enter your choice: ");
                    var adminChoice = Console.ReadLine();
                    Console.WriteLine();

                    switch (adminChoice)
                    {
                        case "1":
                            EditSubject();
                            break;
                        case "2":
                            DeleteSubject();
                            break;
                        case "3":
                            AssignTeacher();
                            break;
                        case "4":
                            MainMenu.AdminMainMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;

                    }
                }
            }
        }

        //---------------------------------------
        //5---->1 option method----->Edit Subject
        //---------------------------------------
        public static void EditSubject()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.WriteLine("Provide following information to edit subject:");
                Console.WriteLine();
                Console.Write("Current subject name: ");
                var currentSubjectName = Console.ReadLine();
                Console.Write("New subject name: ");
                var newSubjectName = Console.ReadLine();

                var subjectToEdit = db.Subjects.FirstOrDefault(s => s.SubjectName == currentSubjectName);
                if (subjectToEdit != null)
                {
                    subjectToEdit.SubjectName = newSubjectName;
                    db.SaveChanges();
                    Console.WriteLine("Subject name updated successfully.✓✓✓");
                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Subject not found. ❌ Please try again.");
                    Console.WriteLine("=======================================");
                    Console.WriteLine();
                }
            }
        }

        //-----------------------------------------
        //5---->2 option method----->Delete Subject
        //-----------------------------------------
        public static void DeleteSubject()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.WriteLine("Provide information to delete a subject:");
                Console.WriteLine();
                Console.Write("Subject name: ");
                var subjectName = Console.ReadLine();

                var subjectToDelete = db.Subjects.FirstOrDefault(s => s.SubjectName == subjectName);
                if (subjectToDelete != null)
                {
                    db.Subjects.Remove(subjectToDelete);
                    db.SaveChanges();
                    Console.WriteLine("Subject deleted successfully.✓✓✓");
                    Console.WriteLine("================================");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Subject not found. ❌ Please try again.");
                    Console.WriteLine("=======================================");
                    Console.WriteLine();
                }
            }
        }

        //-----------------------------------------
        //5---->3 option method----->Assign Teacher
        //-----------------------------------------
        public static void AssignTeacher()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.WriteLine("Please provide following information to assign a teacher for a specific subject to a class:");
                //Console.WriteLine();
                Console.Write("Class name: ");
                var className = Console.ReadLine();
                var existingClass = db.Classes.FirstOrDefault(c => c.ClassName == className);
                if(existingClass==null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Class not found. Admin need to create class.");
                    Console.WriteLine("============================================");
                    return;
                }
                Console.Write("Subject name: ");
                var subjectName = Console.ReadLine();
                var existingSubject = db.Subjects.FirstOrDefault(s => s.SubjectName == subjectName);
                if( existingSubject==null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Subject not found. Admin need to create subject.");
                    Console.WriteLine("================================================");
                    return;
                }
                Console.Write("Teacher Fullname: ");
                var teacherName = Console.ReadLine();         
                var existingTeacher = db.Teachers.FirstOrDefault(t => t.TeacherName == teacherName);
                if (existingTeacher == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Teacher not found. Admin need to create teacher.");
                    Console.WriteLine("================================================");
                    return;
                }
                var classSubjectTeacher = new ClassSubjectTeacher { ClassId = existingClass.Id, SubjectId = existingSubject.Id, TeacherId = existingTeacher.Id };

                var existingClassSubjectTeacher = db.ClassSubjectTeachers.FirstOrDefault(cst => cst.ClassId == classSubjectTeacher.ClassId && cst.SubjectId == classSubjectTeacher.SubjectId && cst.TeacherId == classSubjectTeacher.TeacherId);
                if (existingClassSubjectTeacher == null)
                {
                    db.ClassSubjectTeachers.Add(classSubjectTeacher);
                    Console.WriteLine();
                    Console.WriteLine("Teacher assigned successfully.✓✓✓");
                    Console.WriteLine("=================================");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Teacher assigned before for this subject to this class.");
                    Console.WriteLine("=======================================================");
                }
                db.SaveChanges();
            }


        }
    }
}
