using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject;

public class Subject
{
    public int Id { get; set; }
    public string SubjectName { get; set; }
    public List<ClassSubject> ClassSubjects { get; set; }
    public List<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }


}
