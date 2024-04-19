using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public partial class AdminFunctionality
    {
        //-----------------------------------
        //4th option method----->View Classes
        //-----------------------------------
        public static void ViewClasses()
        {
            using (var db = new FinalProjectDbContext())
            {
                var classes = db.Classes.ToList();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Following classes are present in the system:");

                //Console.WriteLine();

                foreach (var classs in classes)
                {
                    Console.WriteLine(" "+classs.ClassName);
                }

                //Console.WriteLine();

                Console.WriteLine("Available classes are viewed successfully.✓✓✓");
                Console.WriteLine("---------------------------------------------");

                Console.WriteLine();

                

                while(true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1. Edit class.");
                    Console.WriteLine("2. Delete class.");
                    Console.WriteLine("3. Assign subject.");
                    Console.WriteLine("4. Go to admin panel main menu.");

                    Console.WriteLine();

                    Console.Write("Enter your choice: ");
                    var adminChoice = Console.ReadLine();
                    Console.WriteLine();
                    switch (adminChoice)
                    {
                        case "1":
                            EditClass();
                            break;
                        case "2":
                            DeleteClass();
                            break;
                        case "3":
                            AssignSubject();
                            break;
                        case "4":
                            MainMenu.AdminMainMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. ❌ Please try again.");
                            break;
                    }
                }
            }
        }

        //----------------------------------------
        //4-->>1 option method----->Edit class
        //----------------------------------------
        public static void EditClass()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.WriteLine("Provide following information to edit class: ");
                Console.WriteLine();
                Console.Write("Current class name: ");
                var currentClassName = Console.ReadLine();
                Console.Write("New class name: ");
                var newClassName = Console.ReadLine();

                var classToEdit = db.Classes.FirstOrDefault(c => c.ClassName == currentClassName);
                if (classToEdit != null)
                {
                    classToEdit.ClassName = newClassName;
                    db.SaveChanges();
                    Console.WriteLine("Class name updated successfully.✓✓✓");
                    Console.WriteLine("===================================");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Class not found. ❌ Try again.");
                    Console.WriteLine("==============================");
                    Console.WriteLine();
                }
            }
        }


        //----------------------------------------
        //4-->>2 option method----->Delete class
        //----------------------------------------
        public static void DeleteClass()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.WriteLine("Provide information to delete a class:");
                Console.WriteLine();
                Console.Write("Class name: ");
                var className = Console.ReadLine();

                var classToDelete = db.Classes.FirstOrDefault(c => c.ClassName == className);
                if (classToDelete != null)
                {
                    db.Classes.Remove(classToDelete);
                    db.SaveChanges();
                    Console.WriteLine("Class deleted successfully.✓✓✓");
                    Console.WriteLine("==============================");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Class not found. ❌ Please try again.");
                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                }
            }

        }
        //---------------------------------------------------
        //4-->>3 option method----->Assign Subject to a class
        //---------------------------------------------------
        public static void AssignSubject()
        {
            using (var db = new FinalProjectDbContext())
            {
                Console.WriteLine("Provide following information to assign a subject to a class: ");
                //Console.WriteLine();

                Console.Write("Class name: ");
                var className = Console.ReadLine();

                var existingClass = db.Classes.FirstOrDefault(c => c.ClassName == className);
                if (existingClass == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Class not found. Admin need to create class.");
                    Console.WriteLine("============================================");
                    return;
                }

                Console.Write("Subject name: ");
                var subjectName = Console.ReadLine();
                
                var existingSubject = db.Subjects.FirstOrDefault(s => s.SubjectName == subjectName);

                if (existingSubject == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Subject not found. Admin need to create subject.");
                    Console.WriteLine("================================================");
                    return;
                    
                }
                var classSubject = new ClassSubject { ClassId = existingClass.Id, SubjectId = existingSubject.Id };

                var existingClassSubject = db.ClassSubjects.FirstOrDefault(cs => cs.ClassId == classSubject.ClassId && cs.SubjectId == classSubject.SubjectId);
                if (existingClassSubject == null)
                {
                    db.ClassSubjects.Add(classSubject);
                    Console.WriteLine();
                    Console.WriteLine("Subject assigned to class successfully.✓✓✓");
                    Console.WriteLine("==========================================");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("This subject is already assigned to this class.");
                    Console.WriteLine("===============================================");
                }
                db.SaveChanges();



            }
        }
    }
}
