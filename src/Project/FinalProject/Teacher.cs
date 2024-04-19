using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject;

public class Teacher
{
    public int Id { get; set; }
    public string TeacherName { get; set; }
    public string UserName { get; set; }
    public List<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }

}
